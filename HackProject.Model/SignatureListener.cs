using System;
using System.Collections.Generic;
using System.Drawing;
using Leap;

namespace HackProject.Model
{
    public class SignatureListener : Listener
    {
        private Object thisLock = new Object ();

        public Signature Signature
        {
            get { return _signature; }
        }

        private void SafeWriteLine (String line)
        {
            lock (thisLock)
            {
                if (!messageList.Contains(line))
                {
                    messageList.Add(line);
                    Console.WriteLine (line);

                }
            }
        }

        public override void OnInit (Controller controller)
        {
            SafeWriteLine ("Initialized");
        }

        public override void OnConnect (Controller controller)  
        {
            SafeWriteLine ("Connected");
            controller.EnableGesture (Gesture.GestureType.TYPE_CIRCLE);
            controller.EnableGesture (Gesture.GestureType.TYPE_KEY_TAP);
            controller.EnableGesture (Gesture.GestureType.TYPE_SCREEN_TAP);
            controller.EnableGesture (Gesture.GestureType.TYPE_SWIPE);
            _canTypePassword = false;
            _signature=new Signature();
        }

        public override void OnDisconnect (Controller controller)
        {
            //Note: not dispatched when running in a debugger.
            SafeWriteLine ("Disconnected");
        }

        public override void OnExit (Controller controller)
        {
            SafeWriteLine ("Exited");
        }

        List<String> messageList  =new List<string>();

        //public override void OnFrame(Controller controller)
        //{
        //    // Get the most recent frame and report some basic information
        //    Frame frame = controller.Frame();

        //    //SafeWriteLine (
        //    //    //"Frame id: " + frame.Id
        //    //    // + ", timestamp: " + frame.Timestamp
        //    //    ", hands: " + frame.Hands.Count
        //    //    + ", fingers: " + frame.Fingers.Count
        //    //    + ", tools: " + frame.Tools.Count
        //    //    + ", gestures: " + frame.Gestures ().Count);

        //    foreach (Hand hand in frame.Hands)
        //    {
        //        //  SafeWriteLine("  Hand id: " + hand.Id
        //        //                + ", palm position: " + hand.PalmPosition);
        //        // Get the hand's normal vector and direction
        //        Vector normal = hand.PalmNormal;
        //        Vector direction = hand.Direction;
        //        //foreach (Finger finger in hand.Fingers)
        //        //{
        //        //   SafeWriteLine(finger.TipPosition.x.ToString()+finger.TipPosition.y.ToString());
        //        //}
        //    }
        //    //    // Calculate the hand's pitch, roll, and yaw angles
        //    //    SafeWriteLine ("  Hand pitch: " + direction.Pitch * 180.0f / (float)Math.PI + " degrees, "
        //    //                   + "roll: " + normal.Roll * 180.0f / (float)Math.PI + " degrees, "
        //    //                   + "yaw: " + direction.Yaw * 180.0f / (float)Math.PI + " degrees");

        //    //    // Get the Arm bone
        //    //    Arm arm = hand.Arm;
        //    //    SafeWriteLine ("  Arm direction: " + arm.Direction
        //    //                   + ", wrist position: " + arm.WristPosition
        //    //                   + ", elbow position: " + arm.ElbowPosition);

        //    //    // Get fingers
        //    //    foreach (Finger finger in hand.Fingers) {
        //    //        SafeWriteLine ("    Finger id: " + finger.Id
        //    //                       + ", " + finger.Type().ToString()
        //    //                       + ", length: " + finger.Length
        //    //                       + "mm, width: " + finger.Width + "mm");

        //    //        // Get finger bones
        //    //        Bone bone;
        //    //        foreach (Bone.BoneType boneType in (Bone.BoneType[]) Enum.GetValues(typeof(Bone.BoneType)))
        //    //        {
        //    //            bone = finger.Bone(boneType);
        //    //            SafeWriteLine("      Bone: " + boneType
        //    //                          + ", start: " + bone.PrevJoint
        //    //                          + ", end: " + bone.NextJoint
        //    //                          + ", direction: " + bone.Direction);
        //    //        }
        //    //    }

        //    //}

        //    //foreach (Tool tool in frame.Tools) {
        //    //    SafeWriteLine ("  Tool id: " + tool.Id
        //    //                   + ", position: " + tool.TipPosition
        //    //                   + ", direction " + tool.Direction);
        //    //}

        //   GestureList gestures = frame.Gestures();
        //    for (int i = 0; i < gestures.Count; i++)
        //    {
        //        Gesture gesture = gestures[i];

        //        switch (gesture.Type)
        //        {
        //            case Gesture.GestureType.TYPE_CIRCLE:
        //                CircleGesture circle = new CircleGesture(gesture);

        //                // Calculate clock direction using the angle between circle normal and pointable
        //                String clockwiseness;
        //                if (circle.Pointable.Direction.AngleTo(circle.Normal) <= Math.PI/2)
        //                {
        //                    //Clockwise if angle is less than 90 degrees
        //                    clockwiseness = "clockwise";
        //                }
        //                else
        //                {
        //                    clockwiseness = "counterclockwise";
        //                }

