using UnityEngine;
using System.Collections;

public class ColumnSpawn : MonoBehaviour {

public GameObject columnPrefab;

public int columnPoolsize = 5; //미리 만들어 놓을 기둥 개수
public float columnMin = -1f;
public float columnMax = 3f;

GameObject[] columns;

int currentColumn = 0;

void Start ()
{
    //게임오브젝트 5개 남을 수 있는 배열 생성
    columns = new GameObject[columnPoolsize];
    
    for(int i = 0; i < columnPoolsize; ++i)
    {
        columns[i] = (GameObject)Instantiate(columnPrefab);
    }       

    //Invoke("SpawnLoop", 3f); //함수를 지연실행
    //3.인보크함수를 이용한 방법
    InvokeRepeating("SpawnLoop", 0f, 3f);
    //1.타임.타임 이용
    //timer = Time.time + 3f;
}
//내 오브젝트가 비활성화 됐을 때
void OnDisable()
{
    CancelInvoke("SpawnLoop");
}

//2.델타타임 이용
//float timer;
//void Update ()
//{
//1.타임.타임을 이용한 방법
//if (Time.time % 3f <= 0.01f) //게임플레이시간
//    SpawnLoop();

//2. 델타타임을 이용한 방법
//timer += Time.deltaTime; //시간이 누적되서, 시간 측정
//if (timer >= 3f)
//{
//    timer = 0f;
//    SpawnLoop();
//}  

//내가 한 방법
//if (timer < Time.time)
//{
//    timer = Time.time + 3f;
//    SpawnLoop();
//}       

//}

float timer;
void SpawnLoop()
{
    float a = Random.Range(columnMin, columnMax);
    Vector3 pos = new Vector3(transform.position.x, a);

    columns[currentColumn].transform.position = pos;

    if (++currentColumn >= columnPoolsize)
        currentColumn = 0;

    //GameObject obj = (GameObject)Instantiate(columnPrefab, pos, Quaternion.identity);
    //내가 생성완료 오브젝트
    //obj
    //Destroy(obj, 15f);
    //Destroy함수를 쓰면 화면상에서는 보이지 않지만 메모리는 남아있다.
}
}