using System.Collections;
using UnityEngine;

public interface IGlobalCoroutineDispatcher
{
    Coroutine Dispatch(IEnumerator coroutine);
}