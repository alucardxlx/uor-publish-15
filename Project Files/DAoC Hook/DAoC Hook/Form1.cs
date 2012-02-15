using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Process[] processes = Process.GetProcessesByName("game.dll");  //looks for in running processes.


 

        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {


            if (processes.Length == 0) 
                throw new Exception("Please make sure DAoC is running and retry."); //exception if cannot find process.

            


            IntPtr WindowHandle = processes[0].MainWindowHandle;
            WindowsAPI.SwitchWindow(WindowHandle);
            Thread.Sleep(1000); //wait while window is switched
            //WindowsAPI.SetFocus(WindowHandle);  //sets processes window to focused window to send commands.
            while (true)
            Keys.PressKey('1' , true);

        }

      





     /*   public static void SendKeyAsInput(System.Windows.Forms.Keys key, int HoldTime)      //I am hoping that my SendKeyAsInput(Keys.J , 500); is utilizing this correctly.  
        {
            INPUT INPUT1 = new INPUT();
            INPUT1.type = (int)InputType.INPUT_KEYBOARD;
            INPUT1.ki.wVk = (short)key;
            INPUT1.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            INPUT1.ki.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, new INPUT[] { INPUT1 }, Marshal.SizeOf(INPUT1));

            WaitForSingleObject((IntPtr)0xACEFDB, (uint)HoldTime);

            INPUT INPUT2 = new INPUT();
            INPUT2.type = (int)InputType.INPUT_KEYBOARD;
            INPUT2.ki.wVk = (short)key;
            INPUT2.ki.dwFlags = (int)KEYEVENTF.KEYUP;
            INPUT2.ki.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, new INPUT[] { INPUT2 }, Marshal.SizeOf(INPUT2)); */

        }

    }

