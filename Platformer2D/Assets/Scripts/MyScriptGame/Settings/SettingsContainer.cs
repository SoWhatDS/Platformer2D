
using Platformer2d.Engine.Game.Player;
using Platformer2d.Engine.LevelSelect;
using Platformer2d.Engine.Game.Enemy;
using UnityEngine;
using Platformer2d.Engine.Game.UI;
using Platformer2d.Engine.Sound;
using Platformer2d.Engine.Level.InterectableObjects;
using Platformer2d.Engine.Game;

namespace Platformer2d.Settings
{
    [CreateAssetMenu(fileName = nameof(SettingsContainer), menuName = "Settings/ " + nameof(SettingsContainer))]
    internal sealed class SettingsContainer : ScriptableObject
    {
        [field: SerializeField] public LevelSelectModel LevelSelectModel { get; private set; }
        [field: SerializeField] public PlayerModel PlayerModel { get; private set; }
        [field: SerializeField] public EnemyModel KnightModel { get; private set; }
        [field: SerializeField] public UIGameModel UIGameModel { get; private set; }
        [field: SerializeField] public FlyingEyeModel FlyingEyeModel { get; private set; }
        [field: SerializeField] public SoundModel SoundModel { get; private set; }
        [field: SerializeField] public InterectibleObjectsModel InterectibleObjectsModel { get; private set; }
        [field: SerializeField] public PlayerManagerModel PlayerManagerModel { get; private set; }
    }
}
