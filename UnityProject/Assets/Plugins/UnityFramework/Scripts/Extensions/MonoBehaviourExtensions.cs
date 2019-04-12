using System;
using System.Collections;
using UniRx;
using UnityEngine;

public static class MonoBehaviourExtensions
{
    public static void WaitForFixedUpdate(this MonoBehaviour monoBehaviour, Action action)
    {
        if (!monoBehaviour.gameObject.activeInHierarchy)
        {
            return;
        }

        MainThreadDispatcher.StartFixedUpdateMicroCoroutine(WaitForFixedUpdate(action));
    }

    private static IEnumerator WaitForFixedUpdate(Action action)
    {
        yield return null;

        action.Invoke();
    }
}
