using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour 
{

public float lifetime = 1f;

void OnEnable () {
    Invoke("Die", lifetime);
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