using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace COMP2351_Game_Engine
{
    class Player : RelicHunterEntity, IPlayer, ICollisionListener
    {
        public Player()
        {
        }

        /// <summary>
        /// Initialisation logic
        /// </summary>
        public override void Initialise()
        {
            // Set initial entity mind:
            _mind = _aiComponentManager.RequestMind<PlayerMind>();

        }

        public void OnNewCollision(object sender, ICollisionInput args)
        {
            Console.WriteLine(_uName + " collided");
            
            this._killSelf = _mind.OnNewCollision(args,_uid);

        }

        public override void SetCollider()
        {
            Vector2 ColliderOrigin;
            ColliderOrigin.X = location.X + 0.5f * texture.Width;
            ColliderOrigin.Y = location.Y + 0.5f * texture.Height;
            _colliders = new List<ICollider>();
            _colliders.Add(new RectCollider(ColliderOrigin, texture.Width, texture.Height, "Player"));
            _mind.SetCollider(_colliders.Cast<ICreateCollider>().ToList());
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