using System;
using System.Threading;
using System.Collections;
using Leap;
using System.Collections.Generic;

namespace LeapGSLT
{
    public class LeapListener : Listener
    {
        private Stack gesture_stack; //this stack keeps the gesture to identify potential commands for starting/stoping the program
        private Stack letter_stack;

        private void SafeWriteLine(String line)
        {
            Console.WriteLine(line);     
        }

        public char getLastLetter()
        {
            if (letter_stack.Count > 0)
            {
                return (char)letter_stack.Peek();
            }
            else
            {
                char c = ' ';
                return c; //no letter identified
            }
        }

        public override void OnInit(Controller controller)
        {
            SafeWriteLine("Initialized");

            gesture_stack.Clear();
        }

        public override void OnConnect(Controller controller)
        {
            SafeWriteLine("Connected");
            controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
            controller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
            controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }

        public override void OnDisconnect(Controller controller)
        {
            //Note: not dispatched when running in a debugger.
            SafeWriteLine("Disconnected");
        }

        public override void OnExit(Controller controller)
        {
            SafeWriteLine("Exited");
        }

        public override void OnFrame(Controller controller)
        {
            // Get the most recent frame and report some basic information
            Frame frame = controller.Frame();

            SafeWriteLine("Frame id: " + frame.Id
                        + ", timestamp: " + frame.Timestamp
                        + ", hands: " + frame.Hands.Count
                        + ", fingers: " + frame.Fingers.Count
                        + ", tools: " + frame.Tools.Count
                        + ", gestures: " + frame.Gestures().Count);

            foreach (Hand hand in frame.Hands)
            {
                SafeWriteLine("  Hand id: " + hand.Id
                            + ", palm position: " + hand.PalmPosition);
                // Get the hand's normal vector and direction
                Vector normal = hand.PalmNormal;
                Vector direction = hand.Direction;

                // Calculate the hand's pitch, roll, and yaw angles
                SafeWriteLine("  Hand pitch: " + direction.Pitch * 180.0f / (float)Math.PI + " degrees, "
                            + "roll: " + normal.Roll * 180.0f / (float)Math.PI + " degrees, "
                            + "yaw: " + direction.Yaw * 180.0f / (float)Math.PI + " degrees");

                // Get the Arm bone
                Arm arm = hand.Arm;
                SafeWriteLine("  Arm direction: " + arm.Direction
                            + ", wrist position: " + arm.WristPosition
                            + ", elbow position: " + arm.ElbowPosition);

                float pitch = hand.Direction.Pitch;
                float yaw = hand.Direction.Yaw;
                float roll = hand.PalmNormal.Roll;

                //Here, based on the identified Hand and Finger information, we can easily identify all the distinct letters
                Stack candidate_stack = new Stack();
                if (pitch == 0.0 && yaw == 0.0)
                {
                    //candidates are Á, Â, Ä, Ç, É, Ê, Ï, Ñ, Õ, Ö, ×, Ø
                    List<char> current_list = new List<char>();
                    current_list.Add('A');
                    current_list.Add('Â');
                    current_list.Add('Ä');
                    current_list.Add('Ç');
                    current_list.Add('É');
                    current_list.Add('Ê');
                    current_list.Add('Ï');
                    current_list.Add('Ñ');
                    current_list.Add('Õ');
                    current_list.Add('Ö');
                    current_list.Add('×');
                    current_list.Add('Ø');

                    candidate_stack.Push(current_list);
                }
                else if (pitch == 90.0 && yaw == 0.0)
                {
                    //candidates are Ã, Ë, Ì, Í, Ð, Ó, Ô
                    List<char> current_list = new List<char>();
                    current_list.Add('Ã');
                    current_list.Add('Ë');
                    current_list.Add('Ì');
                    current_list.Add('Í');
                    current_list.Add('Ð');
                    current_list.Add('Ó');
                    current_list.Add('Ô');                    

                    candidate_stack.Push(current_list);
                }
                else if (pitch == 0.0 && yaw == 90.0)
                {
                    //candidates are Å, 
                    List<char> current_list = new List<char>();
                    current_list.Add('Å');                    
                    
                    candidate_stack.Push(current_list);
                }
                else if (pitch == 0.0 && yaw == -90.0)
                {
                    //candidates are Æ, È, Î, Ù
                    List<char> current_list = new List<char>();
                    current_list.Add('Æ');
                    current_list.Add('È');
                    current_list.Add('Î');
                    current_list.Add('Ù');                    

                    candidate_stack.Push(current_list);
                }

                // Get fingers
                foreach (Finger finger in hand.Fingers)
                {
                    SafeWriteLine("    Finger id: " + finger.Id
                                + ", " + finger.Type.ToString()
                                + ", length: " + finger.Length
                                + "mm, width: " + finger.Width + "mm");

                    // Get finger bones
                    Bone bone;
                    foreach (Bone.BoneType boneType in (Bone.BoneType[])Enum.GetValues(typeof(Bone.BoneType)))
                    {
                        bone = finger.Bone(boneType);
                        SafeWriteLine("      Bone: " + boneType
                                    + ", start: " + bone.PrevJoint
                                    + ", end: " + bone.NextJoint
                                    + ", direction: " + bone.Direction);
                    }
                }


            }            

            // Get tools
            foreach (Tool tool in frame.Tools)
            {
                SafeWriteLine("  Tool id: " + tool.Id
                            + ", position: " + tool.TipPosition
                            + ", direction " + tool.Direction);
            }

            // Get gestures
            GestureList gestures = frame.Gestures();
            for (int i = 0; i < gestures.Count; i++)
            {
                Gesture gesture = gestures[i];

                switch (gesture.Type)
                {
                    case Gesture.GestureType.TYPE_CIRCLE:
                        CircleGesture circle = new CircleGesture(gesture);

                        // Calculate clock direction using the angle between circle normal and pointable
                        String clockwiseness;
                        if (circle.Pointable.Direction.AngleTo(circle.Normal) <= Math.PI / 2)
                        {
                            //Clockwise if angle is less than 90 degrees
                            clockwiseness = "clockwise";
                        }
                        else
                        {
                            clockwiseness = "counterclockwise";
                        }

                        float sweptAngle = 0;

                        // Calculate angle swept since last frame
                        if (circle.State != Gesture.GestureState.STATE_START)
                        {
                            CircleGesture previousUpdate = new CircleGesture(controller.Frame(1).Gesture(circle.Id));
                            sweptAngle = (circle.Progress - previousUpdate.Progress) * 360;
                        }

                        SafeWriteLine("  Circle id: " + circle.Id
                                       + ", " + circle.State
                                       + ", progress: " + circle.Progress
                                       + ", radius: " + circle.Radius
                                       + ", angle: " + sweptAngle
                                       + ", " + clockwiseness);

                        gesture_stack.Push(circle);

                        break;
                    case Gesture.GestureType.TYPE_SWIPE:
                        SwipeGesture swipe = new SwipeGesture(gesture);
                        SafeWriteLine("  Swipe id: " + swipe.Id
                                       + ", " + swipe.State
                                       + ", position: " + swipe.Position
                                       + ", direction: " + swipe.Direction
                                       + ", speed: " + swipe.Speed);
                        gesture_stack.Push(swipe);
                        break;
                    case Gesture.GestureType.TYPE_KEY_TAP:
                        KeyTapGesture keytap = new KeyTapGesture(gesture);
                        SafeWriteLine("  Tap id: " + keytap.Id
                                       + ", " + keytap.State
                                       + ", position: " + keytap.Position
                                       + ", direction: " + keytap.Direction);
                        gesture_stack.Push(keytap);
                        break;
                    case Gesture.GestureType.TYPE_SCREEN_TAP:
                        ScreenTapGesture screentap = new ScreenTapGesture(gesture);
                        SafeWriteLine("  Tap id: " + screentap.Id
                                       + ", " + screentap.State
                                       + ", position: " + screentap.Position
                                       + ", direction: " + screentap.Direction);
                        gesture_stack.Push(screentap);
                        break;
                    default:
                        SafeWriteLine("  Unknown gesture type.");
                        break;
                }
            }

            if (!frame.Hands.IsEmpty || !frame.Gestures().IsEmpty)
            {
                SafeWriteLine("");
            }
        }
    }

    class Test
    {
        public static void testListener()
        {
            // Create a sample listener and controller
            LeapListener listener = new LeapListener();
            Controller controller = new Controller();

            // Have the sample listener receive events from the controller
            controller.AddListener(listener);

            // Keep this process running until Enter is pressed
            Console.WriteLine("Press Enter to quit...");
            Console.ReadLine();

            // Remove the sample listener when done
            controller.RemoveListener(listener);
            controller.Dispose();
        }
    }
}
