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
using System.Collections;
using DOL.GS.PacketHandler;
using DOL.Language;

namespace DOL.GS.Trainer
{
	/// <summary>
	/// Cleric Trainer
	/// </summary>
	[NPCGuildScript("Transended Trainer")]		// this attribute instructs DOL to use this script for all "Cleric Trainer" NPC's in Albion (multiple guilds are possible for one script)
	public class TransendedTrainer : GameTrainer
	{
		public override eCharacterClass TrainedClass
		{
			get { return eCharacterClass.Transended; }
		}

		/// <summary>
		/// The crush sword template ID
		/// </summary>
		public const string WEAPON_ID1 = "crush_sword_item";


		/// <summary>
		/// Interact with trainer
		/// </summary>
		/// <param name="player"></param>
		/// <returns></returns>
		public override bool Interact(GamePlayer player)
		{
			if (!base.Interact(player)) return false;
            IList specs = player.GetSpecList(); //Enumerate spec list for count
			
			// check if class matches.
			if (player.CharacterClass.ID == (int)TrainedClass)
			{
                if (specs.Count < 6)
                {
                    player.Out.SendMessage(this.Name + " says, \"Would you like to [add a spec] to your charecter?\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                }

				OfferTraining(player);
			}
			else
			{
				// perhaps player can be promoted
				if (CanPromotePlayer(player))
				{
                    player.Out.SendMessage(this.Name + " says, \"Becoming a Transended player allows you to leave the confines of your class.\\ You will be able to select six lines to train in from any of classes in your realm.\\Three of these lines will have the baseline included. The other three will only be the spec line.\\ You will not gain skills in these when you level.\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    player.Out.SendMessage(this.Name + " says, \"You can only decide to transend at level one. You can only transend one time. This is permanent!\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
					player.Out.SendMessage(this.Name + " says, \"Do you desire to [Transend]?\"",eChatType.CT_Say,eChatLoc.CL_PopupWindow);
					
				}
				else
				{
					CheckChampionTraining(player);
				}
			}
			return true;
		}

		/// <summary>
		/// checks wether a player can be promoted or not
		/// </summary>
		/// <param name="player"></param>
		/// <returns></returns>
		public static bool CanPromotePlayer(GamePlayer player)
		{
            return (player.Level == 1);
		}

		/// <summary>
		/// Talk to trainer
		/// </summary>
		/// <param name="source"></param>
		/// <param name="text"></param>
		/// <returns></returns>
		public override bool WhisperReceive(GameLiving source, string text)
		{
			if (!base.WhisperReceive(source, text)) return false;
			GamePlayer player = source as GamePlayer;
            IList specs = player.GetSpecList(); //Enumerate spec list for count
			
			switch (text)
            {
                #region AddSpec
                case "add a spec":
                    if (player.Realm == eRealm.Albion)
                    {
                        player.Out.SendMessage(this.Name + "says, \"From which class do you want your spec? \n[Armsman]  \n[Cabalist] \n[Cleric]  \n[Friar]  \n[Heretic]  \n[Infiltrator]  \n[Mauler]  \n[Mercenary]  \n[Minstrel]  \n[Necromancer]  \n[Paladin]  \n[Reaver]  \n[Scout]  \n[Sorcerer]  \n[Theurgist]  \n[Wizard].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    if (player.Realm == eRealm.Midgard)
                    {
                        player.Out.SendMessage(this.Name + "says, \"From which class do you want your spec? \n[Berserker]\n[Bonedancer]\n[Healer]\n[Hunter]\n[Mauler]\n[Runemaster]\n[Savage]\n[Shadowblade]\n[Shaman]\n[Skald]\n[Spiritmaster]\n[Thane]\n[Valkyrie]\n[Warlock]\n[Warrior].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    if (player.Realm == eRealm.Hibernia)
                    {
                        player.Out.SendMessage(this.Name + "says, \"From which class do you want your spec? \n[Animist]\n[Bainshee]\n[Bard]\n[Blademaster]\n[Champion]\n[Druid]\n[Eldritch]\n[Enchanter]\n[Hero]\n[Mauler]\n[Mentalist]\n[Nightshade]\n[Ranger]\n[Valewalker]\n[Vampiir]\n[Warden].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Transend
                case "Transend":
					// promote player to other class
					if (CanPromotePlayer(player))
                    {
						PromotePlayer(player, (int)eCharacterClass.Transended, "You have transended beyond the confines of a class.", null);
						player.ReceiveItem(this,WEAPON_ID1);


                        //Remove linguring base class skill lines and abilities
                        player.RemoveAllSkills();
                        player.RemoveAllSpecs();
                        player.RemoveAllSpellLines();
                        player.RemoveAllStyles();
                        player.RespecChampionSkills();

                        player.Reset();

                        //Save everything in the Database
                        player.SaveIntoDatabase();

                        player.SendTrainerWindow();

                        player.Out.SendPlayerQuit(false);
                        player.Quit(true);


					}
                    return true;
                #endregion


//Begin Class Switches
#region All Realms Classes

                #region Mauler
                case "Mauler":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from \n[Fist Wraps]\n[Mauler Staff]\n[Aura Manipulation]\n[Magnetism]\n[Power Strikes].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;

                #endregion
 #endregion

#region Albion Classes
                #region Armsman
                case "Armsman":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Crush],[Slash],[Thrust] \n[Polearms],[Two Handed],[Shields].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Cabalist
                case "Cabalist":
                    {
                        if (player.BaseLinesChosen < 3)
                        {
                            player.Out.SendMessage(this.Name + "says, \"You may choose from [Matter],[Body Destruction],[Spirit Animation].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                        }
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Matter Manipulation],[Essense Manipulation],[Vivification].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Cleric
                case "Cleric":
                    {
                       if(player.BaseLinesChosen < 3) //Test, set where needed.
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Rejuvenation],[Enhancement],[Smiting].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Friar
                case "Friar":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Staff],[Rejuvenation],[Enhancement].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Heretic
                case "Heretic":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Crush],[Flexible],[Shields]\n[Rejuventaion],[Enhancements].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Infiltrator
                case "Infiltrator":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Slash],[Thrust],[Critical Strike]\n[Dual Wield],[Stealth].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Mercenary
                case "Mercenary":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Crush],[Slash],[Thrust]\n[Dual Wield],[Shields].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Minstrel
                case "Minstrel":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Slash],[Thrust],[Instruments],[Stealth].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Necromancer
                case "Necromancer":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Deathsight],[Pain Working],[Death Servant].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Paladin
                case "Paladin":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Crush],[Slash],[Thrust]\n[Two Handed],[Shields],[Chants].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Reaver
                case "Revear":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Crush],[Slash],[Thrust]\n[Flexible],[Shields],[Soulrending].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Scout
                case "Scout":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Slash],[Thrust],[Shields]\n[Archery],[Stealth].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Sorcerer
                case "Sorcerer":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Matter],[Body Detruction],[Mind Twisting].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Theurgist
                case "Theurgist":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Path of Earth],[Path of Ice],[Path of Air].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Wizard
                case "Wizard":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Path of Earth],[Path of Ice],[Path of Fire].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion
 #endregion

#region Midgard Classes

