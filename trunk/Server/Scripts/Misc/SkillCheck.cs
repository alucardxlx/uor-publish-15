using System;
using Server;
using Server.Mobiles;
using Server.Factions;

namespace Server.Misc
{
	public class SkillCheck
	{
		private static readonly bool AntiMacroCode = false;		//Change this to false to disable anti-macro code

		public static TimeSpan AntiMacroExpire = TimeSpan.FromMinutes( 5.0 ); //How long do we remember targets/locations?
		public const int Allowance = 3;	//How many times may we use the same location/target for gain
		private const int LocationSize = 5; //The size of eeach location, make this smaller so players dont have to move as far
		private static bool[] UseAntiMacro = new bool[]
		{
			// true if this skill uses the anti-macro code, false if it does not
			false,// Alchemy = 0,
			true,// Anatomy = 1,
			true,// AnimalLore = 2,
			true,// ItemID = 3,
			true,// ArmsLore = 4,
			false,// Parry = 5,
			true,// Begging = 6,
			false,// Blacksmith = 7,
			false,// Fletching = 8,
			true,// Peacemaking = 9,
			true,// Camping = 10,
			false,// Carpentry = 11,
			false,// Cartography = 12,
			false,// Cooking = 13,
			true,// DetectHidden = 14,
			true,// Discordance = 15,
			true,// EvalInt = 16,
			true,// Healing = 17,
			true,// Fishing = 18,
			true,// Forensics = 19,
			true,// Herding = 20,
			true,// Hiding = 21,
			true,// Provocation = 22,
			false,// Inscribe = 23,
			true,// Lockpicking = 24,
			true,// Magery = 25,
			true,// MagicResist = 26,
			false,// Tactics = 27,
			true,// Snooping = 28,
			true,// Musicianship = 29,
			true,// Poisoning = 30,
			false,// Archery = 31,
			true,// SpiritSpeak = 32,
			true,// Stealing = 33,
			false,// Tailoring = 34,
			true,// AnimalTaming = 35,
			true,// TasteID = 36,
			false,// Tinkering = 37,
			true,// Tracking = 38,
			true,// Veterinary = 39,
			false,// Swords = 40,
			false,// Macing = 41,
			false,// Fencing = 42,
			false,// Wrestling = 43,
			true,// Lumberjacking = 44,
			true,// Mining = 45,
			true,// Meditation = 46,
			true,// Stealth = 47,
			true,// RemoveTrap = 48,
			true,// Necromancy = 49,
			false,// Focus = 50,
			true,// Chivalry = 51
			true,// Bushido = 52
			true,//Ninjitsu = 53
			true // Spellweaving
		};

		public static void Initialize()
		{
			Mobile.SkillCheckLocationHandler = new SkillCheckLocationHandler( Mobile_SkillCheckLocation );
			Mobile.SkillCheckDirectLocationHandler = new SkillCheckDirectLocationHandler( Mobile_SkillCheckDirectLocation );

			Mobile.SkillCheckTargetHandler = new SkillCheckTargetHandler( Mobile_SkillCheckTarget );
			Mobile.SkillCheckDirectTargetHandler = new SkillCheckDirectTargetHandler( Mobile_SkillCheckDirectTarget );
		}

		public static bool Mobile_SkillCheckLocation( Mobile from, SkillName skillName, double minSkill, double maxSkill )
		{
			Skill skill = from.Skills[skillName];

			if ( skill == null )
				return false;

			double value = skill.Value;

			if ( value < minSkill )
				return false; // Too difficult
			else if ( value >= maxSkill )
				return true; // No challenge

			double chance = (value - minSkill) / (maxSkill - minSkill);

			Point2D loc = new Point2D( from.Location.X / LocationSize, from.Location.Y / LocationSize );
			return CheckSkill( from, skill, loc, chance );
		}

		public static bool Mobile_SkillCheckDirectLocation( Mobile from, SkillName skillName, double chance )
		{
			Skill skill = from.Skills[skillName];

			if ( skill == null )
				return false;

			if ( chance < 0.0 )
				return false; // Too difficult
			else if ( chance >= 1.0 )
				return true; // No challenge

			Point2D loc = new Point2D( from.Location.X / LocationSize, from.Location.Y / LocationSize );
			return CheckSkill( from, skill, loc, chance );
		}

