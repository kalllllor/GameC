using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class GymirHymirFactory : InteractionFactory
    {
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            HymirEncounter hymir = new HymirEncounter(parentSession);
            GymirEncounter gymir = new GymirEncounter(parentSession, hymir);
            return new List<Interaction>() { hymir, gymir };
        }
    }
}
