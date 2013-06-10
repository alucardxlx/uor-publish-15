using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WindowsFormsApplication1
{
    class Keys
    {

        public static void PressKey(char ch, bool press)
        {
            byte vk = WindowsAPI.VkKeyScan(ch);
            ushort scanCode = (ushort)WindowsAPI.MapVirtualKey(vk, 0);

            if (press)
                KeyDown(vk, scanCode);
            else
                KeyUp(vk, scanCode);
            //KeyUp(vk, scanCode);
            //Thread.Sleep(5000);
        }

        public static void KeyDown(byte vk, ushort scanCode)
        {
            INPUT[] inputs = new INPUT[1];
            inputs[0].type = WindowsAPI.INPUT_KEYBOARD;
            inputs[0].ki.wVk = (byte)(vk);
            inputs[0].ki.dwFlags = 0;
            inputs[0].ki.wScan = (ushort)(scanCode & 0xff);

            uint intReturn = WindowsAPI.SendInput(1, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
            if (intReturn != 1)
            {
                throw new Exception("Could not send key: "); //+ scanCode
            }
        }

        public static void KeyUp(byte vk, ushort scanCode)
        {
            INPUT[] inputs = new INPUT[1];
            inputs[0].type = WindowsAPI.INPUT_KEYBOARD;
            inputs[0].ki.wVk = (byte)(vk);
            inputs[0].ki.wScan = scanCode;
            inputs[0].ki.dwFlags = WindowsAPI.KEYEVENTF_KEYUP;
            uint intReturn = WindowsAPI.SendInput(1, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
            if (intReturn != 1)
            {
                throw new Exception("Could not send key: " + scanCode);
            }
        }
    }
}