        public static bool CheckSkill(Mobile from, Skill skill, object amObj, double chance)
        {
            if (from.Skills.Cap == 0)
                return false;

            // hunger bonus: completely full +2%
            //double bonusph = 1.0;

            

            double bonus = (from.Hunger) / 1000.0;
            if (bonus > 0.02)
                bonus = 0.02;
            else if (bonus < 0)
                bonus = 0;
                chance += bonus;

            //from.SendMessage("you have {0} success chance with {1}", chance , skill.SkillName);  //Debug to see success chance

            bool success = (chance >= Utility.RandomDouble());

            if (chance > 1.0)
                chance = 1.0;


            double gc = ((from.Skills.Cap - from.Skills.Total) / from.Skills.Cap);
            gc += 0.001 + (((skill.Cap - skill.Base) / skill.Cap) * 0.999);
            // gc += ( -Math.Pow( (1.5*chance - 0.9), 2 ) + 0.85 ) * (success ? 1.0 : 0.5); // for c=0 this=0.04, for c=.6 this=0.85, for c=1, this=0.49
            gc += (-Math.Pow(((1.75 * chance) - 0.83), 2) + 0.85) * (success ? 1.0 : 0.5); // for c=0 this=0.161, for c=.475 this=0.85, for c=1, this=0.0036
            //this gives a nearly even distribution cirve, osi most likely has a symetrical curve, which is gay.
            gc /= 3; // avg of the 3 (the highest this can be is (1+1+0.85)/3=0.95)

            gc *= skill.Info.GainFactor;

            if (skill.SkillID == 0) gc /= 1.75;  //Alchemy
            if (skill.SkillID == 1) gc /= 1.75;  //Anatomy
            if (skill.SkillID == 2) gc /= 0.75;  //Animal Lore
            if (skill.SkillID == 3) gc /= 1.02;  //Item ID
            if (skill.SkillID == 4) gc /= 0.75;  //Arms Lore
            if (skill.SkillID == 5) gc /= 1.75;  //Parry
            if (skill.SkillID == 6) gc /= 1.75;  //Begging
            if (skill.SkillID == 7) gc /= 1.75;  //Blacksmith
            if (skill.SkillID == 8) gc /= 1.75;  //Fletching
            if (skill.SkillID == 9) gc /= 0.75;  //Peacemaking
            if (skill.SkillID == 10) gc /= 1.75; //Camping
            if (skill.SkillID == 11) gc /= 1.75; //Carpentry
            if (skill.SkillID == 12) gc /= 1.75; //Cartography
            if (skill.SkillID == 13) gc /= 1.75; //Cooking
            if (skill.SkillID == 14) gc /= 1.75; //Detect Hidden
            if (skill.SkillID == 15) gc /= 0.75; //Discordance - Enticement
            if (skill.SkillID == 16) gc /= 1.75; //Eval INT
            if (skill.SkillID == 17) gc /= 1.75; //Healing
            if (skill.SkillID == 18) gc /= 1.75; //Fishing
            if (skill.SkillID == 19) gc /= 0.75; //Forensics
            if (skill.SkillID == 20) gc /= 1.75; //Herding
            if (skill.SkillID == 21) gc /= 1.75; //Hiding
            if (skill.SkillID == 22) gc /= 1.75; //Provocation
            if (skill.SkillID == 23) gc /= 1.75; //Inscription
            if (skill.SkillID == 24) gc /= 1.75; //Lockpicking
            if (skill.SkillID == 25) gc /= 1.75; //Magery
            if (skill.SkillID == 26) gc /= 1.75; //Magic Resist
            if (skill.SkillID == 27) gc /= 0.75; //Tactics
            if (skill.SkillID == 28) gc /= 1.75; //Snooping
            if (skill.SkillID == 29) gc /= 0.75; //Musicianship
            if (skill.SkillID == 30) gc /= 1.75; //Poisoning
            if (skill.SkillID == 31) gc /= 1.75; //Archery
            if (skill.SkillID == 32) gc /= 0.75; //Spirit Speak
            if (skill.SkillID == 33) gc /= 1.75; //Stealing
            if (skill.SkillID == 34) gc /= 1.75; //Tailoring
            if (skill.SkillID == 35) gc /= 1.75; //Animal Taming
            if (skill.SkillID == 36) gc /= 0.75; //Taste ID
            if (skill.SkillID == 37) gc /= 1.75; //Tinkering
            if (skill.SkillID == 38) gc /= 0.75; //Tracking
            if (skill.SkillID == 39) gc /= 1.75; //Veterinary
            if (skill.SkillID == 40) gc /= 1.10; //Swords
            if (skill.SkillID == 41) gc /= 1.10; //Macing
            if (skill.SkillID == 42) gc /= 1.10; //Fencing
            if (skill.SkillID == 43) gc /= 1.10; //Wrestling
            if (skill.SkillID == 44) gc /= 1.75; //Lumberjacking
            if (skill.SkillID == 45) gc /= 0.75; //Mining
            if (skill.SkillID == 46) gc /= 0.75; //Meditation
            if (skill.SkillID == 47) gc /= 1.75; //Stealth
            if (skill.SkillID == 48) gc /= 1.75; //Remove Trap
            if (skill.SkillID == 49) gc /= 1.75; //Necromancy
            if (skill.SkillID == 50) gc /= 1.75; //Focus
            if (skill.SkillID == 51) gc /= 1.75; //Chivalry
            if (skill.SkillID == 52) gc /= 1.75; //Bushido
            if (skill.SkillID == 53) gc /= 1.75; //Ninjitsu
            if (skill.SkillID == 54) gc /= 1.75; //Spellweaving

            //gc /= 2.5;  //was 2.5 // Not used when using individual Gains.

            if (skill.Base >= 90.0)
            {
                gc *= ((100.0 - (skill.Base - 80)) / 110.0);

                from.SendMessage("you have {0} chance to gain {1} over 90.", gc , skill.SkillName);

                if (from is PlayerMobile && (((PlayerMobile)from).m_InPowerHour == true))
                {
                    gc *= 2.0;
                    from.SendMessage("you have {0} chance to gain {1} over 90 in Power Hour.", gc, skill.SkillName);
                }

            }

            if (skill.Base >= 80.0 && skill.Base <= 89.9)
            {
                gc *= ((100.0 - (skill.Base - 80.0)) / 105.0);
                from.SendMessage("you have {0} chance to gain  {1} over 80.", gc, skill.SkillName);

                if (from is PlayerMobile && (((PlayerMobile)from).m_InPowerHour == true))
                {
                    gc *= 2.0;
                    from.SendMessage("you have {0} chance to gain  {1} over 80 in Power Hour.", gc, skill.SkillName);
                }

            }

            else if (skill.Base >= 0.0 && skill.Base <= 79.9)
            {
                gc *= 0.9; //originally 0.9
                from.SendMessage("you have {0} chance to gain  {1} Under 80.", gc, skill.SkillName);

                if (from is PlayerMobile && (((PlayerMobile)from).m_InPowerHour == true))
                {
                    gc *= 2.0;
                    from.SendMessage("you have {0} chance to gain  {1} under 80 in Power Hour.", gc, skill.SkillName);
                }
            }

            if (chance >= 1.0 && skill.Base == skill.Cap)
                gc = gc * 1.25 + 0.01;

            if (from.Alive && gc >= Utility.RandomDouble() && AllowGain(from, skill, amObj))
                Gain(from, skill);

            return success;
        }

