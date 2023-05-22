using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    public GameObject red, green, blue, purple, pink, yellow;
    public List<GameObject> characters;
    public Sprite[] redImg, greenImg, blueImg, purpleImg, pinkImg, yellowImg;
    public List<Sprite[]> images;
    public bool isIntro = true;

    // Start is called before the first frame update
    void Awake()
    {
        red = GameObject.FindGameObjectWithTag("red");
        green = GameObject.FindGameObjectWithTag("green");
        blue = GameObject.FindGameObjectWithTag("blue");
        purple = GameObject.FindGameObjectWithTag("purple");
        pink = GameObject.FindGameObjectWithTag("pink");
        yellow = GameObject.FindGameObjectWithTag("yellow");

        characters = new List<GameObject>{red, green, blue, purple, pink, yellow};
        //씬에서 캐릭터별 이미지 오브젝트 찾아서 저장
        
        redImg = Resources.LoadAll<Sprite>("RedImage");
        greenImg = Resources.LoadAll<Sprite>("GreenImage");
        blueImg = Resources.LoadAll<Sprite>("BlueImage");
        purpleImg = Resources.LoadAll<Sprite>("PurpleImage");
        pinkImg = Resources.LoadAll<Sprite>("PinkImage");
        yellowImg = Resources.LoadAll<Sprite>("YellowImage");

        images = new List<Sprite[]>{redImg, greenImg, blueImg, purpleImg, pinkImg, yellowImg};
        //리소스 폴더에서 캐릭터별 이미지 불러와서 저장

        for(int i=0; i<characters.Count; i++){
            characters[i].SetActive(false);
        }
        //일단 다 안보이게 하기
    }
    
    //setImage(현재 장소에 있는 사람, 현재 대화상대, 그 상대가 선택한 키워드를 좋아하는지)
    public void SetImage(List<int> ppHere, int pp, bool like){
        
        //전부 비활성화
        for(int i=0; i<characters.Count; i++){
            characters[i].SetActive(false);
        }

        if(isIntro){
            //현재가 인트로면
            for(int i=0; i<ppHere.Count; i++){
                characters[ppHere[i]].GetComponent<Image>().sprite = images[ppHere[i]][0];
                characters[ppHere[i]].SetActive(true);
                //현재 장소에 있는 모든 캐릭터의 0번(기본) 사진 활성화
            }
            return;
        }

        if(pp<characters.Count){ //pp가 더미값(10)인지 아닌지 판단

            characters[pp].SetActive(true); //해당 캐릭터 활성화

            if(like){
                characters[pp].GetComponent<Image>().sprite = images[pp][1];
            }
            else{
                characters[pp].GetComponent<Image>().sprite = images[pp][2];
            }
            //캐릭터가 키워드를 좋아하면 1번(긍정), 싫어하면 2번(부정) 사진 띄우기
        }

    }

}
