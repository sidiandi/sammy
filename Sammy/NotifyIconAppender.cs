// Copyright (c) 2008, Andreas Grimme (http://andreas-grimme.gmxhome.de/)
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Appender;
using System.Windows.Forms;

namespace Sidi.Sammy
{
    class NotifyIconAppender : AppenderSkeleton
    {
        NotifyIcon notifyIcon;

        public NotifyIconAppender(NotifyIcon notifyIcon)
        {
            this.notifyIcon = notifyIcon;
            this.Layout = new log4net.Layout.PatternLayout(
                "%logger %M %property{NDC}%newline%message");
        }

        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            string s = RenderLoggingEvent(loggingEvent);
            notifyIcon.BalloonTipText = s;
            notifyIcon.BalloonTipTitle = loggingEvent.Level.ToString();
            notifyIcon.ShowBalloonTip(1000);
        }
    }
}
