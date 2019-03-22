using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2351_Game_Engine
{
    class Floor : RelicHunterEntity, ICollisionListener
    {
        public Floor()
        {
        }
        public void OnNewCollision(object sender, ICollisionHandler args)
        {
        }
    }
}
