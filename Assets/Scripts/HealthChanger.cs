using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthChanger : MonoBehaviour
{
    private IEnemy _enemy;
    private float _maxHealth;
    private float _healthCoefficient;

    private void Start()
    {
        _enemy = GetComponentInParent<IEnemy>();
        _maxHealth = _enemy.Health;
        _healthCoefficient = transform.localScale.x;
    }

    public void ChangeHealthView()
    {
        Debug.Log($"MaxHP:{_maxHealth}\n CurrentHP:{_enemy.Health}");
        transform.localScale = new Vector3((_enemy.Health / _maxHealth) * _healthCoefficient, transform.localScale.y, transform.localScale.z);
    }
}
