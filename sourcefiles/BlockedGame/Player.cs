using System.Drawing;

namespace GXPEngine{
    public class Player : AnimationSprite{
        private float playerSpeed = 3;
        private int frameCounter;
        
        public Player() : base("player.png", 8, 1, 8){
            SetOrigin(width / 2, height / 2);
            y = game.height / 2;
            x = game.width / 2;
            frameCounter = 0;
        }

        public void Update(){
            //Input
            if (Input.GetKey(Key.W)){
                y -= playerSpeed;
            }
            if (Input.GetKey(Key.S)){
                y += playerSpeed;
            }
            if (Input.GetKey(Key.A)){
                x -= playerSpeed;
            }
            if (Input.GetKey(Key.D)){
                x += playerSpeed;
            }
            
            //Animation
            if (frameCounter >= 20){
                NextFrame();
                frameCounter = 0;
            }
            frameCounter++;
        }
    }
}