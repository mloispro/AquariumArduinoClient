using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AquariumArduinoClient.Utilities
{
    
    public class Status
    {
        public enum StatusType
        {
            Info,
            ConnError
        }

        private static StatusStrip _statusBar;
        private static ToolStripStatusLabel _connStatus;
        private static ToolStripStatusLabel _message;
        //private ToolStripItem _connStatus;
        //private ToolStripItem _message;
        public static void Init(StatusStrip statusBar)
        {
            _statusBar = statusBar;
            _connStatus = (ToolStripStatusLabel)statusBar.Items[0];
            _message = (ToolStripStatusLabel)statusBar.Items[1];
            _statusBar.SetControlText(_connStatus, "...");
            _statusBar.SetControlText(_message, "");
        }
        public static void SetStatus(string msg, StatusType statusType=StatusType.Info)
        {
            if (statusType == StatusType.ConnError)
            {
                _statusBar.SetControlText(_connStatus, "Connection Error!", System.Drawing.Color.Red);
                
            }
            else if(statusType == StatusType.Info)
            {
                _statusBar.SetControlText(_connStatus, "Connected", System.Drawing.Color.Green);
            }
            _statusBar.SetControlText(_message, msg);
        }
    }
}
