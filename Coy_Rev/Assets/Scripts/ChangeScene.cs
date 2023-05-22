using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public void ToChooseEpisode()
    {
        SceneManager.LoadScene("2_CharCut");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("0_Start");
    }

    public void ToPrologue()
    {
        SceneManager.LoadScene("1_Prologue");
    }
}
