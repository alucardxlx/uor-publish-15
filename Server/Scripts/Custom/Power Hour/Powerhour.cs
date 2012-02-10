using System;
using Server;
using System.Collections;
using Server.Mobiles;
using Server.Items;
namespace Server.Mobiles
{
    public class PowerHourClass
    {
        public static void Initialize()
        {
            //register event handler
            EventSink.Speech += new SpeechEventHandler(EventSink_PowerHour);
        }
        public static void EventSink_PowerHour(SpeechEventArgs e)
        {
            Mobile from = e.Mobile;
            if ((e.Speech == "power hour") || (e.Speech == "powerhour"))
            {
                TimeSpan timeleft = (((PlayerMobile)from).m_PowerHourExpiration) - DateTime.Now;
                TimeSpan timenext = (((PlayerMobile)from).m_NextPowerHour) - DateTime.Now;
                if (from is PlayerMobile)
                {
                    PlayerMobile pm = (PlayerMobile)from;
                    if (pm.PowerHourExpiration > TimeSpan.Zero)
                    {

                        if (timeleft < TimeSpan.Zero)
                            timeleft = TimeSpan.Zero;

                        from.SendMessage( 0x35, "You have {0} minutes of powerhour left.", timeleft.Minutes);
                    }

                    else if (pm.NextPowerHour > TimeSpan.Zero)
                    {
                        if (timenext > TimeSpan.FromHours(2.0))
                        {
                            from.SendMessage(0x35, "Your next powerhour will be available in {0} hours.", timenext.Hours);
                        }
                        else if (timenext <= TimeSpan.FromHours(2.0) && timenext >= TimeSpan.FromHours(1.0))
                        {
                            from.SendMessage(0x35, "Your next powerhour will available in {0} hour.", timenext.Hours);
                        }
                        else
                        {
                            from.SendMessage(0x35, "Your next powerhour will available in {0} minutes.", timenext.Minutes);
                        }
                    }
                    else if (pm.NextPowerHour == TimeSpan.Zero)
                    {
                        Timer t = new WaitPowerHourTimer(pm);
                        t.Start();
                        pm.m_NextPowerHour = DateTime.Now +TimeSpan.FromHours(24.0);
                        pm.InPowerHour = true;
                        pm.SendMessage(0x35, "Your powerhour will begin soon.");
                    }
                    else
                        from.SendMessage(0x35, "An error occured. Please contact a gamemaster if you encounter this error.");
                }
            }
        }
        public class WaitPowerHourTimer : Timer
        {
            private PlayerMobile pm;
            public WaitPowerHourTimer(PlayerMobile from)
                : base(TimeSpan.FromSeconds(10.0))
            {
                pm = from;
            }
            protected override void OnTick()
            {
                pm.m_PowerHourExpiration = DateTime.Now + TimeSpan.FromMinutes(60.0);
                pm.SendMessage(0x35, "Your powerhour has started.");
                Timer ti = new PowerHourTimer(pm);
                ti.Start();
            }
        }
        public class PowerHourTimer : Timer
        {
            private PlayerMobile pm;
            public PowerHourTimer(PlayerMobile from)
                : base(TimeSpan.FromMinutes(60.0))
            {
                pm = from;
            }
            protected override void OnTick()
            {

                pm.InPowerHour = false;
                pm.SendMessage(0x35, "Your powerhour has ended.");

            }
        }
    }
}