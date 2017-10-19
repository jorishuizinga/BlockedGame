namespace GXPEngine{
    public class GameCore : Game{
        public GameCore() : base(800, 800, false){
            Level level = new Level();
            AddChild(level);
        }
    }
}