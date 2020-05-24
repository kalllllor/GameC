using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.created
{
    class ReadyMasterOfMagicStrategy :IMasterStrategy
    {
        public void Execute(GameSession parentSession, bool visited)
        {
            if (visited)
            {
                parentSession.SendText("\nWelcome again true wizard! Im sorry I dont have much time right now...");
                return;
            }
            else
            {
                parentSession.SendText("\nWelcome adventurer! You must be that wizard i heard about from the barracks...");
                parentSession.SendText("Alright, I think You are powerfull enough to start my training!");
                parentSession.UpdateStat(7, 300);
                parentSession.UpdateStat(5, 200);
            }
        }
    }
}
