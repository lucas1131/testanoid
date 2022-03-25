using UnityEngine;
using Zenject;

public class BallInstaller : MonoInstaller<BallInstaller>
{
	public GameObject ballPrefab;

	public override void InstallBindings()
	{
		Container.BindInterfacesTo<BallPresenter>()
			.FromComponentInNewPrefab(ballPrefab)
			.AsSingle();
			
		Container.BindInterfacesTo<BallController>()
			.AsSingle();
	}
}