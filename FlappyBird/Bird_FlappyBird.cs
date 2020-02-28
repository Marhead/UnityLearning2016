using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

float forwardSpeed = 1.5f;
float upForce = 175f;

Animator anim;
void Start ()
{
    anim = GetComponent<Animator>();

    GetComponent<Rigidbody2D>().velocity = new Vector2(forwardSpeed + Time.deltaTime , 0);
}

bool flap = false;
void Update()
{
    if (isGameover)
    {
        if(Input.anyKeyDown)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);//재시작하는 명령어
        }
        return;
    }
        
    if (Input.anyKeyDown) //키 받는건 Update에서 받아줘야 반응속도가 빨라짐
    {
        flap = true;
        anim.SetTrigger("Flap");
    }
}

void FixedUpdate () //FixedUpdate는 edit -> time 에서 0.02면 1초에 50번 인데 Update는 70~80프레임 나오면 Update가 더 많이 호출하므로 어차피 물리법칙은 FixedUpdate에서 적용된다.
                    //따라서 FixedUpdate에서 하는게 더 효율적임
{
    if (flap)
    {
        flap = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0); //키 누르면 중력 초기화
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, upForce));
    }
    //transform.Translate(Vector3.right * Time.deltaTime);
}

//bool Die = false;
bool isGameover = false;
void OnCollisionEnter2D(Collision2D other)
{
    //Die = true;
    anim.SetTrigger("Die");
    GameManager.current.BirdDied();
    isGameover = true;
}
}