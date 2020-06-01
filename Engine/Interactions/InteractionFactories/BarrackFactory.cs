using Game.Engine.Interactions.created;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class BarrackFactory : InteractionFactory
    {
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            // Gymir and Hymir must always appear together in the game world
            MasterOfMagicEncounter masterMagic = new MasterOfMagicEncounter(parentSession);
            MasterOfStrengthEncounter masterStrength = new MasterOfStrengthEncounter(parentSession);
            BarrackEncounter barracks = new BarrackEncounter(parentSession,masterMagic,masterStrength);

            return new List<Interaction>() { barracks, masterStrength, masterMagic };
        }
    }
}
