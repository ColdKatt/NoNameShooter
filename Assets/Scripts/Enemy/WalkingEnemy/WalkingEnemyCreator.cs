using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyCreator : MonoBehaviour, IEnemyCreator
{
    [SerializeField] private GameObject _enemyPrefab;
    public void CreateEnemy(int count)
    {
        for (var i = 0; i < count; i++)
        {
            var enemy = Instantiate(_enemyPrefab, new Vector3(10, 5, 0), Quaternion.Euler(0, 0, 0));
        }
        //return enemy.GetComponent<WalkingEnemy>();
    }
}
