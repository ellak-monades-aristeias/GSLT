using System;
using System.Threading;
using System.Collections;
using Leap;
using System.Collections.Generic;

namespace LeapGSLT
{
    public class LeapListener : Listener
    {
        private Stack gesture_stack = null; //this stack keeps the gesture to identify potential commands for starting/stoping the program
        private Stack letter_stack = null;

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
                List<bool> fingers_vertical_flags = new List<bool>();
                List<bool> fingers_horizontal_flags = new List<bool>();

                bool is_all_vertical = true;
                bool is_all_horizontal = true;
                int horizontal_count = 0;
                int vertical_count = 0;
                int diagonal_count = 0;
                int inversed_diagonal_count = 0;
                int closed_count = 0;
                foreach (Finger finger in hand.Fingers)
                {
                    SafeWriteLine("    Finger id: " + finger.Id
                                + ", " + finger.Type.ToString()
                                + ", length: " + finger.Length
                                + "mm, width: " + finger.Width + "mm");

                    // Get finger bones
                    Bone bone;

                    List<Vector> bone_directions = new List<Vector>();

                    foreach (Bone.BoneType boneType in (Bone.BoneType[])Enum.GetValues(typeof(Bone.BoneType)))
                    {
                        bone = finger.Bone(boneType);
                        SafeWriteLine("      Bone: " + boneType
                                    + ", start: " + bone.PrevJoint
                                    + ", end: " + bone.NextJoint
                                    + ", direction: " + bone.Direction);

                        bone_directions.Add(bone.Direction);

                        bool is_vertical = false;
                        bool is_horizontal = false;
                        if (bone.Direction.Pitch == 90.0 && bone.Direction.Yaw == 0.0)
                        {
                            is_vertical = true;
                            vertical_count++;
                        }
                        else if (bone.Direction.Pitch == 0.0 && bone.Direction.Yaw == 90.0)
                        {
                            is_horizontal = true;
                            horizontal_count++;
                        }
                        else if (bone.Direction.Pitch == 45.0 && bone.Direction.Yaw == 0.0)
                        {
                            diagonal_count++;
                        }
                        else if (bone.Direction.Pitch == 45.0 && bone.Direction.Yaw == 90.0)
                        {
                            inversed_diagonal_count++;
                        }
                        else if (bone.Direction.Pitch == 0.0 && bone.Direction.Yaw == 0.0)
                        {
                            closed_count++;
                        }

                        if (!is_vertical)
                        {
                            is_all_vertical = false;
                        }
                        if (!is_horizontal)
                        {
                            is_all_horizontal = false;
                        }
                    }

                    fingers_horizontal_flags.Add(is_all_horizontal);
                    fingers_vertical_flags.Add(is_all_vertical);
                }


                //now, based on the vertical, horizontal position, try to identify candidate letters
                bool all_fingers_vertical = true;
                bool all_fingers_horizontal = true;
                for (int i = 0; i < fingers_horizontal_flags.Count; i++)
                {
                    if (!fingers_horizontal_flags[i])
                    {
                        all_fingers_horizontal = false;
                    }
                }
                for (int i = 0; i < fingers_vertical_flags.Count; i++)
                {
                    if (!fingers_vertical_flags[i])
                    {
                        all_fingers_vertical = false;
                    }
                }
                
                List<char> current_list_2 = new List<char>();                 

                if (all_fingers_horizontal)
                {
                   //candidates are 
                }
                else if (all_fingers_vertical)
                {
                    //candidates are Â
                    current_list_2.Add('B');
                }
                else if (closed_count == 5)
                {
                    current_list_2.Add('A');
                }
                else if (diagonal_count == 2 && closed_count == 3)
                {
                    current_list_2.Add('Ã');
                }
                else if (diagonal_count == 1 && closed_count == 2)
                {
                    current_list_2.Add('Ä');
                    current_list_2.Add('Æ');
                }
                else if (diagonal_count == 1 && closed_count == 3)
                {
                    current_list_2.Add('Ç');
                }
                else if (horizontal_count == 2 && closed_count == 2)
                {
                    current_list_2.Add('È');
                }
                else if (closed_count == 4 && vertical_count == 1)
                {
                    current_list_2.Add('É');
                }
                else if (closed_count == 2 && vertical_count == 1 && horizontal_count == 1)
                {
                    current_list_2.Add('K');
                }
                else if (horizontal_count == 3 && closed_count == 1)
                {
                    current_list_2.Add('Ë');
                    current_list_2.Add('Ì');
                }
                else if (horizontal_count == 3 && closed_count == 2)
                {
                    current_list_2.Add('N');
                    current_list_2.Add('Î');
                }
                else if (diagonal_count == 2 && closed_count == 2)
                {
                    current_list_2.Add('Ð');
                }
                else if (vertical_count == 3 && closed_count == 2)
                {
                    current_list_2.Add('Ï');
                }
                else if (diagonal_count == 1 && inversed_diagonal_count == 1)
                {
                    current_list_2.Add('Ñ');
                }
                else if (closed_count == 5)
                {
                    current_list_2.Add('Ó');
                }
                else if (closed_count == 4 && vertical_count == 1)
                {
                    current_list_2.Add('T');
                }
                else if (closed_count == 3 && vertical_count == 2)
                {
                    current_list_2.Add('Õ');
                }
                else if (horizontal_count == 3)
                {
                    current_list_2.Add('Ö');
                }
                else if (horizontal_count == 2 && closed_count == 1 && diagonal_count == 1)
                {
                    current_list_2.Add('×');
                }
                else if (horizontal_count == 3 && closed_count == 1 && diagonal_count == 1)
                {
                    current_list_2.Add('Ø');
                }
                else
                {
                    current_list_2.Add('Ù');
                }
                                
                candidate_stack.Push(current_list_2);
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
