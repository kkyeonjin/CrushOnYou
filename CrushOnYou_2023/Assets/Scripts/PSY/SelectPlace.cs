using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlace : MonoBehaviour
{
    public int PlaceIndex;
    public GameObject Red;
    public GameObject Green;
    public GameObject Blue;
    public GameObject Purple;
    public GameObject Pink;
    public GameObject Yellow;

    // Start is called before the first frame update
    void Start()
    { //캐릭터가 위치한 장소에만 하트 표시
        if(DataManager.Data.place[0] != PlaceIndex) Red.SetActive(false);
        if(DataManager.Data.place[1] != PlaceIndex) Green.SetActive(false);
        if(DataManager.Data.place[2] != PlaceIndex) Blue.SetActive(false);
        if(DataManager.Data.place[3] != PlaceIndex) Purple.SetActive(false);
        if(DataManager.Data.place[4] != PlaceIndex) Pink.SetActive(false);
        if(DataManager.Data.place[5] != PlaceIndex) Yellow.SetActive(false);
    }
    public void Select() {

        DataManager.Data.myPlace = PlaceIndex; //선택한 장소 저장
        DataManager.Data.turn++; //턴 증가
        if(DataManager.Data.count[PlaceIndex] == 0){ //선택한 장소에 아무도 없을 때
            SceneManager.LoadScene("TalkScene0_PSY");
        }
        else{ //선택한 장소에 한 명이나 두 명이 있을 때
            SceneManager.LoadScene("TalkScene1_PSY");
        }
        
    }
}
