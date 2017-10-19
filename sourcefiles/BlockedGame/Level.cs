namespace GXPEngine{
    public class Level : GameObject{
        public Level(){
            Player player = new Player();
            AddChild(player);
        }

        public void Update(){
            
        }
    }
}