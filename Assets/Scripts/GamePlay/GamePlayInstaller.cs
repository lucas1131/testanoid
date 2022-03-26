using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GamePlayInstaller : MonoInstaller
{
	public enum GameTextsIds
	{
		Score,
		Lives,
		Ready
	};

	[SerializeField] private Text _scoreText;
    [SerializeField] private Text _livesText;
    [SerializeField] private Text _getReadyText;

    public override void InstallBindings()
    {
    	InstallTexts();
    	InstallGamePlay();
    }

    private void InstallTexts()
    {
		Container.Bind<Text>()
			.WithId(GameTextsIds.Score)
			.FromInstance(_scoreText)
			.AsTransient();

		Container.Bind<Text>()
			.WithId(GameTextsIds.Lives)
			.FromInstance(_livesText)
			.AsTransient();

		Container.Bind<Text>()
			.WithId(GameTextsIds.Ready)
			.FromInstance(_getReadyText)
			.AsTransient();
    }

    private void InstallGamePlay()
    {
    	Container.BindInterfacesTo<GamePlay>()
			.FromNew()
			.AsSingle()
			.NonLazy();
    }
}