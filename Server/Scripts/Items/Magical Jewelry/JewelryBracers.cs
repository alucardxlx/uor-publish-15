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
    public class MBracerOfClumsy : BaseJewelry
    {
        [Constructable]
        public MBracerOfClumsy()
            : base(JewelryEffect.Clumsy, Layer.Bracelet, 0x1086, 51, 61)
        {
            Name = "Mystic Bracer Of Clumsy";
        }

        public MBracerOfClumsy(Serial serial)
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
    public class MBracerOfHeal : BaseJewelry
    {
        [Constructable]
        public MBracerOfHeal()
            : base(JewelryEffect.Heal, Layer.Bracelet, 0x1086, 51, 61)
        {
            Name = "Mystic Bracer Of Heal";
        }

        public MBracerOfHeal(Serial serial)
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
    public class MBracerOfMagicArrow : BaseJewelry
    {
        [Constructable]
        public MBracerOfMagicArrow()
            : base(JewelryEffect.MagicArrow, Layer.Bracelet, 0x1086, 51, 61)
        {
            Name = "Mystic Bracer Of Magic Arrow";
        }

        public MBracerOfMagicArrow(Serial serial)
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
    public class MBracerOfFeeblemind : BaseJewelry
    {
        [Constructable]
        public MBracerOfFeeblemind()
            : base(JewelryEffect.Feeblemind, Layer.Bracelet, 0x1086, 51, 61)
        {
            Name = "Mystic Bracer Of Feeblemind";
        }

        public MBracerOfFeeblemind(Serial serial)
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
    public class MBracerOfWeaken : BaseJewelry
    {
        [Constructable]
        public MBracerOfWeaken()
            : base(JewelryEffect.Weaken, Layer.Bracelet, 0x1086, 51, 61)
        {
            Name = "Mystic Bracer Of Weaken";
        }

        public MBracerOfWeaken(Serial serial)
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
    public class MBracerOfCreateFood : BaseJewelry   // Self Target
    {
        [Constructable]
        public MBracerOfCreateFood()
            : base(JewelryEffect.CreateFood, Layer.Bracelet, 0x1086, 51, 61)
        {
            Name = "Mystic Bracer Of Create Food";
        }

        public MBracerOfCreateFood(Serial serial)
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
    public class MBracerOfNightSight : BaseJewelry  // Self Target
    {
        [Constructable]
        public MBracerOfNightSight()
            : base(JewelryEffect.NightSight, Layer.Bracelet, 0x1086, 51, 61)
        {
            Name = "Mystic Bracer Of Night Sight";
        }

        public MBracerOfNightSight(Serial serial)
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
    public class MBracerOfReactiveArmor : BaseJewelry  // Self Target
    {
        [Constructable]
        public MBracerOfReactiveArmor()
            : base(JewelryEffect.ReactiveArmor, Layer.Bracelet, 0x1086, 51, 61)
        {
            Name = "Mystic Bracer Of ReactiveArmor";
        }

        public MBracerOfReactiveArmor(Serial serial)
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
    public class MBracerOfCure : BaseJewelry
    {
        [Constructable]
        public MBracerOfCure()
            : base(JewelryEffect.Cure, Layer.Bracelet, 0x1086, 46, 56)
        {
            Name = "Mystic Bracer Of Cure";
        }

        public MBracerOfCure(Serial serial)
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
    public class MBracerOfRemoveTrap : BaseJewelry
    {
        [Constructable]
        public MBracerOfRemoveTrap()
            : base(JewelryEffect.RemoveTrap, Layer.Bracelet, 0x1086, 46, 56)
        {
            Name = "Mystic Bracer Of Remove Trap";
        }

        public MBracerOfRemoveTrap(Serial serial)
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
    public class MBracerOfMagicTrap : BaseJewelry
    {
        [Constructable]
        public MBracerOfMagicTrap()
            : base(JewelryEffect.MagicTrap, Layer.Bracelet, 0x1086, 46, 56)
        {
            Name = "Mystic Bracer Of Magic Trap";
        }

        public MBracerOfMagicTrap(Serial serial)
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
    public class MBracerOfHarm : BaseJewelry
    {
        [Constructable]
        public MBracerOfHarm()
            : base(JewelryEffect.Harm, Layer.Bracelet, 0x1086, 46, 56)
        {
            Name = "Mystic Bracer Of Harm";
        }

        public MBracerOfHarm(Serial serial)
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
    public class MBracerOfAgility : BaseJewelry
    {
        [Constructable]
        public MBracerOfAgility()
            : base(JewelryEffect.Agility, Layer.Bracelet, 0x1086, 46, 56)
        {
            Name = "Mystic Bracer Of Agility";
        }

        public MBracerOfAgility(Serial serial)
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
    public class MBracerOfCunning : BaseJewelry
    {
        [Constructable]
        public MBracerOfCunning()
            : base(JewelryEffect.Cunning, Layer.Bracelet, 0x1086, 46, 56)
        {
            Name = "Mystic Bracer Of Cunning";
        }

        public MBracerOfCunning(Serial serial)
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
    public class MBracerOfStrength : BaseJewelry
    {
        [Constructable]
        public MBracerOfStrength()
            : base(JewelryEffect.Strength, Layer.Bracelet, 0x1086, 46, 56)
        {
            Name = "Mystic Bracer Of Strength";
        }

        public MBracerOfStrength(Serial serial)
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
    public class MBracerOfProtection : BaseJewelry  // Self Target
    {
        [Constructable]
        public MBracerOfProtection()
            : base(JewelryEffect.Protection, Layer.Bracelet, 0x1086, 46, 56)
        {
            Name = "Mystic Bracer Of Protection";
        }

        public MBracerOfProtection(Serial serial)
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
    public class MBracerOfTeleport : BaseJewelry
    {
        [Constructable]
        public MBracerOfTeleport()
            : base(JewelryEffect.Teleport, Layer.Bracelet, 0x1086, 41, 51)
        {
            Name = "Mystic Bracer Of Teleport";
        }

        public MBracerOfTeleport(Serial serial)
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
    public class MBracerOfTelekinesis : BaseJewelry
    {
        [Constructable]
        public MBracerOfTelekinesis()
            : base(JewelryEffect.Telekinesis, Layer.Bracelet, 0x1086, 41, 51)
        {
            Name = "Mystic Bracer Of Telekinesis";
        }

        public MBracerOfTelekinesis(Serial serial)
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
    public class MBracerOfWallOfStone : BaseJewelry
    {
        [Constructable]
        public MBracerOfWallOfStone()
            : base(JewelryEffect.WallOfStone, Layer.Bracelet, 0x1086, 41, 51)
        {
            Name = "Mystic Bracer Of Wall Of Stone";
        }

        public MBracerOfWallOfStone(Serial serial)
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
    public class MBracerOfMagicLock : BaseJewelry
    {
        [Constructable]
        public MBracerOfMagicLock()
            : base(JewelryEffect.MagicLock, Layer.Bracelet, 0x1086, 41, 51)
        {
            Name = "Mystic Bracer Of Magic Lock";
        }

        public MBracerOfMagicLock(Serial serial)
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
    public class MBracerOfUnlock : BaseJewelry
    {
        [Constructable]
        public MBracerOfUnlock()
            : base(JewelryEffect.Unlock, Layer.Bracelet, 0x1086, 41, 51)
        {
            Name = "Mystic Bracer Of Unlock";
        }

        public MBracerOfUnlock(Serial serial)
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
    public class MBracerOfBless : BaseJewelry
    {
        [Constructable]
        public MBracerOfBless()
            : base(JewelryEffect.Bless, Layer.Bracelet, 0x1086, 41, 51)
        {
            Name = "Mystic Bracer Of Bless";
        }

        public MBracerOfBless(Serial serial)
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
    public class MBracerOfFireball : BaseJewelry
    {
        [Constructable]
        public MBracerOfFireball()
            : base(JewelryEffect.Fireball, Layer.Bracelet, 0x1086, 41, 51)
        {
            Name = "Mystic Bracer Of Fireball";
        }

        public MBracerOfFireball(Serial serial)
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
    public class MBracerOfPoison : BaseJewelry
    {
        [Constructable]
        public MBracerOfPoison()
            : base(JewelryEffect.Poison, Layer.Bracelet, 0x1086, 41, 51)
        {
            Name = "Mystic Bracer Of Poison";
        }

        public MBracerOfPoison(Serial serial)
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
    public class MBracerOfFireField : BaseJewelry
    {
        [Constructable]
        public MBracerOfFireField()
            : base(JewelryEffect.FireField, Layer.Bracelet, 0x1086, 36, 46)
        {
            Name = "Mystic Bracer Of Fire Field";
        }

        public MBracerOfFireField(Serial serial)
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
    public class MBracerOfManaDrain : BaseJewelry
    {
        [Constructable]
        public MBracerOfManaDrain()
            : base(JewelryEffect.ManaDrain, Layer.Bracelet, 0x1086, 36, 46)
        {
            Name = "Mystic Bracer Of Mana Drain";
        }

        public MBracerOfManaDrain(Serial serial)
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
    public class MBracerOfGreaterHeal : BaseJewelry
    {
        [Constructable]
        public MBracerOfGreaterHeal()
            : base(JewelryEffect.GreaterHeal, Layer.Bracelet, 0x1086, 36, 46)
        {
            Name = "Mystic Bracer Of Greater Heal";
        }

        public MBracerOfGreaterHeal(Serial serial)
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
    public class MBracerOfCurse : BaseJewelry
    {
        [Constructable]
        public MBracerOfCurse()
            : base(JewelryEffect.Curse, Layer.Bracelet, 0x1086, 36, 46)
        {
            Name = "Mystic Bracer Of Curse";
        }

        public MBracerOfCurse(Serial serial)
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
    public class MBracerOfLightning : BaseJewelry
    {
        [Constructable]
        public MBracerOfLightning()
            : base(JewelryEffect.Lightning, Layer.Bracelet, 0x1086, 36, 46)
        {
            Name = "Mystic Bracer Of Lightning";
        }

        public MBracerOfLightning(Serial serial)
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
    public class MBracerOfRecall : BaseJewelry
    {
        [Constructable]
        public MBracerOfRecall()
            : base(JewelryEffect.Recall, Layer.Bracelet, 0x1086, 36, 46)
        {
            Name = "Mystic Bracer Of Recall";
        }

        public MBracerOfRecall(Serial serial)
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
    public class MBracerOfArchProtection : BaseJewelry
    {
        [Constructable]
        public MBracerOfArchProtection()
            : base(JewelryEffect.ArchProtection, Layer.Bracelet, 0x1086, 36, 46)
        {
            Name = "Mystic Bracer Of Arch Protection";
        }

        public MBracerOfArchProtection(Serial serial)
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
    public class MBracerOfArchCure : BaseJewelry
    {
        [Constructable]
        public MBracerOfArchCure()
            : base(JewelryEffect.ArchCure, Layer.Bracelet, 0x1086, 36, 46)
        {
            Name = "Mystic Bracer Of Arch Cure";
        }

        public MBracerOfArchCure(Serial serial)
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
    public class MBracerOfParalyze : BaseJewelry
    {
        [Constructable]
        public MBracerOfParalyze()
            : base(JewelryEffect.Paralyze, Layer.Bracelet, 0x1086, 31, 41)
        {
            Name = "Mystic Bracer Of Paralyze";
        }

        public MBracerOfParalyze(Serial serial)
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
    public class MBracerOfMindBlast : BaseJewelry
    {
        [Constructable]
        public MBracerOfMindBlast()
            : base(JewelryEffect.MindBlast, Layer.Bracelet, 0x1086, 31, 41)
        {
            Name = "Mystic Bracer Of Mind Blast";
        }

        public MBracerOfMindBlast(Serial serial)
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
    public class MBracerOfDispelField : BaseJewelry
    {
        [Constructable]
        public MBracerOfDispelField()
            : base(JewelryEffect.DispelField, Layer.Bracelet, 0x1086, 31, 41)
        {
            Name = "Mystic Bracer Of Dispel Field";
        }

        public MBracerOfDispelField(Serial serial)
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
    public class MBracerOfPoisonField : BaseJewelry
    {
        [Constructable]
        public MBracerOfPoisonField()
            : base(JewelryEffect.PoisonField, Layer.Bracelet, 0x1086, 31, 41)
        {
            Name = "Mystic Bracer Of Poison Field";
        }

        public MBracerOfPoisonField(Serial serial)
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
    public class MBracerOfBladeSpirits : BaseJewelry
    {
        [Constructable]
        public MBracerOfBladeSpirits()
            : base(JewelryEffect.BladeSpirits, Layer.Bracelet, 0x1086, 31, 41)
        {
            Name = "Mystic Bracer Of Blade Spirits";
        }

        public MBracerOfBladeSpirits(Serial serial)
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
    public class MBracerOfMagicReflect : BaseJewelry  // Self Target
    {
        [Constructable]
        public MBracerOfMagicReflect()
            : base(JewelryEffect.MagicReflect, Layer.Bracelet, 0x1086, 31, 41)
        {
            Name = "Mystic Bracer Of Magic Reflect";
        }

        public MBracerOfMagicReflect(Serial serial)
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
    public class MBracerOfIncognito : BaseJewelry
    {
        [Constructable]
        public MBracerOfIncognito()
            : base(JewelryEffect.Incognito, Layer.Bracelet, 0x1086, 31, 41)
        {
            Name = "Mystic Bracer Of Incognito";
        }

        public MBracerOfIncognito(Serial serial)
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
    public class MBracerOfEnergyBolt : BaseJewelry
    {
        [Constructable]
        public MBracerOfEnergyBolt()
            : base(JewelryEffect.EnergyBolt, Layer.Bracelet, 0x1086, 26, 36)
        {
            Name = "Mystic Bracer Of Energy Bolt";
        }

        public MBracerOfEnergyBolt(Serial serial)
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
    public class MBracerOfExplosion : BaseJewelry
    {
        [Constructable]
        public MBracerOfExplosion()
            : base(JewelryEffect.Explosion, Layer.Bracelet, 0x1086, 26, 36)
        {
            Name = "Mystic Bracer Of Explosion";
        }

        public MBracerOfExplosion(Serial serial)
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
    public class MBracerOfDispel : BaseJewelry
    {
        [Constructable]
        public MBracerOfDispel()
            : base(JewelryEffect.Dispel, Layer.Bracelet, 0x1086, 26, 36)
        {
            Name = "Mystic Bracer Of Dispel";
        }

        public MBracerOfDispel(Serial serial)
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
    public class MBracerOfReveal : BaseJewelry
    {
        [Constructable]
        public MBracerOfReveal()
            : base(JewelryEffect.Reveal, Layer.Bracelet, 0x1086, 26, 36)
        {
            Name = "Mystic Bracer Of Reveal";
        }

        public MBracerOfReveal(Serial serial)
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
    public class MBracerOfMark : BaseJewelry
    {
        [Constructable]
        public MBracerOfMark()
            : base(JewelryEffect.Mark, Layer.Bracelet, 0x1086, 26, 36)
        {
            Name = "Mystic Bracer Of Mark";
        }

        public MBracerOfMark(Serial serial)
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
    public class MBracerOfParalyzeField : BaseJewelry
    {
        [Constructable]
        public MBracerOfParalyzeField()
            : base(JewelryEffect.ParalyzeField, Layer.Bracelet, 0x1086, 26, 36)
        {
            Name = "Mystic Bracer Of Paralyze Field";
        }

        public MBracerOfParalyzeField(Serial serial)
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
    public class MBracerOfInvisibility : BaseJewelry  // Self Target
    {
        [Constructable]
        public MBracerOfInvisibility()
            : base(JewelryEffect.Invisibility, Layer.Bracelet, 0x1086, 26, 36)
        {
            Name = "Mystic Bracer Of Invisibility";
        }

        public MBracerOfInvisibility(Serial serial)
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
    public class MBracerOfPolymorph : BaseJewelry
    {
        [Constructable]
        public MBracerOfPolymorph()
            : base(JewelryEffect.Polymorph, Layer.Bracelet, 0x1086, 21, 31)
        {
            Name = "Mystic Bracer Of Polymorph";
        }

        public MBracerOfPolymorph(Serial serial)
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
    public class MBracerOfManaVampire : BaseJewelry
    {
        [Constructable]
        public MBracerOfManaVampire()
            : base(JewelryEffect.ManaVampire, Layer.Bracelet, 0x1086, 21, 31)
        {
            Name = "Mystic Bracer Of Mana Vampire";
        }

        public MBracerOfManaVampire(Serial serial)
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
    public class MBracerOfMassDispel : BaseJewelry
    {
        [Constructable]
        public MBracerOfMassDispel()
            : base(JewelryEffect.MassDispel, Layer.Bracelet, 0x1086, 21, 31)
        {
            Name = "Mystic Bracer Of Mass Dispel";
        }

        public MBracerOfMassDispel(Serial serial)
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
    public class MBracerOfMeteorSwarm : BaseJewelry
    {
        [Constructable]
        public MBracerOfMeteorSwarm()
            : base(JewelryEffect.MeteorSwarm, Layer.Bracelet, 0x1086, 21, 31)
        {
            Name = "Mystic Bracer Of Meteor Swarm";
        }

        public MBracerOfMeteorSwarm(Serial serial)
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
    public class MBracerOfChainLightning : BaseJewelry
    {
        [Constructable]
        public MBracerOfChainLightning()
            : base(JewelryEffect.ChainLightning, Layer.Bracelet, 0x1086, 21, 31)
        {
            Name = "Mystic Bracer Of Chain Lightning";
        }

        public MBracerOfChainLightning(Serial serial)
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
    public class MBracerOfFlameStrike : BaseJewelry
    {
        [Constructable]
        public MBracerOfFlameStrike()
            : base(JewelryEffect.FlameStrike, Layer.Bracelet, 0x1086, 21, 31)
        {
            Name = "Mystic Bracer Of Flame Strike";
        }

        public MBracerOfFlameStrike(Serial serial)
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
    public class MBracerOfGateTravel : BaseJewelry
    {
        [Constructable]
        public MBracerOfGateTravel()
            : base(JewelryEffect.GateTravel, Layer.Bracelet, 0x1086, 21, 31)
        {
            Name = "Mystic Bracer Of Gate Travel";
        }

        public MBracerOfGateTravel(Serial serial)
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
    public class MBracerOfEnergyField : BaseJewelry
    {
        [Constructable]
        public MBracerOfEnergyField()
            : base(JewelryEffect.EnergyField, Layer.Bracelet, 0x1086, 21, 31)
        {
            Name = "Mystic Bracer Of Energy Field";
        }

        public MBracerOfEnergyField(Serial serial)
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
    public class MBracerOfWaterElemental : BaseJewelry
    {
        [Constructable]
        public MBracerOfWaterElemental()
            : base(JewelryEffect.WaterElemental, Layer.Bracelet, 0x1086, 16, 26)
        {
            Name = "Mystic Bracer Of Water Elemental";
        }

        public MBracerOfWaterElemental(Serial serial)
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
    public class MBracerOfAirElemental : BaseJewelry
    {
        [Constructable]
        public MBracerOfAirElemental()
            : base(JewelryEffect.AirElemental, Layer.Bracelet, 0x1086, 16, 26)
        {
            Name = "Mystic Bracer Of Air Elemental";
        }

        public MBracerOfAirElemental(Serial serial)
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
    public class MBracerOfFireElemental : BaseJewelry
    {
        [Constructable]
        public MBracerOfFireElemental()
            : base(JewelryEffect.FireElemental, Layer.Bracelet, 0x1086, 16, 26)
        {
            Name = "Mystic Bracer Of Fire Elemental";
        }

        public MBracerOfFireElemental(Serial serial)
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
    public class MBracerOfEarthElemental : BaseJewelry
    {
        [Constructable]
        public MBracerOfEarthElemental()
            : base(JewelryEffect.EarthElemental, Layer.Bracelet, 0x1086, 16, 26)
        {
            Name = "Mystic Bracer Of Earth Elemental";
        }

        public MBracerOfEarthElemental(Serial serial)
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
    public class MBracerOfEnergyVortex : BaseJewelry
    {
        [Constructable]
        public MBracerOfEnergyVortex()
            : base(JewelryEffect.EnergyVortex, Layer.Bracelet, 0x1086, 16, 26)
        {
            Name = "Mystic Bracer Of Energy Vortex";
        }

        public MBracerOfEnergyVortex(Serial serial)
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
    public class MBracerOfSummonDaemon : BaseJewelry
    {
        [Constructable]
        public MBracerOfSummonDaemon()
            : base(JewelryEffect.SummonDaemon, Layer.Bracelet, 0x1086, 16, 26)
        {
            Name = "Mystic Bracer Of Summon Daemon";
        }

        public MBracerOfSummonDaemon(Serial serial)
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
    public class MBracerOfResurrection : BaseJewelry
    {
        [Constructable]
        public MBracerOfResurrection()
            : base(JewelryEffect.Resurrection, Layer.Bracelet, 0x1086, 16, 26)
        {
            Name = "Mystic Bracer Of Resurrection";
        }

        public MBracerOfResurrection(Serial serial)
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
    public class MBracerOfEarthquake : BaseJewelry
    {

        [Constructable]
        public MBracerOfEarthquake()
            : base(JewelryEffect.Earthquake, Layer.Bracelet, 0x1086, 4, 6)
        {
            Name = "Mystic Bracer Of Earth Quake";
        }

        public MBracerOfEarthquake(Serial serial)
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