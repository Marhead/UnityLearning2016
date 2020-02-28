using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

public GameObject GameOverText;

public static GameManager current; //게임시작할 때 메모리를 만들어놓음

void Awake()
{
    if(current == null)
    {
        current = this;
    }
}

int score = 0;
public UnityEngine.UI.Text scoreText;

public void BirdScored()
{
    ++score;
    scoreText.text = "Score : " + score;
}

public void BirdDied()
{
    //게임 오버 텍스트 활성화
    GameOverText.SetActive(true);
}
}