		public static bool Mobile_SkillCheckTarget( Mobile from, SkillName skillName, object target, double minSkill, double maxSkill )
		{
			Skill skill = from.Skills[skillName];

			if ( skill == null )
				return false;

			double value = skill.Value;

			if ( value < minSkill )
				return false; // Too difficult
			else if ( value >= maxSkill )
				return true; // No challenge

			double chance = (value - minSkill) / (maxSkill - minSkill);

			return CheckSkill( from, skill, target, chance );
		}

		public static bool Mobile_SkillCheckDirectTarget( Mobile from, SkillName skillName, object target, double chance )
		{
			Skill skill = from.Skills[skillName];

			if ( skill == null )
				return false;

			if ( chance < 0.0 )
				return false; // Too difficult
			else if ( chance >= 1.0 )
				return true; // No challenge

			return CheckSkill( from, skill, target, chance );
		}

		private static bool AllowGain( Mobile from, Skill skill, object obj )
		{
			if ( Core.AOS && Faction.InSkillLoss( from ) )	//Changed some time between the introduction of AoS and SE.
				return false;

			if ( AntiMacroCode && from is PlayerMobile && UseAntiMacro[skill.Info.SkillID] )
				return ((PlayerMobile)from).AntiMacroCheck( skill, obj );
			else
				return true;
		}

