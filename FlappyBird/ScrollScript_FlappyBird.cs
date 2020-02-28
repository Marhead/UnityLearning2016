using UnityEngine;
using System.Collections;

public class ScrollScirpt : MonoBehaviour 
{
void OnTriggerEnter2D(Collider2D other)
{
    if (other.tag == "Ground")
    {
        print("충돌!!");
        Vector3 pos = other.transform.position;
        pos.x += 54.6f;
        other.transform.position = pos;
    }
}
}