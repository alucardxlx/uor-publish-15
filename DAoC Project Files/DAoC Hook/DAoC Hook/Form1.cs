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



        int LifeAddr = Addr.ToDec("0145CDF8");       //4byte
        int StamAddr = Addr.ToDec("0145CE00");       //4byte
        int EnemyLifeAddr = Addr.ToDec("0145CE0C");  //4byte
        int XCoOrdAddr = Addr.ToDec("00980520");     //float
        int YcoOrdAddr = Addr.ToDec("00980524");     //float
        int stam;
        int life;
        int enemyLife;



        char attack1;
        char attack2;
        char stick;
        char pull;
        char nearesttarget;
        char face;
        char DD1;

        bool pulling = false;
        bool inCombat = false;
        bool combat = false;
        bool healthcheckloop = false;
        bool On = false;
        bool resting = false;
        bool restingLoop = false;
        bool healer = false;
        bool shaman = false;
        bool hunter = false;
        bool shadowblade = false;
        bool skald = false;
        bool berserker = false;
        bool savage = false;
        bool spiritmaster = false;
        bool runemaster = false;
        bool bonedancer = false;
        bool thane = false;
        bool warrior = false;


        delegate void SetTextCallback(string text);






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

        public void Resting()
        {
           
            while(resting == true)
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

                if (restingLoop == false && life < 100 | stam < 100 )
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
            while(combat == true)
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
            while(On == true)
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

                        if (panicPercent >= life)
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //healer
        {
            if (radioButton1.Checked == true)
            {

                healer = true;
                shaman = false;
                hunter = false;
                shadowblade = false;
                skald = false;
                berserker = false;
                savage = false;
                spiritmaster = false;
                runemaster = false;
                bonedancer = false;
                thane = false;
                warrior = false;

                //string hmessage = healer.ToString();
                //string smessage = shaman.ToString();
                //MessageBox.Show(smessage, hmessage);
            }


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) //shaman
        {
            if (radioButton2.Checked == true)
            {
                healer = false;
                shaman = true;
                hunter = false;
                shadowblade = false;
                skald = false;
                berserker = false;
                savage = false;
                spiritmaster = false;
                runemaster = false;
                bonedancer = false;
                thane = false;
                warrior = false;

                //string hmessage = healer.ToString();
                //string smessage = shaman.ToString();
                //MessageBox.Show(smessage, hmessage);
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) //hunter
        {
            if (radioButton3.Checked == true)
            {
                healer = false;
                shaman = false;
                hunter = true;
                shadowblade = false;
                skald = false;
                berserker = false;
                savage = false;
                spiritmaster = false;
                runemaster = false;
                bonedancer = false;
                thane = false;
                warrior = false;
            }

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e) //shadowblade
        {
            if (radioButton4.Checked == true)
            {
                healer = false;
                shaman = false;
                hunter = false;
                shadowblade = true;
                skald = false;
                berserker = false;
                savage = false;
                spiritmaster = false;
                runemaster = false;
                bonedancer = false;
                thane = false;
                warrior = false;
            }

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e) //skald
        {
            if (radioButton5.Checked == true)
            {
                healer = false;
                shaman = false;
                hunter = false;
                shadowblade = false;
                skald = true;
                berserker = false;
                savage = false;
                spiritmaster = false;
                runemaster = false;
                bonedancer = false;
                thane = false;
                warrior = false;
            }

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e) //berserker
        {
            if (radioButton6.Checked == true)
            {
                healer = false;
                shaman = false;
                hunter = false;
                shadowblade = false;
                skald = false;
                berserker = true;
                savage = false;
                spiritmaster = false;
                runemaster = false;
                bonedancer = false;
                thane = false;
                warrior = false;
            }

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e) //savage
        {
            if (radioButton7.Checked == true)
            {
                healer = false;
                shaman = false;
                hunter = false;
                shadowblade = false;
                skald = false;
                berserker = false;
                savage = true;
                spiritmaster = false;
                runemaster = false;
                bonedancer = false;
                thane = false;
                warrior = false;
            }

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e) // spiritmaster
        {
            if (radioButton8.Checked == true)
            {
                healer = false;
                shaman = false;
                hunter = false;
                shadowblade = false;
                skald = false;
                berserker = false;
                savage = false;
                spiritmaster = true;
                runemaster = false;
                bonedancer = false;
                thane = false;
                warrior = false;
            }

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e) //runemaster
        {
            if (radioButton9.Checked == true)
            {
                healer = false;
                shaman = false;
                hunter = false;
                shadowblade = false;
                skald = false;
                berserker = false;
                savage = false;
                spiritmaster = false;
                runemaster = true;
                bonedancer = false;
                thane = false;
                warrior = false;
            }

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e) //bonedancer
        {
            if (radioButton10.Checked == true)
            {
                healer = false;
                shaman = false;
                hunter = false;
                shadowblade = false;
                skald = false;
                berserker = false;
                savage = false;
                spiritmaster = false;
                runemaster = false;
                bonedancer = true;
                thane = false;
                warrior = false;
            }

        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e) //thane
        {
            if (radioButton11.Checked == true)
            {
                healer = false;
                shaman = false;
                hunter = false;
                shadowblade = false;
                skald = false;
                berserker = false;
                savage = false;
                spiritmaster = false;
                runemaster = false;
                bonedancer = false;
                thane = true;
                warrior = false;
            }

        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e) //warrior
        {
            if (radioButton12.Checked == true)
            {
                healer = false;
                shaman = false;
                hunter = false;
                shadowblade = false;
                skald = false;
                berserker = false;
                savage = false;
                spiritmaster = false;
                runemaster = false;
                bonedancer = false;
                thane = false;
                warrior = true;
            }

        }




    }

}

