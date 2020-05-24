using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.created
{
    class caveEncounter : ListBoxInteraction
    {
        int preparation = 0;
        int littleFound = 10;
        int mediumFound = 50;
        int bigFound = 100;
        bool visited = false;

        public caveEncounter(GameSession ses) : base (ses)
        {
            Name = "interaction0006";
        }

        protected override void RunContent()
        {
            if(preparation ==0 && !visited)
            {
                parentSession.SendText("\nWelcome in my cave adventurer, " +
                    "\nI cant let u pass into " +
                    "\n if u dont have nothing for me");
                if (!parentSession.TestForItem("item9999"))
                {
                    parentSession.SendText("\nYou dont have nothing that means something to me, LEAVE!");
                    return;
                }
                else if (parentSession.TestForItem("item9999") && parentSession.currentPlayer.Level < 5)
                {
                    parentSession.SendText("\nOh, You got that ring, but You are too weak to face " +
                        "the darkness inside my cave!");
                    return;
                }
                else
                {
                    parentSession.SendText("\nOk, You are strong enough to go into my place, are You sure? There is no going back after!");
                    int choice = GetListBoxChoice(new List<string>() { "I think I am ready!", "I need to prepare..." });
                    if (choice == 1)
                    {
                        parentSession.SendText("\nThen prepare Yourself and come back!");
                        preparation++;
                    }
                    else
                    {
                        IntoTheCave();
                    }
                }
            }
            else if(!visited)
            {
                parentSession.SendText("\nI assume You prepared Yourself, alright then...");
                IntoTheCave();
            }
            else if(visited)
            {
                parentSession.SendText("\nYou have been in my cave already, go back then...");
                return;
            }

        }

        private void IntoTheCave()
        {
            parentSession.SendText("\nThere is complete darkness... If only I find a tourch....");
            if(parentSession.currentPlayer.Precision > 50)
            {
                parentSession.SendText("\nTHERE IT IS!");
                parentSession.SendText("\n*You have temporary boost due to better visibility*");
                parentSession.UpdateStat(1, 50);
                if(parentSession.TestForItemClass("Staff"))
                {
                    parentSession.UpdateStat(2, 10);
                }
                else
                {
                    parentSession.UpdateStat(5, 10);
                }
            }
            else
            {
                parentSession.SendText("\nI cant find anything...!");
            }

            parentSession.SendText("\nThere is a fork... " +
                "which way should i choose....");
            int choice2 = GetListBoxChoice(new List<string>() { "Go straight!", "Turn left!","Turn right!" });
            if(choice2 == 0)
            {
                parentSession.SendText("\nI found something... " +
                    " its a chest!");
                parentSession.UpdateStat(littleFound, 8);

            }
            else if(choice2 == 1)
            {
                parentSession.SendText("\nThere is a monster!");
                parentSession.FightRandomMonster();
            }
            else
            {
                parentSession.SendText("\n Ahhh there is a dead end...");
            }
            parentSession.SendText("\nThere is a fork... " +
             "which way should i choose....");
            int choice3 = GetListBoxChoice(new List<string>() { "Go straight!", "Turn left!", "Turn right!" });
            if (choice3 == 1)
            {
                parentSession.SendText("\nI found something... " +
                    " its a chest!");
                parentSession.UpdateStat(mediumFound, 8);

            }
            else if (choice3 == 0)
            {
                parentSession.SendText("\nThere is a monster!");
                parentSession.FightRandomMonster();
            }
            else
            {
                parentSession.SendText("\n Ahhh there is a dead end...");
            }
            parentSession.SendText("\nThere is a fork... " +
            "which way should i choose....");
            int choice4 = GetListBoxChoice(new List<string>() { "Go straight!", "Turn left!", "Turn right!" });
            if (choice4 == 2)
            {
                parentSession.SendText("\nI found something... " +
                    " its a chest!");
                parentSession.UpdateStat(bigFound, 8);

            }
            else if (choice4 == 1)
            {
                parentSession.SendText("\nThere is a group of monsters!");
                parentSession.FightRandomMonster();
                parentSession.FightRandomMonster();
                parentSession.FightRandomMonster();
            }
            else
            {
                parentSession.SendText("\n Ahhh there is a dead end...");
            }
            parentSession.SendText("\nI think i see the light!!");
            parentSession.UpdateStat(200, 7);
            visited = true;
        }
    }
}
