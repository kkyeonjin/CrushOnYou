using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLover : MonoBehaviour
{
    public int CharIndex;
    public void Select() {

        DataController.Instance.gameData.myLover = CharIndex; //선택한 캐릭터의 번호를 myLover에 저장
        DataController.Instance.gameData.LoveList[6][CharIndex] = 100;  //그 캐릭터를 향한 코이의 호감도는 100
        DataController.Instance.gameData.WPlayedBefore = true;
        SceneManager.LoadScene("PlaceScene_PSY"); //다음 씬으로 이동
        
    }
}
