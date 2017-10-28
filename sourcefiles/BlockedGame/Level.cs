namespace GXPEngine{
    public class Level : GameObject{
        public Level(){
            Player player = new Player(this);
            AddChild(player);
            
            //Temporary reference sprite
            AddChild(new Sprite("colors.png"));
        }

        public void Update(){
            
        }

        public float GetFloor(Sprite sprite){
            return game.height - sprite.height;
        }
    }
}