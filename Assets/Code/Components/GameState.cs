namespace Client.Components
{
    public enum GameStatus
    {
        Menu = 0,
        Play = 1
    }
    public struct GameState
    {
        public GameStatus GameStatus;
    }
}