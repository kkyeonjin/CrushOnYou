using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

//수정함
public class TalkSceneManager : MonoBehaviour
{
    public GameObject Btns; //키워드 버튼 4개

    class Keyword //키워드, 키워드를 좋아하는 캐릭터 번호
    {
        public string category;
        public bool[] like;
    }

    List<string> Keywords; //KeyInfo 키 모음 리스트

    Dictionary<string, Keyword> KeyInfo = new Dictionary<string, Keyword>()
    {
        {"운동", new Keyword(){category = "special", like = new bool[6]{true, false, false, false, true, true}}},
        {"필름 카메라", new Keyword(){category = "special", like = new bool[6]{false, true, true, true, false, false}}},
        {"클래식 음악", new Keyword(){category = "special", like = new bool[6]{true, false, true, true, false, false}}},        
        {"인디 음악", new Keyword(){category = "special", like = new bool[6]{false, true, false, true, false, true}}},
        {"드라마", new Keyword(){category = "special", like = new bool[6]{true, false, false, true, true, false}}},        
        {"노래방", new Keyword(){category = "special", like = new bool[6]{false, true, false, false, true, true}}},
        {"별 보기", new Keyword(){category = "hobby", like = new bool[6]{true, false, true, true, false, true}}},
        {"영화 감상", new Keyword(){category = "hobby", like = new bool[6]{false, true, true, true, true, true}}},
        {"산책", new Keyword(){category = "hobby", like = new bool[6]{true, true, true, true, false, true}}},
        {"스포츠 경기 직관", new Keyword(){category = "hobby", like = new bool[6]{true, false, false, true, true, false}}},
        {"게임", new Keyword(){category = "hobby", like = new bool[6]{false, false, true, true, false, false}}},
        {"요리", new Keyword(){category = "hobby", like = new bool[6]{true, true, true, false, true, false}}},
        {"환경문제", new Keyword(){category = "issue", like = new bool[6]{false, true, true, true, true, false}}},
        {"경제", new Keyword(){category = "issue", like = new bool[6]{false, true, true, false, true, false}}},
        {"연예인", new Keyword(){category = "issue", like = new bool[6]{true, false, false, true, true, true}}},
        {"베스트셀러", new Keyword(){category = "issue", like = new bool[6]{false, true, true, true, false, false}}},
        {"패션 브랜드", new Keyword(){category = "issue", like = new bool[6]{true, false, false, true, true, true}}},
        {"SNS", new Keyword(){category = "issue", like = new bool[6]{false, false, false, true, true, true}}},
        {"학교 수업", new Keyword(){category = "school", like = new bool[6]{false, true, true, false, true, true}}},
        {"수행평가", new Keyword(){category = "school", like = new bool[6]{false, false, true, true, true, false}}},
        {"시험공부", new Keyword(){category = "school", like = new bool[6]{false, true, true, false, true, false}}},
        {"급식", new Keyword(){category = "school", like = new bool[6]{true, true, false, false, true, true}}},
        {"점심시간", new Keyword(){category = "school", like = new bool[6]{true, true, false, true, true, true}}},
        {"선생님", new Keyword(){category = "school", like = new bool[6]{true, true, false, true, true, true}}},
        {"어젯밤 꿈", new Keyword(){category = "life", like = new bool[6]{true, true, false, true, true, false}}},
        {"맛집", new Keyword(){category = "life", like = new bool[6]{true, true, false, true, true, false}}},
        {"반려동물", new Keyword(){category = "life", like = new bool[6]{true, true, false, true, true, false}}},
        {"플레이리스트", new Keyword(){category = "life", like = new bool[6]{false, true, false, true, true, true}}},
        {"위시리스트", new Keyword(){category = "life", like = new bool[6]{false, false, false, true, true, true}}},
        {"TMI", new Keyword(){category = "life", like = new bool[6]{false, false, false, true, true, true}}}
    };

