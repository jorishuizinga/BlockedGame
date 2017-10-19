using System.Drawing;

namespace GXPEngine{
    public class Player : AnimationSprite{
        private float playerSpeed = 10;
        
        public Player() : base("colors.png", 1, 1, 1){
            SetOrigin(width / 2, height / 2);
            y = game.height / 2;
            x = game.width / 2;
        }

        public void Update(){
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
        }
    }
}