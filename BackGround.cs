using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {

public float speed = 0.1f; //스크롤 속도

void Update () {
    float y = Mathf.Repeat(Time.time * speed, 1);

    Vector2 offset = new Vector2(0, y);

    GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);


}
}