    public TMP_Text kw1;
    public TMP_Text kw2;
    public TMP_Text kw3;
    public TMP_Text kw4;

    List<string> toShow = new List<string>(); //선택된 4개 키워드 리스트

    List<int> ppHere = new List<int>(); 
    //해당 장소에 있는 사람(0:red, 1:green, 2:blue, 3:yellow, 4:pink, 5:purple)

    void Start()
    {   
        Keywords = new List<string>(KeyInfo.Keys);
        talkData = new List<List<string>>();
        ManageKeyword();
        WhoAreHere();
        kw1.text = toShow[0];
        kw2.text = toShow[1];
        kw3.text = toShow[2];
        kw4.text = toShow[3];
    }

    void WhoAreHere(){ //해당 장소에 있는 캐릭터 찾아서 ppHere에 저장
        for(int i=0; i<6; i++){
            if(DataManager.Data.place[i] == DataManager.Data.myPlace){
                ppHere.Add(i);
            }
        }
    }

    void ManageKeyword(){ //키워드 중복없이 4개 선정
        for(int i=0; i<4; i++){
            while(true){
                int temp = Random.Range(0, Keywords.Count);
                if(!toShow.Contains(Keywords[temp])){
                    toShow.Add(Keywords[temp]);
                    break;
                }
            }
        }
    }

    public void SelectKeyword(){ //사용자가 키워드 버튼 눌렀을 때
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        switch(ButtonName){
            case "Kw1" : GenerateData(toShow[0]); ManageLove(0); Talk(); break;
            case "Kw2" : GenerateData(toShow[1]); ManageLove(1); Talk(); break;
            case "Kw3" : GenerateData(toShow[2]); ManageLove(2); Talk(); break;
            case "Kw4" : GenerateData(toShow[3]); ManageLove(3); Talk(); break;
        }
        Btns.SetActive(false); //버튼 한번 누르면 비활성화
    }

    void ManageLove(int i){ //호감도 조정하는 함수

        int key = i; //사용자가 누른 버튼 번호 ex) toShow[i].ch -> 해당 키워드를 좋아하는 캐릭터
        int e = 10; //호감도 변화 정도
        List<int[]> LoveList = DataManager.Data.LoveList;

        void increaseLove(int a, int b){
            LoveList[a][b] += e;
            LoveList[a][b] = Mathf.Min(100, LoveList[a][b]);
        }

        void decreaseLove(int a, int b){
            LoveList [a][b] -= e;
            LoveList[a][b] = Mathf.Max(0, LoveList[a][b]);
        } 

        switch(ppHere.Count){

            case 1 :  //장소에 한 명 있음          
                    if(KeyInfo[toShow[i]].like[ppHere[0]] == true){ //선택한 키워드가 같이있는 사람이 좋아하는 키워드
                        increaseLove(ppHere[0],6);
                    }
                    else{ //선택한 키워드가 안좋아하는 키워드
                        decreaseLove(ppHere[0],6);
                    }
                    break;

            case 2 : //장소에 두 명 있음
                    if(KeyInfo[toShow[i]].like[ppHere[0]] == true && KeyInfo[toShow[i]].like[ppHere[1]] == true){ //둘 다 좋아하는 키워드
                        increaseLove(ppHere[0],6);
                        increaseLove(ppHere[0],ppHere[1]);
                    
                        increaseLove(ppHere[1],6);
                        increaseLove(ppHere[1],ppHere[0]);
                    }
                    else if(KeyInfo[toShow[i]].like[ppHere[0]] == true && KeyInfo[toShow[i]].like[ppHere[1]] == false){ //첫번째 사람만 좋아하는 키워드 
                        increaseLove(ppHere[0],6);
                        decreaseLove(ppHere[0],ppHere[1]); 
                    
                        decreaseLove(ppHere[1],6);
                        decreaseLove(ppHere[1],ppHere[0]);
                    }
                    else if(KeyInfo[toShow[i]].like[ppHere[0]] == false && KeyInfo[toShow[i]].like[ppHere[1]] == true){ //두번째 사람만 좋아하는 키워드
                        increaseLove(ppHere[1],6);
                        decreaseLove(ppHere[1],ppHere[0]);                    
                        
                        decreaseLove(ppHere[0],6);
                        decreaseLove(ppHere[0],ppHere[1]);
                    }
                    else{ //둘다 안좋아하는 키워드
                        decreaseLove(ppHere[1],6);
                        increaseLove(ppHere[1],ppHere[0]);

                        decreaseLove(ppHere[0],6);
                        increaseLove(ppHere[0],ppHere[1]);
                    }

            break;
        }

        DataManager.Data.LoveList = LoveList;
    }

