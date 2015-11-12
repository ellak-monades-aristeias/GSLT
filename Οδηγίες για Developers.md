Οδηγίες για Developers

Προαπαιτούμενα
==============

Για να μπορέσετε να εγκαταστήσετε και να επεκτείνετε την εφαρμογής *GSLT* είναι
απαραίτητα τα εξής :

·       Λειτουργικό Σύστημα:** ** *Windows 7/8 x64*. Γενικά, το σύστημα
αναγνώρισης νοηματικής γραφής θα ελεγχθεί ότι δουλεύει αποτελεσματικά τόσο σε
Windows 7 x64 όσο και σε Windows 8 x64.

·       Συσκευή Αναγνώρισης Κίνησης**:**  *Leap Motion*. Ως συσκευή αναγνώρισης
των κινήσεων του χεριού θα χρησιμοποιήσουμε το Leap Motion
(<https://www.leapmotion.com/>). To LeapMotion είναι μια μικροσκοπική συσκευή
(80mm x 12.7mm) σε μέγεθος αναπτήρα, η οποία συνδέεται με USB στον υπολογιστή. Η
συσκευή ενσωματώνει μια υψηλής ανάλυσης κάμερα, η οποία αναγνωρίζει τις
διαφορετικές κινήσεις των χεριών του χρήστη (gestures) και ενημερώνει το
πρόγραμμα-πελάτη (driver) που "τρέχει" στον υπολογιστή με χρήση events. Ο
προγραμματιστής καλείται να διαχειριστεί αυτά τα events ανάλογα με τις ανάγκες
της εκάστοτε εφαρμογής. Το μεγάλο πλεονέκτημα του LeapMotion είναι ότι
υποστηρίζει μια πληθώρα γλωσσών προγραμματισμού (C++, C\#, Java, Python, Unity,
JavaScript, Objective-C, Unreal) καθώς και διαφορετικά λειτουργικά συστήματα
(Linux, Windows, Mac). Επομένως, η επιλογή των εργαλείων υλοποίησης δεν είναι
περιοριστική και επαφίεται στον κάθε προγραμματιστή. Επιπλέον, παρέχονται
drivers για διάφορα IDE (π.χ. Microsoft Visual Studio), κάνοντας ακόμη πιο
εύκολη την ανάπτυξη εφαρμογών βασισμένες σε αυτό.

·       Πλατφόρμα Υλοποίησης**: ** *Microsoft Visual Studio 2012.* Ως πλατφόρμα
υλοποίησης επιλέξαμε το Microsoft Visual Studio 2012. Η επιλογή μας έγινε με
βάση την ευκολία χρήσης και το σύνολο των παρεχόμενων εργαλείων. Το Visual
Studio 2012 είναι ένα ολοκληρωμένο περιβάλλον προγραμματισμού και υποστηρίζεται
απευθείας από το LeapMotion. Επιπλέον, υποστηρίζει μια πληθώρα γλωσσών
προγραμματισμού, οπότε η επιλογή της γλώσσας προγραμματισμού επαφίεται μόνο στον
προγραμματιστή. Τέλος, τα εργαλεία αποσφαλμάτωσης (debugging) που παρέχει είναι
αρκετά εύχρηστα και θα μας βοηθήσουν ώστε να ελέγξουμε τη σωστή λειτουργία της
εφαρμογής.

·       Γλώσσα Προγραμματισμού**: ** *C\#.* Ως γλώσσα προγραμματισμού επιλέξαμε
τη C\#, λόγω της απλότητάς της καθώς και της απευθείας υποστήριξή της από το
Visual Studio 2012.

 

SDK Libraries
=============

The Leap Motion library is written in C++. Leap Motion also uses SWIG, an open
source tool, to generate language bindings for C\#, Java, and Python. The
SWIG-generated bindings translate calls written in the bound programming
language to calls into the base C++ Leap Motion library. Each SWIG binding uses
two additional libraries. For JavaScript and web application development, Leap
Motion provides a WebSocket server and a client-side JavaScript library.

All the library, code, and header files required to develop Leap-enabled
applications and plugins are included in the Leap Motion SDK, except
the leap.js client JavaScript library. You can download the Leap Motion SDK from
the Leap Motion Developer Portal. An SDK package is available for each supported
operating system. The JavaScript client library is distributed separately and
can be downloaded from the [LeapJS GitHub
repository](<https://github.com/leapmotion/leapjs>).

Plugins for Unity 5 and Unreal Engine 4.9 are provided separately from the main
SDK. The Unreal plugin is included with Unreal Engine 4.9+ (source code release
only, at this time). The Unity plugin is available
at <https://developer.leapmotion.com/downloads/unity>.

**Supported Compilers and IDEs**
--------------------------------

·       C++ on Windows: Visual Studio 2008, 2010, 2012, and 2013

·       C++ on Mac: Xcode 3.0+, clang 3.0+, and gcc

·       Objective-C: Mac OS 10.7+, Xcode 4.2+ and clang 3.0+

·       C\# for .NET framework versions 3.5 and 4.0

·       Mono version 2.10

·       Unity Pro and Personal versions 5.0

·       Java versions 6 and 7

·       Python version 2.7.3

·       UnrealEngine 4.9

**C\#**
-------

The C\# class definitions are provided for .NET 3.5 and .NET 4.0 in separate
libraries. Your code can reference either LeapCSharp.NET3.5.dll or
LeapCSharp.NET4.0.dll (the same library names are used for this library on all
supported operating systems). These libraries load libCSharp.dylib (Mac),
LeapCSharp.dll (Windows), or libLeapCSharp.so (Linux). The intermediate
libraries load libLeap.dylib, Leap.dll, or libLeap.so (depending on platform).

**C++**
-------

To develop for the Leap Motion Controller in C++, include the API header files
in your program and link with the Leap Motion library, either libLeap.dylib,
Leap.dll, or libLeap.so, depending on platform.

On Windows, separate libraries are provided for 32-bit versus 64-bit
architectures as well as debug builds versus release builds (for a total of 4
versions for each component).

On Mac OS X, both architectures and release modes are supported in a single
library file.

**Objective-C**
---------------

Objective-C applications are supported by hand-written wrapper code. To build a
Leap-enabled Objective-C application, include the wrapper header and
Objective-C++ code file in your application along with the Leap Motion C++
headers. You can then use the classes defined in the wrapper in (otherwise) pure
Objective-C applications. Link your application with libLeap.dylib and include
the library in your application package.

**Unity**
---------

As of Unity 5, both the Pro and Personal versions support plugins. The Unity
plugin uses the C\# class definitions in LeapCSharp.NET3.5.dll. This library
loads the native libCSharp.dylib (Mac) or LeapCSharp.dll (Windows) library. In
turn, these intermediate libraries load libLeap.dylib or Leap.dll (depending on
platform).

**Java**
--------

Leap.jar contains the Leap Motion Java classes. This code loads
libLeapJava.dylib (Mac), LeapJava.dll (Windows), or libLeapJava.so (Linux).
These libraries contain the native code that translates the Java calls to the
base Leap Motion API in libLeap.dylib, Leap.dll, or libLeap.so (depending on
platform). The base Leap Motion dynamic library is loaded by the intermediate
library. For Windows 64-bit architectures, the Microsoft Visual C runtime
libraries are also required.

**Python**
----------

Leap.py contains the Python module that you reference in your Python
application. This module loads LeapPython.so (Mac and Linux) or LeapPython.dll
(Windows). These libraries load libLeap.dylib, Leap.dll, or libLeap.so
(depending on platform).

**JavaScript**
--------------

Leap Motion JavaScript support has two main components. The first component is
the WebSocket server provided by the Leap Motion service. This server allows web
applications (or any application that can connect to a WebSocket) to access Leap
Motion tracking data as JSON-formatted messages. The second component is the
JavaScript client library, Leap.js. Leap.js is an open-source JavaScript API
that consumes the WebSocket JSON output and presents it in a form that is
consistent in philosophy and structure to the native Leap Motion API.

**Other Languages**
-------------------

Many community-created language bindings are available, for a partial list,
visit: [Community Libraries](<https://developer.leapmotion.com/links>).

### Operating System Support

The Leap Motion software currently supports Linux (Ubuntu 12), OS X 10.7+,
Windows 7+.

 

Hello World (Παράδειγμα)
========================

This article demonstrates how to connect to the Leap Motion controller and
access basic tracking data. After reading this article and following along with
your own basic program, you should have a solid foundation for beginning your
own application development.

First, a little background...

**How the Leap Motion Controller Works**
----------------------------------------

The Leap Motion controller encompasses both hardware and software components.

The Leap Motion hardware consists primarily of a pair of stereo infrared cameras
and illumination LEDs. The camera sensors look upward (when the device is in its
standard orientation). The following illustration shows how a user’s hands look
from the perspective of the Leap Motion sensor:

![https://di4564baj7skl.cloudfront.net/documentation/images/Leap\_View.jpg](<file:///C:\Users\stef\AppData\Local\Temp\msohtmlclip1\01\clip_image002.jpg>)

The Leap Motion software receives the sensor data and analyzes this data
specifically for hands, fingers, arms, and tools. (Tracking for other types of
objects could be added in the future, but this is the current set of tracked
entities). The software maintains an internal model of the human hand and
compares that model to the sensor data to determine the best fit. Sensor data is
analyzed frame-by-frame and the service sends each frame of data to Leap
Motion-enabled applications.
The [Frame](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Frame.html>) object
received by your application contains all the known positions, velocities and
identities of tracked entities, such as hands, fingers, and tools. Constructs
such as gestures and motions that span multiple frames are also updated each
frame. For an overview for the tracking data provided by the controller,
read[API
Overview](<https://developer.leapmotion.com/documentation/csharp/devguide/Leap_Overview.html>).

The Leap Motion software runs as a service (Windows) or daemon (Mac and Linux)
on the client computer. Native Leap Motion-enabled applications can connect to
this service using the API provide by the Leap Motion dynamic libraries
(provided as part of the Leap Motion SDK). Web applications can connect to a
WebSocket server hosted by the service. The WebSocket provides tracking data as
a JSON-formatted message – one message per frame of data. A JavaScript library,
LeapJS, provides an API wrapping this data. For more information read [System
Architecture](<https://developer.leapmotion.com/documentation/csharp/devguide/Leap_Architecture.html>).

**Set Up the Files**
--------------------

This tutorial also uses command line compilers and linkers (where needed) in
order to focus on the code rather than the environment. For details on how to
set up projects using the Leap Motion SDK in popular IDEs, see [Setting Up a
Project](<https://developer.leapmotion.com/documentation/csharp/devguide/Project_Setup.html>).

1.     If you haven’t already, download and unzip the latest Leap Motion SDK
from the [developer site](<https://developer.leapmotion.com/>) and install the
latest Leap Motion service.

2.     Open a terminal or console window and navigate to the SDK samples folder.

3.     Sample.cs contains the finished code for this tutorial, but to get the
most out of this lesson, you can rename the existing file, and create a new,
blank Sample.cs file in this folder. Keep the existing file for reference.

4.     In your new Sample.cs file, add code to reference the Leap Motion
libraries:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
5.  using Leap;
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

6.     Add the “structural” code to define a command-line program:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
7.  class Sample
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
8.  {
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
9.      public static void Main ()
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
10.           {
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
11.               // Keep this process running until Enter is pressed
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
12.               Console.WriteLine ("Press Enter to quit...");
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
13.               Console.ReadLine ();
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
14.           }
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
15.       }
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

This code simply prints a message and then waits for keyboard input before
exiting. See [Running the
Sample](<https://developer.leapmotion.com/documentation/csharp/devguide/Sample_Tutorial.html#run-sample>) for
instructions on running the program.

**Get Connected**
-----------------

The next step is to add
a [Controller](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Controller.html>) object
to the program – which serves as our connection to the Leap Motion
service/daemon.

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
class Sample
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
{
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public static void Main ()
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    {
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Controller controller = new Controller ();
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Keep this process running until Enter is pressed
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Console.WriteLine ("Press Enter to quit...");
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Console.ReadLine ();
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
}
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

When you create
a [Controller](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Controller.html>) object,
it automatically connects to the Leap Motion service and, once the connection
has been established, you can get tracking data from it using
the [Controller.Frame()](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Controller.html#csharpclass_leap_1_1_controller_1a8c8b46780daec303084314bf1c014faa>) method.

The connection process is asynchronous, so you can’t create the Controller in
one line and expect to get data in the next line. You have to wait for the
connection to complete. But for how long?

**To Listen or not to Listen?**
-------------------------------

You can add
a [Listener](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Listener.html>) object
to
the [Controller](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Controller.html>),
which provides an event-based mechanism for responding to
important Controller state changes. This is the approach used in this tutorial –
but it is not always the best approach.

**The Problem with
Listeners:** [Listener](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Listener.html>) objects
use independent threads to invoke the code that you implement for each event.
Thus, using the listener mechanism can introduce the complexities of threading
into your program. It becomes your responsibility to make sure that the code you
implement in your Listener subclass accesses other parts of your program in a
thread-safe manner. For example, you might not be able to access variables
related to GUI controls from anything except the main thread. There can also be
additional overhead associated with the creation and cleanup of threads.

**Avoiding Listeners:** You can avoid
using [Listener](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Listener.html>) objects
by simply polling
the [Controller](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Controller.html>) object
for frames (or other state) when convenient for your program. Many programs
already have a event- or animation-loop to drive user input and animation. If
so, you can get the tracking data once per loop – which is often as fast as you
can use the data anyway.

The [Listener](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Listener.html>) class
in the API defines the signatures for a function that will be called when
a [Controller](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Controller.html>) event
occurs. You create a listener by creating a subclass of Listener and
implementing the callback functions for the events you are interested in.

To continue this tutorial, add the SampleListener class to your program:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
class SampleListener : Listener
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
{
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    private Object thisLock = new Object ();
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    private void SafeWriteLine (String line)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    {
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        lock (thisLock) {
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                Console.WriteLine (line);
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public override void OnConnect (Controller controller)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    {
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        SafeWriteLine ("Connected");
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public override void OnFrame (Controller controller)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    {
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        SafeWriteLine ("Frame available");
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
}
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Note that the SafeWriteLine function exists because the Listener is
multi-threaded. Calling Console.WriteLine() directly occasionally causes a
threading conflict.

If you have already taken a look at the finished file, you may have noticed that
several more callback functions are present. You can add those too, if you wish,
but to keep things simple, we will concentrate
on [OnConnect()](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Listener.html#csharpclass_leap_1_1_listener_1aab601b3a55d6865a55186260e12052d1>) and [OnFrame()](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Listener.html#csharpclass_leap_1_1_listener_1a2a45d3b6c4b59d4315521cb2a851e70d>).

Now create a SampleListener object using your new class and add it to your
controller:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
class Sample
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
{
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public static void Main ()
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    {
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        SampleListener listener = new SampleListener ();
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Controller controller = new Controller ();
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        controller.AddListener (listener);
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Keep this process running until Enter is pressed
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Console.WriteLine ("Press Enter to quit...");
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        Console.ReadLine ();
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        controller.RemoveListener (listener);
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        controller.Dispose ();
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
}
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Now is a good time to test your sample program. Follow the directions
in: [Running the
Sample](<https://developer.leapmotion.com/documentation/csharp/devguide/Sample_Tutorial.html#run-sample>).

If everything is correct (and your Leap Motion hardware is plugged in), then you
should see the string “Connected” printed to the terminal window followed by an
rapid series of “Frame available”. If things go wrong and you cannot figure out
why, you can get help on our developer forum
at [developer.leapmotion.com](<https://developer.leapmotion.com/>).

Whenever you run into trouble developing a Leap Motion application, try opening
the diagnostic visualizer. This program displays a visualization of the Leap
Motion tracking data. You can compare what you see in your program to what you
see in the visualizer (which uses the same API) to isolate and identify many
problems.

**On Connect**
--------------

When
your [Controller](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Controller.html>) object
successfully connects to the Leap Motion service/daemon AND the Leap Motion
hardware is plugged in, The Controller object changes its IsConnected property
to true and invokes
your [Listener.OnConnect()](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Listener.html#csharpclass_leap_1_1_listener_1aab601b3a55d6865a55186260e12052d1>) callback
(if there is one).

When the controller connects, you can set controller properties using
the [Controller.EnableGesture()](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Controller.html#csharpclass_leap_1_1_controller_1a89651d01dfd34ab2fc67a2b5ab4d8fcf>) and [Controller.SetPolicy()](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Controller.html#csharpclass_leap_1_1_controller_1a2e9e33b47c2b764f92304fc758b8cde4>) methods.
For example, you could enable the swipe gesture with the
following onConnect() function:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public override void OnConnect (Controller controller)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
{
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
   SafeWriteLine ("Connected");
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
   controller.EnableGesture (Gesture.GestureType.TYPE_SWIPE);
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
}
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

**On Frame**
------------

All the tracking data in the Leap Motion system arrives through
the [Frame](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Frame.html>) object.
You can get Frame objects from your controller (after it has connected) by
calling
the [Controller.Frame()](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Controller.html#csharpclass_leap_1_1_controller_1a8c8b46780daec303084314bf1c014faa>) method.
The [OnFrame()](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Listener.html#csharpclass_leap_1_1_listener_1a2a45d3b6c4b59d4315521cb2a851e70d>) callback
of
your [Listener](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Listener.html>) subclass
is called when a new frame of data becomes available. When you aren’t using a
listener, you can compare
the [Id](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Frame.html#csharpclass_leap_1_1_frame_1ae9b19c3ce0c8c0be64991f7a4370fec7>) value
to that of the last frame you processed to see if there is a new frame. Note
that by setting the history parameter of the Frame() function, you can get
earlier frames than the current one (up to 60 frames are stored). Thus, even
when polling at a slower rate than the Leap Motion frame rate, you can process
every frame, if desired.

To get the frame, add this call
to [Frame()](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Controller.html#csharpclass_leap_1_1_controller_1a8c8b46780daec303084314bf1c014faa>) to
your OnFrame() callback:

Then, print out some properties of
the [Frame](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Frame.html>) object:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public override void OnFrame (Controller controller)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
{
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    Frame frame = controller.Frame ();
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    SafeWriteLine ("Frame id: " + frame.Id
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
             + ", timestamp: " + frame.Timestamp
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
             + ", hands: " + frame.Hands.Count
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
             + ", fingers: " + frame.Fingers.Count
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
             + ", tools: " + frame.Tools.Count
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
             + ", gestures: " + frame.Gestures ().Count);
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
}
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Run your sample again, put a hand or two over the Leap Motion device and you
should now see the basic statistics of each frame printed to the console window.

I’ll end this tutorial here, but you can look at the rest of the code in the
original sample program for examples on how to get all
the [Hand](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Hand.html>),[Finger](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Finger.html>), [Arm](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Arm.html>), [Bone](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Bone.html>) and [Gesture](<https://developer.leapmotion.com/documentation/csharp/api/Leap.Gesture.html>) objects
in a frame.

**Running the Sample**
----------------------

To run the sample application:

1.     Compile the sample application:

o   On Windows, make sure that Sample.cs and
either LeapCSharp.NET3.5.dll or LeapCSharp.NET4.0.dllare in the current
directory. Run the following command in a command-line prompt (using the proper
library reference for the .NET framework you are using):

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
o   csc /reference:LeapCSharp.NET4.0.dll /platform:x86 /target:exe Sample.cs
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

*Note: use the \`\`csc\`\` compiler from the appropriate version of the .NET
framework.*

o   On Mac, you can use the Mono project to compile C\# programs. Make sure
that Sample.cs and either LeapCSharp.NET3.5.dll or LeapCSharp.NET4.0.dll are in
the current directory:

o   For the .NET 3.5 framework, run:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
o   gmcs /reference:LeapCSharp.NET3.5.dll /platform:x86 /target:exe Sample.cs
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

o   For the .NET 4.0 framework, run:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
o   dmcs /reference:LeapCSharp.NET4.0.dll /platform:x86 /target:exe Sample.cs
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

2.     Run the sample application:

o   On Windows, make sure that Sample.exe, LeapCSharp.dll, Leap.dll and
either LeapCSharp.NET3.5.dll, or LeapCSharp.NET4.0.dll are in the current
directory. Use the libraries in the lib\\x86 directory for 32-bit projects. Use
the libraries in the lib\\x64 directory for 64-bit projects. Run the following
command in a command-line prompt:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
o   Sample.exe
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

o   On Mac, make sure that Sample.exe, libLeapCSharp.dylib, libLeap.dylib and
either LeapCSharp.NET3.5.dll, or LeapCSharp.NET4.0.dll are in the current
directory and run the following command in a terminal window:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
mono Sample.exe
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

 

 
