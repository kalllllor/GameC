using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.created
{
    class barrackEncounter : ListBoxInteraction
    {
        private MasterOfMagicEncounter magicMaster;
        private MasterOfStrengthEncounter strengthMaster;
        private int numberOfTrainings = 0;
        private string typeOfWarrior;
        private bool visited = false;
        private int magicTraning,staminaTraining,strengthTraining,armorTraining = 50;

        public barrackEncounter(GameSession ses,MasterOfMagicEncounter magicMaster,MasterOfStrengthEncounter strengthMaster) : base(ses)
        {
            Name = "interaction0007";
            this.magicMaster = magicMaster;
            this.strengthMaster = strengthMaster;
        }

        protected override void RunContent()
        {

            if (!visited)
            {
                parentSession.SendText("\nWelcome adventurer in the barracks. ");
                if (parentSession.TestForItemClass("staff"))
                {
                    parentSession.SendText("\nI see, You like to deal with magic, alright then..");
                    typeOfWarrior = "magician";
                }
                else
                {
                    parentSession.SendText("\nI see You like to deal with a real weapon..");
                    typeOfWarrior = "warrior";
                }
                parentSession.SendText("\nAlright so what do You want to train?");
                while (numberOfTrainings < 6)
                {
                    if(typeOfWarrior == "magician")
                    {
                        int choice = GetListBoxChoice(new List<string>() { "Magic Power ("+ magicTraning +" gold per training)", "Stamina!  ("+ staminaTraining +" gold per training)" });
                        if (choice == 0)
                        {
                            if (parentSession.currentPlayer.Gold > magicTraning)
                            {
                                parentSession.UpdateStat(8, -magicTraning);
                                parentSession.UpdateStat(5, 10);
                                magicTraning += 50;
                            }
                            else
                            {
                                parentSession.SendText("\nYou dont have enough money " + typeOfWarrior+"!");
                                break;
                            }

                        }
                        else
                        {
                            if (parentSession.currentPlayer.Gold > staminaTraining)
                            {
                                parentSession.UpdateStat(8, -staminaTraining);
                                parentSession.UpdateStat(6, 10);
                                staminaTraining += 20;
                            }
                            else
                            {
                                parentSession.SendText("\nYou dont have enough money " + typeOfWarrior + "!");
                                break;
                            }
                        }
                    }
                    else
                    {
                        int choice2 = GetListBoxChoice(new List<string>() { "Strength (" + strengthTraining + " gold per training)", "Armor!  (" + armorTraining + " gold per training)" });
                        if (choice2 == 0)
                        {
                            if (parentSession.currentPlayer.Gold > strengthTraining)
                            {
                                parentSession.UpdateStat(8, -strengthTraining);
                                parentSession.UpdateStat(2, 10);
                                strengthTraining += 50;
                            }
                            else
                            {
                                parentSession.SendText("\nYou dont have enough money " + typeOfWarrior + "!");
                                break;
                            }

                        }
                        else
                        {
                            if (parentSession.currentPlayer.Gold > armorTraining)
                            {
                                parentSession.UpdateStat(8, -armorTraining);
                                parentSession.UpdateStat(3, 10);
                                staminaTraining += 20;
                            }
                            else
                            {
                                parentSession.SendText("\nYou dont have enough money " + typeOfWarrior + "!");
                                break;
                            }
                        }
                    }
                }
                if(numberOfTrainings > 5)
                {
                    parentSession.SendText("I think your muscles are too exhausted! The training has come to an end!");
                    parentSession.SendText("Go find the the masters of power!");
                    visited = true;
                }

                if(typeOfWarrior == "magician")
                {
                    magicMaster.Strategy = new ReadyMasterOfMagicStrategy();
                }
                else
                {
                    strengthMaster.Strategy = new ReadyMasterOfStrengthStrategy();
                }

            }
            else
            {
                parentSession.SendText("Welcome back great student! We train You everything we could...");
            }

        }
    }
}
