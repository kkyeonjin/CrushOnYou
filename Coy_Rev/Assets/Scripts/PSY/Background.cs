using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public GameObject BackPanel;
    public Sprite[] classroom, hall, lib, music, art, gym;

    public List<Sprite[]> Backgrounds;

    void Awake() {
        //리소스 폴더에서 장소별 배경화면 불러오기
        classroom = Resources.LoadAll<Sprite>("classroom");
        hall = Resources.LoadAll<Sprite>("hallway");
        lib = Resources.LoadAll<Sprite>("library");
        music = Resources.LoadAll<Sprite>("musicroom");
        art = Resources.LoadAll<Sprite>("artroom");
        gym = Resources.LoadAll<Sprite>("gym");

        Backgrounds = new List<Sprite[]>{classroom, hall, lib, music, art, gym};

        BackPanel.GetComponent<Image>().sprite = Backgrounds[DataController.Instance.gameData.myPlace][Random.Range(0,2)];
        //현재 장소에 따라서 랜덤으로 배경화면 띄우기
    }

}
