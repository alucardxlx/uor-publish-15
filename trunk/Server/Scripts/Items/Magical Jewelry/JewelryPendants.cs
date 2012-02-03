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
    public class MPendantOfClumsy : BaseJewelry
    {
        [Constructable]
        public MPendantOfClumsy()
            : base(JewelryEffect.Clumsy, Layer.Neck, 0x1088, 51, 61)
        {
             //Name = "Mystic Pendant Of Clumsy";
        }

        public MPendantOfClumsy(Serial serial)
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
    public class MPendantOfHeal : BaseJewelry
    {
        [Constructable]
        public MPendantOfHeal()
            : base(JewelryEffect.Heal, Layer.Neck, 0x1088, 51, 61)
        {
             //Name = "Mystic Pendant Of Heal";
        }

        public MPendantOfHeal(Serial serial)
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
    public class MPendantOfMagicArrow : BaseJewelry
    {
        [Constructable]
        public MPendantOfMagicArrow()
            : base(JewelryEffect.MagicArrow, Layer.Neck, 0x1088, 51, 61)
        {
             //Name = "Mystic Pendant Of Magic Arrow";
        }

        public MPendantOfMagicArrow(Serial serial)
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
    public class MPendantOfFeeblemind : BaseJewelry
    {
        [Constructable]
        public MPendantOfFeeblemind()
            : base(JewelryEffect.Feeblemind, Layer.Neck, 0x1088, 51, 61)
        {
             //Name = "Mystic Pendant Of Feeblemind";
        }

        public MPendantOfFeeblemind(Serial serial)
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
    public class MPendantOfWeaken : BaseJewelry
    {
        [Constructable]
        public MPendantOfWeaken()
            : base(JewelryEffect.Weaken, Layer.Neck, 0x1088, 51, 61)
        {
             //Name = "Mystic Pendant Of Weaken";
        }

        public MPendantOfWeaken(Serial serial)
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
    public class MPendantOfCreateFood : BaseJewelry   // Self Target
    {
        [Constructable]
        public MPendantOfCreateFood()
            : base(JewelryEffect.CreateFood, Layer.Neck, 0x1088, 51, 61)
        {
             //Name = "Mystic Pendant Of Create Food";
        }

        public MPendantOfCreateFood(Serial serial)
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
    public class MPendantOfNightSight : BaseJewelry  // Self Target
    {
        [Constructable]
        public MPendantOfNightSight()
            : base(JewelryEffect.NightSight, Layer.Neck, 0x1088, 51, 61)
        {
             //Name = "Mystic Pendant Of Night Sight";
        }

        public MPendantOfNightSight(Serial serial)
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
    public class MPendantOfReactiveArmor : BaseJewelry  // Self Target
    {
        [Constructable]
        public MPendantOfReactiveArmor()
            : base(JewelryEffect.ReactiveArmor, Layer.Neck, 0x1088, 51, 61)
        {
             //Name = "Mystic Pendant Of ReactiveArmor";
        }

        public MPendantOfReactiveArmor(Serial serial)
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
    public class MPendantOfCure : BaseJewelry
    {
        [Constructable]
        public MPendantOfCure()
            : base(JewelryEffect.Cure, Layer.Neck, 0x1088, 46, 56)
        {
             //Name = "Mystic Pendant Of Cure";
        }

        public MPendantOfCure(Serial serial)
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
    public class MPendantOfRemoveTrap : BaseJewelry
    {
        [Constructable]
        public MPendantOfRemoveTrap()
            : base(JewelryEffect.RemoveTrap, Layer.Neck, 0x1088, 46, 56)
        {
             //Name = "Mystic Pendant Of Remove Trap";
        }

        public MPendantOfRemoveTrap(Serial serial)
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
    public class MPendantOfMagicTrap : BaseJewelry
    {
        [Constructable]
        public MPendantOfMagicTrap()
            : base(JewelryEffect.MagicTrap, Layer.Neck, 0x1088, 46, 56)
        {
             //Name = "Mystic Pendant Of Magic Trap";
        }

        public MPendantOfMagicTrap(Serial serial)
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
    public class MPendantOfHarm : BaseJewelry
    {
        [Constructable]
        public MPendantOfHarm()
            : base(JewelryEffect.Harm, Layer.Neck, 0x1088, 46, 56)
        {
             //Name = "Mystic Pendant Of Harm";
        }

        public MPendantOfHarm(Serial serial)
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
    public class MPendantOfAgility : BaseJewelry
    {
        [Constructable]
        public MPendantOfAgility()
            : base(JewelryEffect.Agility, Layer.Neck, 0x1088, 46, 56)
        {
             //Name = "Mystic Pendant Of Agility";
        }

        public MPendantOfAgility(Serial serial)
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
    public class MPendantOfCunning : BaseJewelry
    {
        [Constructable]
        public MPendantOfCunning()
            : base(JewelryEffect.Cunning, Layer.Neck, 0x1088, 46, 56)
        {
             //Name = "Mystic Pendant Of Cunning";
        }

        public MPendantOfCunning(Serial serial)
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
    public class MPendantOfStrength : BaseJewelry
    {
        [Constructable]
        public MPendantOfStrength()
            : base(JewelryEffect.Strength, Layer.Neck, 0x1088, 46, 56)
        {
             //Name = "Mystic Pendant Of Strength";
        }

        public MPendantOfStrength(Serial serial)
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
    public class MPendantOfProtection : BaseJewelry  // Self Target
    {
        [Constructable]
        public MPendantOfProtection()
            : base(JewelryEffect.Protection, Layer.Neck, 0x1088, 46, 56)
        {
             //Name = "Mystic Pendant Of Protection";
        }

        public MPendantOfProtection(Serial serial)
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
    public class MPendantOfTeleport : BaseJewelry
    {
        [Constructable]
        public MPendantOfTeleport()
            : base(JewelryEffect.Teleport, Layer.Neck, 0x1088, 41, 51)
        {
             //Name = "Mystic Pendant Of Teleport";
        }

        public MPendantOfTeleport(Serial serial)
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
    public class MPendantOfTelekinesis : BaseJewelry
    {
        [Constructable]
        public MPendantOfTelekinesis()
            : base(JewelryEffect.Telekinesis, Layer.Neck, 0x1088, 41, 51)
        {
             //Name = "Mystic Pendant Of Telekinesis";
        }

        public MPendantOfTelekinesis(Serial serial)
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
    public class MPendantOfWallOfStone : BaseJewelry
    {
        [Constructable]
        public MPendantOfWallOfStone()
            : base(JewelryEffect.WallOfStone, Layer.Neck, 0x1088, 41, 51)
        {
             //Name = "Mystic Pendant Of Wall Of Stone";
        }

        public MPendantOfWallOfStone(Serial serial)
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
    public class MPendantOfMagicLock : BaseJewelry
    {
        [Constructable]
        public MPendantOfMagicLock()
            : base(JewelryEffect.MagicLock, Layer.Neck, 0x1088, 41, 51)
        {
             //Name = "Mystic Pendant Of Magic Lock";
        }

        public MPendantOfMagicLock(Serial serial)
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
    public class MPendantOfUnlock : BaseJewelry
    {
        [Constructable]
        public MPendantOfUnlock()
            : base(JewelryEffect.Unlock, Layer.Neck, 0x1088, 41, 51)
        {
             //Name = "Mystic Pendant Of Unlock";
        }

        public MPendantOfUnlock(Serial serial)
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
    public class MPendantOfBless : BaseJewelry
    {
        [Constructable]
        public MPendantOfBless()
            : base(JewelryEffect.Bless, Layer.Neck, 0x1088, 41, 51)
        {
             //Name = "Mystic Pendant Of Bless";
        }

        public MPendantOfBless(Serial serial)
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
    public class MPendantOfFireball : BaseJewelry
    {
        [Constructable]
        public MPendantOfFireball()
            : base(JewelryEffect.Fireball, Layer.Neck, 0x1088, 41, 51)
        {
             //Name = "Mystic Pendant Of Fireball";
        }

        public MPendantOfFireball(Serial serial)
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
    public class MPendantOfPoison : BaseJewelry
    {
        [Constructable]
        public MPendantOfPoison()
            : base(JewelryEffect.Poison, Layer.Neck, 0x1088, 41, 51)
        {
             //Name = "Mystic Pendant Of Poison";
        }

        public MPendantOfPoison(Serial serial)
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
    public class MPendantOfFireField : BaseJewelry
    {
        [Constructable]
        public MPendantOfFireField()
            : base(JewelryEffect.FireField, Layer.Neck, 0x1088, 36, 46)
        {
             //Name = "Mystic Pendant Of Fire Field";
        }

        public MPendantOfFireField(Serial serial)
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
    public class MPendantOfManaDrain : BaseJewelry
    {
        [Constructable]
        public MPendantOfManaDrain()
            : base(JewelryEffect.ManaDrain, Layer.Neck, 0x1088, 36, 46)
        {
             //Name = "Mystic Pendant Of Mana Drain";
        }

        public MPendantOfManaDrain(Serial serial)
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
    public class MPendantOfGreaterHeal : BaseJewelry
    {
        [Constructable]
        public MPendantOfGreaterHeal()
            : base(JewelryEffect.GreaterHeal, Layer.Neck, 0x1088, 36, 46)
        {
             //Name = "Mystic Pendant Of Greater Heal";
        }

        public MPendantOfGreaterHeal(Serial serial)
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
    public class MPendantOfCurse : BaseJewelry
    {
        [Constructable]
        public MPendantOfCurse()
            : base(JewelryEffect.Curse, Layer.Neck, 0x1088, 36, 46)
        {
             //Name = "Mystic Pendant Of Curse";
        }

        public MPendantOfCurse(Serial serial)
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
    public class MPendantOfLightning : BaseJewelry
    {
        [Constructable]
        public MPendantOfLightning()
            : base(JewelryEffect.Lightning, Layer.Neck, 0x1088, 36, 46)
        {
             //Name = "Mystic Pendant Of Lightning";
        }

        public MPendantOfLightning(Serial serial)
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
    public class MPendantOfRecall : BaseJewelry
    {
        [Constructable]
        public MPendantOfRecall()
            : base(JewelryEffect.Recall, Layer.Neck, 0x1088, 36, 46)
        {
             //Name = "Mystic Pendant Of Recall";
        }

        public MPendantOfRecall(Serial serial)
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
    public class MPendantOfArchProtection : BaseJewelry
    {
        [Constructable]
        public MPendantOfArchProtection()
            : base(JewelryEffect.ArchProtection, Layer.Neck, 0x1088, 36, 46)
        {
             //Name = "Mystic Pendant Of Arch Protection";
        }

        public MPendantOfArchProtection(Serial serial)
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
    public class MPendantOfArchCure : BaseJewelry
    {
        [Constructable]
        public MPendantOfArchCure()
            : base(JewelryEffect.ArchCure, Layer.Neck, 0x1088, 36, 46)
        {
             //Name = "Mystic Pendant Of Arch Cure";
        }

        public MPendantOfArchCure(Serial serial)
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
    public class MPendantOfParalyze : BaseJewelry
    {
        [Constructable]
        public MPendantOfParalyze()
            : base(JewelryEffect.Paralyze, Layer.Neck, 0x1088, 31, 41)
        {
             //Name = "Mystic Pendant Of Paralyze";
        }

        public MPendantOfParalyze(Serial serial)
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
    public class MPendantOfMindBlast : BaseJewelry
    {
        [Constructable]
        public MPendantOfMindBlast()
            : base(JewelryEffect.MindBlast, Layer.Neck, 0x1088, 31, 41)
        {
             //Name = "Mystic Pendant Of Mind Blast";
        }

        public MPendantOfMindBlast(Serial serial)
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
    public class MPendantOfDispelField : BaseJewelry
    {
        [Constructable]
        public MPendantOfDispelField()
            : base(JewelryEffect.DispelField, Layer.Neck, 0x1088, 31, 41)
        {
             //Name = "Mystic Pendant Of Dispel Field";
        }

        public MPendantOfDispelField(Serial serial)
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
    public class MPendantOfPoisonField : BaseJewelry
    {
        [Constructable]
        public MPendantOfPoisonField()
            : base(JewelryEffect.PoisonField, Layer.Neck, 0x1088, 31, 41)
        {
             //Name = "Mystic Pendant Of Poison Field";
        }

        public MPendantOfPoisonField(Serial serial)
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
    public class MPendantOfBladeSpirits : BaseJewelry
    {
        [Constructable]
        public MPendantOfBladeSpirits()
            : base(JewelryEffect.BladeSpirits, Layer.Neck, 0x1088, 31, 41)
        {
             //Name = "Mystic Pendant Of Blade Spirits";
        }

        public MPendantOfBladeSpirits(Serial serial)
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
    public class MPendantOfMagicReflect : BaseJewelry  // Self Target
    {
        [Constructable]
        public MPendantOfMagicReflect()
            : base(JewelryEffect.MagicReflect, Layer.Neck, 0x1088, 31, 41)
        {
             //Name = "Mystic Pendant Of Magic Reflect";
        }

        public MPendantOfMagicReflect(Serial serial)
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
    public class MPendantOfIncognito : BaseJewelry
    {
        [Constructable]
        public MPendantOfIncognito()
            : base(JewelryEffect.Incognito, Layer.Neck, 0x1088, 31, 41)
        {
             //Name = "Mystic Pendant Of Incognito";
        }

        public MPendantOfIncognito(Serial serial)
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
    public class MPendantOfEnergyBolt : BaseJewelry
    {
        [Constructable]
        public MPendantOfEnergyBolt()
            : base(JewelryEffect.EnergyBolt, Layer.Neck, 0x1088, 26, 36)
        {
             //Name = "Mystic Pendant Of Energy Bolt";
        }

        public MPendantOfEnergyBolt(Serial serial)
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
    public class MPendantOfExplosion : BaseJewelry
    {
        [Constructable]
        public MPendantOfExplosion()
            : base(JewelryEffect.Explosion, Layer.Neck, 0x1088, 26, 36)
        {
             //Name = "Mystic Pendant Of Explosion";
        }

        public MPendantOfExplosion(Serial serial)
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
    public class MPendantOfDispel : BaseJewelry
    {
        [Constructable]
        public MPendantOfDispel()
            : base(JewelryEffect.Dispel, Layer.Neck, 0x1088, 26, 36)
        {
             //Name = "Mystic Pendant Of Dispel";
        }

        public MPendantOfDispel(Serial serial)
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
    public class MPendantOfReveal : BaseJewelry
    {
        [Constructable]
        public MPendantOfReveal()
            : base(JewelryEffect.Reveal, Layer.Neck, 0x1088, 26, 36)
        {
             //Name = "Mystic Pendant Of Reveal";
        }

        public MPendantOfReveal(Serial serial)
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
    public class MPendantOfMark : BaseJewelry
    {
        [Constructable]
        public MPendantOfMark()
            : base(JewelryEffect.Mark, Layer.Neck, 0x1088, 26, 36)
        {
             //Name = "Mystic Pendant Of Mark";
        }

        public MPendantOfMark(Serial serial)
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
    public class MPendantOfParalyzeField : BaseJewelry
    {
        [Constructable]
        public MPendantOfParalyzeField()
            : base(JewelryEffect.ParalyzeField, Layer.Neck, 0x1088, 26, 36)
        {
             //Name = "Mystic Pendant Of Paralyze Field";
        }

        public MPendantOfParalyzeField(Serial serial)
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
    public class MPendantOfInvisibility : BaseJewelry  // Self Target
    {
        [Constructable]
        public MPendantOfInvisibility()
            : base(JewelryEffect.Invisibility, Layer.Neck, 0x1088, 26, 36)
        {
             //Name = "Mystic Pendant Of Invisibility";
        }

        public MPendantOfInvisibility(Serial serial)
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
    public class MPendantOfPolymorph : BaseJewelry
    {
        [Constructable]
        public MPendantOfPolymorph()
            : base(JewelryEffect.Polymorph, Layer.Neck, 0x1088, 21, 31)
        {
             //Name = "Mystic Pendant Of Polymorph";
        }

        public MPendantOfPolymorph(Serial serial)
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
    public class MPendantOfManaVampire : BaseJewelry
    {
        [Constructable]
        public MPendantOfManaVampire()
            : base(JewelryEffect.ManaVampire, Layer.Neck, 0x1088, 21, 31)
        {
             //Name = "Mystic Pendant Of Mana Vampire";
        }

        public MPendantOfManaVampire(Serial serial)
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
    public class MPendantOfMassDispel : BaseJewelry
    {
        [Constructable]
        public MPendantOfMassDispel()
            : base(JewelryEffect.MassDispel, Layer.Neck, 0x1088, 21, 31)
        {
             //Name = "Mystic Pendant Of Mass Dispel";
        }

        public MPendantOfMassDispel(Serial serial)
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
    public class MPendantOfMeteorSwarm : BaseJewelry
    {
        [Constructable]
        public MPendantOfMeteorSwarm()
            : base(JewelryEffect.MeteorSwarm, Layer.Neck, 0x1088, 21, 31)
        {
             //Name = "Mystic Pendant Of Meteor Swarm";
        }

        public MPendantOfMeteorSwarm(Serial serial)
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
    public class MPendantOfChainLightning : BaseJewelry
    {
        [Constructable]
        public MPendantOfChainLightning()
            : base(JewelryEffect.ChainLightning, Layer.Neck, 0x1088, 21, 31)
        {
             //Name = "Mystic Pendant Of Chain Lightning";
        }

        public MPendantOfChainLightning(Serial serial)
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
    public class MPendantOfFlameStrike : BaseJewelry
    {
        [Constructable]
        public MPendantOfFlameStrike()
            : base(JewelryEffect.FlameStrike, Layer.Neck, 0x1088, 21, 31)
        {
             //Name = "Mystic Pendant Of Flame Strike";
        }

        public MPendantOfFlameStrike(Serial serial)
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
    public class MPendantOfGateTravel : BaseJewelry
    {
        [Constructable]
        public MPendantOfGateTravel()
            : base(JewelryEffect.GateTravel, Layer.Neck, 0x1088, 21, 31)
        {
             //Name = "Mystic Pendant Of Gate Travel";
        }

        public MPendantOfGateTravel(Serial serial)
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
    public class MPendantOfEnergyField : BaseJewelry
    {
        [Constructable]
        public MPendantOfEnergyField()
            : base(JewelryEffect.EnergyField, Layer.Neck, 0x1088, 21, 31)
        {
             //Name = "Mystic Pendant Of Energy Field";
        }

        public MPendantOfEnergyField(Serial serial)
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
    public class MPendantOfWaterElemental : BaseJewelry
    {
        [Constructable]
        public MPendantOfWaterElemental()
            : base(JewelryEffect.WaterElemental, Layer.Neck, 0x1088, 16, 26)
        {
             //Name = "Mystic Pendant Of Water Elemental";
        }

        public MPendantOfWaterElemental(Serial serial)
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
    public class MPendantOfAirElemental : BaseJewelry
    {
        [Constructable]
        public MPendantOfAirElemental()
            : base(JewelryEffect.AirElemental, Layer.Neck, 0x1088, 16, 26)
        {
             //Name = "Mystic Pendant Of Air Elemental";
        }

        public MPendantOfAirElemental(Serial serial)
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
    public class MPendantOfFireElemental : BaseJewelry
    {
        [Constructable]
        public MPendantOfFireElemental()
            : base(JewelryEffect.FireElemental, Layer.Neck, 0x1088, 16, 26)
        {
             //Name = "Mystic Pendant Of Fire Elemental";
        }

        public MPendantOfFireElemental(Serial serial)
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
    public class MPendantOfEarthElemental : BaseJewelry
    {
        [Constructable]
        public MPendantOfEarthElemental()
            : base(JewelryEffect.EarthElemental, Layer.Neck, 0x1088, 16, 26)
        {
             //Name = "Mystic Pendant Of Earth Elemental";
        }

        public MPendantOfEarthElemental(Serial serial)
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
    public class MPendantOfEnergyVortex : BaseJewelry
    {
        [Constructable]
        public MPendantOfEnergyVortex()
            : base(JewelryEffect.EnergyVortex, Layer.Neck, 0x1088, 16, 26)
        {
             //Name = "Mystic Pendant Of Energy Vortex";
        }

        public MPendantOfEnergyVortex(Serial serial)
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
    public class MPendantOfSummonDaemon : BaseJewelry
    {
        [Constructable]
        public MPendantOfSummonDaemon()
            : base(JewelryEffect.SummonDaemon, Layer.Neck, 0x1088, 16, 26)
        {
             //Name = "Mystic Pendant Of Summon Daemon";
        }

        public MPendantOfSummonDaemon(Serial serial)
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
    public class MPendantOfResurrection : BaseJewelry
    {
        [Constructable]
        public MPendantOfResurrection()
            : base(JewelryEffect.Resurrection, Layer.Neck, 0x1088, 16, 26)
        {
             //Name = "Mystic Pendant Of Resurrection";
        }

        public MPendantOfResurrection(Serial serial)
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
    public class MPendantOfEarthquake : BaseJewelry
    {

        [Constructable]
        public MPendantOfEarthquake()
            : base(JewelryEffect.Earthquake, Layer.Neck, 0x1088, 4, 6)
        {
             //Name = "Mystic Pendant Of Earth Quake";
        }

        public MPendantOfEarthquake(Serial serial)
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
