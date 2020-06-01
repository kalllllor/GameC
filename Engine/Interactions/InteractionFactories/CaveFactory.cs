using Game.Engine.Interactions.created;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class CaveFactory : InteractionFactory
    {
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            GoblinEncounter goblic = new GoblinEncounter(parentSession);
            CaveEncounter cave = new CaveEncounter(parentSession);
            return new List<Interaction>() {goblic, cave};
        }
    }
}
