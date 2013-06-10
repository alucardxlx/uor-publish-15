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
        int LifeAddr = Addr.ToDec("0145CDF8");       //4byte
        int StamAddr = Addr.ToDec("0145CE00");       //4byte
        int EnemyLifeAddr = Addr.ToDec("0145CE0C");  //4byte
        int XCoOrdAddr = Addr.ToDec("00980520");     //float
        int YcoOrdAddr = Addr.ToDec("00980524");     //float

        //Party Adresses

        int life1Addr = Addr.ToDec("00A04538");     //4byte
        int life2Addr = Addr.ToDec("00A05514");     //4byte
        int life3Addr = Addr.ToDec("0145CDF8");     //4byte
        int life4Addr = Addr.ToDec("0145CDF8");     //4byte
        int life5Addr = Addr.ToDec("0145CDF8");     //4byte
        int life6Addr = Addr.ToDec("0145CDF8");     //4byte
        int life7Addr = Addr.ToDec("0145CDF8");     //4byte
        int life8Addr = Addr.ToDec("0145CDF8");     //4byte


        int stam;
        int life;
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

            //return life3Value;
            return 100;

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
            if (life3 < life1 && life3 < life2 && life3 < life4 && life3 < life5 && life3 < life6 && life3 < life7 && life3 < life8)
          {
              int check = 3;
              return check;
          }
            if (life4 < life1 && life4 < life2 && life4 < life3 && life4 < life5 && life4 < life6 && life4 < life7 && life4 < life8)
          {
              int check = 4;
              return check;
          }
            if (life5 < life1 && life5 < life2 && life5 < life3 && life5 < life4 && life5 < life6 && life5 < life7 && life5 < life8)
          {
              int check = 5;
              return check;
          }
            if (life6 < life1 && life6 < life2 && life6 < life3 && life6 < life4 && life6 < life5 && life6 < life7 && life6 < life8)
          {
              int check = 6;
              return check;
          }
            if (life7 < life1 && life7 < life2 && life7 < life3 && life7 < life4 && life7 < life5 && life7 < life6 && life7 < life8)
          {
              int check = 7;
              return check;
          }
            if (life8 < life1 && life8 < life2 && life8 < life3 && life8 < life4 && life8 < life5 && life8 < life6 && life8 < life7)
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



        public void MainLoop()
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

                            newText = "Instant Healing Party Member 1"; // running on worker thread
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

                            newText = "Large Healing Party Member 2"; // running on worker thread
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

                            newText = "Small Healing Party Member 2"; // running on worker thread
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


                             newText = "Instant Healing Party Member 2"; // running on worker thread
                            this.Invoke((MethodInvoker)delegate
                            {
                                label5.Text = newText; // runs on UI thread
                            });
                        }
                        else if (life2 <= 50)
                        {
                            Keys.PressKey(lgHeal, true);
                            Thread.Sleep(3000);

                            newText = "Large Healing Party Member 2"; // running on worker thread
                            this.Invoke((MethodInvoker)delegate
                            {
                                label5.Text = newText; // runs on UI thread
                            });
                        }
                        else if (life2 <= 80)
                        {
                            Keys.PressKey(smHeal, true);
                            Thread.Sleep(3000);

                            newText = "Small Healing Party Member 2"; // running on worker thread
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
                            Keys.PressKey(iHeal, true);
                        }
                        else if (life3 <= 50)
                        {
                            Keys.PressKey(lgHeal, true);
                        }
                        else if (life3 <= 80)
                        {
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

                        if (label1.Text == "Off")
                        {
                            Thread.CurrentThread.Abort();
                        }
                    }
                    while (needheal == 9);

                }
                else
                {
                    Keys.PressKey(sit, true);//Stand Up
                    Thread.Sleep(1000);
                }

                

            }
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

                Thread mainLoop = new Thread(MainLoop);
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

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
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