        //                float sweptAngle = 0;

        //                // Calculate angle swept since last frame
        //                if (circle.State != Gesture.GestureState.STATE_START)
        //                {
        //                    CircleGesture previousUpdate = new CircleGesture(controller.Frame(1).Gesture(circle.Id));
        //                    sweptAngle = (circle.Progress - previousUpdate.Progress)*360;
        //                }

        //                SafeWriteLine("  Circle id: " + circle.Id
        //                              + ", " + circle.State
        //                              + ", progress: " + circle.Progress
        //                              + ", radius: " + circle.Radius
        //                              + ", angle: " + sweptAngle
        //                              + ", " + clockwiseness);
        //                break;
        //            case Gesture.GestureType.TYPE_SWIPE:
        //                SwipeGesture swipe = new SwipeGesture(gesture);
        //                SafeWriteLine("  Swipe id: " + swipe.Id
        //                              + ", " + swipe.State
        //                              + ", position: " + swipe.Position
        //                              + ", direction: " + swipe.Direction
        //                              + ", speed: " + swipe.Speed);
        //                break;
        //            case Gesture.GestureType.TYPE_KEY_TAP:
        //                KeyTapGesture keytap = new KeyTapGesture(gesture);
        //                SafeWriteLine("  Tap id: " + keytap.Id
        //                              + ", " + keytap.State
        //                              + ", position: " + keytap.Position
        //                              + ", direction: " + keytap.Direction);
        //                break;
        //            case Gesture.GestureType.TYPE_SCREEN_TAP:
        //                ScreenTapGesture screentap = new ScreenTapGesture(gesture);
        //                SafeWriteLine("  Tap id: " + screentap.Id
        //                              + ", " + screentap.State
        //                              + ", position: " + screentap.Position
        //                              + ", direction: " + screentap.Direction);
        //                break;
        //            default:
        //                SafeWriteLine("  Unknown gesture type.");
        //                break;
        //        }
        //        //}

        //        if (!frame.Hands.IsEmpty || !frame.Gestures().IsEmpty)
        //        {
        //            SafeWriteLine("");
        //        }
        //    }
        //}

        private long currentTime;
        private long previousTime;
        private long timeChange;
        private static bool _canTypePassword;
        private static SwipeGesture _firstSwipe;
        private static SwipeGesture _lastSwipe;
        private Signature _signature;

        public override void OnFrame(Controller cntrlr)
        {
            // Get the current frame.
            Frame currentFrame = cntrlr.Frame();

            currentTime = currentFrame.Timestamp;
            timeChange = currentTime - previousTime;

            if (timeChange > 5000)
            {
                if (!currentFrame.Hands.IsEmpty)
                {
                //    CheckSwipeGesture(currentFrame);
                 //   if(_canTypePassword)
                    // Get the first finger in the list of fingers
                 //   {
                        Finger finger = currentFrame.Fingers[0];
                        // Get the closest screen intercepting a ray projecting from the finger
                        Screen screen = cntrlr.LocatedScreens.ClosestScreenHit(finger);

                        if (screen != null && screen.IsValid)
                        {
                            // Get the velocity of the finger tip
                            var tipVelocity = (int)finger.TipVelocity.Magnitude;

                            // Use tipVelocity to reduce jitters when attempting to hold
                            // the cursor steady
                            if (tipVelocity > 25)
                            {
                                var xScreenIntersect = screen.Intersect(finger, true).x;
                                var yScreenIntersect = screen.Intersect(finger, true).y;

                                if (xScreenIntersect.ToString() != "NaN")
                                {
                                    var x = (int)(xScreenIntersect * screen.WidthPixels);
                                    var y = (int)(screen.HeightPixels - (yScreenIntersect * screen.HeightPixels));
                                    var position = new Point(x, y);
                                    Signature.Add(position);
                                   // Move the cursor
                                                     MouseCursor.MoveCursor(x, y);
                                }

                            }
                        }
                    }

                //}

                previousTime = currentTime;
            }
        }

        private static void CheckSwipeGesture(Frame currentFrame)
        {
            GestureList gestures = currentFrame.Gestures();
            for (int i = 0; i < gestures.Count; i++)
            {
                Gesture gesture = gestures[i];
                if (gesture.Type == Gesture.GestureType.TYPE_SWIPE)
                {
                    var swipeGesture = new SwipeGesture(gesture);
                    if (swipeGesture.StartPosition.x>0)
                    {
                        _canTypePassword = true;
                    }
                    else
                    {
                        _canTypePassword = false;
                    }
                }
                    //if (_firstSwipe == null)
                    //{
                    //    _firstSwipe = new SwipeGesture(gesture);
                    //}
                    //_lastSwipe = new SwipeGesture(gesture);
                    //if(_firstSwipe.po)
                    ////                SafeWriteLine("  Swipe id: " + swipe.Id
                    ////                              + ", " + swipe.State
                    ////                              + ", position: " + swipe.Position
                    ////                              + ", direction: " + swipe.Direction
                    ////                              + ", speed: " + swipe.Speed);
                }
            }
        }
}
