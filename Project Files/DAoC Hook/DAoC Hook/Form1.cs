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
using MemoryEditor;
using System.Globalization;


namespace WindowsFormsApplication1
{
    

    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Int32 bInheritHandle, UInt32 dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern Int32 WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesWritten);



        Process[] processes = Process.GetProcessesByName("game.dll");  //looks for in running processes.
        Memory oMemory = new Memory(); //For memory read/write
        Memory value = new Memory();

        // DAoC Life Pointer? 0145CDF8

//               [DllImport("Kernel32.Dll")] 
//public static extern IntPtr OpenProcess(WindowHandle dwDesiredAccess, bool bInheritance, DWORD dwProcessId); 

//[DllImport("Kernel32.Dll")] 
//public static extern bool ReadProcessMemory(IntPtr hProcess,IntPtr BaseAddress, out byte[] buffer, Int32 b_size, out Int32 dwBytesRead); 




 

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


        private void button2_Click(object sender, EventArgs e)
        {
            if (processes.Length != 0) //If the process exists 
            {
                IntPtr WindowHandle = processes[0].MainWindowHandle;
                WindowsAPI.SwitchWindow(WindowHandle);
                Thread.Sleep(1000); //wait while window is switched
              
                int LifeAddr = Addr.ToDec("0145CDF8");
                oMemory.ReadProcess = processes[0]; //Sets the Process to Read/Write From/To 
                oMemory.Open(); //Open Process 



               
                

          
               // int Life = bytesRead;
                int PanicPercent = 20;

                int loop = 15;

              

                while (loop > 1)
                {
                    int bytesReaded; //This will hold the number of bytes that were successfully read 
                    byte[] ThisIs4Bytes = oMemory.Read((IntPtr)LifeAddr, 4, out  bytesReaded); //Reads 4 bytes to a byte array 
                    int ReadValue = BitConverter.ToInt32(ThisIs4Bytes, 0); //Converts the byte array to a single integer 

                    /* string message = ReadValue.ToString();
                    MessageBox.Show("bytes read are {0}", message);*/ //Debug Message

                    if (PanicPercent >= ReadValue)
                    {
                        Keys.PressKey('1', true);
                        Thread.Sleep(5000);
                        loop --;
                    }
                    Thread.Sleep(1000);
                }
                
                
                //The static address of the pointer (#1) 
                //int[] iStep2_Offsets = { 0x98, 0x4, 0x288, 0x24, 0x458 }; //Offsets from bottom to top (#2-#6) 

                //int bytesWritten; //Holds how many bytes were written by PointerWrite 

                //int iValue_To_Write = 1000; //Value that we want to write (Step2 requires that you change the value to 1000) 
                //byte[] bValue_To_Write = BitConverter.GetBytes(iValue_To_Write); //Turns 1000 into bytes 

                //string sWritten_Address = oMemory.PointerWrite((IntPtr)iStep2_Address, //PointerWrite starting with our Step2 Address 
                 //                 bValue_To_Write, //The value to write (as bytes) 
                //                  iStep2_Offsets, //Our offsets 
                 //                 out bytesWritten); //Stores the # of Written Bytes 

                //if (bytesWritten == bValue_To_Write.Length) //If writing was successful 
                   // MessageBox.Show("Wrote " + iValue_To_Write.ToString() + " to " + sWritten_Address + "!"); //Notify the user of success 
                //else
                  //  MessageBox.Show("There was an error writing " + iValue_To_Write.ToString() + " to " + sWritten_Address + "."); //Notify the user of failure 

                oMemory.CloseHandle(); //Close Memory Handle 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

      
 
/* class implementation */ 
//IntPtr hProc = IntPtr.Zero; 
//Int32 dwBytesRead, Value; 
//hProc = OpenProcess(0x0010 /* PROCESS_VM_READ access */, false,iPID); // iPID is your process id get it by your self using Process class 
//byte[] memory = new byte[6]; // can be more than 6 depends how many bytes you're interesting to read 
////ReadProcessMemory(hProc,(IntPtr)0xFFFFFFFF /* your address */, out memory, memory.Length,out dwBytesRead); 
//Value = BitConvert.ToInt32(memory); 




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

