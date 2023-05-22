using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TalkSceneManager : MonoBehaviour
{
    public GameObject Btns; //키워드 버튼 4개


    class Keyword //키워드, 키워드를 좋아하는 캐릭터 번호
    {
        public string category;
        public bool[] like;
    }

    List<string> Keywords; //KeyInfo 키 모음 리스트

    Dictionary<string, Keyword> KeyInfo = new Dictionary<string, Keyword>() //키:키워드 이름, 값:키워드 정보
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
        {"패션 트렌드", new Keyword(){category = "issue", like = new bool[6]{true, false, false, true, true, true}}},
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

    //kw1~4 : 장소에 사람 1명일 때
    public TMP_Text kw1;
    public TMP_Text kw2;
    public TMP_Text kw3;
    public TMP_Text kw4;

    //kw5~8 : 장소에 사람 2명일 때
    public TMP_Text kw5;
    public TMP_Text kw6;
    public TMP_Text kw7;
    public TMP_Text kw8;

    List<string> toShow = new List<string>(); //선택된 4개 키워드 리스트

    List<int> ppHere = new List<int>(); 
    //해당 장소에 있는 사람(0:red, 1:green, 2:blue, 3:purple, 4:pink, 5:yellow)

    void WhoAreHere(){ //해당 장소에 있는 캐릭터 찾아서 ppHere에 저장
        for(int i=0; i<6; i++){
            if(DataController.Instance.gameData.place[i] == DataController.Instance.gameData.myPlace){
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
        //선택한 버튼 번호 이름 저장 (kw1~4든 kw5~8이든 "오브젝트" 이름을 Kw1~4로 지어놓음)
        switch(ButtonName){
            //선택한 키워드에 따라 대화 데이터 생성 - 호감도 조정 - 인트로 끝났다고 변수 변경 - 대화 시작
            case "Kw1" : GenerateData(toShow[0]); ManageLove(0); Img.isIntro = false; Talk(); break;
            case "Kw2" : GenerateData(toShow[1]); ManageLove(1); Img.isIntro = false; Talk(); break;
            case "Kw3" : GenerateData(toShow[2]); ManageLove(2); Img.isIntro = false; Talk(); break;
            case "Kw4" : GenerateData(toShow[3]); ManageLove(3); Img.isIntro = false; Talk(); break;
        }
        Btns.SetActive(false); //버튼 한번 누르면 비활성화
    }

    void ManageLove(int i){ //호감도 조정하는 함수

        int key = i; //사용자가 누른 버튼 번호 ex) toShow[i].ch -> 해당 키워드를 좋아하는 캐릭터
        int e = 10; //호감도 변화 정도
        List<int[]> LoveList = DataController.Instance.gameData.LoveList;

        void increaseLove(int a, int b){
            LoveList[a][b] += e; //e만큼 호감도 증가
            LoveList[a][b] = Mathf.Min(100, LoveList[a][b]); //증가했을 때 100 넘으면 100으로 설정
        }

        void decreaseLove(int a, int b){
            LoveList [a][b] -= e; //e만큼 호감도 감소
            LoveList[a][b] = Mathf.Max(0, LoveList[a][b]); //감소했을 때 0 밑이면 0으로 설정
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

        DataController.Instance.gameData.LoveList = LoveList;
    }

    
    void Start()
    {   
        Keywords = new List<string>(KeyInfo.Keys); //키워드 이름들 저장
        talkData = new List<List<string>>();
        Img = this.gameObject.AddComponent<ImageChange>(); //캐릭터 이미지 변경해줄 스크립트
        ManageKeyword(); //키워드 4개 선정
        WhoAreHere(); //현재 장소에 있는 캐릭터 파악
        Debug.Log("실행2");
        Intro(); //인트로 실행(안녕 무슨일이야)

        if(ppHere.Count >1){ //현재 장소에 사람 2명 있으면 Keyword2를 버튼으로 설정(기본이 Keyword1)
            Btns = GameObject.Find("Keyword2");
            kw5.text = toShow[0];
            kw6.text = toShow[1];
            kw7.text = toShow[2];
            kw8.text = toShow[3];
            Btns.SetActive(false); //일단 안보이게 설정(인트로 끝나고 띄워야됨)   
        }
        else{
            GameObject.Find("Keyword2").SetActive(false);
        }
        
        kw1.text = toShow[0];
        kw2.text = toShow[1];
        kw3.text = toShow[2];
        kw4.text = toShow[3];
    }
    
    ////////대사창

    public GameObject talkPanel;
    public GameObject SceneLoadBtn;
    public GameObject dialog;
    public GameObject text;
    public TMP_Text TalkName;
    public TMP_Text TalkText;
    public ImageChange Img;
    public bool isAction;
    public int talkIndex;
    public string KW;

    public List<List<string>> talkData;

    void Intro(){

        Btns.SetActive(false);
        TalkName.text = SetName(ppHere[0]); //장소에 있는 한명 이름
        TalkText.text = "안녕, 무슨 일이야?";
        Img.SetImage(ppHere, 10, true); //차례에 맞는 이미지 설정(10은 더미값 LoveWho에 7같은 느낌)
    }

    void GenerateData(string ButtonName){ //대화 데이터 생성

        KW = ButtonName; //키워드 이름
        string key;

        switch(ppHere.Count){
            case 1 : //사람 한명인 경우
                    key = KeyInfo[ButtonName].like[ppHere[0]].ToString() + ButtonName;
                    //key는 스크립트 저장해놓은 딕셔너리에서 검색할 키
                    //캐릭터가 키워드를 좋아하는지 + 키워드 이름
                    Debug.Log(key);
                    talkData.Add(ScriptManager.ScriptsInfo1[key]); //스크립트 추가
                    break;

            case 2 : //사람 두명인 경우
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

        Debug.Log("talk 실행");
        Debug.Log(Img.isIntro);
        if(Img.isIntro){ //인트로인 경우
            Btns.SetActive(true);
            dialog.SetActive(false);
            text.SetActive(true);
            //TalkName.text = "나";
            //TalkText.text = "(어떤 대화 주제를 꺼낼까?)";
            //Img.isIntro = false;
        }
        else{//키워드 선택한 이후
            dialog.SetActive(true);
            text.SetActive(false);
            string line = GetTalk(); //대사 불러오기
            if(line == null) return; //대화가 끝나면 리턴

            string name = GetInfo(); //이름, 이미지 불러오기

            TalkName.text = name;
            TalkText.text = line;
            isAction = true;
            talkIndex++; //인덱스 하나 증가
        }

    }

    private string GetInfo(){ //현재 대화하고 있는 캐릭터의 이름, 이미지 불러오기

        if(ppHere.Count == 1){
            switch(talkIndex){//대사 인덱스에 따라 불러오기
                
                //setImage(현재 장소에 있는 사람, 현재 대화상대, 그 상대가 선택한 키워드를 좋아하는지)
                case 0 : Img.SetImage(ppHere, ppHere[0], KeyInfo[KW].like[ppHere[0]]); 
                         return SetName(ppHere[0]);

                case 1 : Img.SetImage(ppHere, ppHere[0], KeyInfo[KW].like[ppHere[0]]);
                         return SetName(ppHere[0]);

                case 2 : Img.SetImage(ppHere, 10, true); return "";
                    
                default : Img.SetImage(ppHere, 10, true); return "";    
            }
        }
        else{
            switch(talkIndex){
                case 0 : Img.SetImage(ppHere, ppHere[0], KeyInfo[KW].like[ppHere[0]]);  
                         return SetName(ppHere[0]);

                case 1 : Img.SetImage(ppHere, ppHere[1], KeyInfo[KW].like[ppHere[1]]); 
                         return SetName(ppHere[1]);

                case 2 : Img.SetImage(ppHere, 10, true); return "";
                    
                default : Img.SetImage(ppHere, 10, true); return "";    
            }
        }
    }

    private string SetName(int i){
        switch(i){ 
        case 0 : return "가영"; 
        case 1 : return "서준";
        case 2 : return "테오";
        case 3 : return "유이";
        case 4 : return "하나";
        case 5 : return "시우";
        }
        return "";
    }

    public string GetTalk(){ //버튼 종류에 따라 대사 가져오기

        if(talkData.Count == 0){ //대사가 다 끝나면 null 리턴
            return null;
        }
        
        if(talkIndex == talkData[0].Count){
            //대사가 끝나면
            //talkPanel.SetActive(false); //대사창 비활성화
            SceneLoadBtn.SetActive(true); //돌아가기 버튼 활성화
            talkIndex = 0; //인덱스 초기화
            talkData.RemoveAt(0); //대사데이터 초기화
            Debug.Log("삭제");
            Debug.Log(talkData.Count);
            return null; //널 리턴
        }
        else 
        //대사 남아있으면
            return talkData[0][talkIndex]; //해당 대사 리턴
    }

    
}

