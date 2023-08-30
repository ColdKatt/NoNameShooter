using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Weapons;

public class WeaponStateHandler
{
    public WeaponState State { get => _state; }

    private WeaponState _state;

    public WeaponStateHandler(WeaponState state) => SetState(state);

    public void SetState(WeaponState state)
    {
        _state = state;
        _state.Weapon = this;
    }

    public void ChangeState()
    {
        _state.ChangeState();
    }
}
