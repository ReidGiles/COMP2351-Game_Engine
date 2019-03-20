using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2351_Game_Engine.Component.Engine
{
    interface IKeyboardListener
    {
        void OnNewKeyboardInput(object sender, KeyboardInput args);
    }
}