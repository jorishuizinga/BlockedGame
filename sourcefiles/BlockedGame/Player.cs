using System;
using System.Drawing;

namespace GXPEngine{
    public class Player : AnimationSprite{
        private float playerSpeed = 3;
        private float xSpeed;
        private float ySpeed;
        private int frameCounter;
        private int idleCounter;

        private Level level;

        enum PlayerState{
            IDLE,
            WALKING,
            SHOOTING,
            JUMPING,
            FALLING
        };

        enum JumpState{
            NONE,
            ASCENDING,
            DESCENDING
        }

        private PlayerState playerState;
        
        public Player(Level level) : base("player.png", 8, 1, 8){
            this.level = level;
            SetOrigin(width / 2, height / 2);
            y = game.height / 2;
            x = game.width / 2;
            frameCounter = 0;
        }

        public void Update(){
            //Input
            if (Input.GetKey(Key.LEFT)){
                xSpeed -= 2;
                playerState = PlayerState.WALKING;
            }else if (Input.GetKey(Key.RIGHT)){
                xSpeed += 2;
                playerState = PlayerState.WALKING;
            }else if (Input.GetKey(Key.UP) && (playerState == PlayerState.IDLE || playerState == PlayerState.WALKING)){
                playerState = PlayerState.JUMPING;
            }else if (idleCounter >= 20 && playerState != PlayerState.IDLE){
                playerState = PlayerState.IDLE;
            }else{
                idleCounter++;
            }

            if (playerState == PlayerState.FALLING){
                
            }

            x += xSpeed;
            level.x -= xSpeed;

            xSpeed *= 0.9f;
            
            //Animation
            if (playerState == PlayerState.WALKING){
                if (frameCounter >= 15){
                    NextFrame();
                    frameCounter = 0;
                }
                frameCounter++;
            }else{
                currentFrame = 0;
                frameCounter = 0;
            }
        }
    }
}