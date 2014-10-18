using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HackProject.Test;
using Leap;

namespace HackProject.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ILeapEventDelegate
    {
        private readonly Controller _controller = new Controller();
        private readonly LeapEventListener _listener;

        public MainWindow()
        {
            InitializeComponent();
            this._controller = new Controller();
            this._listener = new LeapEventListener(this);
            _controller.AddListener(_listener);
        }

        delegate void LeapEventDelegate(string EventName);
        public void LeapEventNotification(string EventName)
        {
            if (this.CheckAccess())
            {
                switch (EventName)
                {
                    case "onInit":
                        Debug.WriteLine("Init");
                        break;
                    case "onConnect":
                        this.connectHandler();
                        break;
                    case "onFrame":
                        this.newFrameHandler(this._controller.Frame());
                        break;
                }
            }
            else
            {
                Dispatcher.Invoke(new LeapEventDelegate(LeapEventNotification), new object[] { EventName });
            }
        }

        void connectHandler()
        {
            //this.controller.SetPolicyFlags(Controller.PolicyFlag.POLICY_IMAGES);
            this._controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
            this._controller.Config.SetFloat("Gesture.Swipe.MinLength", 100.0f);
        }

        void newFrameHandler(Leap.Frame frame)
        {
            this.displayID.Text = frame.Id.ToString();
            this.displayTimestamp.Text = frame.Timestamp.ToString();
            this.displayFPS.Text = frame.CurrentFramesPerSecond.ToString();
            this.displayIsValid.Text = frame.IsValid.ToString();
            this.displayGestureCount.Text = frame.Gestures().Count.ToString();
            this.displayImageCount.Text = frame.Images.Count.ToString();
        }

        void MainWindow_Closing(object sender, EventArgs e)
        {
            this._controller.RemoveListener(this._listener);
            this._controller.Dispose();
        }
    }

    public interface ILeapEventDelegate
    {
        void LeapEventNotification(string EventName);
    }

    public class LeapEventListener : Listener
    {
        ILeapEventDelegate eventDelegate;

        public LeapEventListener(ILeapEventDelegate delegateObject)
        {
            this.eventDelegate = delegateObject;
        }
        public override void OnInit(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onInit");
        }
        public override void OnConnect(Controller controller)
        {
            controller.SetPolicyFlags(Controller.PolicyFlag.POLICY_IMAGES);
            controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
            this.eventDelegate.LeapEventNotification("onConnect");
        }

        public override void OnFrame(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onFrame");
        }
        public override void OnExit(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onExit");
        }
        public override void OnDisconnect(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onDisconnect");
        }

    }
}
