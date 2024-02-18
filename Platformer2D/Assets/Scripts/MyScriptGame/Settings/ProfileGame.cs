
using Platformer2d.Utils;

namespace Platformer2d.Settings
{
    internal sealed class ProfileGame
    {
        public readonly SubscriptionProperty<GameState> CurrentGameState;

        public ProfileGame(GameState initialGameState)
        {
            CurrentGameState = new SubscriptionProperty<GameState>();
            CurrentGameState.Value = initialGameState;
        }
    }
}
