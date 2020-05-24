using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.created
{
    class NeutralMasterOfMagicStrategy :IMasterStrategy
    {
        public void Execute(GameSession parentSession, bool visited)
        {
            parentSession.SendText("\nHello adventurer. I am the master of magic!");
            parentSession.SendText("Im sorry but You are too weak to face my training...");
        }
    }
}
