using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName="CoroutineDispatcherInstaller", menuName="Installers/CoroutineDispatcherInstaller")]
public class GlobalCoroutineDispatcherInstaller : ScriptableObjectInstaller<GlobalCoroutineDispatcherInstaller>
{
    public GameObject coroutineObjectPrefab;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GlobalCoroutineDispatcher>()
            .FromComponentInNewPrefab(coroutineObjectPrefab)
            .AsSingle(); 
    }
}