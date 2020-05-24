using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.created
{
    class ReadyMasterOfStrengthStrategy:IMasterStrategy
    {
        public void Execute(GameSession parentSession, bool visited)
        {
            if (visited)
            {
                parentSession.SendText("\nWelcome again true warrior! Im sorry I dont have much time right now...");
                return;
            }
            else
            {
                parentSession.SendText("\nWelcome adventurer! You must be that warrior i heard about from the barracks...");
                parentSession.SendText("Alright, I think You are powerfull enough to start my training!");
                parentSession.UpdateStat(7, 300);
                parentSession.UpdateStat(2, 200);
            }
        }
    }
}
