using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Rings
{
    class DestroyedRing: Item
    {
        public DestroyedRing() : base("item9999")
        {
            PublicName = "DestroyedRing";
            PublicTip = "Broken Ring, not doing anything special besides weird shining";
            GoldValue = 1;
        }
}
}
