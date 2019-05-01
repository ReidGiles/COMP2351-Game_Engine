using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2351_Game_Engine
{
    class RelicMind : Mind
    {
        public RelicMind()
        {
            _mindID = "Relic";
        }

        public override bool OnNewCollision(ICollisionInput args)
        {
            bool rtnValue = base.OnNewCollision(args);
            if (_collidedWith == "PlayerB" && _collidedThis == "RelicSaw" || _collidedWith == "PlayerT" && _collidedThis == "RelicSaw")
            {
                rtnValue = true;
            }
            return rtnValue;
        }
    }
}
