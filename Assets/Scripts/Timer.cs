using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private static Timer _instance;
    private static Coroutine _timeCoroutine;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }


    public static IEnumerator CountDown(float time, Weapon weapon)
    {
        while (time > 0.0f)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        weapon.WeaponStHandler.ChangeState();
        StopTimer();
    }

    public static void SetTimer(float duration, Weapon weapon)
    {
        _timeCoroutine = _instance.StartCoroutine(CountDown(duration, weapon));
    }

    public static void StopTimer()
    {
        if (_timeCoroutine != null)
        {
            _instance.StopCoroutine(_timeCoroutine);
            _timeCoroutine = null;
        }
    }
}
