using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2351_Game_Engine
{
    class CollisionHandler : ICollisionInput
    {
        private String[] _collided;
        private int[] _UID;
        public CollisionHandler(String[] pCollided, int[] pUID)
        {
            _collided = pCollided;
            _UID = pUID;
        }

        public String[] GetCollided()
        {
            return _collided;
        }

        public int[] GetUID()
        {
            return _UID;
        }
    }
}
