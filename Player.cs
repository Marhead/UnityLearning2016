using UnityEngine;
using System.Collections;

public class Player : SpaceShip { //상속자로 인해 SpaceShip에 있는 것은 생략가능

//Transform[] shotPositions; //총알을 발사하는 위치

/* void Awake()
{
    //내 자식에 있는 오브젝트를 전부 가져와서 shotPositions에 넣는다.
    shotPositions = new Transform[transform.childCount];
    for(int i=0; i<transform.childCount; ++i)
    {
        shotPositions[i] = transform.GetChild(i);
    }

    InvokeRepeating("Shoot", 1, 1);

} 생략 */

// float speed = 3f; 생략
void Move(Vector2 direction)
{

    Vector2 pos =  transform.position;
    pos += direction * Time.deltaTime * speed;

    //Vector2 min = new Vector2(-4, -3);
    //Vector2 max = new Vector2(4, 3);

    Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


    pos.x  = Mathf.Clamp(pos.x, min.x, max.x);
    pos.y = Mathf.Clamp(pos.y, min.y, max.y);

    //if (pos.x > 4)
    //    pos.x = 4;

    //if (pos.x > -4)
    //    pos.x = -4;

    transform.position = pos;
}

void Update () {
    //입력을 받아온다.
    //왼쪽방향이면 -1 오른쪽 방향이면 1
    //입력 안하면 0
    float x = Input.GetAxisRaw("Horizontal");
    float y = Input.GetAxisRaw("Vertical");
    Vector2 Direction = new Vector2(x, y);
    //print(Direction);
    Direction.Normalize(); //어느 방향이던 크기를 1로 만들어줌
    Move(Direction);

    //if(Input.GetKeyDown(KeyCode.Space))
    //{
    //    Shoot();
    //}
}

public int currentHP = 2;
//처음 만났을 때 한번
void OnTriggerEnter2D(Collider2D other)
{

    ObjectPool.current.PoolObject(other.gameObject);
    --currentHP;

    if (currentHP <= 0)
    {
        Explode();
        Destroy(this.gameObject);  //부딪힌 적 제거
    }
}

// public GameObject BulletPrefab; 생략

/* void Shoot()
{
    for (int i = 0; i < transform.childCount; ++i)
    {

        GameObject Obj = ObjectPool.current.GetObject(BulletPrefab);

        Obj.transform.position = shotPositions[i].position;
        Obj.transform.rotation = shotPositions[i].rotation;
        Obj.SetActive(true);
        //GameObject Obj = (GameObject)Instantiate(BulletPrefab, shotPositions[i].position, shotPositions[i].rotation);
        //Destroy(Obj, 2f);
    }


    //Vector3 Pos = transform.position;
    //Pos.y += 1;
    //GameObject Obj1 = (GameObject)Instantiate(BulletPrefab, Pos, transform.rotation);
    //Destroy(Obj1, 3f);

    //Quaternion Rot1 = Quaternion.Euler(0, 0, 10); //z축으로 10도 회전한 뒤 발사
    //GameObject Obj2 = (GameObject)Instantiate(BulletPrefab, Pos, Rot1);
    //Destroy(Obj2, 3f);

    //Quaternion Rot2 = Quaternion.Euler(0, 0, -10); //z축으로 -10도 회전한 뒤 발사
    //GameObject Obj3 = (GameObject)Instantiate(BulletPrefab, Pos, Rot2);
    //Destroy(Obj3, 3f);


} 생략 */
}