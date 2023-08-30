using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class ShootState : WeaponState
{
    public override void ChangeState()
    {
        _weapon.SetState(new CooldownState());
    }
}
