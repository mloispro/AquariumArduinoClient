using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AquariumArduinoClient.Controls
{
    public static class TextBoxExt
    {

        [DllImport("user32.dll")]

        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private const int WM_SETREDRAW = 0xb;

        private const int WM_USER = 0x400;

        private const int EM_GETLINECOUNT = 0xba;

        private const int EM_GETEVENTMASK = (WM_USER + 59);

        private const int EM_SETEVENTMASK = (WM_USER + 69);



        public static void AppendLine(this TextBox textBox, string text, int maxLinesToShow)

        {

            // Please note that the returned line count is affected if the control

            // is resized and WordWrap is set to true

            int lineCount = (int)SendMessage(textBox.Handle, EM_GETLINECOUNT, (IntPtr)0, (IntPtr)0);



            if (maxLinesToShow < lineCount)

            {

                int posNewLine = textBox.Text.IndexOf(Environment.NewLine);

                textBox.Text = textBox.Text.Substring(posNewLine + Environment.NewLine.Length);

            }



            IntPtr eventMask = IntPtr.Zero;



            try

            {

                // Anti-flickering code source: Johan Danforth's blog:

                // http://weblogs.asp.net/jdanforth/archive/2004/03/12/88458.aspx

                SendMessage(textBox.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);

                textBox.AppendText(text + Environment.NewLine);

                eventMask = SendMessage(textBox.Handle, EM_GETEVENTMASK, IntPtr.Zero, IntPtr.Zero);

            }

            finally

            {

                SendMessage(textBox.Handle, EM_SETEVENTMASK, IntPtr.Zero, eventMask);

                SendMessage(textBox.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);



                if (textBox.SelectionStart != textBox.Text.Length)

                    textBox.SelectionStart = textBox.Text.Length;



                textBox.ScrollToCaret();

            }

        }

    }

}
