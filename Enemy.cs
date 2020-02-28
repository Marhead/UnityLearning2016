using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : SpaceShip
{
//Transform[] shotPositions; //총알을 발사하는 위치

//float speed = 1f;

/*
void Awake()
{
    //내 자식에 있는 오브젝트를 전부 가져와서 shotPositions에 넣는다.
    shotPositions = new Transform[transform.childCount];
    for (int i = 0; i < transform.childCount; ++i)
    {
        shotPositions[i] = transform.GetChild(i);
    }

    InvokeRepeating("Shoot", 0.1f, 1);
} 생략 */

Animator anim;

void OnEnable()
{
    base.OnEnable(); //부모의 OnEnable을 실행
    GetComponent<Rigidbody2D>().velocity = transform.up * -1 * speed;
    anim = GetComponent<Animator>();
}

public int currentHP = 2;
//처음 만났을 때 한번
void OnTriggerEnter2D(Collider2D other)
{
    anim.SetTrigger("Damage");

    ObjectPool.current.PoolObject(other.gameObject);
    //Destroy(other.gameObject); //부딪힌 총알 제거
    --currentHP;

    if (currentHP <= 0)
    {
        Explode();
        Destroy(this.gameObject);  //부딪힌 적 제거
    }
}

/*
public GameObject BulletPrefab;

void Shoot()
{
    for (int i = 0; i < transform.childCount; ++i)
    {

        GameObject Obj = ObjectPool.current.GetObject(BulletPrefab);

        Obj.transform.position = shotPositions[i].position;
        Obj.transform.rotation = shotPositions[i].rotation;
        Obj.SetActive(true);

    }

} 생략 */
}