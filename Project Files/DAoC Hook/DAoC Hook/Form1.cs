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




        public int LifeAddr = Addr.ToDec("0145CDF8");       //4byte
        public int StamAddr = Addr.ToDec("0145CE00");       //4byte
        public int EnemyLifeAddr = Addr.ToDec("0145CE0C");  //4byte
        public int XCoOrdAddr = Addr.ToDec("00980520");     //float
        public int YcoOrdAddr = Addr.ToDec("00980524");     //float
 

        public Form1()
        {
            InitializeComponent();
        }


        public int LifeStat()
        {
            int lifeBytesRead; //This will hold the number of bytes that were successfully read 

            byte[] LifeBytes = oMemory.Read((IntPtr)LifeAddr, 4, out  lifeBytesRead); //Reads 4 bytes to a byte array 
            int lifeValue = BitConverter.ToInt32(LifeBytes, 0); //Converts the byte array to a single integer
                       
            return lifeValue;
        }

        public int StamStat()
        {
            int stamBytesRead;

            byte[] StamBytes = oMemory.Read((IntPtr)StamAddr, 4, out stamBytesRead);
            int stamValue = BitConverter.ToInt32(StamBytes, 0);

            return stamValue;
        }

        public int EnemyLife()
        {
            int enemyLifeBytesRead;

            byte[] EnemyLifeBytes = oMemory.Read((IntPtr)EnemyLifeAddr, 4, out enemyLifeBytesRead);
            int enemyLifeValue = BitConverter.ToInt32(EnemyLifeBytes, 0);

            return enemyLifeValue;

        }

        bool combatloop = false;
        bool resting = false;

        private void button1_Click(object sender, EventArgs e)
        {


            if (processes.Length != 0)
            {


                string text = textBox1.Text;
                char input;
                input = text[0];
                IntPtr WindowHandle = processes[0].MainWindowHandle;
                WindowsAPI.SwitchWindow(WindowHandle);
                Thread.Sleep(1000); //wait while window is switched


                if (combatloop == true)
                    combatloop = false;
                else
                {
                    combatloop = true;
                    do
                    {
                        oMemory.ReadProcess = processes[0]; //Sets the Process to Read/Write From/To 
                        oMemory.Open(); //Open Process 

                        int stamcheck = StamStat();
                        int lifecheck = LifeStat();
                        int enemyLife = EnemyLife();


                        //string message = enemyLife.ToString();
                        //string lifemessage = life.ToString();
                        //MessageBox.Show(message, lifemessage); //Debug Message

                        if (enemyLife > 0 && enemyLife <= 100)
                        {
                            Keys.PressKey(input, true);
                            Thread.Sleep(2500); //Wait between sends
                        }
                        else if(lifecheck < 100 || stamcheck < 100)
                        {
                            do
                            {
                                int stam = StamStat();
                                int life = LifeStat();

                                if (life < 100 || stam < 100 && resting == false)
                                {
                                    Keys.PressKey('x', true); //sit
                                    resting = true;
                                    Thread.Sleep(5000);

                                }
                                else if (life == 100 && stam == 100)
                                {
                                    Keys.PressKey('x', true); //standxx
                                    resting = false;
                                    Thread.Sleep(5000);
                                }
                                else
                                {
                                    Thread.Sleep(5000);
                                }
                            }
                            while (resting == true);
                        }
                    }
                    while (combatloop == true);
                }
            }
        }

        bool healthcheckloop = false;

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (processes.Length != 0) //If the process exists 
            {
                IntPtr WindowHandle = processes[0].MainWindowHandle;
                WindowsAPI.SwitchWindow(WindowHandle);
                Thread.Sleep(1000); //wait while window is switched


                if (healthcheckloop == true)
                    healthcheckloop = false;
                else
                {
                    healthcheckloop = true;
                 do
                {           
                        oMemory.ReadProcess = processes[0]; //Sets the Process to Read/Write From/To 
                        oMemory.Open(); //Open Process 


                        int panicPercent = 20;
                        int enemyLife = EnemyLife();
                        int life = LifeStat();
                        int stam = StamStat();




                        /* string message = life.ToString();
                         MessageBox.Show("bytes read are {0}", message); */
                        //Debug Message 

                        if (panicPercent >= life)
                        {
                            Keys.PressKey('1', true);
                            Thread.Sleep(2000);
                        }
                        Thread.Sleep(1000);
                    }

                 while (healthcheckloop == true);

                }
                oMemory.CloseHandle(); //Close Memory Handle 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


    }

}

