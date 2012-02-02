using System;
using System.Collections;
using Server.Items;
using Server;
using Server.Spells.First;
using Server.Spells.Second;
using Server.Spells.Third;
using Server.Spells.Fourth;
using Server.Spells.Fifth;
using Server.Spells.Sixth;
using Server.Spells.Seventh;
using Server.Spells.Eighth;
using Server.Spells;
using Server.Targeting;


namespace Server.Items
{
    #region  PVP Helpers  -  Pendants
    public class PVPPendantOfInvisibility : BaseJewelry
    {
        [Constructable]
        public PVPPendantOfInvisibility()
            : base(JewelryEffect.Invisibility, Layer.Neck, 0x1088, 51, 61)
        {
            Name = "Mystic Pendant Of Invisibility II";
        }

        public PVPPendantOfInvisibility(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            if (from.Hidden != true)
            {
                SpellHelper.Turn(from, from);

                Effects.SendLocationParticles(EffectItem.Create(new Point3D(from.X, from.Y, from.Z + 16), from.Map, EffectItem.DefaultDuration), 0x376A, 10, 15, 5045);
                from.PlaySound(0x3C4);

                from.Hidden = true;

                BuffInfo.RemoveBuff(from, BuffIcon.HidingAndOrStealth);
                BuffInfo.AddBuff(from, new BuffInfo(BuffIcon.Invisibility, 1075825));

                RemoveTimer(from);

                TimeSpan duration = TimeSpan.FromSeconds(120);

                Timer t = new InternalTimer(from, duration);

                m_Table[from] = t;

                t.Start();

                OnFinish(from);
            }
            else
                from.SendMessage("You are already hidden.");
            return;

        }
        private static Hashtable m_Table = new Hashtable();

        public static bool HasTimer(Mobile from)
        {
            return m_Table[from] != null;
        }

        public static void RemoveTimer(Mobile from)
        {
            Timer t = (Timer)m_Table[from];

            if (t != null)
            {
                t.Stop();
                m_Table.Remove(from);
            }
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Mobile;

            public InternalTimer(Mobile from, TimeSpan duration)
                : base(duration)
            {
                Priority = TimerPriority.OneSecond;
                m_Mobile = from;
            }

            protected override void OnTick()
            {
                m_Mobile.RevealingAction();
                RemoveTimer(m_Mobile);
            }
        }
    }


    public class PVPPendantOfGreaterHeal : BaseJewelry
    {
        [Constructable]
        public PVPPendantOfGreaterHeal()
            : base(JewelryEffect.GreaterHeal, Layer.Neck, 0x1088, 51, 61)
        {
            Name = "Mystic Pendant Of Greater Heal II";
        }

        public PVPPendantOfGreaterHeal(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            if (from.Poisoned || Server.Items.MortalStrike.IsWounded(from))
            {
                from.SendLocalizedMessage(1005000);
            }
            else
            {
                // Algorithm: (40% of magery) + (1-10)
                int toHeal = (int)(from.Skills[SkillName.Magery].Value + 100);
                toHeal += Utility.Random(1, 10);

                //m.Heal( toHeal, Caster );
                SpellHelper.Heal(toHeal, from, from);

                from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);
                from.PlaySound(0x202);
            }

