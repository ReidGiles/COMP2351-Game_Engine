using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace COMP2351_Game_Engine
{
    class HostileMind : Mind
    {
        // the effect of gravity on the entity
        private float _gravity;
        // the movement speed of the entity
        private float _speed;
        // used to push the ntity out of the floor when colliding
        private float _counterForce;
        // the velocity of the entity
        private Vector2 _velocity;
        // floor collision flag
        private bool _floorCollide;
        // in air flag
        private bool _inAir;
        // on floor status flag
        private bool _onFloor;

        public HostileMind()
        {
            // set gravity
            _gravity = 10;
            // set speed
            _speed = 5;
            // set counterforce
            _counterForce = 0;
            //Set velocity 
            _velocity.X = 1;
            _velocity.Y = -1;
            // set facing direction of the sprite
            _facingDirectionX = 1;
            // set mind ID
            _mindID = "Hostile";
            // set floorCollide flag to false
            _floorCollide = false;
            // set in Air flag to true
            _inAir = true;
            // set onFoor status to false
            _onFloor = false;
        }

        public override float TranslateX()
        {
            // move the sprite along the X axis in the direction it is facing at its speed
            return (_speed * _facingDirectionX) * _velocity.X;
        }

        public override bool OnNewCollision(ICollisionInput args)
        {
            bool rtnValue = base.OnNewCollision(args);

            // on collision with HBoundary change facing direction in order to move the opposite direction
            if (_collidedWith == "HBoundary" && _collidedThis == "HostileB" ||  _collidedWith == "HBoundary" && _collidedThis == "HostileT")
            {
                _facingDirectionX *= -1;
            }

            // on collision with another entity change facing direction in order to move the opposite direction
            if (_collidedWith == "HostileB" && _collidedThis == "HostileB")
            {
                _facingDirectionX *= -1;
            }

            // on collision with Floor change floorCollide flag to true
            if (_collidedWith == "Floor" && _collidedThis == "HostileB")
            {
                _floorCollide = true;
            }

            // on collisio with the base of the player and the top of this entity remove this entity from the scene
            if (_collidedWith == "PlayerB" && _collidedThis == "HostileT")
            {
                rtnValue = true;
            }

            // Reset Collided with and this to null
            _collidedWith = null;
            _collidedThis = null;

            // return rtnValue
            return rtnValue;
        }

        public override float TranslateY()
        {
            // Gravity, always active
            if (!_floorCollide && _inAir)
            {
                // if the character is in the air and not colliding with the floor then gravity is active
                _gravity = 10;
            }
            else
            {
                // the player is colliding with the floor so inAir is false and gravity is set to 0 to emulate the floor holding the entity
                _inAir = false;
                _gravity = 0;
            }

            // if onFloor status is false but the entity is colliding with the floor and not in the air
            if (!_onFloor && _floorCollide && !_inAir)
            {
                // ensure gravity is still 0
                _gravity = 0;
                // set counterforce to push the entity ot of the floor
                _counterForce = 1;
            }

            // if the entity has just been pushed out of the floor and is now not colliding with it
            if (!_onFloor && !_floorCollide && !_inAir)
            {
                // set onFloor status to true and set counter force to push the entity back into collision with the floor
                _onFloor = true;
                _counterForce = -1;
            }

            // if the onFloor Status is true and the entity is colliding with the floor
            if (_onFloor && _floorCollide)
            {
                // set counterforce to 0 to leave the entity colliding with the floor
                _counterForce = 0;
            }

            // if the onFloor status is true and the entity is not colliding with the floorCollide and also isnt being pushed out/into the floor
            if (_onFloor && !_floorCollide && _counterForce == 0)
            {
                // then the entity is in the air
                _inAir = true;
                _onFloor = false;
            }

            // apply gravity to the entity
            return (_counterForce - _gravity) * _velocity.Y;
        }
    }
}