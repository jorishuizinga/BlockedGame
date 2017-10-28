namespace GXPEngine{
    public class GameCore : Game{
        public GameCore() : base(1600, 900, false){
            Level level = new Level();
            AddChild(level);
        }
    }
}