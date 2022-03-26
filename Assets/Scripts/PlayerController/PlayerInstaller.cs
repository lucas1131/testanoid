using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller<PlayerInstaller>
{
	public GameObject playerPrefab;
	public GameObject inputListenerPrefab;
	public GameObject playerSpawnPoint;

	public override void InstallBindings()
	{
		Container.BindInterfacesTo<PlayerPresenter>()
			.FromMethod((InjectContext context) => {
				var playerObj = GameObject.Instantiate(playerPrefab, playerSpawnPoint.transform);
				return playerObj.GetComponent<PlayerPresenter>();
			})
			.AsSingle();

		Container.BindInterfacesTo<PlayerInputListener>()
			.FromComponentInNewPrefab(inputListenerPrefab)
			.AsSingle();
			
		Container.BindInterfacesTo<PlayerController>()
			.AsSingle();
	}
}