    ////////대사창

    public GameObject talkPanel;
    public GameObject SceneLoadBtn;
    public TMP_Text TalkName;
    public TMP_Text TalkText;
    public GameObject TalkImage0;
    public bool isAction;
    public int talkIndex;

    public List<List<string>> talkData;

    void GenerateData(string ButtonName){

        string key;

        switch(ppHere.Count){
            case 1 :
                    key = KeyInfo[ButtonName].like[ppHere[0]].ToString() + ButtonName;
                    Debug.Log(key);
                    talkData.Add(ScriptManager.ScriptsInfo1[key]);
                    break;

            case 2 :
                    key = arrangeList(ButtonName);
                    Debug.Log(key);
                    talkData.Add(ScriptManager.ScriptsInfo2[key]);
                    break;
        }
        
    }

    private string arrangeList(string Btn){
        if(KeyInfo[Btn].like[ppHere[0]]){//긍정
            if(KeyInfo[Btn].like[ppHere[1]]){//긍정
                return "tt"+Btn;
            }
            else{//부정
                return "tf"+Btn;

            }
        }
        else{//부정
            if(KeyInfo[Btn].like[ppHere[1]]){//긍정
                ppHere.Reverse();
                return "tf"+Btn;                
            }
            else{//긍정
                return "ff"+Btn;
            }
        }
    }

    public void Talk(){ //대사 띄우고 대사 끝났는지 안끝났는지 확인

        string line = GetTalk();
        if(line == null) return;

        string name = GetName();

        TalkName.text = name;
        TalkText.text = line;
        isAction = true;
        talkIndex++;

    }

    private string GetName(){

        if(ppHere.Count == 1){
            switch(talkIndex){
                case 0 : SetImage(ppHere[0]); return SetName(ppHere[0]);

                case 1 : SetImage(ppHere[0]); return SetName(ppHere[0]);

                case 2 : return "";
                    
                default : return "";    
            }
        }
        else{
            switch(talkIndex){
                case 0 : SetImage(ppHere[0]); return SetName(ppHere[0]);

                case 1 : SetImage(ppHere[1]); return SetName(ppHere[1]);

                case 2 : return "";
                    
                default : return "";    
            }
        }
    }

    private string SetName(int i){
        switch(i){ 
        case 0 : return "배수정"; 
        case 1 : return "도서준";
        case 2 : return "장민혁";
        case 3 : return "민예리";
        case 4 : return "송현주";
        case 5 : return "김연호";
        }
        return "";
    }

    private void SetImage(int i){
        TalkImage0.SetActive(false);
        switch(i){
            case 0 : TalkImage0.SetActive(true); break;
            default : break;
        }
    }

    public string GetTalk(){ //버튼 종류에 따라 대사 가져오기

        if(talkIndex == talkData[0].Count){
            talkPanel.SetActive(false);
            SceneLoadBtn.SetActive(true);
            talkIndex = 0;
            talkData.RemoveAt(0);
            Debug.Log("삭제");
            Debug.Log(talkData.Count);
            return null;
        }
        else 
            return talkData[0][talkIndex];
    }

    
}