                #region Berserker
                case "Berserker":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Left Axe], [Axe], [Hammer], [Sword].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Bonedancer
                case "Bonedancer":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Darkness], [Suppression], [Bone Army].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Healer
                case "Healer":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Mending], [Augmentation], [Pacification].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Hunter
                case "Hunter":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Sword], [Spear], [Archery], \n[Beast Craft], [Stealth].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;

                #endregion

                #region Runemaster
                case "Runemaster":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Darkness], [Suppression], [Rune Carving].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;

                #endregion

                #region Savage
                case "Savage":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Axe], [Hammer], [Sword]\n[Hand to Hand], [Savagery].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Shadowblade
                case "Shadowblade":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Axe], [Hammer], [Sword]\n [Left Axe], [Critical Strike], [Stealth].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Shaman
                case "Shaman":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Mending], [Augmentation], [Subterranean].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Skald
                case "Skald":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Axe], [Hammer], [Sword], [Battlesongs].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Spiritmaster
                case "Spiritmaster":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Darkness], [Suppresion], [Summoning].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Thane
                case "Thane":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Axe], [Hammer], [Sword]\n [Shields], [Stormcalling].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Valkyrie
                case "Valkyrie":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Sword], [Spear], [Shields]\n[Odins Will], [Mending].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Warlock
                case "Warlock":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Cursing], [Hexing], [Witchcraft].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Warrior
                case "Warrior":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Axe], [Hammer], [Sword], [Shields].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion
