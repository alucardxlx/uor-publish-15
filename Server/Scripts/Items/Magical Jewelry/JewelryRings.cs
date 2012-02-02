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
    #region First Spell Circle 50 - 60 charges
    public class MRingOfClumsy : BaseJewelry
    {
        [Constructable]
        public MRingOfClumsy()
            : base(JewelryEffect.Clumsy, Layer.Ring, 0x108A, 51, 61)
        {
            Name = "Mystic Ring Of Clumsy";
        }

        public MRingOfClumsy(Serial serial)
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
            Cast(new ClumsySpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfHeal : BaseJewelry
    {
        [Constructable]
        public MRingOfHeal()
            : base(JewelryEffect.Heal, Layer.Ring, 0x108A, 51, 61)
        {
            Name = "Mystic Ring Of Heal";
        }

        public MRingOfHeal(Serial serial)
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
            Cast(new HealSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfMagicArrow : BaseJewelry
    {
        [Constructable]
        public MRingOfMagicArrow()
            : base(JewelryEffect.MagicArrow, Layer.Ring, 0x108A, 51, 61)
        {
            Name = "Mystic Ring Of Magic Arrow";
        }

        public MRingOfMagicArrow(Serial serial)
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
            Cast(new MagicArrowSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfFeeblemind : BaseJewelry
    {
        [Constructable]
        public MRingOfFeeblemind()
            : base(JewelryEffect.Feeblemind, Layer.Ring, 0x108A, 51, 61)
        {
            Name = "Mystic Ring Of Feeblemind";
        }

        public MRingOfFeeblemind(Serial serial)
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
            Cast(new FeeblemindSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfWeaken : BaseJewelry
    {
        [Constructable]
        public MRingOfWeaken()
            : base(JewelryEffect.Weaken, Layer.Ring, 0x108A, 51, 61)
        {
            Name = "Mystic Ring Of Weaken";
        }

        public MRingOfWeaken(Serial serial)
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
            Cast(new WeakenSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfCreateFood : BaseJewelry   // Self Target
    {
        [Constructable]
        public MRingOfCreateFood()
            : base(JewelryEffect.CreateFood, Layer.Ring, 0x108A, 51, 61)
        {
            Name = "Mystic Ring Of Create Food";
        }

        public MRingOfCreateFood(Serial serial)
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
            Cast(new CreateFoodSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfNightSight : BaseJewelry  // Self Target
    {
        [Constructable]
        public MRingOfNightSight()
            : base(JewelryEffect.NightSight, Layer.Ring, 0x108A, 51, 61)
        {
            Name = "Mystic Ring Of Night Sight";
        }

        public MRingOfNightSight(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnJewelryUse(Mobile from)
        {
            Cast(new NightSightSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfReactiveArmor : BaseJewelry  // Self Target
    {
        [Constructable]
        public MRingOfReactiveArmor()
            : base(JewelryEffect.ReactiveArmor, Layer.Ring, 0x108A, 51, 61)
        {
            Name = "Mystic Ring Of ReactiveArmor";
        }

        public MRingOfReactiveArmor(Serial serial)
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
            Cast(new ReactiveArmorSpell(from, this));
            OnFinish(from);
        }
    }
    #endregion

    #region Second Spell Circle 45 - 55 charges
    public class MRingOfCure : BaseJewelry
    {
        [Constructable]
        public MRingOfCure()
            : base(JewelryEffect.Cure, Layer.Ring, 0x108A, 46, 56)
        {
            Name = "Mystic Ring Of Cure";
        }

        public MRingOfCure(Serial serial)
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
            Cast(new CureSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfRemoveTrap : BaseJewelry
    {
        [Constructable]
        public MRingOfRemoveTrap()
            : base(JewelryEffect.RemoveTrap, Layer.Ring, 0x108A, 46, 56)
        {
            Name = "Mystic Ring Of Remove Trap";
        }

        public MRingOfRemoveTrap(Serial serial)
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
            Cast(new RemoveTrapSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfMagicTrap : BaseJewelry
    {
        [Constructable]
        public MRingOfMagicTrap()
            : base(JewelryEffect.MagicTrap, Layer.Ring, 0x108A, 46, 56)
        {
            Name = "Mystic Ring Of Magic Trap";
        }

        public MRingOfMagicTrap(Serial serial)
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
            Cast(new MagicTrapSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfHarm : BaseJewelry
    {
        [Constructable]
        public MRingOfHarm()
            : base(JewelryEffect.Harm, Layer.Ring, 0x108A, 46, 56)
        {
            Name = "Mystic Ring Of Harm";
        }

        public MRingOfHarm(Serial serial)
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
            Cast(new HarmSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfAgility : BaseJewelry
    {
        [Constructable]
        public MRingOfAgility()
            : base(JewelryEffect.Agility, Layer.Ring, 0x108A, 46, 56)
        {
            Name = "Mystic Ring Of Agility";
        }

        public MRingOfAgility(Serial serial)
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
            Cast(new AgilitySpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfCunning : BaseJewelry
    {
        [Constructable]
        public MRingOfCunning()
            : base(JewelryEffect.Cunning, Layer.Ring, 0x108A, 46, 56)
        {
            Name = "Mystic Ring Of Cunning";
        }

        public MRingOfCunning(Serial serial)
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
            Cast(new CunningSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfStrength : BaseJewelry
    {
        [Constructable]
        public MRingOfStrength()
            : base(JewelryEffect.Strength, Layer.Ring, 0x108A, 46, 56)
        {
            Name = "Mystic Ring Of Strength";
        }

        public MRingOfStrength(Serial serial)
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
            Cast(new StrengthSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfProtection : BaseJewelry  // Self Target
    {
        [Constructable]
        public MRingOfProtection()
            : base(JewelryEffect.Protection, Layer.Ring, 0x108A, 46, 56)
        {
            Name = "Mystic Ring Of Protection";
        }

        public MRingOfProtection(Serial serial)
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
            Cast(new ProtectionSpell(from, this));
            OnFinish(from);
        }
    }
    #endregion

    #region Third Spell Circle 40 - 50 charges
    public class MRingOfTeleport : BaseJewelry
    {
        [Constructable]
        public MRingOfTeleport()
            : base(JewelryEffect.Teleport, Layer.Ring, 0x108A, 41, 51)
        {
            Name = "Mystic Ring Of Teleport";
        }

        public MRingOfTeleport(Serial serial)
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
    // 
    public class MRingOfTelekinesis : BaseJewelry
    {
        [Constructable]
        public MRingOfTelekinesis()
            : base(JewelryEffect.Telekinesis, Layer.Ring, 0x108A, 41, 51)
        {
            Name = "Mystic Ring Of Telekinesis";
        }

        public MRingOfTelekinesis(Serial serial)
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
            Cast(new TelekinesisSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfWallOfStone : BaseJewelry
    {
        [Constructable]
        public MRingOfWallOfStone()
            : base(JewelryEffect.WallOfStone, Layer.Ring, 0x108A, 41, 51)
        {
            Name = "Mystic Ring Of Wall Of Stone";
        }

        public MRingOfWallOfStone(Serial serial)
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
            if (SpellHelper.CheckTown(from, from))
            {
                Cast(new WallOfStoneSpell(from, this));
                OnFinish(from);
            }
            else
                return;
        }
    }
    //
    public class MRingOfMagicLock : BaseJewelry
    {
        [Constructable]
        public MRingOfMagicLock()
            : base(JewelryEffect.MagicLock, Layer.Ring, 0x108A, 41, 51)
        {
            Name = "Mystic Ring Of Magic Lock";
        }

        public MRingOfMagicLock(Serial serial)
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
            Cast(new MagicLockSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfUnlock : BaseJewelry
    {
        [Constructable]
        public MRingOfUnlock()
            : base(JewelryEffect.Unlock, Layer.Ring, 0x108A, 41, 51)
        {
            Name = "Mystic Ring Of Unlock";
        }

        public MRingOfUnlock(Serial serial)
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
            Cast(new UnlockSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfBless : BaseJewelry
    {
        [Constructable]
        public MRingOfBless()
            : base(JewelryEffect.Bless, Layer.Ring, 0x108A, 41, 51)
        {
            Name = "Mystic Ring Of Bless";
        }

        public MRingOfBless(Serial serial)
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
            Cast(new BlessSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfFireball : BaseJewelry
    {
        [Constructable]
        public MRingOfFireball()
            : base(JewelryEffect.Fireball, Layer.Ring, 0x108A, 41, 51)
        {
            Name = "Mystic Ring Of Fireball";
        }

        public MRingOfFireball(Serial serial)
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
            Cast(new FireballSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfPoison : BaseJewelry
    {
        [Constructable]
        public MRingOfPoison()
            : base(JewelryEffect.Poison, Layer.Ring, 0x108A, 41, 51)
        {
            Name = "Mystic Ring Of Poison";
        }

        public MRingOfPoison(Serial serial)
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
            Cast(new PoisonSpell(from, this));
            OnFinish(from);
        }
    }
    #endregion

    #region Forth Spell Circle 35 - 45 charges
    public class MRingOfFireField : BaseJewelry
    {
        [Constructable]
        public MRingOfFireField()
            : base(JewelryEffect.FireField, Layer.Ring, 0x108A, 36, 46)
        {
            Name = "Mystic Ring Of Fire Field";
        }

        public MRingOfFireField(Serial serial)
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
            if (SpellHelper.CheckTown(from, from))
            {
                Cast(new FireFieldSpell(from, this));
                OnFinish(from);
            }
            else
                return;
        }
    }
    //
    public class MRingOfManaDrain : BaseJewelry
    {
        [Constructable]
        public MRingOfManaDrain()
            : base(JewelryEffect.ManaDrain, Layer.Ring, 0x108A, 36, 46)
        {
            Name = "Mystic Ring Of Mana Drain";
        }

        public MRingOfManaDrain(Serial serial)
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
            Cast(new ManaDrainSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfGreaterHeal : BaseJewelry
    {
        [Constructable]
        public MRingOfGreaterHeal()
            : base(JewelryEffect.GreaterHeal, Layer.Ring, 0x108A, 36, 46)
        {
            Name = "Mystic Ring Of Greater Heal";
        }

        public MRingOfGreaterHeal(Serial serial)
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
            Cast(new GreaterHealSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfCurse : BaseJewelry
    {
        [Constructable]
        public MRingOfCurse()
            : base(JewelryEffect.Curse, Layer.Ring, 0x108A, 36, 46)
        {
            Name = "Mystic Ring Of Curse";
        }

        public MRingOfCurse(Serial serial)
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
            Cast(new CurseSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfLightning : BaseJewelry
    {
        [Constructable]
        public MRingOfLightning()
            : base(JewelryEffect.Lightning, Layer.Ring, 0x108A, 36, 46)
        {
            Name = "Mystic Ring Of Lightning";
        }

        public MRingOfLightning(Serial serial)
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
            Cast(new LightningSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfRecall : BaseJewelry
    {
        [Constructable]
        public MRingOfRecall()
            : base(JewelryEffect.Recall, Layer.Ring, 0x108A, 36, 46)
        {
            Name = "Mystic Ring Of Recall";
        }

        public MRingOfRecall(Serial serial)
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
            Cast(new RecallSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfArchProtection : BaseJewelry
    {
        [Constructable]
        public MRingOfArchProtection()
            : base(JewelryEffect.ArchProtection, Layer.Ring, 0x108A, 36, 46)
        {
            Name = "Mystic Ring Of Arch Protection";
        }

        public MRingOfArchProtection(Serial serial)
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
            Cast(new ArchProtectionSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfArchCure : BaseJewelry
    {
        [Constructable]
        public MRingOfArchCure()
            : base(JewelryEffect.ArchCure, Layer.Ring, 0x108A, 36, 46)
        {
            Name = "Mystic Ring Of Arch Cure";
        }

        public MRingOfArchCure(Serial serial)
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
            Cast(new ArchCureSpell(from, this));
            OnFinish(from);
        }
    }
    #endregion

    #region Fifth Spell Circle 30 - 40 charges
    public class MRingOfParalyze : BaseJewelry
    {
        [Constructable]
        public MRingOfParalyze()
            : base(JewelryEffect.Paralyze, Layer.Ring, 0x108A, 31, 41)
        {
            Name = "Mystic Ring Of Paralyze";
        }

        public MRingOfParalyze(Serial serial)
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
            Cast(new ParalyzeSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfMindBlast : BaseJewelry
    {
        [Constructable]
        public MRingOfMindBlast()
            : base(JewelryEffect.MindBlast, Layer.Ring, 0x108A, 31, 41)
        {
            Name = "Mystic Ring Of Mind Blast";
        }

        public MRingOfMindBlast(Serial serial)
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
            Cast(new MindBlastSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfDispelField : BaseJewelry
    {
        [Constructable]
        public MRingOfDispelField()
            : base(JewelryEffect.DispelField, Layer.Ring, 0x108A, 31, 41)
        {
            Name = "Mystic Ring Of Dispel Field";
        }

        public MRingOfDispelField(Serial serial)
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
            Cast(new DispelFieldSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfPoisonField : BaseJewelry
    {
        [Constructable]
        public MRingOfPoisonField()
            : base(JewelryEffect.PoisonField, Layer.Ring, 0x108A, 31, 41)
        {
            Name = "Mystic Ring Of Poison Field";
        }

        public MRingOfPoisonField(Serial serial)
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
            if (SpellHelper.CheckTown(from, from))
            {
                Cast(new PoisonFieldSpell(from, this));
                OnFinish(from);
            }
            else
                return;
        }
    }
    //
    public class MRingOfBladeSpirits : BaseJewelry
    {
        [Constructable]
        public MRingOfBladeSpirits()
            : base(JewelryEffect.BladeSpirits, Layer.Ring, 0x108A, 31, 41)
        {
            Name = "Mystic Ring Of Blade Spirits";
        }

        public MRingOfBladeSpirits(Serial serial)
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
            if (SpellHelper.CheckTown(from, from))
            {
            Cast(new BladeSpiritsSpell(from, this));
            OnFinish(from);
            }
            else
                return;
        }
    }
    //
    public class MRingOfMagicReflect : BaseJewelry  // Self Target
    {
        [Constructable]
        public MRingOfMagicReflect()
            : base(JewelryEffect.MagicReflect, Layer.Ring, 0x108A, 31, 41)
        {
            Name = "Mystic Ring Of Magic Reflect";
        }

        public MRingOfMagicReflect(Serial serial)
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
            Cast(new MagicReflectSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfIncognito : BaseJewelry
    {
        [Constructable]
        public MRingOfIncognito()
            : base(JewelryEffect.Incognito, Layer.Ring, 0x108A, 31, 41)
        {
            Name = "Mystic Ring Of Incognito";
        }

        public MRingOfIncognito(Serial serial)
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
            Cast(new IncognitoSpell(from, this));
            OnFinish(from);
        }
    }
    #endregion

    #region Sixth Spell Circle 25 - 35 charges
    public class MRingOfEnergyBolt : BaseJewelry
    {
        [Constructable]
        public MRingOfEnergyBolt()
            : base(JewelryEffect.EnergyBolt, Layer.Ring, 0x108A, 26, 36)
        {
            Name = "Mystic Ring Of Energy Bolt";
        }

        public MRingOfEnergyBolt(Serial serial)
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
            Cast(new EnergyBoltSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfExplosion : BaseJewelry
    {
        [Constructable]
        public MRingOfExplosion()
            : base(JewelryEffect.Explosion, Layer.Ring, 0x108A, 26, 36)
        {
            Name = "Mystic Ring Of Explosion";
        }

        public MRingOfExplosion(Serial serial)
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
            Cast(new ExplosionSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfDispel : BaseJewelry
    {
        [Constructable]
        public MRingOfDispel()
            : base(JewelryEffect.Dispel, Layer.Ring, 0x108A, 26, 36)
        {
            Name = "Mystic Ring Of Dispel";
        }

        public MRingOfDispel(Serial serial)
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
            Cast(new DispelSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfReveal : BaseJewelry
    {
        [Constructable]
        public MRingOfReveal()
            : base(JewelryEffect.Reveal, Layer.Ring, 0x108A, 26, 36)
        {
            Name = "Mystic Ring Of Reveal";
        }

        public MRingOfReveal(Serial serial)
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
            Cast(new RevealSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfMark : BaseJewelry
    {
        [Constructable]
        public MRingOfMark()
            : base(JewelryEffect.Mark, Layer.Ring, 0x108A, 26, 36)
        {
            Name = "Mystic Ring Of Mark";
        }

        public MRingOfMark(Serial serial)
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
            if (!SpellHelper.CheckTravel(from, TravelCheckType.Mark))
			{
			}
            else if (SpellHelper.CheckMulti(from.Location, from.Map, !Core.AOS))
			{
                from.SendLocalizedMessage(501942); // That location is blocked.
			}
			else 
			{
                Cast(new MarkSpell(from, this));
            }
            OnFinish(from);
        }
    }
    //
    public class MRingOfParalyzeField : BaseJewelry
    {
        [Constructable]
        public MRingOfParalyzeField()
            : base(JewelryEffect.ParalyzeField, Layer.Ring, 0x108A, 26, 36)
        {
            Name = "Mystic Ring Of Paralyze Field";
        }

        public MRingOfParalyzeField(Serial serial)
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
            if (SpellHelper.CheckTown(from, from))
            {
                Cast(new ParalyzeFieldSpell(from, this));
                OnFinish(from);
            }
            else
                return;
        }
    }
    //
    public class MRingOfInvisibility : BaseJewelry  // Self Target
    {
        [Constructable]
        public MRingOfInvisibility()
            : base(JewelryEffect.Invisibility, Layer.Ring, 0x108A, 26, 36)
        {
            Name = "Mystic Ring Of Invisibility";
        }

        public MRingOfInvisibility(Serial serial)
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
            Cast(new InvisibilitySpell(from, this));
            OnFinish(from);
        }
    }
    #endregion

    #region Seventh Spell Circle 20 - 30 charges
    public class MRingOfPolymorph : BaseJewelry
    {
        [Constructable]
        public MRingOfPolymorph()
            : base(JewelryEffect.Polymorph, Layer.Ring, 0x108A, 21, 31)
        {
            Name = "Mystic Ring Of Polymorph";
        }

        public MRingOfPolymorph(Serial serial)
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
            Cast(new PolymorphSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfManaVampire : BaseJewelry
    {
        [Constructable]
        public MRingOfManaVampire()
            : base(JewelryEffect.ManaVampire, Layer.Ring, 0x108A, 21, 31)
        {
            Name = "Mystic Ring Of Mana Vampire";
        }

        public MRingOfManaVampire(Serial serial)
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
            Cast(new ManaVampireSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfMassDispel : BaseJewelry
    {
        [Constructable]
        public MRingOfMassDispel()
            : base(JewelryEffect.MassDispel, Layer.Ring, 0x108A, 21, 31)
        {
            Name = "Mystic Ring Of Mass Dispel";
        }

        public MRingOfMassDispel(Serial serial)
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
            Cast(new MassDispelSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfMeteorSwarm : BaseJewelry
    {
        [Constructable]
        public MRingOfMeteorSwarm()
            : base(JewelryEffect.MeteorSwarm, Layer.Ring, 0x108A, 21, 31)
        {
            Name = "Mystic Ring Of Meteor Swarm";
        }

        public MRingOfMeteorSwarm(Serial serial)
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
            if (SpellHelper.CheckTown(from, from))
            {
                Cast(new MeteorSwarmSpell(from, this));
                OnFinish(from);
            }
            else
                return;
        }
    }
    //
    public class MRingOfChainLightning : BaseJewelry
    {
        [Constructable]
        public MRingOfChainLightning()
            : base(JewelryEffect.ChainLightning, Layer.Ring, 0x108A, 21, 31)
        {
            Name = "Mystic Ring Of Chain Lightning";
        }

        public MRingOfChainLightning(Serial serial)
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
            if (SpellHelper.CheckTown(from, from))
            {
                Cast(new ChainLightningSpell(from, this));
                OnFinish(from);
            }
            else
                return;
        }
    }
    //
    public class MRingOfFlameStrike : BaseJewelry
    {
        [Constructable]
        public MRingOfFlameStrike()
            : base(JewelryEffect.FlameStrike, Layer.Ring, 0x108A, 21, 31)
        {
            Name = "Mystic Ring Of Flame Strike";
        }

        public MRingOfFlameStrike(Serial serial)
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

            Cast(new FlameStrikeSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfGateTravel : BaseJewelry
    {
        [Constructable]
        public MRingOfGateTravel()
            : base(JewelryEffect.GateTravel, Layer.Ring, 0x108A, 21, 31)
        {
            Name = "Mystic Ring Of Gate Travel";
        }

        public MRingOfGateTravel(Serial serial)
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

            Cast(new GateTravelSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfEnergyField : BaseJewelry
    {
        [Constructable]
        public MRingOfEnergyField()
            : base(JewelryEffect.EnergyField, Layer.Ring, 0x108A, 21, 31)
        {
            Name = "Mystic Ring Of Energy Field";
        }

        public MRingOfEnergyField(Serial serial)
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
            if (SpellHelper.CheckTown(from, from))
            {
                Cast(new EnergyFieldSpell(from, this));
                OnFinish(from);
            }
            else
                return;
        }
    }
    #endregion

    #region Eighth Spell Circle 15 - 25 charges
    public class MRingOfWaterElemental : BaseJewelry
    {
        [Constructable]
        public MRingOfWaterElemental()
            : base(JewelryEffect.WaterElemental, Layer.Ring, 0x108A, 16, 26)
        {
            Name = "Mystic Ring Of Water Elemental";
        }

        public MRingOfWaterElemental(Serial serial)
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
            if (SpellHelper.CheckTown(from, from))
            {
                Cast(new WaterElementalSpell(from, this));
                OnFinish(from);
            }
            else
                return;
        }
    }
    //
    public class MRingOfAirElemental : BaseJewelry
    {
        [Constructable]
        public MRingOfAirElemental()
            : base(JewelryEffect.AirElemental, Layer.Ring, 0x108A, 16, 26)
        {
            Name = "Mystic Ring Of Air Elemental";
        }

        public MRingOfAirElemental(Serial serial)
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
            if (SpellHelper.CheckTown(from, from))
            {
                Cast(new AirElementalSpell(from, this));
                OnFinish(from);
            }
            else
                return;
        }
    }
    //
    public class MRingOfFireElemental : BaseJewelry
    {
        [Constructable]
        public MRingOfFireElemental()
            : base(JewelryEffect.FireElemental, Layer.Ring, 0x108A, 16, 26)
        {
            Name = "Mystic Ring Of Fire Elemental";
        }

        public MRingOfFireElemental(Serial serial)
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
            if (SpellHelper.CheckTown(from, from))
            {
                Cast(new FireElementalSpell(from, this));
                OnFinish(from);
            }
            else
                return;
        }
    }
    //
    public class MRingOfEarthElemental : BaseJewelry
    {
        [Constructable]
        public MRingOfEarthElemental()
            : base(JewelryEffect.EarthElemental, Layer.Ring, 0x108A, 16, 26)
        {
            Name = "Mystic Ring Of Earth Elemental";
        }

        public MRingOfEarthElemental(Serial serial)
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
            if (SpellHelper.CheckTown(from, from))
            {
                Cast(new EarthElementalSpell(from, this));
                OnFinish(from);
            }
            else
                return;
        }
    }
    //
    public class MRingOfEnergyVortex : BaseJewelry
    {
        [Constructable]
        public MRingOfEnergyVortex()
            : base(JewelryEffect.EnergyVortex, Layer.Ring, 0x108A, 16, 26)
        {
            Name = "Mystic Ring Of Energy Vortex";
        }

        public MRingOfEnergyVortex(Serial serial)
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
            if (SpellHelper.CheckTown(from, from))
            {
                Cast(new EnergyVortexSpell(from, this));
                OnFinish(from);
            }
            else
                return;
        }
    }
    //
    public class MRingOfSummonDaemon : BaseJewelry
    {
        [Constructable]
        public MRingOfSummonDaemon()
            : base(JewelryEffect.SummonDaemon, Layer.Ring, 0x108A, 16, 26)
        {
            Name = "Mystic Ring Of Summon Daemon";
        }

        public MRingOfSummonDaemon(Serial serial)
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
            if (SpellHelper.CheckTown(from, from))
            {
                Cast(new SummonDaemonSpell(from, this));
                OnFinish(from);
            }
            else
                return;
        }
    }
    //
    public class MRingOfResurrection : BaseJewelry
    {
        [Constructable]
        public MRingOfResurrection()
            : base(JewelryEffect.Resurrection, Layer.Ring, 0x108A, 16, 26)
        {
            Name = "Mystic Ring Of Resurrection";
        }

        public MRingOfResurrection(Serial serial)
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
            Cast(new ResurrectionSpell(from, this));
            OnFinish(from);
        }
    }
    //
    public class MRingOfEarthquake : BaseJewelry
    {

        [Constructable]
        public MRingOfEarthquake()
            : base(JewelryEffect.Earthquake, Layer.Ring, 0x108A, 4, 6)
        {
            Name = "Mystic Ring Of Earth Quake";
        }

        public MRingOfEarthquake(Serial serial)
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
            if (SpellHelper.CheckTown(from, from))
            {
                this.Cast(new EarthquakeSpell(from, this));
                OnFinish(from);
            }
            else
                return;
        }
    }
    #endregion
}