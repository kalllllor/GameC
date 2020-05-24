using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.created
{
    class MasterOfMagicEncounter : ConsoleInteraction
    {
        private bool visited = false;
        public IMasterStrategy Strategy { get; set; }  
        public MasterOfMagicEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction0008";
            Strategy = new NeutralMasterOfMagicStrategy(); 
        }
        protected override void RunContent()
        {
            Strategy.Execute(parentSession, visited); 
            visited = true;
        }
    }
}
