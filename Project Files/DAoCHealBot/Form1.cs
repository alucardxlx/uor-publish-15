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
//using MemoryEditor;
using System.Globalization;
using System.Xml;
using System.IO;
using System.Timers;
using WindowsInput;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        private XmlDocument doc;
        private XmlElement root;
        public string PATH = @"config.xml";

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


        //Self Addresses
        int LevelAddr = Addr.ToDec("00A1EB68");      //4byte  //Alternate 00A04168
        int LifeAddr = Addr.ToDec("0145CDF8");       //4byte
        int StamAddr = Addr.ToDec("0145CE00");       //4byte
        int PowAddr = Addr.ToDec("0145CDFC");        //4byte
        int EnemyNameAddr = Addr.ToDec("0145D280");  //String
        int EnemyLifeAddr = Addr.ToDec("0145CE0C");  //4byte
        int XCoOrdAddr = Addr.ToDec("00980520");     //float
        int YcoOrdAddr = Addr.ToDec("00980524");     //float



        //Skill Addresses
        int FirstSkillAddr = Addr.ToDec("00A12688");
        int SixthSkillAddr = Addr.ToDec("00A129D0");

        //Party Adresses

        int life1Addr = Addr.ToDec("00A04538");     //4byte
        int life2Addr = Addr.ToDec("00A05514");     //4byte
        int life3Addr = Addr.ToDec("00A064F0");     //4byte
        int life4Addr = Addr.ToDec("0145CDF8");     //4byte
        int life5Addr = Addr.ToDec("0145CDF8");     //4byte
        int life6Addr = Addr.ToDec("0145CDF8");     //4byte
        int life7Addr = Addr.ToDec("0145CDF8");     //4byte
        int life8Addr = Addr.ToDec("0145CDF8");     //4byte

       // int sitting;
        int life;
        int stam;
        int pow;

        int life1;
        int life2;
        int life3;
        int life4;
        int life5;
        int life6;
        int life7;
        int life8;
        int targetLife;




        char smHeal;
        char lgHeal;
        char iHeal;
        char gpIHeal;

        char member1;
        char member2;
        char member3;
        char member4;
        char member5;
        char member6;
        char member7;
        char member8;

        char stick;
        char face;
        char sit;
        char combatKey;

        char targetnearest;
        char DD1;
        char attack1;
        char attack2;

        char buff1;
        char buff2;
        char buff3;
        char buff4;
        char buff5;

        public string enemyname;
        public string className;


        delegate void SetTextCallback(string text);


        public Form1()
        {
            InitializeComponent();
        }

        public void StatusUpdate()
        {
            string smallHeal = textBox1.Text;
            smHeal = smallHeal[0];
            string largeHeal = textBox3.Text;
            lgHeal = largeHeal[0];
            string instantHeal = textBox2.Text;
            iHeal = instantHeal[0];
            string groupInstantHeal = textBox4.Text;
            gpIHeal = groupInstantHeal[0];


            string stickKey = textBox5.Text;
            stick = stickKey[0];
            string faceKey = textBox6.Text;
            face = faceKey[0];
            string sitKey = textBox15.Text;
            sit = sitKey[0];
            string combatsKey = textBox20.Text;
            combatKey = combatsKey[0];


            string member1Key = textBox7.Text;
            member1 = member1Key[0];
            string member2Key = textBox8.Text;
            member2 = member2Key[0];
            string member3Key = textBox9.Text;
            member3 = member3Key[0];
            string member4Key = textBox10.Text;
            member4 = member4Key[0];
            string member5Key = textBox11.Text;
            member5 = member5Key[0];
            string member6Key = textBox12.Text;
            member6 = member6Key[0];
            string member7Key = textBox13.Text;
            member7 = member7Key[0];
            string member8Key = textBox14.Text;
            member8 = member8Key[0];

            string targetKey = textBox16.Text;
            targetnearest = targetKey[0];
            string DD1Key = textBox17.Text;
            DD1 = DD1Key[0];
            string attack1Key = textBox18.Text;
            attack1 = attack1Key[0];
            string attack2Key = textBox19.Text;
            attack2 = attack2Key[0];

            string buff1Key = textBox21.Text;
            buff1 = buff1Key[0];
            string buff2Key = textBox22.Text;
            buff2 = buff2Key[0];
            string buff3Key = textBox23.Text;
            buff3 = buff3Key[0];
            string buff4Key = textBox24.Text;
            buff4 = buff4Key[0];
            string buff5Key = textBox25.Text;
            buff5 = buff5Key[0];

            //string testKey = textBox26.Text;
            //test = testKey[0];

        }

        public int Level()
        {
            int levelBytesRead; //This will hold the number of bytes that were successfully read 

            byte[] LevelBytes = oMemory.Read((IntPtr)LevelAddr, 4, out  levelBytesRead); //Reads 4 bytes to a byte array 
            int levelValue = BitConverter.ToInt32(LevelBytes, 0); //Converts the byte array to a single integer

            return levelValue;
        }

        public string EnemyName()
        {
            int enemyNameBytesRead; //This will hold the number of bytes that were successfully read 

            byte[] EnemyNameBytes = oMemory.Read((IntPtr)EnemyNameAddr, 4, out  enemyNameBytesRead); //Reads 4 bytes to a byte array 
            string enemyNameValue = BitConverter.ToString(EnemyNameBytes, 0); //Converts the byte array to a single integer

            return enemyNameValue;
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

        public int PowStat()
        {
            int powBytesRead;
            byte[] PowBytes = oMemory.Read((IntPtr)PowAddr, 4, out powBytesRead);
            int powValue = BitConverter.ToInt32(PowBytes, 0);
            return powValue;
        }

        public int EnemyLife()
        {
            int enemyLifeBytesRead;

            byte[] EnemyLifeBytes = oMemory.Read((IntPtr)EnemyLifeAddr, 4, out enemyLifeBytesRead);
            int enemyLifeValue = BitConverter.ToInt32(EnemyLifeBytes, 0);

            return enemyLifeValue;

        }

        public int FirstSkill()
        {
            int firstSkillBytesRead; //This will hold the number of bytes that were successfully read 

            byte[] FirstSkillBytes = oMemory.Read((IntPtr)FirstSkillAddr, 4, out  firstSkillBytesRead); //Reads 4 bytes to a byte array 
            int firstSkillValue = BitConverter.ToInt32(FirstSkillBytes, 0); //Converts the byte array to a single integer

            return firstSkillValue;
        }

        public int SixthSkill()
        {
            int sixthSkillBytesRead; //This will hold the number of bytes that were successfully read 

            byte[] SixthSkillBytes = oMemory.Read((IntPtr)SixthSkillAddr, 4, out  sixthSkillBytesRead); //Reads 4 bytes to a byte array 
            int sixthSkillValue = BitConverter.ToInt32(SixthSkillBytes, 0); //Converts the byte array to a single integer

            return sixthSkillValue;
        }

        public int Life1()
        {
            int life1BytesRead;

            byte[] life1Bytes = oMemory.Read((IntPtr)life1Addr, 4, out life1BytesRead);
            int life1Value = BitConverter.ToInt32(life1Bytes, 0);

            return life1Value;

        }

        public int Life2()
        {
            int life2BytesRead;

            byte[] life2Bytes = oMemory.Read((IntPtr)life2Addr, 4, out life2BytesRead);
            int life2Value = BitConverter.ToInt32(life2Bytes, 0);

            return life2Value;
        }

        public int Life3()
        {
            int life3BytesRead;

            byte[] life3Bytes = oMemory.Read((IntPtr)life3Addr, 4, out life3BytesRead);
            int life3Value = BitConverter.ToInt32(life3Bytes, 0);

            return life3Value;
           // return 100;

        }

        public int Life4()
        {
            int life4BytesRead;

            byte[] life4Bytes = oMemory.Read((IntPtr)life4Addr, 4, out life4BytesRead);
            int life4Value = BitConverter.ToInt32(life4Bytes, 0);

            //return life4Value;
            return 100;

        }

        public int Life5()
        {
            int life5BytesRead;

            byte[] life5Bytes = oMemory.Read((IntPtr)life5Addr, 4, out life5BytesRead);
            int life5Value = BitConverter.ToInt32(life5Bytes, 0);

            //return life5Value;
            return 100;

        }

        public int Life6()
        {
            int life6BytesRead;

            byte[] life6Bytes = oMemory.Read((IntPtr)life6Addr, 4, out life6BytesRead);
            int life6Value = BitConverter.ToInt32(life6Bytes, 0);

            //return life6Value;
            return 100;

        }

        public int Life7()
        {
            int life7BytesRead;

            byte[] life7Bytes = oMemory.Read((IntPtr)life7Addr, 4, out life7BytesRead);
            int life7Value = BitConverter.ToInt32(life7Bytes, 0);

           // return life7Value;
            return 100;

        }

        public int Life8()
        {
            int life8BytesRead;

            byte[] life8Bytes = oMemory.Read((IntPtr)life8Addr, 4, out life8BytesRead);
            int life8Value = BitConverter.ToInt32(life8Bytes, 0);

            //return life8Value;
            return 100;

        }

        public void CtrlKey()
        {
            Keys.AltKeyDown(17, 29); //ALT DOWN
            Thread.Sleep(1000);
            Keys.AltKeyUp(17, 29); //ALT UP
        }

        public void AltKey()
        {
            Keys.AltKeyDown(18, 38); //ALT DOWN
            Thread.Sleep(1000);
            Keys.AltKeyUp(18, 38); //ALT UP
        }

        public int HealthCheck()
        {
            if (life1 < 70 && life1 < life2 && life1 < life3 && life1 < life4 && life1 < life5 && life1 < life6 && life1 < life7 && life1 < life8)
          {
              int check = 1;
              return check;
          }
            if ( life2 < 70 && life2 < life1 && life2 < life3 && life2 < life4 && life2 < life5 && life2 < life6 && life2 < life7 && life2 < life8)
          {
              int check = 2;
              return check;
          }
            if (life3 < 70 && life3 < life1 && life3 < life2 && life3 < life4 && life3 < life5 && life3 < life6 && life3 < life7 && life3 < life8)
          {
              int check = 3;
              return check;
          }
            if (life4 < 70 && life4 < life1 && life4 < life2 && life4 < life3 && life4 < life5 && life4 < life6 && life4 < life7 && life4 < life8)
          {
              int check = 4;
              return check;
          }
            if (life5 < 70 && life5 < life1 && life5 < life2 && life5 < life3 && life5 < life4 && life5 < life6 && life5 < life7 && life5 < life8)
          {
              int check = 5;
              return check;
          }
            if (life6 < 70 && life6 < life1 && life6 < life2 && life6 < life3 && life6 < life4 && life6 < life5 && life6 < life7 && life6 < life8)
          {
              int check = 6;
              return check;
          }
            if (life7 < 70 && life7 < life1 && life7 < life2 && life7 < life3 && life7 < life4 && life7 < life5 && life7 < life6 && life7 < life8)
          {
              int check = 7;
              return check;
          }
            if (life8 < 70 && life8 < life1 && life8 < life2 && life8 < life3 && life8 < life4 && life8 < life5 && life8 < life6 && life8 < life7)
          {
              int check = 8;
              return check;
          }
          else
          {
              int check = 9;
              return check;
          }
        }

        public void HealBot()
        {

            oMemory.ReadProcess = processes[0]; //Sets the Process to Read/Write From/To 
            oMemory.Open(); //Open Process 

            int needheal = HealthCheck();
            bool On = true;

            while (On == true)
            {
                //Self
                stam = StamStat();
                life = LifeStat();
                targetLife = EnemyLife();

                //Party
                life1 = Life1();
                life2 = Life2();
                life3 = Life3();
                life4 = Life4();
                life5 = Life5();
                life6 = Life6();
                life7 = Life7();
                life8 = Life8();

                if (label1.Text == "Off")
                {
                    Thread.CurrentThread.Abort();
                }

                //MessageBox.Show("Looping");
                //Thread.Sleep(2000);
                StatusUpdate();
                needheal = HealthCheck();

                if (needheal == 1) //member 1 is the lowest life
                {
                    string newText = "Healing Party Member 1"; // running on worker thread
                    this.Invoke((MethodInvoker)delegate
                    {
                        label5.Text = newText; // runs on UI thread
                    });



                    //if (targetLife != life1)
                    //{

                    Keys.PressKey(member1, true);
                    Thread.Sleep(500);
                    Keys.PressKey(face, true);
                    Thread.Sleep(500);
                    //}
                    do
                    {
                        needheal = HealthCheck();
                        life1 = Life1();
                        life2 = Life2();
                        life3 = Life3();
                        life4 = Life4();
                        life5 = Life5();
                        life6 = Life6();
                        life7 = Life7();
                        life8 = Life8();

                        if (label1.Text == "Off")
                        {
                            Thread.CurrentThread.Abort();
                        }

                        if (life1 < 10)
                        {
                            // MessageBox.Show("instanthealing");
                            Keys.PressKey(iHeal, true);
                            Thread.Sleep(3000);

                            newText = "Instant Healing Member 1"; // running on worker thread
                            this.Invoke((MethodInvoker)delegate
                            {
                                label5.Text = newText; // runs on UI thread
                            });
                        }
                        else if (life1 < 50)
                        {
                            // MessageBox.Show("lghealing");
                            Keys.PressKey(lgHeal, true);
                            Thread.Sleep(3000);

                            newText = "Large Healing Member 1"; // running on worker thread
                            this.Invoke((MethodInvoker)delegate
                            {
                                label5.Text = newText; // runs on UI thread
                            });
                        }
                        else if (life1 < 80)
                        {
                            //MessageBox.Show("smhealing");
                            Keys.PressKey(smHeal, true);
                            Thread.Sleep(3000);

                            newText = "Small Healing Member 1"; // running on worker thread
                            this.Invoke((MethodInvoker)delegate
                            {
                                label5.Text = newText; // runs on UI thread
                            });
                        }
                    }
                    while (life1 < 80  & needheal == 1);

                }

                if (needheal == 2) //member 2 is the lowest life
                {
                    string newText = "Healing Party Member 2"; // running on worker thread
                    this.Invoke((MethodInvoker)delegate
                    {
                        label5.Text = newText; // runs on UI thread
                    });
                    //if (targetLife != life2)
                    //{
                    Keys.PressKey(member2, true);
                    Thread.Sleep(500);
                    Keys.PressKey(face, true);
                    Thread.Sleep(500);

                    // }
                    do
                    {
                        needheal = HealthCheck();
                        life1 = Life1();
                        life2 = Life2();
                        life3 = Life3();
                        life4 = Life4();
                        life5 = Life5();
                        life6 = Life6();
                        life7 = Life7();
                        life8 = Life8();

                        if (label1.Text == "Off")
                        {
                            Thread.CurrentThread.Abort();
                        }

                        if (life2 <= 10)
                        {
                            Keys.PressKey(iHeal, true);
                            Thread.Sleep(3000);


                             newText = "Instant Healing Member 2"; // running on worker thread
                            this.Invoke((MethodInvoker)delegate
                            {
                                label5.Text = newText; // runs on UI thread
                            });
                        }
                        else if (life2 <= 50)
                        {
                            Keys.PressKey(lgHeal, true);
                            Thread.Sleep(3000);

                            newText = "Large Healing Member 2"; // running on worker thread
                            this.Invoke((MethodInvoker)delegate
                            {
                                label5.Text = newText; // runs on UI thread
                            });
                        }
                        else if (life2 <= 80)
                        {
                            Keys.PressKey(smHeal, true);
                            Thread.Sleep(3000);

                            newText = "Small Healing Member 2"; // running on worker thread
                            this.Invoke((MethodInvoker)delegate
                            {
                                label5.Text = newText; // runs on UI thread
                            });
                        }
                    }
                    while (life2 < 80 & needheal == 2);

                }


                if (needheal == 3) //member 3 is the lowest life
                {
                    //if (targetLife != life3)
                    //{
                    Keys.PressKey(member3, true);
                    Thread.Sleep(500);
                    Keys.PressKey(face, true);
                    Thread.Sleep(500);
                    // }
                    do
                    {
                        string newText = "Healing Member 3"; // running on worker thread
                        this.Invoke((MethodInvoker)delegate
                        {
                            label5.Text = newText; // runs on UI thread
                        });

                        needheal = HealthCheck();
                        life1 = Life1();
                        life2 = Life2();
                        life3 = Life3();
                        life4 = Life4();
                        life5 = Life5();
                        life6 = Life6();
                        life7 = Life7();
                        life8 = Life8();

                        if (label1.Text == "Off")
                        {
                            Thread.CurrentThread.Abort();
                        }

                        if (life3 <= 10)
                        {
                            newText = "Instant Healing Member 3"; // running on worker thread
                            this.Invoke((MethodInvoker)delegate
                            {
                                label5.Text = newText; // runs on UI thread
                            });
                            Keys.PressKey(iHeal, true);
                        }
                        else if (life3 <= 50)
                        {
                            newText = "Large Healing Member 3"; // running on worker thread
                            this.Invoke((MethodInvoker)delegate
                            {
                                label5.Text = newText; // runs on UI thread
                            });

                            Keys.PressKey(lgHeal, true);
                        }
                        else if (life3 <= 80)
                        {
                            newText = "Large Healing Member 3"; // running on worker thread
                            this.Invoke((MethodInvoker)delegate
                            {
                                label5.Text = newText; // runs on UI thread
                            });
                            Keys.PressKey(smHeal, true);
                        }
                    }
                    while (life3 < 80 & needheal == 3);

                }

                if (needheal == 4) //member 4 is the lowest life
                {
                    //if (targetLife != life4)
                    //{

                    Keys.PressKey(member4, true);
                    Thread.Sleep(500);
                    Keys.PressKey(face, true);
                    Thread.Sleep(500);
                    // }

                    do
                    {
                        needheal = HealthCheck();
                        life1 = Life1();
                        life2 = Life2();
                        life3 = Life3();
                        life4 = Life4();
                        life5 = Life5();
                        life6 = Life6();
                        life7 = Life7();
                        life8 = Life8();

                        if (label1.Text == "Off")
                        {
                            Thread.CurrentThread.Abort();
                        }

                        if (life4 <= 10)
                        {
                            Keys.PressKey(iHeal, true);
                        }
                        else if (life4 <= 50)
                        {
                            Keys.PressKey(lgHeal, true);
                        }
                        else if (life4 <= 90)
                        {
                            Keys.PressKey(smHeal, true);
                        }
                    }
                    while (life4 < 90);

                }

                if (needheal == 5) //member 5 is the lowest life
                {
                    //if (targetLife != life5)
                    //{
                    Keys.PressKey(member5, true);
                    Thread.Sleep(500);
                    Keys.PressKey(face, true);
                    Thread.Sleep(500);
                    //}

                    do
                    {
                        needheal = HealthCheck();
                        life1 = Life1();
                        life2 = Life2();
                        life3 = Life3();
                        life4 = Life4();
                        life5 = Life5();
                        life6 = Life6();
                        life7 = Life7();
                        life8 = Life8();

                        if (label1.Text == "Off")
                        {
                            Thread.CurrentThread.Abort();
                        }

                        if (life5 <= 10)
                        {
                            Keys.PressKey(iHeal, true);
                        }
                        else if (life5 <= 50)
                        {
                            Keys.PressKey(lgHeal, true);
                        }
                        else if (life5 <= 90)
                        {
                            Keys.PressKey(smHeal, true);
                        }
                    }
                    while (life5 < 90);

                }

                if (needheal == 6) //member 6 is the lowest life
                {
                    //if (targetLife != life6)
                    //{
                    Keys.PressKey(member6, true);
                    Thread.Sleep(500);
                    Keys.PressKey(face, true);
                    Thread.Sleep(500);
                    // }

                    do
                    {
                        needheal = HealthCheck();
                        life1 = Life1();
                        life2 = Life2();
                        life3 = Life3();
                        life4 = Life4();
                        life5 = Life5();
                        life6 = Life6();
                        life7 = Life7();
                        life8 = Life8();

                        if (label1.Text == "Off")
                        {
                            Thread.CurrentThread.Abort();
                        }

                        if (life6 <= 10)
                        {
                            Keys.PressKey(iHeal, true);
                        }
                        else if (life6 <= 50)
                        {
                            Keys.PressKey(lgHeal, true);
                        }
                        else if (life6 <= 90)
                        {
                            Keys.PressKey(smHeal, true);
                        }
                    }
                    while (life6 < 90);

                }

                if (needheal == 7) //member 7 is the lowest life
                {
                    if (targetLife != life7)
                    {
                        Keys.PressKey(member7, true);
                        Thread.Sleep(500);
                        Keys.PressKey(face, true);
                        Thread.Sleep(500);
                    }

                    do
                    {
                        needheal = HealthCheck();
                        life1 = Life1();
                        life2 = Life2();
                        life3 = Life3();
                        life4 = Life4();
                        life5 = Life5();
                        life6 = Life6();
                        life7 = Life7();
                        life8 = Life8();

                        if (label1.Text == "Off")
                        {
                            Thread.CurrentThread.Abort();
                        }

                        if (life7 <= 10)
                        {
                            Keys.PressKey(iHeal, true);
                        }
                        else if (life7 <= 50)
                        {
                            Keys.PressKey(lgHeal, true);
                        }
                        else if (life7 <= 90)
                        {
                            Keys.PressKey(smHeal, true);
                        }
                    }

                    while (life7 < 90);

                }

                if (needheal == 8) //member 8 is the lowest life
                {
                    if (targetLife != life8)
                    {
                        Keys.PressKey(member8, true);
                        Thread.Sleep(500);
                        Keys.PressKey(face, true);
                        Thread.Sleep(500);
                    }

                    do
                    {
                        needheal = HealthCheck();
                        life1 = Life1();
                        life2 = Life2();
                        life3 = Life3();
                        life4 = Life4();
                        life5 = Life5();
                        life6 = Life6();
                        life7 = Life7();
                        life8 = Life8();

                        if (label1.Text == "Off")
                        {
                            Thread.CurrentThread.Abort();
                        }

                        if (life8 <= 10)
                        {
                            Keys.PressKey(iHeal, true);
                        }
                        else if (life8 <= 50)
                        {
                            Keys.PressKey(lgHeal, true);
                        }
                        else if (life8 <= 90)
                        {
                            Keys.PressKey(smHeal, true);
                        }
                    }
                    while (life8 < 90);

                }

                if (needheal == 9)
                {
                    Keys.PressKey(sit, true); //Sit down
                    Thread.Sleep(2000);

                    do
                    {
                        needheal = HealthCheck();
                        life1 = Life1();
                        life2 = Life2();
                        life3 = Life3();
                        life4 = Life4();
                        life5 = Life5();
                        life6 = Life6();
                        life7 = Life7();
                        life8 = Life8();

                        if (needheal != 9)
                        {
                            Keys.PressKey(sit, true); //Stand up
                            Thread.Sleep(2000);
                        }

                        if (label1.Text == "Off")
                        {
                            Thread.CurrentThread.Abort();
                        }
                    }
                    while (needheal == 9);

                }

                
            }
        }

        public void XpBot()
        {
            oMemory.ReadProcess = processes[0]; //Sets the Process to Read/Write From/To 
            oMemory.Open(); //Open Process 

            life = LifeStat();
            stam = StamStat();
            bool On = true;

            //StatusUpdate();

            do
            {

                if (label7.Text == "Off")
                {
                    Thread.CurrentThread.Abort();
                }

                string newText = "XpBot Main"; // running on worker thread
                this.Invoke((MethodInvoker)delegate
                {
                    label13.Text = newText; // runs on UI thread
                });

                    Resting();
                    Buffing();
                    Pull();
                    MagicCombat();
                    MeleeCombat();
 

            }
            while (On == true);

        }

        public void Resting()
        {
            string newText = "Resting"; // running on worker thread
            this.Invoke((MethodInvoker)delegate
            {
                label13.Text = newText; // runs on UI thread
            });

            bool resting = true;

            Keys.PressKey('x', true); //Sit
            Thread.Sleep(1000);

            
            do
            {

                stam = StamStat();
                life = LifeStat();
                pow = PowStat();
                targetLife = EnemyLife();


                if (label7.Text == "Off")
                {
                    Thread.CurrentThread.Abort();
                }

                if (resting == true && targetLife >= 0 && targetLife <= 100)
                {
                    resting = false;
                }


                if (resting == true && life == 100 && stam == 100 && pow == 100)
                {
                    Keys.PressKey('x', true); //stand
                    Thread.Sleep(1000);
                    resting = false;
                }

            }
            while (resting == true);

        }

        public void Pull()
        {
            string newText = "Pulling"; // running on worker thread
            this.Invoke((MethodInvoker)delegate
            {
                label13.Text = newText; // runs on UI thread
            });

            bool pulling = true;

            targetLife = EnemyLife();

            Keys.PressKey(targetnearest, true);
            Thread.Sleep(1000);

            newText = "Targeted"; // running on worker thread
            this.Invoke((MethodInvoker)delegate
            {
                label13.Text = newText; // runs on UI thread
            });

            if (radioButton5.Checked)
            {
                do
                {

                    targetLife = EnemyLife();

                    if (label7.Text == "Off")
                    {
                        Thread.CurrentThread.Abort();
                    }

                    if (targetLife == 100)
                    {
                        Keys.PressKey(face, true);
                        Thread.Sleep(500);
                        Keys.PressKey(DD1, true);
                        Thread.Sleep(3000);
                        pulling = false;

                        newText = "Pulled?"; // running on worker thread
                        this.Invoke((MethodInvoker)delegate
                        {
                            label13.Text = newText; // runs on UI thread
                        });
                    }

                    if (targetLife != 100)
                    {
                        Keys.PressKey(targetnearest, true);
                        Thread.Sleep(2000);

                        newText = "Can't find a target";// running on worker thread
                        this.Invoke((MethodInvoker)delegate
                        {
                            label13.Text = newText; // runs on UI thread
                        });
                    }
                    else
                    {
                        newText = "Null Zone";// running on worker thread
                        this.Invoke((MethodInvoker)delegate
                        {
                            label13.Text = newText; // runs on UI thread
                        });
                    }

                }
                while (pulling == true);
            }
        }

        public void MagicCombat()
        {
            string newText = "Casting"; // running on worker thread
            this.Invoke((MethodInvoker)delegate
            {
                label13.Text = newText; // runs on UI thread
            });

            bool magiccombat = true;
            int precastLife = LifeStat();

            targetLife = EnemyLife();


            this.Invoke((MethodInvoker)delegate
            {
                label13.Text = newText; // runs on UI thread
            });

            if (radioButton5.Checked)
            {
                do
                {
                    int currentLife = LifeStat();
                    targetLife = EnemyLife();

                    if (label7.Text == "Off")
                    {
                        Thread.CurrentThread.Abort();
                    }

                    if (targetLife > 0 && currentLife >= precastLife)
                    {
                        Keys.PressKey(DD1, true);
                        Thread.Sleep(2500);
                    }
                    else
                    {
                        magiccombat = false;
                    }

                }
                while (magiccombat == true);

            }

        }

        public void MeleeCombat()
        {
            string newText = "Combat"; // running on worker thread
            this.Invoke((MethodInvoker)delegate
            {
                label13.Text = newText; // runs on UI thread
            });

            bool combat = true;

            Keys.PressKey(combatKey, true);

            if (radioButton5.Checked) //Runemaster
            {
                do
                {
                    stam = StamStat();
                    life = LifeStat();
                    targetLife = EnemyLife();

                    if (label7.Text == "Off")
                    {
                        Thread.CurrentThread.Abort();
                    }

                    if (targetLife >= 0 & targetLife <= 100)
                    {
                        Keys.PressKey(attack2, true);
                        Thread.Sleep(50);
                        Keys.PressKey(attack1, true);
                        Thread.Sleep(2500); //Wait between sends

                        newText = "Meleeing";// running on worker thread
                        this.Invoke((MethodInvoker)delegate
                        {
                            label13.Text = newText; // runs on UI thread
                        });
                    }

                    else
                    {
                        combat = false;
                    }
                }
                while (combat == true);
            }
        }

        public void Buffing()
        {

            if (label16.Text == "True")
            {

                StatusUpdate();

                string buffed = "False"; // running on worker thread
                this.Invoke((MethodInvoker)delegate
                {
                    label16.Text = buffed; // runs on UI thread
                });

                if (label7.Text == "Off")
                {
                    Thread.CurrentThread.Abort();
                }

                string newText = "Buffing"; // running on worker thread
                this.Invoke((MethodInvoker)delegate
                {
                    label13.Text = newText; // runs on UI thread
                });

                if (checkBox15.Checked)
                {
                    if (checkBox4.Checked)
                    {
                        Thread alt = new Thread(AltKey);
                        alt.Start();
                        Thread.Sleep(500);
                        Keys.PressKey(buff1, true);
                        Thread.Sleep(3000);
                    }

                    if (checkBox5.Checked)
                    {
                        Thread ctrl = new Thread(CtrlKey);
                        ctrl.Start();
                        Keys.PressKey(buff1, true);
                        Thread.Sleep(3000);
                    }

                }

                if (checkBox16.Checked)
                {
                    if (checkBox6.Checked)
                    {
                        Thread alt = new Thread(AltKey);
                        alt.Start();
                        Thread.Sleep(500);
                        Keys.PressKey(buff2, true);
                        Thread.Sleep(3000);
                    }

                    if (checkBox7.Checked)
                    {
                        Thread ctrl = new Thread(CtrlKey);
                        ctrl.Start();
                        Thread.Sleep(500);
                        Keys.PressKey(buff2, true);
                        Thread.Sleep(3000);
                    }
                }

                if (checkBox17.Checked)
                {
                    if (checkBox8.Checked)
                    {
                        Thread alt = new Thread(AltKey);
                        alt.Start();
                        Thread.Sleep(500);
                        Keys.PressKey(buff3, true);
                        Thread.Sleep(3000);
                    }

                    if (checkBox9.Checked)
                    {
                        Thread ctrl = new Thread(CtrlKey);
                        ctrl.Start();
                        Thread.Sleep(500);
                        Keys.PressKey(buff3, true);
                        Thread.Sleep(3000);
                    }

                    if (checkBox18.Checked)
                    {
                        if (checkBox10.Checked)
                        {
                            Thread alt = new Thread(AltKey);
                            alt.Start();
                            Thread.Sleep(500);
                            Keys.PressKey(buff4, true);
                            Thread.Sleep(3000);
                        }

                        if (checkBox11.Checked)
                        {
                            Thread ctrl = new Thread(CtrlKey);
                            ctrl.Start();
                            Thread.Sleep(500);
                            Keys.PressKey(buff4, true);
                            Thread.Sleep(3000);
                        }
                    }

                    if (checkBox19.Checked)
                    {
                        if (checkBox12.Checked)
                        {
                            Thread alt = new Thread(AltKey);
                            alt.Start();
                            Thread.Sleep(500);
                            Keys.PressKey(buff5, true);
                            Thread.Sleep(3000);
                        }

                        if (checkBox13.Checked)
                        {
                            Thread ctrl = new Thread(CtrlKey);
                            ctrl.Start();
                            Thread.Sleep(500);
                            Keys.PressKey(buff5, true);
                            Thread.Sleep(3000);
                        }
                    }



                }

            }
        }





        private void timer_Elapsed(object myobject, System.Timers.ElapsedEventArgs e)
        {
           // string newText = "True"; // running on worker thread
           // this.Invoke((MethodInvoker)delegate
           // {
           //     label13.Text = newText; // runs on UI thread
           // });


            Invoke(new Action(() => label16.Text = "True"));
        }

        private void button1_Click(object sender, EventArgs e) //Start Button
        {
            if (processes.Length != 0) //Checks to see if DAoC is running
            {
                label1.Text = "On";
                label1.ForeColor = System.Drawing.Color.Green;

                IntPtr WindowHandle = processes[0].MainWindowHandle;
                WindowsAPI.SwitchWindow(WindowHandle);
                Thread.Sleep(2000); //wait while window is switched

                Thread mainLoop = new Thread(HealBot);
                mainLoop.Start();
            }
            else
            {
                MessageBox.Show("Dark Age of Camelot is not running!");
            }

        }

        private void button2_Click(object sender, EventArgs e) //Stop Button
        {
            label1.Text = "Off";
            label1.ForeColor = System.Drawing.Color.Red;
         
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                Opacity = .50;
            }
            else
            {
                Opacity = 1.0;
            }


        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBox3.Checked;
        }

        private void button3_Click(object sender, EventArgs e) //HealBot Save
        {
            XmlWriter xmlWriter = XmlWriter.Create(PATH);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Config");

            xmlWriter.WriteStartElement("smHeal");
            xmlWriter.WriteString(textBox1.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("instantHeal");
            xmlWriter.WriteString(textBox2.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("lgHeal");
            xmlWriter.WriteString(textBox3.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("gpInstantHeal");
            xmlWriter.WriteString(textBox4.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("member1");
            xmlWriter.WriteString(textBox7.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("member2");
            xmlWriter.WriteString(textBox8.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("member3");
            xmlWriter.WriteString(textBox9.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("member4");
            xmlWriter.WriteString(textBox10.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("member5");
            xmlWriter.WriteString(textBox11.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("member6");
            xmlWriter.WriteString(textBox12.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("member7");
            xmlWriter.WriteString(textBox13.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("member8");
            xmlWriter.WriteString(textBox14.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("stick");
            xmlWriter.WriteString(textBox5.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("sit");
            xmlWriter.WriteString(textBox15.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("face");
            xmlWriter.WriteString(textBox6.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndDocument();

            xmlWriter.Close();
        }

        private void button4_Click(object sender, EventArgs e) //HealBot Load
        {
            doc = new XmlDocument();
            doc.Load(PATH);
            root = doc.DocumentElement;
            textBox1.Text = root.GetElementsByTagName("smHeal")[0].InnerText;
            textBox2.Text = root.GetElementsByTagName("instantHeal")[0].InnerText;
            textBox3.Text = root.GetElementsByTagName("lgHeal")[0].InnerText;
            textBox4.Text = root.GetElementsByTagName("lgHeal")[0].InnerText;

            textBox7.Text = root.GetElementsByTagName("member1")[0].InnerText;
            textBox8.Text = root.GetElementsByTagName("member2")[0].InnerText;
            textBox9.Text = root.GetElementsByTagName("member3")[0].InnerText;
            textBox10.Text = root.GetElementsByTagName("member4")[0].InnerText;
            textBox11.Text = root.GetElementsByTagName("member5")[0].InnerText;
            textBox12.Text = root.GetElementsByTagName("member6")[0].InnerText;
            textBox13.Text = root.GetElementsByTagName("member7")[0].InnerText;
            textBox14.Text = root.GetElementsByTagName("member8")[0].InnerText;

            textBox5.Text = root.GetElementsByTagName("stick")[0].InnerText;
            textBox15.Text = root.GetElementsByTagName("sit")[0].InnerText;
            textBox6.Text = root.GetElementsByTagName("face")[0].InnerText;
        }
//-----------------------------------XP BOT------------------------------------------//
//-----------------------------------------------------------------------------------//
        private void button5_Click(object sender, EventArgs e) //XP BOT
        {
            if (processes.Length != 0) //Checks to see if DAoC is running
            {
                label7.Text = "On";
                label7.ForeColor = System.Drawing.Color.Green;

                if (checkBox14.Checked)
                {
                    System.Timers.Timer needBuff = new System.Timers.Timer();

                    needBuff.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                    needBuff.Interval = 600000; //10 minutes

                    needBuff.Enabled = true;
                    needBuff.Start();

                }

                IntPtr WindowHandle = processes[0].MainWindowHandle;
                WindowsAPI.SwitchWindow(WindowHandle);
                Thread.Sleep(2000); //wait while window is switched

                Thread mainLoop = new Thread(XpBot);
                mainLoop.Start();
            }
            else
            {
                MessageBox.Show("Dark Age of Camelot is not running!");
            }

        }
        private void button6_Click(object sender, EventArgs e)
        {
            label7.Text = "Off";
            label7.ForeColor = System.Drawing.Color.Red;
        }

        //BUFF 1
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox5.Checked = false;
            }

        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox4.Checked = false;
            }

        }
        //BUFF 2
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox7.Checked = false;
            }

        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                checkBox6.Checked = false;
            }

        }
        //BUFF 3
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                checkBox9.Checked = false;
            }

        }
        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                checkBox8.Checked = false;
            }

        }
        //BUFF 4
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                checkBox11.Checked = false;
            }

        }
        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                checkBox10.Checked = false;
            }

        }
        //BUFF 5
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                checkBox13.Checked = false;
            }

        }
        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
                checkBox12.Checked = false;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)//Berserker
        {
            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton9.Checked = false;
                radioButton10.Checked = false;
                radioButton11.Checked = false;
                radioButton12.Checked = false;
                radioButton13.Checked = false;
                radioButton14.Checked = false;
                radioButton15.Checked = false;
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                radioButton25.Checked = false;
                radioButton26.Checked = false;
                radioButton27.Checked = false;
                radioButton28.Checked = false;
                radioButton29.Checked = false;
                radioButton30.Checked = false;
                radioButton31.Checked = false;
                radioButton32.Checked = false;
                radioButton33.Checked = false;
                radioButton34.Checked = false;
                radioButton35.Checked = false;
                radioButton36.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)//Bonedancer
        {
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton9.Checked = false;
                radioButton10.Checked = false;
                radioButton11.Checked = false;
                radioButton12.Checked = false;
                radioButton13.Checked = false;
                radioButton14.Checked = false;
                radioButton15.Checked = false;
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                radioButton25.Checked = false;
                radioButton26.Checked = false;
                radioButton27.Checked = false;
                radioButton28.Checked = false;
                radioButton29.Checked = false;
                radioButton30.Checked = false;
                radioButton31.Checked = false;
                radioButton32.Checked = false;
                radioButton33.Checked = false;
                radioButton34.Checked = false;
                radioButton35.Checked = false;
                radioButton36.Checked = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)//Healer
        {
            if (radioButton3.Checked)
            {
                radioButton2.Checked = false;
                radioButton1.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton9.Checked = false;
                radioButton10.Checked = false;
                radioButton11.Checked = false;
                radioButton12.Checked = false;
                radioButton13.Checked = false;
                radioButton14.Checked = false;
                radioButton15.Checked = false;
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                radioButton25.Checked = false;
                radioButton26.Checked = false;
                radioButton27.Checked = false;
                radioButton28.Checked = false;
                radioButton29.Checked = false;
                radioButton30.Checked = false;
                radioButton31.Checked = false;
                radioButton32.Checked = false;
                radioButton33.Checked = false;
                radioButton34.Checked = false;
                radioButton35.Checked = false;
                radioButton36.Checked = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)//Hunter
        {
            if (radioButton4.Checked)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton1.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton9.Checked = false;
                radioButton10.Checked = false;
                radioButton11.Checked = false;
                radioButton12.Checked = false;
                radioButton13.Checked = false;
                radioButton14.Checked = false;
                radioButton15.Checked = false;
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                radioButton25.Checked = false;
                radioButton26.Checked = false;
                radioButton27.Checked = false;
                radioButton28.Checked = false;
                radioButton29.Checked = false;
                radioButton30.Checked = false;
                radioButton31.Checked = false;
                radioButton32.Checked = false;
                radioButton33.Checked = false;
                radioButton34.Checked = false;
                radioButton35.Checked = false;
                radioButton36.Checked = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)//Runemaster
        {
            if (radioButton5.Checked)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton1.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton9.Checked = false;
                radioButton10.Checked = false;
                radioButton11.Checked = false;
                radioButton12.Checked = false;
                radioButton13.Checked = false;
                radioButton14.Checked = false;
                radioButton15.Checked = false;
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                radioButton25.Checked = false;
                radioButton26.Checked = false;
                radioButton27.Checked = false;
                radioButton28.Checked = false;
                radioButton29.Checked = false;
                radioButton30.Checked = false;
                radioButton31.Checked = false;
                radioButton32.Checked = false;
                radioButton33.Checked = false;
                radioButton34.Checked = false;
                radioButton35.Checked = false;
                radioButton36.Checked = false;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)//Savage
        {
            if (radioButton6.Checked)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton1.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton9.Checked = false;
                radioButton10.Checked = false;
                radioButton11.Checked = false;
                radioButton12.Checked = false;
                radioButton13.Checked = false;
                radioButton14.Checked = false;
                radioButton15.Checked = false;
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                radioButton25.Checked = false;
                radioButton26.Checked = false;
                radioButton27.Checked = false;
                radioButton28.Checked = false;
                radioButton29.Checked = false;
                radioButton30.Checked = false;
                radioButton31.Checked = false;
                radioButton32.Checked = false;
                radioButton33.Checked = false;
                radioButton34.Checked = false;
                radioButton35.Checked = false;
                radioButton36.Checked = false;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)//Shadowblade  /Vale Walker Temporary
        {

            className = "Valewalker";
             
            if (radioButton7.Checked)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton1.Checked = false;
                radioButton8.Checked = false;
                radioButton9.Checked = false;
                radioButton10.Checked = false;
                radioButton11.Checked = false;
                radioButton12.Checked = false;
                radioButton13.Checked = false;
                radioButton14.Checked = false;
                radioButton15.Checked = false;
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                radioButton25.Checked = false;
                radioButton26.Checked = false;
                radioButton27.Checked = false;
                radioButton28.Checked = false;
                radioButton29.Checked = false;
                radioButton30.Checked = false;
                radioButton31.Checked = false;
                radioButton32.Checked = false;
                radioButton33.Checked = false;
                radioButton34.Checked = false;
                radioButton35.Checked = false;
                radioButton36.Checked = false;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)//Shaman
        {
            if (radioButton8.Checked)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton1.Checked = false;
                radioButton9.Checked = false;
                radioButton10.Checked = false;
                radioButton11.Checked = false;
                radioButton12.Checked = false;
                radioButton13.Checked = false;
                radioButton14.Checked = false;
                radioButton15.Checked = false;
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                radioButton25.Checked = false;
                radioButton26.Checked = false;
                radioButton27.Checked = false;
                radioButton28.Checked = false;
                radioButton29.Checked = false;
                radioButton30.Checked = false;
                radioButton31.Checked = false;
                radioButton32.Checked = false;
                radioButton33.Checked = false;
                radioButton34.Checked = false;
                radioButton35.Checked = false;
                radioButton36.Checked = false;
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)//Skald
        {
            if (radioButton9.Checked)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton1.Checked = false;
                radioButton10.Checked = false;
                radioButton11.Checked = false;
                radioButton12.Checked = false;
                radioButton13.Checked = false;
                radioButton14.Checked = false;
                radioButton15.Checked = false;
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                radioButton25.Checked = false;
                radioButton26.Checked = false;
                radioButton27.Checked = false;
                radioButton28.Checked = false;
                radioButton29.Checked = false;
                radioButton30.Checked = false;
                radioButton31.Checked = false;
                radioButton32.Checked = false;
                radioButton33.Checked = false;
                radioButton34.Checked = false;
                radioButton35.Checked = false;
                radioButton36.Checked = false;
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)//Spiritmaster
        {
            if (radioButton10.Checked)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton9.Checked = false;
                radioButton1.Checked = false;
                radioButton11.Checked = false;
                radioButton12.Checked = false;
                radioButton13.Checked = false;
                radioButton14.Checked = false;
                radioButton15.Checked = false;
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                radioButton25.Checked = false;
                radioButton26.Checked = false;
                radioButton27.Checked = false;
                radioButton28.Checked = false;
                radioButton29.Checked = false;
                radioButton30.Checked = false;
                radioButton31.Checked = false;
                radioButton32.Checked = false;
                radioButton33.Checked = false;
                radioButton34.Checked = false;
                radioButton35.Checked = false;
                radioButton36.Checked = false;
            }
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)//Thane
        {
            if (radioButton11.Checked)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton9.Checked = false;
                radioButton10.Checked = false;
                radioButton1.Checked = false;
                radioButton12.Checked = false;
                radioButton13.Checked = false;
                radioButton14.Checked = false;
                radioButton15.Checked = false;
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                radioButton25.Checked = false;
                radioButton26.Checked = false;
                radioButton27.Checked = false;
                radioButton28.Checked = false;
                radioButton29.Checked = false;
                radioButton30.Checked = false;
                radioButton31.Checked = false;
                radioButton32.Checked = false;
                radioButton33.Checked = false;
                radioButton34.Checked = false;
                radioButton35.Checked = false;
                radioButton36.Checked = false;
            }
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)//Warrior
        {
            if (radioButton12.Checked)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton9.Checked = false;
                radioButton10.Checked = false;
                radioButton11.Checked = false;
                radioButton1.Checked = false;
                radioButton13.Checked = false;
                radioButton14.Checked = false;
                radioButton15.Checked = false;
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                radioButton25.Checked = false;
                radioButton26.Checked = false;
                radioButton27.Checked = false;
                radioButton28.Checked = false;
                radioButton29.Checked = false;
                radioButton30.Checked = false;
                radioButton31.Checked = false;
                radioButton32.Checked = false;
                radioButton33.Checked = false;
                radioButton34.Checked = false;
                radioButton35.Checked = false;
                radioButton36.Checked = false;
            }
        }





    }

}

