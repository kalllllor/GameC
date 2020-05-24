using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Game.Engine.Interactions.created
{
    class GoblinEncounter : ListBoxInteraction
    {
        private int visited = 0;

        List<string> weapons = new List<string>()
        {
            "Axe",
            "Spear",
            "Staff",
            "Sword"
        };

        public GoblinEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction0005";
        }

        protected override void RunContent()
        {
            foreach (string weapon in weapons)
            {
                if (parentSession.TestForItemClass(weapon) && visited >= 0)
                {
                    parentSession.SendText("\n Put that " + weapon +" in Your pocket, then get back You human useless being!");
                    visited++;
                    break;
                }
                else if(visited >= 0 && visited <= 3)
                {
                    parentSession.SendText("\nNow We can start talk! Listen now, if You will pass two of my mysteries I will price You!");
                    int choice = GetListBoxChoice(new List<string>() { "Sure, I will try!", "I dont have time for games!" });
                    if (choice == 1)
                    {
                        parentSession.SendText("\nGET LOST THEN!!!");
                        visited = -1;
                        return;
                    }
                    else
                    {
                        parentSession.SendText("\nAlright, first question... \n What has roots as nobody sees,\nIs taller than trees,\n Up, up it goes, \n And yet never grows? \n");
                        int choice2 = GetListBoxChoice(new List<string>() { "Thats easy! Its forest!", "I think its a mountain..." });
                        if(choice == 0)
                        {
                            parentSession.SendText("HAHA You fool! Wrong!");
                            visited = -1;
                            return;
                        }
                        else
                        {
                            parentSession.SendText("AHHHH HOW DO KNOW IT! YOU ARE CHEATING...\n Alright.... \n You can leave now and I can pray You with a little price, but if You want another one and You will be wrong You wil be dead HAHA!");
                            int choice3 = GetListBoxChoice(new List<string>() { "Hey! You are changing the rules!!!!", "I will take already whats mine!","I want to guess another one..." });
                            switch(choice3)
                            {
                                case 0:
                                    parentSession.FightRandomMonster();
                                    visited = -1;
                                    break;
                                case 1:
                                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0381"));
                                    visited = -1;
                                    break;
                                case 2:
                                    parentSession.SendText("\nAlright, here we go... \n Voiceless it cries,\nWingless flutters,\n Toothless bites, \n Mouthless mutters.  WHATS THAT??\n");
                                    int choice4 = GetListBoxChoice(new List<string>() { "Thats easy! Its fire!", "I think its a wind..." });
                                    if (choice4 == 0)
                                    {
                                        parentSession.SendText("HAHA You fool! Wrong! NOW YOU ARE DEAD");
                                        visited = -1;
                                        parentSession.FightRandomMonster();
                                        parentSession.FightRandomMonster();
                                        parentSession.FightRandomMonster();
                                        return;
                                    }
                                    else
                                    {
                                        parentSession.SendText("\nHOW DO YOU KNOW IT!! GET LOST WITH THAT RING, GIVE THAT RING TO GATEKEEPER OF DANGEONS!");
                                        parentSession.AddThisItem(Index.ProduceSpecificItem("item9999"));
                                        visited = -1;
                                        return;
                                    }
                            }
                        }
                    }
                }
                else
                {
                    parentSession.SendText("\nDont waste my time.");
                    return;
                }    
            }

        }
    }
}