		public enum Stat { Str, Dex, Int }

        public static void Gain(Mobile from, Skill skill)
        {
            if (from.Region.IsPartOf(typeof(Regions.Jail)))
                return;

            if (from is BaseCreature && ((BaseCreature)from).IsDeadPet)
                return;

            if (skill.SkillName == SkillName.Focus && from is BaseCreature)
                return;

            if (skill.Base < skill.Cap && skill.Lock == SkillLock.Up)
            {
                int toGain = 1;
                //CUSTOM POWERHOUR
                //if (from is PlayerMobile && (((PlayerMobile)from).m_InPowerHour == true))
                 //   toGain *= 2; //is in powerhour?

                //Powerhour Modifier!?

                if (skill.Base <= 10.0)
                    toGain = Utility.Random(4) + 1;

                Skills skills = from.Skills;

                if (from.Player && (skills.Total / skills.Cap) >= Utility.RandomDouble())//( skills.Total >= skills.Cap )
                {
                    for (int i = 0; i < skills.Length; ++i)
                    {
                        Skill toLower = skills[i];

                        if (toLower != skill && toLower.Lock == SkillLock.Down && toLower.BaseFixedPoint >= toGain)
                        {
                            toLower.BaseFixedPoint -= toGain;
                            break;
                        }
                    }
                }

                #region Scroll of Alacrity
                PlayerMobile pm = from as PlayerMobile;

                if (from is PlayerMobile)
                    if (pm != null && skill.SkillName == pm.AcceleratedSkill && pm.AcceleratedStart > DateTime.Now)
                        toGain *= Utility.RandomMinMax(2, 5);
                #endregion

                if (!from.Player || (skills.Total + toGain) <= skills.Cap)
                {
                    skill.BaseFixedPoint += toGain;
                }
            }

                if (skill.Lock == SkillLock.Up)
                {
                    SkillInfo info = skill.Info;
                    if (((PlayerMobile)from).InPowerHour == true && from.StrLock == StatLockType.Up && (info.StrGain / 16.65) > Utility.RandomDouble())  //Power Hour Boost
                        GainStat(from, Stat.Str);

                    if (((PlayerMobile)from).InPowerHour == false && from.StrLock == StatLockType.Up && (info.StrGain / 33.3) > Utility.RandomDouble())
                        GainStat(from, Stat.Str);

                    else if (((PlayerMobile)from).InPowerHour == true && from.DexLock == StatLockType.Up && (info.DexGain / 16.65) > Utility.RandomDouble()) //Power Hour Boost
                        GainStat(from, Stat.Dex);

                    else if (((PlayerMobile)from).InPowerHour == false && from.DexLock == StatLockType.Up && (info.DexGain / 33.3) > Utility.RandomDouble())
                        GainStat(from, Stat.Dex);

                    else if (((PlayerMobile)from).InPowerHour == true && from.IntLock == StatLockType.Up && (info.IntGain / 16.65) > Utility.RandomDouble()) //Power Hour Boost
                        GainStat(from, Stat.Int);

                    else if (((PlayerMobile)from).InPowerHour == false && from.IntLock == StatLockType.Up && (info.IntGain / 33.3) > Utility.RandomDouble())
                        GainStat(from, Stat.Int);
                }
            }
        

