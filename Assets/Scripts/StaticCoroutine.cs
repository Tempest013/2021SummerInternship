using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticCoroutine
{
    private class CoroutineHolder : MonoBehaviour { }

    private static CoroutineHolder runner;
    private static CoroutineHolder Runner
    {
        get
        {
            if (runner == null)
            {
                runner = new GameObject("Static Corotuine Runner").AddComponent<CoroutineHolder>();
            }
            return runner;
        }
    }

    public static void StartCoroutine(IEnumerator corotuine)
    {
        Runner.StartCoroutine(corotuine);
    }
}
