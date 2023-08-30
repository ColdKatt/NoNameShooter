using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour, IEnemy
{
    // Bugs:
    //    too far from player!

    [SerializeField] private Transform _chaseObject;
    [SerializeField] private float _safeDistance;
    [SerializeField] private float _flySpeed;
    [SerializeField] private float _health;

    public float Health { set => _health = value; get => _health; }

    public void DoLogic()
    {
        var distanceToObject = _chaseObject.position - transform.position;
        //Debug.Log(distanceToObject);

        if (distanceToObject.magnitude > 5.0f) 
        {
            //Debug.DrawLine(transform.position, distanceToObject * _flySpeed * Time.deltaTime);
            //Debug.DrawRay(transform.position, distanceToObject * _flySpeed * Time.deltaTime, Color.blue);
            Debug.Log(transform.position);
            Debug.Log(distanceToObject * _flySpeed * Time.deltaTime);
            transform.Translate(new Vector3(distanceToObject.x, distanceToObject.y, 0) * _flySpeed * Time.deltaTime);
        }
        else
        {
            //Debug.DrawLine(transform.position, distanceToObject * _flySpeed * Time.deltaTime, Color.red);
        }
    }

    // Start is called before the first frame update
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
