namespace _Project.Scripts.Infrastructure
{
    public interface IGameStateProvider
    {
        void SaveGameState();
        void LoadGameState();
    }
}