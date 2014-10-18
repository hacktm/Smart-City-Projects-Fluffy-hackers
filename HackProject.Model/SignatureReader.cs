/******************************************************************************\
* Copyright (C) 2012-2014 Leap Motion, Inc. All rights reserved.               *
* Leap Motion proprietary and confidential. Not for distribution.              *
* Use subject to the terms of the Leap Motion SDK Agreement available at       *
* https://developer.leapmotion.com/sdk_agreement, or another agreement         *
* between Leap Motion and you, your company or other organization.             *
\******************************************************************************/

using System;
using Leap;

namespace HackProject.Model
{
    public class SignatureReader
    {
        private SignatureListener _listener;
        private Controller _controller;

        public void WriteSignature()
        {
            // Create a sample listener and controller
            _listener = new SignatureListener();
            _controller = new Controller();

            // Have the sample listener receive events from the controller
            _controller.AddListener(_listener);

        }

        public Signature GetReadSignature()
        {
            var signature = _listener.Signature;
            _controller.RemoveListener(_listener);
            _controller.Dispose();
            return signature;
        }
    }
}