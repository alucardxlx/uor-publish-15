using System;
using System.Text;
using System.Collections;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using Server.Engines.Craft;

namespace Server.Items
{
    #region enum JewlryEffect

    public enum JewelryEffect
    {
        // First Circle
        Clumsy,
        ReactiveArmor,
        NightSight,
        Heal,
        MagicArrow,
        CreateFood,
        Weaken,
        Feeblemind,
        // Second Circle
        Agility,
        Cunning,
        Harm,
        Protection,
        Cure,
        MagicTrap,
        Strength,
        RemoveTrap,
        // Third Circle
        Unlock,
        Fireball,
        Telekinesis,
        Bless,
        Poison,
        WallOfStone,
        MagicLock,
        // Forth Circle
        ArchCure,
        ArchProtection,
        FireField,
        ManaDrain,
        Curse,
        GreaterHeal,
        Lightning,
        Recall,
        // Fifhth Circle
        Paralyze,
        Incognito,
        MindBlast,
        DispelField,
        PoisonField,
        MagicReflect,
        BladeSpirits,
        // Sixth Circle
        EnergyBolt,
        Explosion,
        Dispel,
        Invisibility,
        Reveal,
        Mark,
        ParalyzeField,
        // Seventh Circle
        Polymorph,
        ManaVampire,
        MassDispel,
        MeteorSwarm,
        ChainLightning,
        FlameStrike,
        GateTravel,
        EnergyField,
        // Eighth Circle
        WaterElemental,
        AirElemental,
        FireElemental,
        EarthElemental,
        EnergyVortex,
        SummonDaemon,
        Earthquake,
        Resurrection,
        // PVP Helpers
        Teleport,
        //BlessII
        //CureII,
        //GeaterHealingII,
        //InvisibilityII
    }
    #endregion
    

    public abstract class BaseJewelry : Item
    {
        private Mobile m_Crafter;
        private JewelryEffect m_JewelryEffect;
        public int m_Charges;
        public int itemid;
        public bool FailedSpell = true;

