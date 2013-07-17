using System;
using Server.Network;
using Server;

namespace Server.Misc
{
	public class FoodDecayTimer : Timer
	{
		public static void Initialize()
		{
			new FoodDecayTimer().Start();
		}

		public FoodDecayTimer() : base( TimeSpan.FromMinutes( 5 ), TimeSpan.FromMinutes( 5 ) )
		{
			Priority = TimerPriority.OneMinute;
		}

		protected override void OnTick()
		{
			FoodDecay();			
		}

		public static void FoodDecay()
		{
			foreach ( NetState state in NetState.Instances )
			{
				HungerDecay( state.Mobile );
				ThirstDecay( state.Mobile );
			}
		}

		public static void HungerDecay( Mobile m )
		{
			if ( m != null && m.Hunger >= 1 )
				m.Hunger -= 1;

            if (m != null && m.Hunger <= 5)
            {
                m.SendMessage("You are extremely hungry.");
            }
            else if (m != null && m.Hunger <= 10)
            {
                    m.SendMessage("You are hungry.");
            }
            else  if (m != null && m.Hunger <= 15)
            {
                    m.SendMessage("You begin to feel the effects of hunger.");
            }

            if (m != null && m.Hunger == 0)
            {
                m.SendMessage("You are dying of hunger.");
                m.Hits -= 25;
                m.Mana -= 10;
                m.Stam -= 10;
            }
		}

		public static void ThirstDecay( Mobile m )
		{
			if ( m != null && m.Thirst >= 1 )
				m.Thirst -= 1;

            if (m != null && m.Thirst <= 5)
            {
                m.SendMessage("You are extremely thirsty.");
            }
            else if (m != null && m.Thirst <= 10)
            {
                m.SendMessage("You are thirsty.");
            }
            else if (m != null && m.Thirst <= 15)
            {
                m.SendMessage("You begin to feel the effects of thirst.");
            }

            if (m != null && m.Thirst == 0)
            {
                m.SendMessage("You are dying of thirst.");
                m.Hits -= 25;
                m.Mana -= 10;
                m.Stam -= 10;

            }


		}
	}
}