/*
        public void Resting()
        {

            while (resting == true)
            {
                stam = StamStat();
                life = LifeStat();
                enemyLife = EnemyLife();

                if (resting == true && enemyLife >= 0 && enemyLife <= 100)
                {
                    resting = false;
                    restingLoop = false;
                    return;
                }

                if (On == false)
                {
                    resting = false;
                    restingLoop = false;
                    return;
                }

                if (restingLoop == false && life < 100 | stam < 100)
                {
                    Keys.PressKey('x', true); //sit
                    resting = true;
                    restingLoop = true;
                    combat = false;
                    //Thread.Sleep(1000);
                }


                else if (restingLoop == true && life == 100 & stam == 100)
                {
                    Keys.PressKey('x', true); //stand
                    resting = false;
                    restingLoop = false;
                    //Thread.Sleep(1000);
                    return;

                }


            }

        }


        public void Pull()
        {
            if (healer == true)
            {
                pulling = true;
                while (pulling == true)
                {
                    Keys.PressKey(nearesttarget, true);
                    Thread.Sleep(1000);

                    enemyLife = EnemyLife();
                    if (enemyLife == 100)
                    {
                        Keys.PressKey(face, true);
                        Thread.Sleep(500);
                        Keys.PressKey(pull, true);
                        Thread.Sleep(2000);
                        pulling = false;
                    }
                }
            }

            else if (shaman == true)
            {
                pulling = true;

                while (pulling == true)
                {
                    Keys.PressKey(nearesttarget, true);
                    Thread.Sleep(1000);

                    enemyLife = EnemyLife();

                    if (enemyLife == 100)
                    {
                        Keys.PressKey(face, true);
                        Thread.Sleep(500);
                        Keys.PressKey(pull, true);
                        Thread.Sleep(1000);
                        Keys.PressKey(DD1, true);
                        Thread.Sleep(7000);
                        pulling = false;
                    }

                }
            }
        }

        public void Healer()
        {
            while (combat == true)
            {
                stam = StamStat();
                life = LifeStat();
                enemyLife = EnemyLife();

                if (On == false)
                {
                    inCombat = false;
                    combat = false;
                    return;
                }

                else if (inCombat == true && enemyLife >= 0 & enemyLife <= 100)
                {
                    Thread.Sleep(2000);
                }

                else if (enemyLife >= 0 && enemyLife <= 100 && inCombat == false)
                {
                    combat = true;
                    resting = false;
                    inCombat = true;
                    Keys.PressKey('`', true);
                    Thread.Sleep(1000);
                }


                else
                {
                    inCombat = false;
                    combat = false;
                    return;
                }
            }

        }

        public void Shaman()
        {
            while (combat == true)
            {
                stam = StamStat();
                life = LifeStat();
                enemyLife = EnemyLife();

                if (On == false)
                {
                    inCombat = false;
                    combat = false;
                    return;
                }

                else if (inCombat == true && enemyLife >= 0 & enemyLife <= 100)
                {
                    Thread.Sleep(2000);
                }

                else if (enemyLife >= 0 && enemyLife <= 100 && inCombat == false)
                {
                    combat = true;
                    resting = false;
                    inCombat = true;
                    Keys.PressKey('`', true);
                    Thread.Sleep(1000);
                }


                else
                {
                    inCombat = false;
                    combat = false;
                    return;
                }
            }

        }



        public void Combat()
        {
            while (combat == true)
            {
                stam = StamStat();
                life = LifeStat();
                enemyLife = EnemyLife();


                if (enemyLife >= 0 & enemyLife <= 100)
                {
                    combat = true;
                    resting = false;
                    Keys.PressKey(attack2, true);
                    Thread.Sleep(50);
                    Keys.PressKey(attack1, true);
                    Thread.Sleep(2500); //Wait between sends
                }
                if (On == false)
                {
                    combat = false;
                    return;
                }

                else
                {
                    combat = false;
                    return;
                }
            }

        }


        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.label4.InvokeRequired && text == ("Resting") | text == ("Waiting"))
            {
                label4.ForeColor = System.Drawing.Color.Green;
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }

            else if (this.label4.InvokeRequired && text == ("In Combat"))
            {
                label4.ForeColor = System.Drawing.Color.Red;
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }

            else
            {
                this.label4.Text = text;
            }
        }




        private void StatusUpdate()
        {
            string attackKey1 = textBox1.Text;
            attack1 = attackKey1[0];

            string attackKey2 = textBox3.Text;
            attack2 = attackKey2[0];

            string stickKey = textBox2.Text;
            stick = stickKey[0];

            string pullKey = textBox4.Text;
            pull = pullKey[0];

            string nearestTarget = textBox5.Text;
            nearesttarget = nearestTarget[0];

            string faceKey = textBox6.Text;
            face = faceKey[0];

            string DD1Key = textBox7.Text;
            DD1 = DD1Key[0];



            if (combat == true)
                this.SetText("In Combat");
            if (resting == true)
                this.SetText("Resting");
            if (combat == false & resting == false)
                this.SetText("Waiting");
        }

        public void MainLoop()
        {
            while (On == true)
            {
                oMemory.ReadProcess = processes[0]; //Sets the Process to Read/Write From/To 
                oMemory.Open(); //Open Process 

                stam = StamStat();
                life = LifeStat();
                enemyLife = EnemyLife();

                Thread s = new Thread(new ThreadStart(StatusUpdate));
                s.Start();



                if (enemyLife >= 0 & enemyLife <= 100 && combat == false)
                {
                    if (healer == true)
                    {
                        combat = true;
                        Thread c = new Thread(new ThreadStart(Healer));
                        c.Start();
                    }

                    else if (shaman == true)
                    {
                        combat = true;
                        Thread c = new Thread(new ThreadStart(Shaman));
                        c.Start();
                    }
                    else if (hunter == true)
                    {
                        combat = true;
                        Thread c = new Thread(new ThreadStart(Combat));
                        c.Start();
                    }
                    else if (shadowblade == true)
                    {
                        combat = true;
                        Thread c = new Thread(new ThreadStart(Combat));
                        c.Start();
                    }

                    else if (skald == true)
                    {
                        combat = true;
                        Thread c = new Thread(new ThreadStart(Combat));
                        c.Start();
                    }


                    else if (berserker == true)
                    {
                        combat = true;
                        Thread c = new Thread(new ThreadStart(Combat));
                        c.Start();
                    }

                    else if (savage == true)
                    {
                        combat = true;
                        Thread c = new Thread(new ThreadStart(Combat));
                        c.Start();
                    }

                    else if (spiritmaster == true)
                    {
                        combat = true;
                        Thread c = new Thread(new ThreadStart(Combat));
                        c.Start();
                    }

                    else if (runemaster == true)
                    {
                        combat = true;
                        Thread c = new Thread(new ThreadStart(Combat));
                        c.Start();
                    }

                    else if (bonedancer == true)
                    {
                        combat = true;
                        Thread c = new Thread(new ThreadStart(Combat));
                        c.Start();
                    }

                    else if (thane == true)
                    {
                        combat = true;
                        Thread c = new Thread(new ThreadStart(Combat));
                        c.Start();
                    }

                    else if (warrior == true)
                    {
                        combat = true;
                        Thread c = new Thread(new ThreadStart(Combat));
                        c.Start();
                    }

                    //combat = true;
                    //Thread c = new Thread(new ThreadStart(Combat));
                    //c.Start();
                    //Combat();
                }
                else if (life < 80 | stam < 100 & enemyLife < 0 && combat == false)
                {
                    resting = true;
                    Thread r = new Thread(new ThreadStart(Resting));
                    r.Start();
                    //Resting();
                }

                else if (combat == false & resting == false & enemyLife < 0)
                {
                    Pull();
                }

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {


            if (processes.Length != 0)
            {

                IntPtr WindowHandle = processes[0].MainWindowHandle;
                WindowsAPI.SwitchWindow(WindowHandle);
                Thread.Sleep(2000); //wait while window is switched


                if (On == false)
                {
                    On = true;
                    Thread Main = new Thread(new ThreadStart(MainLoop));
                    Main.Start();
                    label5.Text = ("On");
                    label5.ForeColor = System.Drawing.Color.Green;

                }


                else
                {
                    On = false;
                    combat = false;
                    resting = false;
                    label5.Text = ("Off");
                    label5.ForeColor = System.Drawing.Color.Red;

                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {

            if (processes.Length != 0) //If the process exists 
            {
                IntPtr WindowHandle = processes[0].MainWindowHandle;
                WindowsAPI.SwitchWindow(WindowHandle);
                //Thread.Sleep(1000); //wait while window is switched


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

 /*                       if (panicPercent >= life)
                        {
                            Keys.PressKey('1', true);
                            //Thread.Sleep(2000);
                        }
                        //Thread.Sleep(1000);
                    }

                    while (healthcheckloop == true);

                }
                oMemory.CloseHandle(); //Close Memory Handle 
            }
        }

*/

    }

}

