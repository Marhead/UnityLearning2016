using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour {

public float speed;
public float shotDelay;
public GameObject BulletPrefab;
public bool canShoot;
Transform[] shotPositions;


public GameObject explosion; //폭발할 스프라이트

protected void Explode()
{
    GameObject obj = ObjectPool.current.GetObject(explosion);
    obj.transform.position = transform.position;
    obj.transform.rotation = transform.rotation;
    obj.SetActive(true);
}
void Awake()
{
    //내 자식에 있는 오브젝트를 전부 가져와서 shotPositions에 넣는다.
    shotPositions = new Transform[transform.childCount];
    for (int i = 0; i < transform.childCount; ++i)
    {
        shotPositions[i] = transform.GetChild(i);
    }


}

protected void OnEnable()
{
    if (canShoot)
        InvokeRepeating("Shoot", shotDelay, shotDelay);
}
void OnDisable()  //비활성화 됐을 때 들어오는 함수
{
    if (canShoot)
        CancelInvoke("Shoot");

}

void Shoot()
{
    if (ObjectPool.current == null)
    {
        Debug.LogError("Err");

        return; //비행기보다 먼저 생기면 안됨
    }

    {
        AudioSource Audio = GetComponent<AudioSource>();
        if (Audio)
            Audio.Play();
    }

    for (int i = 0; i < transform.childCount; ++i)
    {

        GameObject Obj = ObjectPool.current.GetObject(BulletPrefab);

        Obj.transform.position = shotPositions[i].position;
        Obj.transform.rotation = shotPositions[i].rotation;
        Obj.SetActive(true);
    }
}
}