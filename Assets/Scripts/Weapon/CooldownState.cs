using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class CooldownState : WeaponState
{
    public override void ChangeState()
    {
        _weapon.SetState(new ShootState());
    }
}
