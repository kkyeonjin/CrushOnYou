using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlace : MonoBehaviour
{
    public int PlaceIndex; //장소별 인덱스(0:교실, 1:복도, 2:도서관, 3:음악실, 4:미술실, 5:체육관)
    public GameObject Red;
    public GameObject Green;
    public GameObject Blue;
    public GameObject Purple;
    public GameObject Pink;
    public GameObject Yellow;

    // Start is called before the first frame update
    void Start()
    { //캐릭터가 위치한 장소에만 캐릭터 이미지 표시
        if(DataController.Instance.gameData.place[0] != PlaceIndex) Red.SetActive(false);
        if(DataController.Instance.gameData.place[1] != PlaceIndex) Green.SetActive(false);
        if(DataController.Instance.gameData.place[2] != PlaceIndex) Blue.SetActive(false);
        if(DataController.Instance.gameData.place[3] != PlaceIndex) Purple.SetActive(false);
        if(DataController.Instance.gameData.place[4] != PlaceIndex) Pink.SetActive(false);
        if(DataController.Instance.gameData.place[5] != PlaceIndex) Yellow.SetActive(false);
    }
    public void Select() {

        DataController.Instance.gameData.myPlace = PlaceIndex; //선택한 장소 저장
        if(DataController.Instance.gameData.count[PlaceIndex] == 0){ //선택한 장소에 아무도 없을 때
            SceneManager.LoadScene("TalkScene0_PSY");
        }
        else{ //선택한 장소에 한 명이나 두 명이 있을 때
            SceneManager.LoadScene("TalkScene1_PSY");
        }
        
    }
}
