using System;
using Server;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
	public class PowerHourTicket : Item
	{

		[Constructable]
        public PowerHourTicket(): base(0x14EF)
		{
            Name = "a powerhour ticket";
			Hue = 2101;
			Weight = 1.0;
			Stackable = false;
		}

		public PowerHourTicket( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{

					if ( from is PlayerMobile  && ((PlayerMobile)from).InPowerHour == true)
                    {
                        from.SendMessage(0x35, "You are in powerhour and cannot reset your timer right now.");

                    }
                    else if (from is PlayerMobile && (((PlayerMobile)from).m_NextPowerHour < (DateTime.Now) ))
                    {
                        from.SendMessage(0x35, "You already have a powerhour available to you.");
                    }
                        else
                        {

                        ((PlayerMobile)from).m_PowerHourExpiration = (DateTime.Now);
                        ((PlayerMobile)from).m_NextPowerHour = (DateTime.Now);

                        from.SendMessage(0x35, "You have a powerhour available now.");

                        Effects.SendLocationParticles(EffectItem.Create(from.Location, from.Map, EffectItem.DefaultDuration), 0, 0, 0, 0, 0, 5060, 0);
                        Effects.PlaySound(from.Location, from.Map, 0x243);

                        Effects.SendMovingParticles(new Entity(Serial.Zero, new Point3D(from.X - 6, from.Y - 6, from.Z + 15), from.Map), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100);
                        Effects.SendMovingParticles(new Entity(Serial.Zero, new Point3D(from.X - 4, from.Y - 6, from.Z + 15), from.Map), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100);
                        Effects.SendMovingParticles(new Entity(Serial.Zero, new Point3D(from.X - 6, from.Y - 4, from.Z + 15), from.Map), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100);

                        Effects.SendTargetParticles(from, 0x375A, 35, 90, 0x00, 0x00, 9502, (EffectLayer)255, 0x100);

                        Delete();


                        }
                    
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}