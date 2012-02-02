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
            if (Charges == 0)
                from.SendMessage("With the power binding your jewelry gone, it vanishes.");//
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
            }
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
                Delete();
        }

        public virtual void OnJewelryUse(Mobile from)
        {

        }
    }
}