using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] private Transform _chaseObject;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _health;

    public float Health { set => _health = value; get => _health; }

    public void DoLogic()
    {
        var delta = transform.position.x - _chaseObject.transform.position.x < 0 ? 1 : -1;
        transform.Translate(Vector3.right * delta * _walkSpeed * Time.deltaTime);
    }

    void Start()
    {
        _chaseObject = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();
    }
}
