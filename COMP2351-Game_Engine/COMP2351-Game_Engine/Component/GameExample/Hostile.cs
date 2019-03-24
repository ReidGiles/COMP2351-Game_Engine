using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2351_Game_Engine
{
    class Hostile : RelicHunterEntity, ICollisionListener
    {
        public Hostile()
        {
        }
        public override void Initialise()
        {
            // Set initial entity mind:
            _mind = _aiComponentManager.RequestMind<HostileMind>();
        }

        public void OnNewCollision(object sender, String[] collided)
        {
            //Console.WriteLine("Hostile collided");
            _mind.OnNewCollision(collided);
            //Translate(0, -10);
        }

        public override void SetCollider()
        {
            Vector2 ColliderOrigin;
            ColliderOrigin.X = location.X + 0.5f * texture.Width;
            ColliderOrigin.Y = location.Y - 0.5f * texture.Height;
            _collider = new RectCollider(ColliderOrigin, texture.Width, texture.Height, "Hostile");
            hasCollider = true;
        }

        /// <summary>
        /// Overides Update() with unique entity behaviour.
        /// </summary>
        public override void Update()
        {
            if (!hasCollider)
            {
                SetCollider();
            }
            if (_mind != null)
            {
                //tell the mind the location of the player
                _mind.UpdateLocation(location);
                //tell the mind the value fo texture
                _mind.UpdateTexture(texture);
                //updates the position of the player
                Translate(_mind.TranslateX(), _mind.TranslateY());
                // updates the position of the collider to follow the player
                _collider.Translate(location.X, location.Y);
            }
            //else Console.WriteLine("Error: Mind is null");
            /*Console.WriteLine("Top"+((ICreateCollider)_collider).CreateCollider()[0]);
            Console.WriteLine("Bottom" + ((ICreateCollider)_collider).CreateCollider()[1]);
            Console.WriteLine("Left" + ((ICreateCollider)_collider).CreateCollider()[2]);
            Console.WriteLine("Right" + ((ICreateCollider)_collider).CreateCollider()[3]);*/
        }
    }
}
