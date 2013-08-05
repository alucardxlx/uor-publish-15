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
using DOL.Database;
using DOL.GS.PacketHandler;
using DOL.Language;

namespace DOL.GS.Trainer
{
	/// <summary>
	/// Destruction Trainer
	/// </summary>
	//Customize per trainer
	[NPCGuildScript("The Trainer", eRealm.None)]
	public class TheTrainer : GameTrainer
	{
		
		public override eCharacterClass TrainedClass
		{
			get { return eCharacterClass.Unknown; }
		}
		//Customize per trainer
		public TheTrainer()
			//: base(eChampionTrainerType.Destruction)
		{
		}

		/// <summary>
		/// Interact with trainer
		/// </summary>
		/// <param name="player"></param>
		/// <returns></returns>
		public override bool Interact(GamePlayer player)
		{
			if (!base.Interact(player)) return false;
			//Customize per trainer
			player.Out.SendMessage(this.Name + " says, \"You can have any six spec lines. Choose wisely this will not be undone. Do you want a spec line from [Albion], [Midgard], or [Hibernia].?\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
			
			OfferTraining(player);
			
			return true;
		}

		/// <summary>
		/// Talk to trainer
		/// </summary>
		/// <param name="source"></param>
		/// <param name="text"></param>
		/// <returns></returns>
		public override bool WhisperReceive(GameLiving source, string text)
		{
			GamePlayer player = source as GamePlayer;
			IList specs = player.GetSpecList(); //Enumerate spec list for count
			if (!base.WhisperReceive(source, text)) return false;
			switch (text)
			{
                //Customize per trainer
                #region Albion

                case "Albion":
                    player.Out.SendMessage(this.Name + "says, \"Your choices are [Archery], [Body Magic], [Matter Magic], [Mind Magic], [Spirit Magic], and [Transend].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
					return true;

                #endregion

                #region Midgard

                case "Midgard":
                    player.Out.SendMessage(this.Name + "says, \"Your choices are [Archery], [Body Magic], [Matter Magic], [Mind Magic].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    return true;
                #endregion

                #region Hibernia

                case "Hibernia":
                    player.Out.SendMessage(this.Name + "says, \"Your choices are [Archery], [Body Magic], [Matter Magic], [Mind Magic].\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    return true;
                #endregion

                #region Archery

                case "Archery":
                    if (specs.Count < 6)
                    {
                       

                        if (player.GetSpellLine("Archery") != null)
                        {
                            //Customize per trainer
                            this.SayTo(player, "You are already on the path of Archery!");
                            return false;
                        }
                        //Customize per trainer
                        player.AddSpecialization(SkillBase.GetSpecialization("Archery"));
                        player.AddSpellLine(SkillBase.GetSpellLine("Archery"));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I cannot teach you.");
                    }
                    return true;
#endregion

                #region Sorc/Cabalist
                #region Body Magic


                case "Body Magic":
                    player.Out.SendMessage(this.Name + "says, \"Do you want [Disorientation] or [Essence Manipulation].?\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    return true;

                case "Disorientation":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpellLine("Disorientation") != null)
                        {
                            //Customize per trainer
                            this.SayTo(player, "You are already have the spell line Disorientation!");
                            return false;
                        }
                        //Customize per trainer
                        if (player.GetSpecialization(Specs.Body_Magic) == null)
                        {
                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Body_Magic));
                        }
                        player.AddSpellLine(SkillBase.GetSpellLine("Disorientation"));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I cannot teach you.");
                    }
                    return true;

                case "Essence Manipulation":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpellLine("Essence Manipulation") != null)
                        {
                            //Customize per trainer
                            this.SayTo(player, "You are already have the spell line Essence Manipulation!");
                            return false;
                        }
                        //Customize per trainer
                        if (player.GetSpecialization(Specs.Body_Magic) != null)
                        {
                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Body_Magic));
                        }
                        player.AddSpellLine(SkillBase.GetSpellLine("Essence Manipulation"));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I cannot teach you.");
                    }
                    return true;
                #endregion

