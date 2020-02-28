using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

public int speed = 10;
float lifeTime = 1f;
void OnEnable () {
    GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    Invoke("Die", lifeTime);
}

void OnDisable()
{
    CancelInvoke("Die");
}

void Die()
{
    ObjectPool.current.PoolObject(gameObject);
}
}