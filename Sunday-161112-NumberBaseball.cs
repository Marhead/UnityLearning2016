using UnityEngine;
using System.Collections;

public class NBBManager : MonoBehaviour {

public UnityEngine.UI.InputField[] Input;

int[] Rand = new int[3];

public UnityEngine.UI.Text ResultText;

// Use this for initialization
void Start ()
{
   for(int i = 0; i<3; i++)
    {
        Rand[i] = i;
    }
}

public void OnClick()
{
    int Myh = int.Parse(Input[0].text);
    int Mym = int.Parse(Input[1].text);
    int Myl = int.Parse(Input[2].text);

    int strike = 0, ball = 0;

    for (int i = 0; i < 3; ++i)
    {
        for (int j = 0; j < 3; j++)
        {
           if(Rand[i] == int.Parse(Input[j].text))
            {
                if (i == j)
                    strike++;
                else
                    ball++;
            }
        }
    }
    ResultText.text = strike + "스트라이크" + ball + "볼";
}

// Update is called once per frame
void Update () {

}
}