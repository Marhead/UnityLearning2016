using UnityEngine;
using System.Collections;

public class ColumnScript : MonoBehaviour
{

void OnTriggerEnter2D(Collider2D other)
{
    if (other.tag == "Player")
    {
        print("기둥 충돌!!");
        GameManager.current.BirdScored();

    }
}
}