                #region Matter Magic
                case "Matter Magic":
                    player.Out.SendMessage(this.Name + "says, \"Do you want [Telekinesis] or [Matter Manipulation].?\"", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                    return true;

                case "Telekinesis":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpellLine("Telekinesis") != null)
                        {
                            //Customize per trainer
                            this.SayTo(player, "You are already have the spell line Telekenisis!");
                            return false;
                        }
                        //Customize per trainer
                        if (player.GetSpecialization(Specs.Matter_Magic) == null)
                        {
                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Matter_Magic));
                        }
                        player.AddSpellLine(SkillBase.GetSpellLine("Telekinesis"));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I cannot teach you.");
                    }
                    return true;

                case "Matter Manipulation":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpellLine("Matter Manipulation") != null)
                        {
                            //Customize per trainer
                            this.SayTo(player, "You are already have the spell line Matter Manipulation!");
                            return false;
                        }
                        //Customize per trainer
                        if (player.GetSpecialization(Specs.Matter_Magic) != null)
                        {
                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Matter_Magic));
                        }
                        player.AddSpellLine(SkillBase.GetSpellLine("Matter Manipulation"));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I cannot teach you.");
                    }
                    return true;

                #endregion

                #region Mind Magic

                case "Mind Magic":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpellLine("Domination") != null)
                        {
                            //Customize per trainer
                            this.SayTo(player, "You are already on the spell line Domination!");
                            return false;
                        }
                        //Customize per trainer
                        if (player.GetSpecialization(Specs.Mind_Magic) == null)
                        {
                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Mind_Magic));
                        }
                        player.AddSpellLine(SkillBase.GetSpellLine("Domination"));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I cannot teach you.");
                    }
                    return true;

                #endregion

                #region Spirit Magic
                case "Spirit Magic":
                    if (specs.Count < 6)
                    {


                        if (player.GetSpellLine("Vivication") != null)
                        {
                            //Customize per trainer
                            this.SayTo(player, "You are already on the spell line Domination!");
                            return false;
                        }
                        //Customize per trainer
                        if (player.GetSpecialization(Specs.Spirit_Magic) == null)
                        {
                            player.AddSpecialization(SkillBase.GetSpecialization(Specs.Spirit_Magic));
                        }
                        player.AddSpellLine(SkillBase.GetSpellLine("Vivication"));
                        player.SaveIntoDatabase();
                        player.SendTrainerWindow();
                    }
                    else
                    {
                        this.SayTo(player, "You already have trained the maximum specializations, I cannot teach you.");
                    }
                    return true;
                #endregion
                #endregion

                #region Cleric/Friar
                #region Rejuvination
#endregion
                #region Enhancement
#endregion
                #region Smite
#endregion
                #endregion

                #region Transend

                case "Transend":
					{
						//Customize per trainer
						player.Out.SendCustomDialog("This will Transend you removing all your skills, spells, styles.", new CustomDialogResponse(Transend));
					}
					return true;

                #endregion
            }
			return true;
		}
		
		public static void Transend(GamePlayer player, byte response)
		{
			if (response != 0x01) return;
			else
			{
				//Customize per trainer
            
                    player.RemoveAllSpecs();
                    player.RemoveAllSpellLines();
                    player.RemoveAllStyles();
                    player.RemoveAllSkills();
                    //player.UpdateSpellLineLevels(true);
                    //player.RefreshSpecDependantSkills(true);
                    player.StartPowerRegeneration();
                    //player.Out.SendUpdatePlayerSpells();
                    player.Out.SendUpdatePlayerSkills();
                    player.Out.SendUpdatePlayer();
                    player.SaveIntoDatabase();
                    player.SendTrainerWindow();
                    
			}
		}

	}
}