#endregion

#region Hibernia Classes

                #region Animist
                case "Animist":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Arboreal path], [Creeping Path], [Verdant Path].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region bainshee
                case "Bainshee":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Spectral Force], [Spectral Guard], [Phantasmal Wail], [Ethereal Shriek].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Bard
                case "Bard":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Blades], [Blunt], [Regrowth], [Nurture], [Music].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Blademaster
                case "Blademaster":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Blades], [Blunt], [Piercing]\n[Celtic Dual], [Shields].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Chamion
                case "Champion":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Blades], [Blunt], [Piercing]\n[Large Weapon], [Shields], [Valor].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Druid
                case "Druid":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Regrowth], [Nurture], [Nature Affinity].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Eldritch
                case "Eldritch":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Way of the Sun], [Way of the Moon], [Way of the Eclipse].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Enchanter
                case "Enchanter":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Way of the Sun], [Way of the Moon], [Enchantment].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Hero
                case "Hero":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Blades], [Blunt], [Piercing]\n[Celtic Spear], [Large Weapon], [Shields].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Mentalist
                case "Mentalist":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Way of the Sun], [Way of the Moon], [Mentalism].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
#endregion

                #region Nightshade
                case "Nightshade":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Blades], [Piercing], [Celtic Dual]\n[Critical Strike], [Nightshade Magic], [Stealth].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Ranger
                case "Ranger":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Blades], [Piercing], [Celtic Dual]\n[Archery], [Stealth].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Valewalker
                case "Valewalker":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Scythe], [Aboreal Path].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Vampiir
                case "Vampiir":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Piercing], [Shadow Mastery], [Vampiiric Embrace], [Dementia].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion

                #region Warden
                case "Warden":
                    {
                        player.Out.SendMessage(this.Name + "says, \"You may choose from [Blades], [Blunt], [Shields]\n[Regrowth], [Nurture].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    }
                    return true;
                #endregion
#endregion

//Begin Skill and Ability Switches

#region Skills\Abilities

                #region Archery

                case "Archery":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpellLine("Archery") != null)
                        {
                            //Customize per trainer
                            this.SayTo(player, "You are already have the Archery line!");
                            return false;
                        }
                        //Customize per trainer
                        player.AddSpecialization(SkillBase.GetSpecialization(Specs.Archery));
                        player.AddSpellLine(SkillBase.GetSpellLine("Archery"));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Aura Manipulation
                case "Aura Manipulation":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpecialization(Specs.Aura_Manipulation) != null)
                        {
                            this.SayTo(player, "You are already have the Aura Manipulation line!");
                            return false;
                        }
                        else
                        {

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Aura_Manipulation));
                            player.AddSpellLine(SkillBase.GetSpellLine("Aura Manipulation"));
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();
                        }
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Body Destruction
                case "Body Destruction":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Body_Magic) != null)
                        {
                            this.SayTo(player, "You are already have the Body Destruction line!");
                            return false;
                        }

                        if (player.BaseLinesChosen >= 3)
                        {
                            this.SayTo(player, "You already have trained the maximum base line specializations, I can't teach you any more.");
                        }

                        else
                        {

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Body_Magic));
                            player.AddSpellLine(SkillBase.GetSpellLine("Body Destruction"));

                            // Increment the amount of Baselines chosen
                            player.BaseLinesChosen++;

                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();
                        }


                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;

                #endregion

                #region Chants
                case "Chants":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Chants) != null)
                        {
                            this.SayTo(player, "You are already have the Chants line!");
                            return false;
                        }


                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Chants));
                            player.AddSpellLine(SkillBase.GetSpellLine("Chants"));
                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();



                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Critical Strike
                case "Critical Strike":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Critical_Strike) != null)
                        {
                            this.SayTo(player, "You are already have the Critical Strike line!");
                            return false;
                        }
                        else
                        {

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Critical_Strike));
                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();
                        }
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Crush
                case "Crush":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpecialization(Specs.Crush) != null)
                        {
                            this.SayTo(player, "You are already have the Crush line!");
                            return false;
                        }

                        player.AddSpecialization(SkillBase.GetSpecialization(Specs.Crush));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Deathsight
                case "Deathsight":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Deathsight) != null)
                        {
                            this.SayTo(player, "You are already have the Deathsight line!");
                            return false;
                        }

                        if (player.BaseLinesChosen >= 3)
                        {
                            this.SayTo(player, "You already have trained the maximum base line specializations, I can't teach you any more.");
                        }

                        else
                        {

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Deathsight));
                            player.AddSpellLine(SkillBase.GetSpellLine("Deathsight"));

                            // Increment the amount of Baselines chosen
                            player.BaseLinesChosen++;

                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();
                        }


                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Death Servant
                case "Death Servant":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Death_Servant) != null)
                        {
                            this.SayTo(player, "You are already have the Matter line!");
                            return false;
                        }

                        if (player.BaseLinesChosen >= 3)
                        {
                            this.SayTo(player, "You already have trained the maximum base line specializations, I can't teach you any more.");
                        }

                        else
                        {

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Death_Servant));
                            player.AddSpellLine(SkillBase.GetSpellLine("Death Servant"));

                            // Increment the amount of Baselines chosen
                            player.BaseLinesChosen++;

                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();
                        }


                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Dual Wield
                case "Dual Wield":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Dual_Wield) != null)
                        {
                            this.SayTo(player, "You are already have the Dual Wield line!");
                            return false;
                        }

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Dual_Wield));
                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();

                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Enhancements
                case "Enhancement":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Enhancement) != null)
                        {
                            this.SayTo(player, "You are already have the Enhancement line!");
                            return false;
                        }

                        if (player.BaseLinesChosen >= 3)
                        {
                            this.SayTo(player, "You already have trained the maximum base line specializations, I can't teach you any more.");
                        }

                        else
                        {

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Enhancement));
                            player.AddSpellLine(SkillBase.GetSpellLine("Enhancement"));

                            // Increment the amount of Baselines chosen
                            player.BaseLinesChosen++;

                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();
                        }


                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Fist Wraps
                case "Fist Wraps":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpecialization(Specs.Fist_Wraps) != null) 
                        {
                            this.SayTo(player, "You are already have the Fist Wraps line!");
                            return false;
                        }

                        player.AddSpecialization(SkillBase.GetSpecialization(Specs.Fist_Wraps));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;

                #endregion

                #region Flexible
                case "Flexible":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Flexible) != null)
                        {
                            this.SayTo(player, "You are already have the Flexible line!");
                            return false;
                        }

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Flexible));
                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();

                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Instruments
                case "Instruments":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Instruments) != null)
                        {
                            this.SayTo(player, "You are already have the Instruments line!");
                            return false;
                        }

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Instruments));
                            player.AddSpellLine(SkillBase.GetSpellLine("Instruments"));
                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();

                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Magnetism
                case "Magnetism":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpecialization(Specs.Magnetism) != null)
                        {
                            this.SayTo(player, "You are already have the Magnetism line!");
                            return false;
                        }

                        player.AddSpecialization(SkillBase.GetSpecialization(Specs.Magnetism));
                        player.AddSpellLine(SkillBase.GetSpellLine("Magnetism"));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Matter
                case "Matter":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Matter_Magic) != null)
                        {
                            this.SayTo(player, "You are already have the Matter line!");
                            return false;
                        }

                        if (player.BaseLinesChosen >= 3)
                        {
                            this.SayTo(player, "You already have trained the maximum base line specializations, I can't teach you any more.");
                        }

                        else
                        {

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Matter_Magic));
                            player.AddSpellLine(SkillBase.GetSpellLine("Matter"));

                            // Increment the amount of Baselines chosen
                            player.BaseLinesChosen++;

                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();
                        }


                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Mauler Staff
                case "Mauler Staff":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpecialization(Specs.Mauler_Staff) != null)
                        {
                            this.SayTo(player, "You are already have the Mauler Staff line!");
                            return false;
                        }

                        player.AddSpecialization(SkillBase.GetSpecialization(Specs.Mauler_Staff));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;

                #endregion

                #region Pain Working
                case "Pain Working":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Painworking) != null)
                        {
                            this.SayTo(player, "You are already have the Pain Working line!");
                            return false;
                        }

                        if (player.BaseLinesChosen >= 3)
                        {
                            this.SayTo(player, "You already have trained the maximum base line specializations, I can't teach you any more.");
                        }

                        else
                        {

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Painworking));
                            player.AddSpellLine(SkillBase.GetSpellLine("Painworking"));

                            // Increment the amount of Baselines chosen
                            player.BaseLinesChosen++;

                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();
                        }


                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Polearms
                case "Polearms":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpecialization(Specs.Polearms) != null)
                        {
                            this.SayTo(player, "You are already have the Polearms line!");
                            return false;
                        }

                        player.AddSpecialization(SkillBase.GetSpecialization(Specs.Polearms));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Power Strikes
                case "Power Strikes":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpecialization(Specs.Power_Strikes) != null)
                        {
                            this.SayTo(player, "You are already have the Power Strikes line!");
                            return false;
                        }

                        player.AddSpecialization(SkillBase.GetSpecialization(Specs.Power_Strikes));
                        player.AddSpellLine(SkillBase.GetSpellLine("Power Strikes"));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Rejuvenation
                case "Rejuvenation":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Rejuvenation) != null)
                        {
                            this.SayTo(player, "You are already have the Rejuvenation line!");
                            return false;
                        }

                        if (player.BaseLinesChosen >= 3)
                        {
                            this.SayTo(player, "You already have trained the maximum base line specializations, I can't teach you any more.");
                        }

                        else
                        {

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Rejuvenation));
                            player.AddSpellLine(SkillBase.GetSpellLine("Rejuvenation"));

                            // Increment the amount of Baselines chosen
                            player.BaseLinesChosen++;

                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();
                        }


                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Shields
                case "Shields":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpecialization(Specs.Shields) != null)
                        {
                            this.SayTo(player, "You are already have the Shields line!");
                            return false;
                        }

                        player.AddSpecialization(SkillBase.GetSpecialization(Specs.Shields));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Slash
                case "Slash":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Slash) != null)
                        {
                            this.SayTo(player, "You are already have the Slash line!");
                            return false;
                        }

                        player.AddSpecialization(SkillBase.GetSpecialization(Specs.Slash));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Smiting
                case "Smiting":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Matter_Magic) != null)
                        {
                            this.SayTo(player, "You are already have the Smiting line!");
                            return false;
                        }

                        if (player.BaseLinesChosen >= 3)
                        {
                            this.SayTo(player, "You already have trained the maximum base line specializations, I can't teach you any more.");
                        }

                        else
                        {

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Smite));
                            player.AddSpellLine(SkillBase.GetSpellLine("Smiting"));

                            // Increment the amount of Baselines chosen
                            player.BaseLinesChosen++;

                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();
                        }


                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Stealth
                case "Stealth":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Stealth) != null)
                        {
                            this.SayTo(player, "You are already have the Stealth line!");
                            return false;
                        }

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Stealth));
                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();


                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Staff
                case "Staff":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Staff) != null)
                        {
                            this.SayTo(player, "You are already have the Staff line!");
                            return false;
                        }

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Staff));
                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();

                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Spirit Animation
                case "Spirit Animation":
                    if (specs.Count < 6)
                    {
                        if (player.GetSpecialization(Specs.Spirit_Magic) != null)
                        {
                            this.SayTo(player, "You are already have the Spirit Animation line!");
                            return false;
                        }

                        if (player.BaseLinesChosen >= 3)
                        {
                            this.SayTo(player, "You already have trained the maximum base line specializations, I can't teach you any more.");
                        }

                        else
                        {

                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Spirit_Magic));
                            player.AddSpellLine(SkillBase.GetSpellLine("Spirit Animation"));

                            // Increment the amount of Baselines chosen
                            player.BaseLinesChosen++;

                            //save to Database
                            player.SaveIntoDatabase();
                            player.SendTrainerWindow();
                        }
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion  

                #region Thrust
                case "Thrust":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpecialization(Specs.Thrust) != null)
                        {
                            this.SayTo(player, "You are already have the Crush line!");
                            return false;
                        }

                        player.AddSpecialization(SkillBase.GetSpecialization(Specs.Thrust));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion

                #region Twohanded
                case "Two Handed":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpecialization(Specs.Two_Handed) != null)
                        {
                            this.SayTo(player, "You are already have the Two Handed line!");
                            return false;
                        }

                        player.AddSpecialization(SkillBase.GetSpecialization(Specs.Two_Handed));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I can't teach you any more.");
                    }
                    return true;
                #endregion



#endregion
            }
			return true;
		}
	}
}
