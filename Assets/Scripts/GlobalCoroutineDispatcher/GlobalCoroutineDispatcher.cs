using System.Collections;
using UnityEngine;

public class GlobalCoroutineDispatcher : MonoBehaviour, IGlobalCoroutineDispatcher {

    public Coroutine Dispatch(IEnumerator coroutine)
    {
        return StartCoroutine(coroutine);
    }
}