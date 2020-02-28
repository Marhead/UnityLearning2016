using UnityEngine;
using System.Collections;

public class myfor2 : MonoBehaviour {

public GameObject CubePrefab;

// Use this for initialization
void Start () {

    for(int i = 0; i < 6; ++i)
    {
        for(int j = 0; j < 5-i; ++j)
            Instantiate(CubePrefab, new Vector3(i, j, 0), Quaternion.identity);
    }

    for(int i = 10; i < 16; ++i)
    {
        for(int j = 10; j < i; ++j)
            Instantiate(CubePrefab, new Vector3(i, j, 0), Quaternion.identity);
    }

    for(int i = 0; i < 6; ++i)
    {
        for(int j = 0; j < i; ++j)
            Instantiate(CubePrefab, new Vector3(i, j, 6), Quaternion.identity);
    }

    for(int i = 10; i < 16; ++i)
    {
        for(int j = 10; j < 15-i; ++j)
            Instantiate(CubePrefab, new Vector3(i, j, 6), Quaternion.identity);
    }
}

// Update is called once per frame
void Update () {

}
}

