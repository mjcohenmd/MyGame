using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayCoroutine : MonoBehaviour
{
    public IEnumerator coroutine;

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
    }
}