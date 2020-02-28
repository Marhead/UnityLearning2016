using UnityEngine;
using System.Collections;
using System.Collections.Generic; //List를 쓰기 위해 필요함

public class ObjectPool : MonoBehaviour
{

public static ObjectPool current;//다른 클래스에서 이 클래스 사용가능
public GameObject[] prefabs; //미리 만들어놓을 객체의 원형
public List<GameObject>[] pooledObjects; //미리 생성한 객체를 모아놓을곳

GameObject containerObject;


public int[] amountToBuffer;
public int DefaultBufferAmount = 10;


void Awake()
{
    if (current == null)
        current = this;
    else
    {
        Debug.LogError("ObjectPool Delete"); //실수로 두개 만들었을 때 에러 메세지 나게함
        Destroy(gameObject);//ObjectPool스크립트가 게임에 하나만 있게
    }

    containerObject = new GameObject("ObjectPool");
    pooledObjects = new List<GameObject>[prefabs.Length];

    for (int i = 0; i < prefabs.Length; ++i)
    {
        pooledObjects[i] = new List<GameObject>();

        for (int j = 0; j < DefaultBufferAmount; j++)
        {
            GameObject obj = (GameObject)Instantiate(prefabs[i]);
            obj.name = prefabs[i].name;
            PoolObject(obj);
        }

    }

}

//넣어주는 함수
public void PoolObject(GameObject Obj)
{
    for (int i = 0; i < prefabs.Length; ++i)
    {
        //프리팹이름이랑 넣어준애랑 동일하면
        if (prefabs[i].name == Obj.name)
        {
            //비활성화
            Obj.SetActive(false);

            //ObjectPool객체의 자식으로 된다.
            Obj.transform.SetParent(containerObject.transform);

            //리스트에 오브젝트를 추가한다.
            pooledObjects[i].Add(Obj);
            return;
        }
    }
}

public GameObject GetObject(GameObject objectType)
{

    for (int i = 0; i < prefabs.Length; ++i)
    {
        if (prefabs[i].name == objectType.name)
        {
            //미리 생성해놓은애가 존재할때만
            if (pooledObjects[i].Count > 0)
            {
                //리스트에 첫번째 오브젝트를 가져온다.
                GameObject pooledObject = pooledObjects[i][0];

                //리스트에 있던 0번째 오브젝트의 참조를 해제한다.
                pooledObjects[i].RemoveAt(0);

                //부모를 없앤다.
                pooledObject.transform.SetParent(null);
                return pooledObject;
            }
            else //총알이 없으면 새로 만든다.
            {
                Debug.LogWarning("objectType.name 신규 생성!");
                GameObject obj = (GameObject)Instantiate(prefabs[i]);
                obj.name = prefabs[i].name;
                return obj;
            }
        }
    }
    return null;
}

void Update()
{

}
}