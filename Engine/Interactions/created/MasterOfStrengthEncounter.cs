using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.created
{
    class MasterOfStrengthEncounter:ConsoleInteraction
    {
        private bool visited = false; 
        public IMasterStrategy Strategy { get; set; } 
        public MasterOfStrengthEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction0009";
            Strategy = new NeutralMasterOfStrengthStrategy(); 
        }
        protected override void RunContent()
        {
            Strategy.Execute(parentSession, visited);
            visited = true;
        }
    }
}
