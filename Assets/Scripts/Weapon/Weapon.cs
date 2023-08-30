using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon", order = 51)]
public class Weapon : ScriptableObject
{
    public Func<bool> OnStateChanged;

    public WeaponStateHandler WeaponStHandler;

    public float _cooldown;

    public void Init()
    {
        Timer.StopTimer();
        WeaponStHandler = new WeaponStateHandler(new ShootState());
        OnStateChanged = IsStateCooldown;
    }

    private bool IsStateCooldown()
    {
        if (WeaponStHandler.State is CooldownState)
        {
            Timer.SetTimer(_cooldown, this);

            return true;
        }
        return false;
    }
}
