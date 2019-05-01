using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2351_Game_Engine
{
    class GoldMind : Mind
    {
        public GoldMind()
        {
            _mindID = "Gold";
        }

        public override bool OnNewCollision(ICollisionInput args)
        {
            bool rtnValue = base.OnNewCollision(args);

            if (_collidedWith == "PlayerB" && _collidedThis == "CoinGold" || _collidedWith == "PlayerT" && _collidedThis == "CoinGold")
            {
                rtnValue = true;
            }
            return rtnValue;
        }
    }
}