            OnFinish(from);
        }
    }

    public class PVPPendantOfCure : BaseJewelry
    {
        [Constructable]
        public PVPPendantOfCure()
            : base(JewelryEffect.Cure, Layer.Neck, 0x1088, 51, 61)
        {
            Name = "Mystic Pendant Of Cure II";
        }

        public PVPPendantOfCure(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            Poison p = from.Poison;

            if (p != null)
            {
                int chanceToCure = 10000 + (int)(from.Skills[SkillName.Magery].Value * 75) - ((p.Level + 1) * (Core.AOS ? (p.Level < 4 ? 3300 : 3100) : 1750));
                chanceToCure /= 100;

                if (chanceToCure > Utility.Random(100))
                {
                    if (from.CurePoison(from))
                        from.SendLocalizedMessage(1010059); // You have been Cured of all poisons.
                }
                else
                {
                    from.SendLocalizedMessage(1010060); // You have failed to Cure yourself!
                }
            }

            from.FixedParticles(0x373A, 10, 15, 5012, EffectLayer.Waist);
            from.PlaySound(0x1E0);

            OnFinish(from);
        }
    }

    public class PVPPendantOfBless : BaseJewelry
    {
        [Constructable]
        public PVPPendantOfBless()
            : base(JewelryEffect.Bless, Layer.Neck, 0x1088, 51, 61)
        {
            Name = "Mystic Pendant Of Bless II";
        }

        public PVPPendantOfBless(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            SpellHelper.AddStatBonus(from, from, StatType.Str); SpellHelper.DisableSkillCheck = true;
            SpellHelper.AddStatBonus(from, from, StatType.Dex);
            SpellHelper.AddStatBonus(from, from, StatType.Int); SpellHelper.DisableSkillCheck = false;

            from.FixedParticles(0x373A, 10, 15, 5018, EffectLayer.Waist);
            from.PlaySound(0x1EA);

            OnFinish(from);
        }
    }


    public class PVPPendantOfTeleport : BaseJewelry
    {
        [Constructable]
        public PVPPendantOfTeleport()
            : base(JewelryEffect.Teleport, Layer.Neck, 0x1088, 41, 51)
        {
            Name = "Mystic Pendant Of Teleport";
        }

        public PVPPendantOfTeleport(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            Cast(new TeleportSpell(from, this));
            OnFinish(from);
        }
    }
    #endregion

    #region  PVP Helpers - Rings
    public class PVPRingOfInvisibility : BaseJewelry
    {
        [Constructable]
        public PVPRingOfInvisibility()
            : base(JewelryEffect.Invisibility, Layer.Ring, 0x108A, 51, 61)
        {
            Name = "Mystic Ring Of Invisibility II";
        }

        public PVPRingOfInvisibility(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            if (from.Hidden != true)
            {
                SpellHelper.Turn(from, from);

                Effects.SendLocationParticles(EffectItem.Create(new Point3D(from.X, from.Y, from.Z + 16), from.Map, EffectItem.DefaultDuration), 0x376A, 10, 15, 5045);
                from.PlaySound(0x3C4);

                from.Hidden = true;

                BuffInfo.RemoveBuff(from, BuffIcon.HidingAndOrStealth);
                BuffInfo.AddBuff(from, new BuffInfo(BuffIcon.Invisibility, 1075825));

                RemoveTimer(from);

                TimeSpan duration = TimeSpan.FromSeconds(120);

                Timer t = new InternalTimer(from, duration);

                m_Table[from] = t;

                t.Start();

                OnFinish(from);
            }
            else
                from.SendMessage("You are already hidden.");
            return;

        }
        private static Hashtable m_Table = new Hashtable();

        public static bool HasTimer(Mobile from)
        {
            return m_Table[from] != null;
        }

        public static void RemoveTimer(Mobile from)
        {
            Timer t = (Timer)m_Table[from];

            if (t != null)
            {
                t.Stop();
                m_Table.Remove(from);
            }
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Mobile;

            public InternalTimer(Mobile from, TimeSpan duration)
                : base(duration)
            {
                Priority = TimerPriority.OneSecond;
                m_Mobile = from;
            }

            protected override void OnTick()
            {
                m_Mobile.RevealingAction();
                RemoveTimer(m_Mobile);
            }
        }
    }



    public class PVPRingOfGreaterHeal : BaseJewelry
    {
        [Constructable]
        public PVPRingOfGreaterHeal()
            : base(JewelryEffect.GreaterHeal, Layer.Ring, 0x108A, 51, 61)
        {
            Name = "Mystic Ring Of Greater Heal II";
        }

        public PVPRingOfGreaterHeal(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            if (from.Poisoned || Server.Items.MortalStrike.IsWounded(from))
            {
                from.SendLocalizedMessage(1005000);
            }
            else
            {
                // Algorithm: (40% of magery) + (1-10)
                int toHeal = (int)(from.Skills[SkillName.Magery].Value + 100);
                toHeal += Utility.Random(1, 10);

                //m.Heal( toHeal, Caster );
                SpellHelper.Heal(toHeal, from, from);

                from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);
                from.PlaySound(0x202);
            }

            OnFinish(from);
        }
    }

    public class PVPRingOfCure : BaseJewelry
    {
        [Constructable]
        public PVPRingOfCure()
            : base(JewelryEffect.Cure, Layer.Ring, 0x108A, 51, 61)
        {
            Name = "Mystic Ring Of Cure II";
        }

        public PVPRingOfCure(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            Poison p = from.Poison;

            if (p != null)
            {
                int chanceToCure = 10000 + (int)(from.Skills[SkillName.Magery].Value * 75) - ((p.Level + 1) * (Core.AOS ? (p.Level < 4 ? 3300 : 3100) : 1750));
                chanceToCure /= 100;

                if (chanceToCure > Utility.Random(100))
                {
                    if (from.CurePoison(from))
                        from.SendLocalizedMessage(1010059); // You have been Cured of all poisons.
                }
                else
                {
                    from.SendLocalizedMessage(1010060); // You have failed to Cure yourself!
                }
            }

            from.FixedParticles(0x373A, 10, 15, 5012, EffectLayer.Waist);
            from.PlaySound(0x1E0);

            OnFinish(from);
        }
    }

    public class PVPRingOfBless : BaseJewelry
    {
        [Constructable]
        public PVPRingOfBless()
            : base(JewelryEffect.Bless, Layer.Ring, 0x108A, 51, 61)
        {
            Name = "Mystic Ring Of Bless II";
        }

        public PVPRingOfBless(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            SpellHelper.AddStatBonus(from, from, StatType.Str); SpellHelper.DisableSkillCheck = true;
            SpellHelper.AddStatBonus(from, from, StatType.Dex);
            SpellHelper.AddStatBonus(from, from, StatType.Int); SpellHelper.DisableSkillCheck = false;

            from.FixedParticles(0x373A, 10, 15, 5018, EffectLayer.Waist);
            from.PlaySound(0x1EA);

            OnFinish(from);
        }
    }


    public class PVPRingOfTeleport : BaseJewelry
    {
        [Constructable]
        public PVPRingOfTeleport()
            : base(JewelryEffect.Teleport, Layer.Ring, 0x108A, 41, 51)
        {
            Name = "Mystic Ring Of Teleport";
        }

        public PVPRingOfTeleport(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            Cast(new TeleportSpell(from, this));
            OnFinish(from);
        }
    }
    #endregion

    #region  PVP Helpers - Bracers
    public class PVPBracerOfInvisibility : BaseJewelry
    {
        [Constructable]
        public PVPBracerOfInvisibility()
            : base(JewelryEffect.Invisibility, Layer.Bracelet, 0x1086, 51, 61)
        {
            Name = "Mystic Bracer Of Invisibility II";
        }

        public PVPBracerOfInvisibility(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            if (from.Hidden != true)
            {
                SpellHelper.Turn(from, from);

                Effects.SendLocationParticles(EffectItem.Create(new Point3D(from.X, from.Y, from.Z + 16), from.Map, EffectItem.DefaultDuration), 0x376A, 10, 15, 5045);
                from.PlaySound(0x3C4);

                from.Hidden = true;

                BuffInfo.RemoveBuff(from, BuffIcon.HidingAndOrStealth);
                BuffInfo.AddBuff(from, new BuffInfo(BuffIcon.Invisibility, 1075825));

                RemoveTimer(from);

                TimeSpan duration = TimeSpan.FromSeconds(120);

                Timer t = new InternalTimer(from, duration);

                m_Table[from] = t;

                t.Start();

                OnFinish(from);
            }
            else
                from.SendMessage("You are already hidden.");
            return;

        }
        private static Hashtable m_Table = new Hashtable();

        public static bool HasTimer(Mobile from)
        {
            return m_Table[from] != null;
        }

        public static void RemoveTimer(Mobile from)
        {
            Timer t = (Timer)m_Table[from];

            if (t != null)
            {
                t.Stop();
                m_Table.Remove(from);
            }
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Mobile;

            public InternalTimer(Mobile from, TimeSpan duration)
                : base(duration)
            {
                Priority = TimerPriority.OneSecond;
                m_Mobile = from;
            }

            protected override void OnTick()
            {
                m_Mobile.RevealingAction();
                RemoveTimer(m_Mobile);
            }
        }
    }



    public class PVPBracerOfGreaterHeal : BaseJewelry
    {
        [Constructable]
        public PVPBracerOfGreaterHeal()
            : base(JewelryEffect.GreaterHeal, Layer.Bracelet, 0x1086, 51, 61)
        {
            Name = "Mystic Bracer Of Greater Heal II";
        }

        public PVPBracerOfGreaterHeal(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            if (from.Poisoned || Server.Items.MortalStrike.IsWounded(from))
            {
                from.SendLocalizedMessage(1005000);
            }
            else
            {
                // Algorithm: (40% of magery) + (1-10)
                int toHeal = (int)(from.Skills[SkillName.Magery].Value + 100);
                toHeal += Utility.Random(1, 10);

                //m.Heal( toHeal, Caster );
                SpellHelper.Heal(toHeal, from, from);

                from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);
                from.PlaySound(0x202);
            }

            OnFinish(from);
        }
    }

    public class PVPBracerOfCure : BaseJewelry
    {
        [Constructable]
        public PVPBracerOfCure()
            : base(JewelryEffect.Cure, Layer.Bracelet, 0x1086, 51, 61)
        {
            Name = "Mystic Bracer Of Cure II";
        }

        public PVPBracerOfCure(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            Poison p = from.Poison;

            if (p != null)
            {
                int chanceToCure = 10000 + (int)(from.Skills[SkillName.Magery].Value * 75) - ((p.Level + 1) * (Core.AOS ? (p.Level < 4 ? 3300 : 3100) : 1750));
                chanceToCure /= 100;

                if (chanceToCure > Utility.Random(100))
                {
                    if (from.CurePoison(from))
                        from.SendLocalizedMessage(1010059); // You have been Cured of all poisons.
                }
                else
                {
                    from.SendLocalizedMessage(1010060); // You have failed to Cure yourself!
                }
            }

            from.FixedParticles(0x373A, 10, 15, 5012, EffectLayer.Waist);
            from.PlaySound(0x1E0);

            OnFinish(from);
        }
    }

    public class PVPBracerOfBless : BaseJewelry
    {
        [Constructable]
        public PVPBracerOfBless()
            : base(JewelryEffect.Bless, Layer.Bracelet, 0x1086, 51, 61)
        {
            Name = "Mystic Bracer Of Bless II";
        }

        public PVPBracerOfBless(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            SpellHelper.AddStatBonus(from, from, StatType.Str); SpellHelper.DisableSkillCheck = true;
            SpellHelper.AddStatBonus(from, from, StatType.Dex);
            SpellHelper.AddStatBonus(from, from, StatType.Int); SpellHelper.DisableSkillCheck = false;

            from.FixedParticles(0x373A, 10, 15, 5018, EffectLayer.Waist);
            from.PlaySound(0x1EA);

            OnFinish(from);
        }
    }


    public class PVPBracerOfTeleport : BaseJewelry
    {
        [Constructable]
        public PVPBracerOfTeleport()
            : base(JewelryEffect.Teleport, Layer.Bracelet, 0x1086, 41, 51)
        {
            Name = "Mystic Bracer Of Teleport";
        }

        public PVPBracerOfTeleport(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            Cast(new TeleportSpell(from, this));
            OnFinish(from);
        }
    }
    #endregion

    #region  PVP Helpers - Earrings
    public class PVPEarringsOfInvisibility : BaseJewelry
    {
        [Constructable]
        public PVPEarringsOfInvisibility()
            : base(JewelryEffect.Invisibility, Layer.Earrings, 0x1087, 51, 61)
        {
            Name = "Mystic Earrings Of Invisibility II";
        }

        public PVPEarringsOfInvisibility(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            if (from.Hidden != true)
            {
                SpellHelper.Turn(from, from);

                Effects.SendLocationParticles(EffectItem.Create(new Point3D(from.X, from.Y, from.Z + 16), from.Map, EffectItem.DefaultDuration), 0x376A, 10, 15, 5045);
                from.PlaySound(0x3C4);

                from.Hidden = true;

                BuffInfo.RemoveBuff(from, BuffIcon.HidingAndOrStealth);
                BuffInfo.AddBuff(from, new BuffInfo(BuffIcon.Invisibility, 1075825));

                RemoveTimer(from);

                TimeSpan duration = TimeSpan.FromSeconds(120);

                Timer t = new InternalTimer(from, duration);

                m_Table[from] = t;

                t.Start();

                OnFinish(from);
            }
            else
                from.SendMessage("You are already hidden.");
            return;

        }
        private static Hashtable m_Table = new Hashtable();

        public static bool HasTimer(Mobile from)
        {
            return m_Table[from] != null;
        }

        public static void RemoveTimer(Mobile from)
        {
            Timer t = (Timer)m_Table[from];

            if (t != null)
            {
                t.Stop();
                m_Table.Remove(from);
            }
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Mobile;

            public InternalTimer(Mobile from, TimeSpan duration)
                : base(duration)
            {
                Priority = TimerPriority.OneSecond;
                m_Mobile = from;
            }

            protected override void OnTick()
            {
                m_Mobile.RevealingAction();
                RemoveTimer(m_Mobile);
            }
        }
    }



    public class PVPEarringsOfGreaterHeal : BaseJewelry
    {
        [Constructable]
        public PVPEarringsOfGreaterHeal()
            : base(JewelryEffect.GreaterHeal, Layer.Earrings, 0x1087, 51, 61)
        {
            Name = "Mystic Earrings Of Greater Heal II";
        }

        public PVPEarringsOfGreaterHeal(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            if (from.Poisoned || Server.Items.MortalStrike.IsWounded(from))
            {
                from.SendLocalizedMessage(1005000);
            }
            else
            {
                // Algorithm: (40% of magery) + (1-10)
                int toHeal = (int)(from.Skills[SkillName.Magery].Value + 100);
                toHeal += Utility.Random(1, 10);

                //m.Heal( toHeal, Caster );
                SpellHelper.Heal(toHeal, from, from);

                from.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);
                from.PlaySound(0x202);
            }

            OnFinish(from);
        }
    }

    public class PVPEarringsOfCure : BaseJewelry
    {
        [Constructable]
        public PVPEarringsOfCure()
            : base(JewelryEffect.Cure, Layer.Earrings, 0x1087, 51, 61)
        {
            Name = "Mystic Earrings Of Cure II";
        }

        public PVPEarringsOfCure(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            Poison p = from.Poison;

            if (p != null)
            {
                int chanceToCure = 10000 + (int)(from.Skills[SkillName.Magery].Value * 75) - ((p.Level + 1) * (Core.AOS ? (p.Level < 4 ? 3300 : 3100) : 1750));
                chanceToCure /= 100;

                if (chanceToCure > Utility.Random(100))
                {
                    if (from.CurePoison(from))
                        from.SendLocalizedMessage(1010059); // You have been Cured of all poisons.
                }
                else
                {
                    from.SendLocalizedMessage(1010060); // You have failed to Cure yourself!
                }
            }

            from.FixedParticles(0x373A, 10, 15, 5012, EffectLayer.Waist);
            from.PlaySound(0x1E0);

            OnFinish(from);
        }
    }

    public class PVPEarringsOfBless : BaseJewelry
    {
        [Constructable]
        public PVPEarringsOfBless()
            : base(JewelryEffect.Bless, Layer.Earrings, 0x1087, 51, 61)
        {
            Name = "Mystic Earrings Of Bless II";
        }

        public PVPEarringsOfBless(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            SpellHelper.AddStatBonus(from, from, StatType.Str); SpellHelper.DisableSkillCheck = true;
            SpellHelper.AddStatBonus(from, from, StatType.Dex);
            SpellHelper.AddStatBonus(from, from, StatType.Int); SpellHelper.DisableSkillCheck = false;

            from.FixedParticles(0x373A, 10, 15, 5018, EffectLayer.Waist);
            from.PlaySound(0x1EA);

            OnFinish(from);
        }
    }


    public class PVPEarringsOfTeleport : BaseJewelry
    {
        [Constructable]
        public PVPEarringsOfTeleport()
            : base(JewelryEffect.Teleport, Layer.Earrings, 0x1087, 41, 51)
        {
            Name = "Mystic Earrings Of Teleport";
        }

        public PVPEarringsOfTeleport(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            Cast(new TeleportSpell(from, this));
            OnFinish(from);
        }
    }
    #endregion
}
