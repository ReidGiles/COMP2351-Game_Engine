using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace COMP2351_Game_Engine
{
    class Platform : RelicHunterEntity, ICollisionListener
    {
        public Platform()
        {

        }

        /// <summary>
        /// Initialisation logic
        /// </summary>
        public override void Initialise()
        {
            // Set initial entity mind:
            _mind = _aiComponentManager.RequestMind<PlatformMind>();
        }

        public void OnNewCollision(object sender, ICollisionInput args)
        {

        }

        public override void SetCollider()
        {
            // Create a list of colliders
            _colliders = new List<ICollider>();
            // SET first collider to Floor
            Vector2 ColliderOrigin;
            ColliderOrigin.X = location.X + 0.5f * texture.Width;
            ColliderOrigin.Y = location.Y + 0.25f * texture.Height;
            _colliders.Add(new RectCollider(ColliderOrigin, texture.Width, texture.Height/2, "Floor"));


            // SET Left collider to keep an hostile entities on the platform when moving
            ColliderOrigin.X = location.X - 10;
            ColliderOrigin.Y = location.Y - 10;
            _colliders.Add(new RectCollider(ColliderOrigin, 20, 20, "Boundary"));

            // SET right collider to keep an hostile entities on the platform when moving

            ColliderOrigin.X = location.X + texture.Width + 10;
            ColliderOrigin.Y = location.Y - 10;
            _colliders.Add(new RectCollider(ColliderOrigin, 20, 20, "Boundary"));

            // SET bottom collider to act as a ceiling to stop player jumping through

            ColliderOrigin.X = location.X + 0.5f * texture.Width;
            ColliderOrigin.Y = location.Y + 0.75f * texture.Height;
            _colliders.Add(new RectCollider(ColliderOrigin, texture.Width, texture.Height/2, "Ceiling"));

            // Add the collider list to the mind
            _mind.SetCollider(_colliders.Cast<ICreateCollider>().ToList());

            // SET has collider bool to true
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
                float DX = _mind.TranslateX();
                float DY = _mind.TranslateY();
                Translate(DX, DY);
                // updates the position of the colliders to follow the player
                foreach (ICollider e in _colliders)
                {
                    e.Translate(DX, DY);
                }
            }
            //else Console.WriteLine("Error: Mind is null");
            /*Console.WriteLine("Top"+((ICreateCollider)_collider).CreateCollider()[0]);
            Console.WriteLine("Bottom" + ((ICreateCollider)_collider).CreateCollider()[1]);
            Console.WriteLine("Left" + ((ICreateCollider)_collider).CreateCollider()[2]);
            Console.WriteLine("Right" + ((ICreateCollider)_collider).CreateCollider()[3]);*/
        }
    }
}
