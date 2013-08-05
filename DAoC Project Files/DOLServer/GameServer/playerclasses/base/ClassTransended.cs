/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */
using System;
using DOL.Language;

namespace DOL.GS.PlayerClass
{
	/// <summary>
	/// 
	/// </summary>
	[CharacterClassAttribute((int)eCharacterClass.Transended, "Transended", "Transended")]
	public class ClassTransended : ClassTransendedBase
	{
		public ClassTransended() : base() 
		{
			m_profession = LanguageMgr.GetTranslation(ServerProperties.Properties.SERV_LANGUAGE, "PlayerClass.Profession.ChurchofAlbion");
			m_specializationMultiplier = 10;
			m_primaryStat = eStat.PIE;
			m_secondaryStat = eStat.CON;
			m_tertiaryStat = eStat.STR;
			m_manaStat = eStat.PIE;
			m_baseHP = 720;
		}

        public override string GetTitle(GamePlayer player, int level) 
		{
			if (level >= 50) return LanguageMgr.GetTranslation(player.Client.Account.Language, "PlayerClass.Transended.GetTitle.50");
            if (level >= 45) return LanguageMgr.GetTranslation(player.Client.Account.Language, "PlayerClass.Transended.GetTitle.45");
            if (level >= 40) return LanguageMgr.GetTranslation(player.Client.Account.Language, "PlayerClass.Transended.GetTitle.40");
            if (level >= 35) return LanguageMgr.GetTranslation(player.Client.Account.Language, "PlayerClass.Transended.GetTitle.35");
            if (level >= 30) return LanguageMgr.GetTranslation(player.Client.Account.Language, "PlayerClass.Transended.GetTitle.30");
            if (level >= 25) return LanguageMgr.GetTranslation(player.Client.Account.Language, "PlayerClass.Transended.GetTitle.25");
            if (level >= 20) return LanguageMgr.GetTranslation(player.Client.Account.Language, "PlayerClass.Transended.GetTitle.20");
            if (level >= 15) return LanguageMgr.GetTranslation(player.Client.Account.Language, "PlayerClass.Transended.GetTitle.15");
            if (level >= 10) return LanguageMgr.GetTranslation(player.Client.Account.Language, "PlayerClass.Transended.GetTitle.10");
            if (level >= 5) return LanguageMgr.GetTranslation(player.Client.Account.Language, "PlayerClass.Transended.GetTitle.5");
			return LanguageMgr.GetTranslation(player.Client.Account.Language, "PlayerClass.GetTitle.none");
		}

		/// <summary>
		/// Update all skills and add new for current level
		/// </summary>
		/// <param name="player"></param>
		public override void OnLevelUp(GamePlayer player, int previousLevel)
		{
			base.OnLevelUp(player, previousLevel);


            //All realms recieve this
            player.AddAbility(SkillBase.GetAbility(Abilities.Sprint));



            if (player.Realm == eRealm.Albion)
            {

                //Armor Types
                player.AddAbility(SkillBase.GetAbility(Abilities.AlbArmor, ArmorLevel.Cloth));
                player.AddAbility(SkillBase.GetAbility(Abilities.AlbArmor, ArmorLevel.Leather));
                player.AddAbility(SkillBase.GetAbility(Abilities.AlbArmor, ArmorLevel.Studded));
                player.AddAbility(SkillBase.GetAbility(Abilities.AlbArmor, ArmorLevel.Chain));
                player.AddAbility(SkillBase.GetAbility(Abilities.AlbArmor, ArmorLevel.Plate));

                //Shields
                player.AddAbility(SkillBase.GetAbility(Abilities.Shield, ShieldLevel.Small));
                player.AddAbility(SkillBase.GetAbility(Abilities.Shield, ShieldLevel.Medium));
                player.AddAbility(SkillBase.GetAbility(Abilities.Shield, ShieldLevel.Large));

                //Weapon Types
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Crushing));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Staves));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Slashing));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Thrusting));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Flexible));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_MaulerStaff));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_FistWraps));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Polearms));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_TwoHanded));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Instruments));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Thrown));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Crossbow));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Shortbows));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Longbows));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_RecurvedBows));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_CompositeBows));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Archery));



            }

            if (player.Realm == eRealm.Midgard)
            {

                //Armor Types
                player.AddAbility(SkillBase.GetAbility(Abilities.MidArmor, ArmorLevel.Cloth));
                player.AddAbility(SkillBase.GetAbility(Abilities.MidArmor, ArmorLevel.Leather));
                player.AddAbility(SkillBase.GetAbility(Abilities.MidArmor, ArmorLevel.Studded));
                player.AddAbility(SkillBase.GetAbility(Abilities.MidArmor, ArmorLevel.Chain));

                //Armor Types
                player.AddAbility(SkillBase.GetAbility(Abilities.Shield, ShieldLevel.Small));
                player.AddAbility(SkillBase.GetAbility(Abilities.Shield, ShieldLevel.Medium));
                player.AddAbility(SkillBase.GetAbility(Abilities.Shield, ShieldLevel.Large));

                //Weapon Types
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Staves));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Axes));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Hammers));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Swords));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_MaulerStaff));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_FistWraps));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_HandToHand));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_LeftAxes));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Spears));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Thrown));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Crossbow));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Shortbows));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Longbows));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_RecurvedBows));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_CompositeBows));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Archery));



            }

            if (player.Realm == eRealm.Hibernia)
            {

                //Armor Types
                player.AddAbility(SkillBase.GetAbility(Abilities.HibArmor, ArmorLevel.Cloth));
                player.AddAbility(SkillBase.GetAbility(Abilities.HibArmor, ArmorLevel.Leather));
                player.AddAbility(SkillBase.GetAbility(Abilities.HibArmor, ArmorLevel.Reinforced));
                player.AddAbility(SkillBase.GetAbility(Abilities.HibArmor, ArmorLevel.Scale));



                //Shield Types
                player.AddAbility(SkillBase.GetAbility(Abilities.Shield, ShieldLevel.Small));
                player.AddAbility(SkillBase.GetAbility(Abilities.Shield, ShieldLevel.Medium));
                player.AddAbility(SkillBase.GetAbility(Abilities.Shield, ShieldLevel.Large));


                //Weapon Types
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Blades));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Blunt));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Piercing));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Staves));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_MaulerStaff));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_FistWraps));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_LargeWeapons));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_CelticSpear));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Scythe));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Instruments));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Thrown));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Crossbow));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Shortbows));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Longbows));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_RecurvedBows));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_CompositeBows));
                player.AddAbility(SkillBase.GetAbility(Abilities.Weapon_Archery));

            }


			/*
            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Smite));
			player.AddSpellLine(SkillBase.GetSpellLine("Smiting"));
			player.AddSpellLine(SkillBase.GetSpellLine("Rebirth (Cleric)"));
			player.AddSpellLine(SkillBase.GetSpellLine("Guardian Angel"));
			player.AddSpellLine(SkillBase.GetSpellLine("Terrible Hammer"));
             */

			if (player.Level >= 10) 
			{
				//player.AddAbility(SkillBase.GetAbility(Abilities.AlbArmor, ArmorLevel.Studded));
				//player.AddAbility(SkillBase.GetAbility(Abilities.Shield, ShieldLevel.Medium));
			}
			if (player.Level >= 20) 
			{
				//player.AddAbility(SkillBase.GetAbility(Abilities.AlbArmor, ArmorLevel.Chain));
			}

		}

		public override bool HasAdvancedFromBaseClass()
		{
			return true;
		}
	}
}
