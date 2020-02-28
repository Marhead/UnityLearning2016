using UnityEngine;
using System.Collections;

public class myCamera : MonoBehaviour {

public Transform target;
float XOffset;
void Start () {
    XOffset = transform.position.x - target.position.x; //카메라의 위치에서 새가 왼쪽에 위치하게 함
}

void Update () {
    transform.position = new Vector3(target.position.x + XOffset,
                                    transform.position.y,
                                    transform.position.z);
}
}