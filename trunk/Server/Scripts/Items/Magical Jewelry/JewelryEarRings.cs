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
    public class MEarringsOfClumsy : BaseJewelry
    {
        [Constructable]
        public MEarringsOfClumsy()
            : base(JewelryEffect.Clumsy, Layer.Earrings, 0x1087, 51, 61)
        {
             //Name = "Mystic Earrings Of Clumsy";
        }

        public MEarringsOfClumsy(Serial serial)
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
    public class MEarringsOfHeal : BaseJewelry
    {
        [Constructable]
        public MEarringsOfHeal()
            : base(JewelryEffect.Heal, Layer.Earrings, 0x1087, 51, 61)
        {
             //Name = "Mystic Earrings Of Heal";
        }

        public MEarringsOfHeal(Serial serial)
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
    public class MEarringsOfMagicArrow : BaseJewelry
    {
        [Constructable]
        public MEarringsOfMagicArrow()
            : base(JewelryEffect.MagicArrow, Layer.Earrings, 0x1087, 51, 61)
        {
             //Name = "Mystic Earrings Of Magic Arrow";
        }

        public MEarringsOfMagicArrow(Serial serial)
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
    public class MEarringsOfFeeblemind : BaseJewelry
    {
        [Constructable]
        public MEarringsOfFeeblemind()
            : base(JewelryEffect.Feeblemind, Layer.Earrings, 0x1087, 51, 61)
        {
             //Name = "Mystic Earrings Of Feeblemind";
        }

        public MEarringsOfFeeblemind(Serial serial)
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
    public class MEarringsOfWeaken : BaseJewelry
    {
        [Constructable]
        public MEarringsOfWeaken()
            : base(JewelryEffect.Weaken, Layer.Earrings, 0x1087, 51, 61)
        {
             //Name = "Mystic Earrings Of Weaken";
        }

        public MEarringsOfWeaken(Serial serial)
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
    public class MEarringsOfCreateFood : BaseJewelry   // Self Target
    {
        [Constructable]
        public MEarringsOfCreateFood()
            : base(JewelryEffect.CreateFood, Layer.Earrings, 0x1087, 51, 61)
        {
             //Name = "Mystic Earrings Of Create Food";
        }

        public MEarringsOfCreateFood(Serial serial)
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
    public class MEarringsOfNightSight : BaseJewelry  // Self Target
    {
        [Constructable]
        public MEarringsOfNightSight()
            : base(JewelryEffect.NightSight, Layer.Earrings, 0x1087, 51, 61)
        {
             //Name = "Mystic Earrings Of Night Sight";
        }

        public MEarringsOfNightSight(Serial serial)
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
    public class MEarringsOfReactiveArmor : BaseJewelry  // Self Target
    {
        [Constructable]
        public MEarringsOfReactiveArmor()
            : base(JewelryEffect.ReactiveArmor, Layer.Earrings, 0x1087, 51, 61)
        {
             //Name = "Mystic Earrings Of ReactiveArmor";
        }

        public MEarringsOfReactiveArmor(Serial serial)
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
    public class MEarringsOfCure : BaseJewelry
    {
        [Constructable]
        public MEarringsOfCure()
            : base(JewelryEffect.Cure, Layer.Earrings, 0x1087, 46, 56)
        {
             //Name = "Mystic Earrings Of Cure";
        }

        public MEarringsOfCure(Serial serial)
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
    public class MEarringsOfRemoveTrap : BaseJewelry
    {
        [Constructable]
        public MEarringsOfRemoveTrap()
            : base(JewelryEffect.RemoveTrap, Layer.Earrings, 0x1087, 46, 56)
        {
             //Name = "Mystic Earrings Of Remove Trap";
        }

        public MEarringsOfRemoveTrap(Serial serial)
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
    public class MEarringsOfMagicTrap : BaseJewelry
    {
        [Constructable]
        public MEarringsOfMagicTrap()
            : base(JewelryEffect.MagicTrap, Layer.Earrings, 0x1087, 46, 56)
        {
             //Name = "Mystic Earrings Of Magic Trap";
        }

        public MEarringsOfMagicTrap(Serial serial)
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
    public class MEarringsOfHarm : BaseJewelry
    {
        [Constructable]
        public MEarringsOfHarm()
            : base(JewelryEffect.Harm, Layer.Earrings, 0x1087, 46, 56)
        {
             //Name = "Mystic Earrings Of Harm";
        }

        public MEarringsOfHarm(Serial serial)
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
    public class MEarringsOfAgility : BaseJewelry
    {
        [Constructable]
        public MEarringsOfAgility()
            : base(JewelryEffect.Agility, Layer.Earrings, 0x1087, 46, 56)
        {
             //Name = "Mystic Earrings Of Agility";
        }

        public MEarringsOfAgility(Serial serial)
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
    public class MEarringsOfCunning : BaseJewelry
    {
        [Constructable]
        public MEarringsOfCunning()
            : base(JewelryEffect.Cunning, Layer.Earrings, 0x1087, 46, 56)
        {
             //Name = "Mystic Earrings Of Cunning";
        }

        public MEarringsOfCunning(Serial serial)
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
    public class MEarringsOfStrength : BaseJewelry
    {
        [Constructable]
        public MEarringsOfStrength()
            : base(JewelryEffect.Strength, Layer.Earrings, 0x1087, 46, 56)
        {
             //Name = "Mystic Earrings Of Strength";
        }

        public MEarringsOfStrength(Serial serial)
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
    public class MEarringsOfProtection : BaseJewelry  // Self Target
    {
        [Constructable]
        public MEarringsOfProtection()
            : base(JewelryEffect.Protection, Layer.Earrings, 0x1087, 46, 56)
        {
             //Name = "Mystic Earrings Of Protection";
        }

        public MEarringsOfProtection(Serial serial)
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
    public class MEarringsOfTeleport : BaseJewelry
    {
        [Constructable]
        public MEarringsOfTeleport()
            : base(JewelryEffect.Teleport, Layer.Earrings, 0x1087, 41, 51)
        {
             //Name = "Mystic Earrings Of Teleport";
        }

        public MEarringsOfTeleport(Serial serial)
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
    public class MEarringsOfTelekinesis : BaseJewelry
    {
        [Constructable]
        public MEarringsOfTelekinesis()
            : base(JewelryEffect.Telekinesis, Layer.Earrings, 0x1087, 41, 51)
        {
             //Name = "Mystic Earrings Of Telekinesis";
        }

        public MEarringsOfTelekinesis(Serial serial)
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
    public class MEarringsOfWallOfStone : BaseJewelry
    {
        [Constructable]
        public MEarringsOfWallOfStone()
            : base(JewelryEffect.WallOfStone, Layer.Earrings, 0x1087, 41, 51)
        {
             //Name = "Mystic Earrings Of Wall Of Stone";
        }

        public MEarringsOfWallOfStone(Serial serial)
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
    public class MEarringsOfMagicLock : BaseJewelry
    {
        [Constructable]
        public MEarringsOfMagicLock()
            : base(JewelryEffect.MagicLock, Layer.Earrings, 0x1087, 41, 51)
        {
             //Name = "Mystic Earrings Of Magic Lock";
        }

        public MEarringsOfMagicLock(Serial serial)
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
    public class MEarringsOfUnlock : BaseJewelry
    {
        [Constructable]
        public MEarringsOfUnlock()
            : base(JewelryEffect.Unlock, Layer.Earrings, 0x1087, 41, 51)
        {
             //Name = "Mystic Earrings Of Unlock";
        }

        public MEarringsOfUnlock(Serial serial)
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
    public class MEarringsOfBless : BaseJewelry
    {
        [Constructable]
        public MEarringsOfBless()
            : base(JewelryEffect.Bless, Layer.Earrings, 0x1087, 41, 51)
        {
             //Name = "Mystic Earrings Of Bless";
        }

        public MEarringsOfBless(Serial serial)
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
    public class MEarringsOfFireball : BaseJewelry
    {
        [Constructable]
        public MEarringsOfFireball()
            : base(JewelryEffect.Fireball, Layer.Earrings, 0x1087, 41, 51)
        {
             //Name = "Mystic Earrings Of Fireball";
        }

        public MEarringsOfFireball(Serial serial)
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
    public class MEarringsOfPoison : BaseJewelry
    {
        [Constructable]
        public MEarringsOfPoison()
            : base(JewelryEffect.Poison, Layer.Earrings, 0x1087, 41, 51)
        {
             //Name = "Mystic Earrings Of Poison";
        }

        public MEarringsOfPoison(Serial serial)
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
    public class MEarringsOfFireField : BaseJewelry
    {
        [Constructable]
        public MEarringsOfFireField()
            : base(JewelryEffect.FireField, Layer.Earrings, 0x1087, 36, 46)
        {
             //Name = "Mystic Earrings Of Fire Field";
        }

        public MEarringsOfFireField(Serial serial)
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
    public class MEarringsOfManaDrain : BaseJewelry
    {
        [Constructable]
        public MEarringsOfManaDrain()
            : base(JewelryEffect.ManaDrain, Layer.Earrings, 0x1087, 36, 46)
        {
             //Name = "Mystic Earrings Of Mana Drain";
        }

        public MEarringsOfManaDrain(Serial serial)
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
    public class MEarringsOfGreaterHeal : BaseJewelry
    {
        [Constructable]
        public MEarringsOfGreaterHeal()
            : base(JewelryEffect.GreaterHeal, Layer.Earrings, 0x1087, 36, 46)
        {
             //Name = "Mystic Earrings Of Greater Heal";
        }

        public MEarringsOfGreaterHeal(Serial serial)
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
    public class MEarringsOfCurse : BaseJewelry
    {
        [Constructable]
        public MEarringsOfCurse()
            : base(JewelryEffect.Curse, Layer.Earrings, 0x1087, 36, 46)
        {
             //Name = "Mystic Earrings Of Curse";
        }

        public MEarringsOfCurse(Serial serial)
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
    public class MEarringsOfLightning : BaseJewelry
    {
        [Constructable]
        public MEarringsOfLightning()
            : base(JewelryEffect.Lightning, Layer.Earrings, 0x1087, 36, 46)
        {
             //Name = "Mystic Earrings Of Lightning";
        }

        public MEarringsOfLightning(Serial serial)
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
    public class MEarringsOfRecall : BaseJewelry
    {
        [Constructable]
        public MEarringsOfRecall()
            : base(JewelryEffect.Recall, Layer.Earrings, 0x1087, 36, 46)
        {
             //Name = "Mystic Earrings Of Recall";
        }

        public MEarringsOfRecall(Serial serial)
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
    public class MEarringsOfArchProtection : BaseJewelry
    {
        [Constructable]
        public MEarringsOfArchProtection()
            : base(JewelryEffect.ArchProtection, Layer.Earrings, 0x1087, 36, 46)
        {
             //Name = "Mystic Earrings Of Arch Protection";
        }

        public MEarringsOfArchProtection(Serial serial)
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
    public class MEarringsOfArchCure : BaseJewelry
    {
        [Constructable]
        public MEarringsOfArchCure()
            : base(JewelryEffect.ArchCure, Layer.Earrings, 0x1087, 36, 46)
        {
             //Name = "Mystic Earrings Of Arch Cure";
        }

        public MEarringsOfArchCure(Serial serial)
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
    public class MEarringsOfParalyze : BaseJewelry
    {
        [Constructable]
        public MEarringsOfParalyze()
            : base(JewelryEffect.Paralyze, Layer.Earrings, 0x1087, 31, 41)
        {
             //Name = "Mystic Earrings Of Paralyze";
        }

        public MEarringsOfParalyze(Serial serial)
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
    public class MEarringsOfMindBlast : BaseJewelry
    {
        [Constructable]
        public MEarringsOfMindBlast()
            : base(JewelryEffect.MindBlast, Layer.Earrings, 0x1087, 31, 41)
        {
             //Name = "Mystic Earrings Of Mind Blast";
        }

        public MEarringsOfMindBlast(Serial serial)
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
    public class MEarringsOfDispelField : BaseJewelry
    {
        [Constructable]
        public MEarringsOfDispelField()
            : base(JewelryEffect.DispelField, Layer.Earrings, 0x1087, 31, 41)
        {
             //Name = "Mystic Earrings Of Dispel Field";
        }

        public MEarringsOfDispelField(Serial serial)
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
    public class MEarringsOfPoisonField : BaseJewelry
    {
        [Constructable]
        public MEarringsOfPoisonField()
            : base(JewelryEffect.PoisonField, Layer.Earrings, 0x1087, 31, 41)
        {
             //Name = "Mystic Earrings Of Poison Field";
        }

        public MEarringsOfPoisonField(Serial serial)
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
    public class MEarringsOfBladeSpirits : BaseJewelry
    {
        [Constructable]
        public MEarringsOfBladeSpirits()
            : base(JewelryEffect.BladeSpirits, Layer.Earrings, 0x1087, 31, 41)
        {
             //Name = "Mystic Earrings Of Blade Spirits";
        }

        public MEarringsOfBladeSpirits(Serial serial)
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
    public class MEarringsOfMagicReflect : BaseJewelry  // Self Target
    {
        [Constructable]
        public MEarringsOfMagicReflect()
            : base(JewelryEffect.MagicReflect, Layer.Earrings, 0x1087, 31, 41)
        {
             //Name = "Mystic Earrings Of Magic Reflect";
        }

        public MEarringsOfMagicReflect(Serial serial)
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
    public class MEarringsOfIncognito : BaseJewelry
    {
        [Constructable]
        public MEarringsOfIncognito()
            : base(JewelryEffect.Incognito, Layer.Earrings, 0x1087, 31, 41)
        {
             //Name = "Mystic Earrings Of Incognito";
        }

        public MEarringsOfIncognito(Serial serial)
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
    public class MEarringsOfEnergyBolt : BaseJewelry
    {
        [Constructable]
        public MEarringsOfEnergyBolt()
            : base(JewelryEffect.EnergyBolt, Layer.Earrings, 0x1087, 26, 36)
        {
             //Name = "Mystic Earrings Of Energy Bolt";
        }

        public MEarringsOfEnergyBolt(Serial serial)
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
    public class MEarringsOfExplosion : BaseJewelry
    {
        [Constructable]
        public MEarringsOfExplosion()
            : base(JewelryEffect.Explosion, Layer.Earrings, 0x1087, 26, 36)
        {
             //Name = "Mystic Earrings Of Explosion";
        }

        public MEarringsOfExplosion(Serial serial)
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
    public class MEarringsOfDispel : BaseJewelry
    {
        [Constructable]
        public MEarringsOfDispel()
            : base(JewelryEffect.Dispel, Layer.Earrings, 0x1087, 26, 36)
        {
             //Name = "Mystic Earrings Of Dispel";
        }

        public MEarringsOfDispel(Serial serial)
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
    public class MEarringsOfReveal : BaseJewelry
    {
        [Constructable]
        public MEarringsOfReveal()
            : base(JewelryEffect.Reveal, Layer.Earrings, 0x1087, 26, 36)
        {
             //Name = "Mystic Earrings Of Reveal";
        }

        public MEarringsOfReveal(Serial serial)
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
    public class MEarringsOfMark : BaseJewelry
    {
        [Constructable]
        public MEarringsOfMark()
            : base(JewelryEffect.Mark, Layer.Earrings, 0x1087, 26, 36)
        {
             //Name = "Mystic Earrings Of Mark";
        }

        public MEarringsOfMark(Serial serial)
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
    public class MEarringsOfParalyzeField : BaseJewelry
    {
        [Constructable]
        public MEarringsOfParalyzeField()
            : base(JewelryEffect.ParalyzeField, Layer.Earrings, 0x1087, 26, 36)
        {
             //Name = "Mystic Earrings Of Paralyze Field";
        }

        public MEarringsOfParalyzeField(Serial serial)
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
    public class MEarringsOfInvisibility : BaseJewelry  // Self Target
    {
        [Constructable]
        public MEarringsOfInvisibility()
            : base(JewelryEffect.Invisibility, Layer.Earrings, 0x1087, 26, 36)
        {
             //Name = "Mystic Earrings Of Invisibility";
        }

        public MEarringsOfInvisibility(Serial serial)
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
    public class MEarringsOfPolymorph : BaseJewelry
    {
        [Constructable]
        public MEarringsOfPolymorph()
            : base(JewelryEffect.Polymorph, Layer.Earrings, 0x1087, 21, 31)
        {
             //Name = "Mystic Earrings Of Polymorph";
        }

        public MEarringsOfPolymorph(Serial serial)
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
    public class MEarringsOfManaVampire : BaseJewelry
    {
        [Constructable]
        public MEarringsOfManaVampire()
            : base(JewelryEffect.ManaVampire, Layer.Earrings, 0x1087, 21, 31)
        {
             //Name = "Mystic Earrings Of Mana Vampire";
        }

        public MEarringsOfManaVampire(Serial serial)
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
    public class MEarringsOfMassDispel : BaseJewelry
    {
        [Constructable]
        public MEarringsOfMassDispel()
            : base(JewelryEffect.MassDispel, Layer.Earrings, 0x1087, 21, 31)
        {
             //Name = "Mystic Earrings Of Mass Dispel";
        }

        public MEarringsOfMassDispel(Serial serial)
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
    public class MEarringsOfMeteorSwarm : BaseJewelry
    {
        [Constructable]
        public MEarringsOfMeteorSwarm()
            : base(JewelryEffect.MeteorSwarm, Layer.Earrings, 0x1087, 21, 31)
        {
             //Name = "Mystic Earrings Of Meteor Swarm";
        }

        public MEarringsOfMeteorSwarm(Serial serial)
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
    public class MEarringsOfChainLightning : BaseJewelry
    {
        [Constructable]
        public MEarringsOfChainLightning()
            : base(JewelryEffect.ChainLightning, Layer.Earrings, 0x1087, 21, 31)
        {
             //Name = "Mystic Earrings Of Chain Lightning";
        }

        public MEarringsOfChainLightning(Serial serial)
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
    public class MEarringsOfFlameStrike : BaseJewelry
    {
        [Constructable]
        public MEarringsOfFlameStrike()
            : base(JewelryEffect.FlameStrike, Layer.Earrings, 0x1087, 21, 31)
        {
             //Name = "Mystic Earrings Of Flame Strike";
        }

        public MEarringsOfFlameStrike(Serial serial)
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
    public class MEarringsOfGateTravel : BaseJewelry
    {
        [Constructable]
        public MEarringsOfGateTravel()
            : base(JewelryEffect.GateTravel, Layer.Earrings, 0x1087, 21, 31)
        {
             //Name = "Mystic Earrings Of Gate Travel";
        }

        public MEarringsOfGateTravel(Serial serial)
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
    public class MEarringsOfEnergyField : BaseJewelry
    {
        [Constructable]
        public MEarringsOfEnergyField()
            : base(JewelryEffect.EnergyField, Layer.Earrings, 0x1087, 21, 31)
        {
             //Name = "Mystic Earrings Of Energy Field";
        }

        public MEarringsOfEnergyField(Serial serial)
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
    public class MEarringsOfWaterElemental : BaseJewelry
    {
        [Constructable]
        public MEarringsOfWaterElemental()
            : base(JewelryEffect.WaterElemental, Layer.Earrings, 0x1087, 16, 26)
        {
             //Name = "Mystic Earrings Of Water Elemental";
        }

        public MEarringsOfWaterElemental(Serial serial)
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
    public class MEarringsOfAirElemental : BaseJewelry
    {
        [Constructable]
        public MEarringsOfAirElemental()
            : base(JewelryEffect.AirElemental, Layer.Earrings, 0x1087, 16, 26)
        {
             //Name = "Mystic Earrings Of Air Elemental";
        }

        public MEarringsOfAirElemental(Serial serial)
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
    public class MEarringsOfFireElemental : BaseJewelry
    {
        [Constructable]
        public MEarringsOfFireElemental()
            : base(JewelryEffect.FireElemental, Layer.Earrings, 0x1087, 16, 26)
        {
             //Name = "Mystic Earrings Of Fire Elemental";
        }

        public MEarringsOfFireElemental(Serial serial)
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
    public class MEarringsOfEarthElemental : BaseJewelry
    {
        [Constructable]
        public MEarringsOfEarthElemental()
            : base(JewelryEffect.EarthElemental, Layer.Earrings, 0x1087, 16, 26)
        {
             //Name = "Mystic Earrings Of Earth Elemental";
        }

        public MEarringsOfEarthElemental(Serial serial)
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
    public class MEarringsOfEnergyVortex : BaseJewelry
    {
        [Constructable]
        public MEarringsOfEnergyVortex()
            : base(JewelryEffect.EnergyVortex, Layer.Earrings, 0x1087, 16, 26)
        {
             //Name = "Mystic Earrings Of Energy Vortex";
        }

        public MEarringsOfEnergyVortex(Serial serial)
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
    public class MEarringsOfSummonDaemon : BaseJewelry
    {
        [Constructable]
        public MEarringsOfSummonDaemon()
            : base(JewelryEffect.SummonDaemon, Layer.Earrings, 0x1087, 16, 26)
        {
             //Name = "Mystic Earrings Of Summon Daemon";
        }

        public MEarringsOfSummonDaemon(Serial serial)
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
    public class MEarringsOfResurrection : BaseJewelry
    {
        [Constructable]
        public MEarringsOfResurrection()
            : base(JewelryEffect.Resurrection, Layer.Earrings, 0x1087, 16, 26)
        {
             //Name = "Mystic Earrings Of Resurrection";
        }

        public MEarringsOfResurrection(Serial serial)
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
    public class MEarringsOfEarthquake : BaseJewelry
    {

        [Constructable]
        public MEarringsOfEarthquake()
            : base(JewelryEffect.Earthquake, Layer.Earrings, 0x1087, 4, 6)
        {
             //Name = "Mystic Earrings Of Earth Quake";
        }

        public MEarringsOfEarthquake(Serial serial)
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