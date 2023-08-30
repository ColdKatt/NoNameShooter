using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform PistolTransform;

    [SerializeField] private Vector3 _direction;

    [SerializeField] private float _speed;
    [SerializeField] private float _damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        _direction = transform.position - PistolTransform.position;
        Debug.Log(transform.eulerAngles);

        Invoke("DestroyBullet", 2.0f);
        //GetComponent<Rigidbody>().AddForce(direction * 100);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<IEnemy>();
            var healthBar = collision.gameObject.GetComponentInChildren<HealthChanger>();
            DamageEnemy(enemy);
            healthBar.ChangeHealthView();
            if (enemy.Health <= 0) Destroy(collision.gameObject);
        }
        DestroyBullet();
    }

    private void DestroyBullet() => Destroy(gameObject);

    public void DamageEnemy(IEnemy enemy)
    {
        enemy.Health -= _damage;
    }
}