        public virtual TimeSpan GetUseDelay { get { return TimeSpan.FromSeconds(4.0); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public JewelryEffect Effect
        {
            get { return m_JewelryEffect; }
            set { m_JewelryEffect = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Crafter
        {
            get { return m_Crafter; }
            set { m_Crafter = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Charges
        {
            get { return m_Charges; }
            set { m_Charges = value; InvalidateProperties(); }
        }

        public BaseJewelry(JewelryEffect effect, Layer layer, int itemid, int minCharges, int maxCharges)
        {
            ItemID = itemid;
            Effect = effect;
            Layer = layer;
            Charges = Utility.RandomMinMax(minCharges, maxCharges);
            Weight = 1.0;
            Stackable = false;
        }

        public void ConsumeCharge(Mobile from)
        {
            --Charges;
           // if (Charges == 0)
           //     from.SendMessage("With the power binding your jewelry gone, it vanishes.");//
            ApplyDelayTo(from);
        }

        public BaseJewelry(Serial serial)
            : base(serial)
        {
        }

        public virtual void ApplyDelayTo(Mobile from)
        {
            from.BeginAction(typeof(BaseJewelry));
            Timer.DelayCall(GetUseDelay, new TimerStateCallback(ReleaseJewelryLock_Callback), from);
        }

        public virtual void ReleaseJewelryLock_Callback(object state)
        {
            ((Mobile)state).EndAction(typeof(BaseJewelry));
        }

        public override void OnDoubleClick(Mobile from)
        {
            FailedSpell = true;

            if (!from.CanBeginAction(typeof(BaseJewelry)))
                return;

            if (Parent == from)
            {
                if (Charges > 0)
                    OnJewelryUse(from);
                else
                    from.SendLocalizedMessage(1019073); // This item is out of charges.
            }
            else
            {
                from.SendLocalizedMessage(502641); // You must equip this item to use it.
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version


            writer.Write((int)m_JewelryEffect);
            writer.Write((int)m_Charges);

        }

       

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        m_JewelryEffect = (JewelryEffect)reader.ReadInt();
                        m_Charges = (int)reader.ReadInt();

                        break;
                    }
            }
        }


        #region GetProperties
        // Get Fizzle on last charge so covered up with -1
        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            switch (m_JewelryEffect)
            {
                case JewelryEffect.Polymorph:       list.Add("Polymorph charges: {0}", m_Charges - 1); break;
                case JewelryEffect.ManaVampire:     list.Add("ManaVampire charges: {0}:", m_Charges - 1); break;
                case JewelryEffect.Protection:      list.Add("Protection charges: {0}", m_Charges - 1); break;
                case JewelryEffect.ReactiveArmor:   list.Add("ReactiveArmor charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Telekinesis:     list.Add("Telekinesis charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Unlock:          list.Add("Unlock charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Fireball:        list.Add("Fireball charges: {0}", m_Charges - 1); break;
                case JewelryEffect.NightSight:      list.Add("NightSight charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Paralyze:        list.Add("Paralyze charges: {0}", m_Charges - 1); break;
                case JewelryEffect.MeteorSwarm:     list.Add("MeteorSwarm charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Incognito:       list.Add("Incognito charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Dispel:          list.Add("Dispel charges: {0}", m_Charges - 1); break;
                case JewelryEffect.MassDispel:      list.Add("MassDispel charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Teleport:        list.Add("Teleport charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Bless:           list.Add("Bless charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Cure:            list.Add("Cure charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Poison:          list.Add("Poison charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Invisibility:    list.Add("Invisibility charges: {0}", m_Charges - 1); break;
                case JewelryEffect.WallOfStone:     list.Add("WallOfStone charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Curse:           list.Add("Curse charges: {0}", m_Charges - 1); break;
                case JewelryEffect.MagicReflect:    list.Add("MagicReflect charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Reveal:          list.Add("Reveal charges: {0}", m_Charges - 1); break;
                case JewelryEffect.BladeSpirits:    list.Add("BladeSpirits charges: {0}", m_Charges - 1); break;
                case JewelryEffect.EnergyBolt:      list.Add("EnergyBolt charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Explosion:       list.Add("Explosion charges: {0}", m_Charges - 1); break;
                case JewelryEffect.ChainLightning:  list.Add("ChainLightning charges: {0}", m_Charges - 1); break;
                case JewelryEffect.FlameStrike:     list.Add("FlameStrike charges: {0}", m_Charges - 1); break;
                case JewelryEffect.GreaterHeal:     list.Add("GreaterHealcharges: {0}", m_Charges - 1); break;
                case JewelryEffect.Lightning:       list.Add("Lightning charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Recall:          list.Add("Recall charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Heal:            list.Add("Heal charges: {0}", m_Charges - 1); break;
                case JewelryEffect.MagicArrow:      list.Add("MagicArrow charges: {0}", m_Charges - 1); break;
                case JewelryEffect.RemoveTrap:      list.Add("RemoveTrap charges: {0}", m_Charges - 1); break;
                case JewelryEffect.DispelField:     list.Add("DispelField charges: {0}", m_Charges - 1); break;
                case JewelryEffect.PoisonField:     list.Add("PoisonField charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Mark:            list.Add("Mark charges: {0}", m_Charges - 1); break;
                case JewelryEffect.ParalyzeField:   list.Add("ParalyzeField charges: {0}", m_Charges - 1); break;
                case JewelryEffect.GateTravel:      list.Add("GateTravel charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Earthquake:      list.Add("EarthQuake charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Resurrection:    list.Add("Resurrection charges: {0}", m_Charges); break;
                //case JewelryEffect.CureII:               list.Add("Cure II charges: {0}",           m_Charges -1); break;
                //case JewelryEffect.InvisibilityII:       list.Add("Invisibility II charges: {0}",   m_Charges -1); break;
                //case JewelryEffect.GreaterHealII:        list.Add("Greater Heal II: {0}",           m_Charges -1); break;
                //case JewelryEffect.BlessII:              list.Add("Bless II: {0}",                  m_Charges -1); break;
                case JewelryEffect.Clumsy:          list.Add("Clumsy charges: {0}", m_Charges - 1); break;
                case JewelryEffect.CreateFood:      list.Add("Create Food charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Weaken:          list.Add("Weaken charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Agility:         list.Add("Agility charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Cunning:         list.Add("Cunning charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Harm:            list.Add("Harm charges: {0}", m_Charges - 1); break;
                case JewelryEffect.MagicTrap:       list.Add("Magic Trap charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Strength:        list.Add("Strength charges: {0}", m_Charges - 1); break;
                case JewelryEffect.MagicLock:       list.Add("Magic Lock charges: {0}", m_Charges - 1); break;
                case JewelryEffect.ArchCure:        list.Add("Arch Cure charges: {0}", m_Charges - 1); break;
                case JewelryEffect.ArchProtection:  list.Add("Arch Protection charges: {0}", m_Charges - 1); break;
                case JewelryEffect.FireField:       list.Add("Fire Field charges: {0}", m_Charges - 1); break;
                case JewelryEffect.ManaDrain:       list.Add("Mana Drain charges: {0}", m_Charges - 1); break;
                case JewelryEffect.MindBlast:       list.Add("Mind Blast charges: {0}", m_Charges - 1); break;
                case JewelryEffect.WaterElemental:  list.Add("Water Elemental charges: {0}", m_Charges - 1); break;
                case JewelryEffect.AirElemental:    list.Add("Air Elemental charges: {0}", m_Charges - 1); break;
                case JewelryEffect.FireElemental:   list.Add("Fire Elemental charges: {0}", m_Charges - 1); break;
                case JewelryEffect.EarthElemental:  list.Add("Earth Elemental charges: {0}", m_Charges - 1); break;
                case JewelryEffect.EnergyVortex:    list.Add("Energy Vortex charges: {0}", m_Charges - 1); break;
                case JewelryEffect.SummonDaemon:    list.Add("Summon Daemon charges: {0}", m_Charges - 1); break;
                case JewelryEffect.EnergyField:     list.Add("Energy Field charges: {0}", m_Charges - 1); break;
                case JewelryEffect.Feeblemind:      list.Add("Feeblemind charges: {0}", m_Charges - 1); break;
            }

        }
        #endregion

        public override void OnSingleClick(Mobile from)
        {
            ArrayList attrs = new ArrayList();

            if (DisplayLootType)
            {
                if (LootType == LootType.Blessed)
                    attrs.Add(new EquipInfoAttribute(1038021)); // blessed
                else if (LootType == LootType.Cursed)
                    attrs.Add(new EquipInfoAttribute(1049643)); // cursed
            
                int num = 0;

                switch (m_JewelryEffect)
                {
                    //Circle One
                    case JewelryEffect.Clumsy: num = 3002011; break;
                    case JewelryEffect.CreateFood: num = 3002012; break;
                    case JewelryEffect.Feeblemind: num = 3002013; break;
                    case JewelryEffect.Heal: num = 3002014; break;
                    case JewelryEffect.MagicArrow: num = 3002015; break;
                    case JewelryEffect.NightSight: num = 3002016; break;
                    case JewelryEffect.ReactiveArmor: num = 3002017; break;
                    case JewelryEffect.Weaken: num = 3002018; break;
                    //Circle Two
                    case JewelryEffect.Agility: num = 3002019; break;
                    case JewelryEffect.Cunning: num = 3002020; break;
                    case JewelryEffect.Cure: num = 3002021; break;
                    case JewelryEffect.Harm: num = 3002022; break;
                    case JewelryEffect.MagicTrap: num = 3002023; break;
                    case JewelryEffect.RemoveTrap: num = 3002024; break;
                    case JewelryEffect.Protection: num = 3002025; break;
                    case JewelryEffect.Strength: num = 3002026; break;
                    //Circle Three
                    case JewelryEffect.Bless: num = 3002027; break;
                    case JewelryEffect.Fireball: num = 3002028; break;
                    case JewelryEffect.MagicLock: num = 3002029; break;
                    case JewelryEffect.Poison: num = 3002030; break;
                    case JewelryEffect.Telekinesis: num = 3002031; break;
                    case JewelryEffect.Teleport: num = 3002032; break;
                    case JewelryEffect.Unlock: num = 3002033; break;
                    case JewelryEffect.WallOfStone: num = 3002034; break;
                    //Circle Four
                    case JewelryEffect.ArchCure: num = 3002035; break;
                    case JewelryEffect.ArchProtection: num = 3002036; break;
                    case JewelryEffect.Curse: num = 3002037; break;
                    case JewelryEffect.FireField: num = 3002038; break;
                    case JewelryEffect.GreaterHeal: num = 3002039; break;
                    case JewelryEffect.Lightning: num = 3002040; break;
                    case JewelryEffect.ManaDrain: num = 3002041; break;
                    case JewelryEffect.Recall: num = 3002042; break;
                    //Circle Five
                    case JewelryEffect.BladeSpirits: num = 3002043; break;
                    case JewelryEffect.DispelField: num = 3002044; break;
                    case JewelryEffect.Incognito: num = 3002045; break;
                    case JewelryEffect.MagicReflect: num = 3002046; break;
                    case JewelryEffect.MindBlast: num = 3002047; break;
                    case JewelryEffect.Paralyze: num = 3002048; break;
                    case JewelryEffect.PoisonField: num = 3002049; break;
                    //Circle Six
                    case JewelryEffect.Dispel: num = 3002051; break;
                    case JewelryEffect.EnergyBolt: num = 3002052; break;
                    case JewelryEffect.Explosion: num = 3002053; break;
                    case JewelryEffect.Invisibility: num = 3002054; break;
                    case JewelryEffect.Mark: num = 3002055; break;
                    case JewelryEffect.ParalyzeField: num = 3002057; break;
                    case JewelryEffect.Reveal: num = 3002058; break;
                    //Circle Seven
                    case JewelryEffect.ChainLightning: num = 3002059; break;
                    case JewelryEffect.EnergyField: num = 3002060; break;
                    case JewelryEffect.FlameStrike: num = 3002061; break;
                    case JewelryEffect.GateTravel: num = 3002062; break;
                    case JewelryEffect.ManaVampire: num = 3002063; break;
                    case JewelryEffect.MassDispel: num = 3002064; break;
                    case JewelryEffect.MeteorSwarm: num = 3002065; break;
                    case JewelryEffect.Polymorph: num = 3002066; break;
                    //Circle Eight
                    case JewelryEffect.Earthquake: num = 3002067; break;
                    case JewelryEffect.EnergyVortex: num = 3002068; break;
                    case JewelryEffect.Resurrection: num = 3002069; break;
                    case JewelryEffect.AirElemental: num = 3002070; break;
                    case JewelryEffect.SummonDaemon: num = 3002071; break;
                    case JewelryEffect.EarthElemental: num = 3002072; break;
                    case JewelryEffect.FireElemental: num = 3002073; break;
                    case JewelryEffect.WaterElemental: num = 3002074; break;

                }

                if (num > 0)
                    attrs.Add(new EquipInfoAttribute(num, m_Charges));
            }

            int number;

            if (Name == null && ItemID == 0x1086)
            {
                number = 1017094;
            }

            else if (Name == null && ItemID == 0x1087)
            {
                number = 1017095;
            }

            else if (Name == null && ItemID == 0x1088)
            {
                number = 1017096;
            }

            else if (Name == null && ItemID == 0x108A)
            {
                number = 1017098;
            }

            else
            {
                this.LabelTo(from, Name);
                number = 1041000;
            }

            if (attrs.Count == 0 && Crafter == null && Name != null)
                return;

            EquipmentInfo eqInfo = new EquipmentInfo(number, Crafter, false, (EquipInfoAttribute[])attrs.ToArray(typeof(EquipInfoAttribute)));

            from.Send(new DisplayEquipmentInfo(this, eqInfo));
        }

        public void Cast(Spell spell)
        {
            bool m = Movable;
            Movable = false;
            spell.Cast();
            Movable = m;
        }


        public virtual void OnFinish(Mobile from)
        {
            if (Deleted || Parent != from)
                return;

            ConsumeCharge(from);

            if (Charges != 0)
                return;
            else
                return; //from.SendMessage("The last of the magic is consumed but was not enough for the spell.");//  //Delete();
        }

        public virtual void OnJewelryUse(Mobile from)
        {

        }
    }
}