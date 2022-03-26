using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName="GameConfigInstaller", menuName="Installers/GameConfigInstaller")]
public class GameConfigInstaller : ScriptableObjectInstaller<GameConfigInstaller>
{
    [SerializeField] private GameConfig _gameConfig;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<GameConfig>()
            .FromScriptableObject(_gameConfig)
            .AsSingle();
    }
}