		public static bool CanLower( Mobile from, Stat stat )
		{
			switch ( stat )
			{
				case Stat.Str: return ( from.StrLock == StatLockType.Down && from.RawStr > 10 );
				case Stat.Dex: return ( from.DexLock == StatLockType.Down && from.RawDex > 10 );
				case Stat.Int: return ( from.IntLock == StatLockType.Down && from.RawInt > 10 );
			}

			return false;
		}

		public static bool CanRaise( Mobile from, Stat stat )
		{
			if ( !(from is BaseCreature && ((BaseCreature)from).Controlled) )
			{
				if ( from.RawStatTotal >= from.StatCap )
					return false;
			}

			switch ( stat )
			{
				case Stat.Str: return ( from.StrLock == StatLockType.Up && from.RawStr < 125 );
				case Stat.Dex: return ( from.DexLock == StatLockType.Up && from.RawDex < 125 );
				case Stat.Int: return ( from.IntLock == StatLockType.Up && from.RawInt < 125 );
			}

			return false;
		}

		public static void IncreaseStat( Mobile from, Stat stat, bool atrophy )
		{
			atrophy = atrophy || (from.RawStatTotal >= from.StatCap);

			switch ( stat )
			{
				case Stat.Str:
				{
					if ( atrophy )
					{
						if ( CanLower( from, Stat.Dex ) && (from.RawDex < from.RawInt || !CanLower( from, Stat.Int )) )
							--from.RawDex;
						else if ( CanLower( from, Stat.Int ) )
							--from.RawInt;
					}

					if ( CanRaise( from, Stat.Str ) )
						++from.RawStr;

					break;
				}
				case Stat.Dex:
				{
					if ( atrophy )
					{
						if ( CanLower( from, Stat.Str ) && (from.RawStr < from.RawInt || !CanLower( from, Stat.Int )) )
							--from.RawStr;
						else if ( CanLower( from, Stat.Int ) )
							--from.RawInt;
					}

					if ( CanRaise( from, Stat.Dex ) )
						++from.RawDex;

					break;
				}
				case Stat.Int:
				{
					if ( atrophy )
					{
						if ( CanLower( from, Stat.Str ) && (from.RawStr < from.RawDex || !CanLower( from, Stat.Dex )) )
							--from.RawStr;
						else if ( CanLower( from, Stat.Dex ) )
							--from.RawDex;
					}

					if ( CanRaise( from, Stat.Int ) )
						++from.RawInt;

					break;
				}
			}
		}

		private static TimeSpan m_StatGainDelay = TimeSpan.FromMinutes( 0.30 );
		private static TimeSpan m_PetStatGainDelay = TimeSpan.FromMinutes( 5.0 );

		public static void GainStat( Mobile from, Stat stat )
		{
			switch( stat )
			{
				case Stat.Str:
				{
					if ( from is BaseCreature && ((BaseCreature)from).Controlled ) {
						if ( (from.LastStrGain + m_PetStatGainDelay) >= DateTime.Now )
							return;
					}
					else if( (from.LastStrGain + m_StatGainDelay) >= DateTime.Now )
						return;

					from.LastStrGain = DateTime.Now;
					break;
				}
				case Stat.Dex:
				{
					if ( from is BaseCreature && ((BaseCreature)from).Controlled ) {
						if ( (from.LastDexGain + m_PetStatGainDelay) >= DateTime.Now )
							return;
					}
					else if( (from.LastDexGain + m_StatGainDelay) >= DateTime.Now )
						return;

					from.LastDexGain = DateTime.Now;
					break;
				}
				case Stat.Int:
				{
					if ( from is BaseCreature && ((BaseCreature)from).Controlled ) {
						if ( (from.LastIntGain + m_PetStatGainDelay) >= DateTime.Now )
							return;
					}

					else if( (from.LastIntGain + m_StatGainDelay) >= DateTime.Now )
						return;

					from.LastIntGain = DateTime.Now;
					break;
				}
			}

			bool atrophy = ( (from.RawStatTotal / (double)from.StatCap) >= Utility.RandomDouble() );

			IncreaseStat( from, stat, atrophy );
		}
	}
}