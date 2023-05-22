using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class EndingManager : MonoBehaviour //엔딩 이전 화면에 적용되는 스크립트
{
    public GameObject red, blue, green, purple, pink, yellow;
    List<GameObject> characters;

    public List<int []> LoveList; //DataController에서 받아와서 쓸 변수(이름 길어서)
    public List<int> tempLover; //최종러버 후보들
    public List<int> favorites; //나를 제일 좋아하는 캐릭터들
    public List<int> SixtyUp; //나를 향한 호감도가 60이상인 캐릭터들
    public GameObject EndingButton;
    public GameObject LoverSelecttext;
    public GameObject TellSelectBtns;
    public GameObject characterImg;

    public bool isClicked;

    // Start is called before the first frame update
    void Start()
    {
        LoveList = DataController.Instance.gameData.LoveList;
        
        SixtyUp = new List<int>();
        favorites = new List<int>();
        tempLover = new List<int>();
        characters = new List<GameObject>{red, green, blue, purple, pink, yellow};
        SetFavorites();
        SetSixtyUp();
        SetTempLover();
        //SetEnding();
    }

    void Update(){
        if(!isClicked){//클릭했을 때 한번 실행
            if(Input.GetMouseButton(0)){//화면 좌클릭하면
                characterImg.SetActive(false); //캐릭터 사진들 비활성화
                SetEndingNew();
                LoverSelecttext.SetActive(false); //텍스트 이거에서
                TellSelectBtns.SetActive(true); //이거로 변경
                isClicked = true;
            }
        }
    }

    void SetFavorites(){ //나를 제일 좋아하는 캐릭터들 favorites에 저장
        
        for(int i=0; i<6; i++){
            
            int max = 0; //가장 좋아하는 캐릭터
            for(int j=0; j<7; j++){
                if(LoveList[i][j]>=LoveList[i][max]){
                    max = j;
                }
            }

            if(max == 6) favorites.Add(i); //가장 좋아하는 캐릭터가 코이면 favorites에 저장
        }

        Debug.Log(favorites.Count);
    }

    void SetSixtyUp() // favorites 중에서 호감도가 60 이상인 후보들 SixtyUp에 저장
    {
        if(favorites.Count == 0)
        {
            return;
        }
        else
        {
            for(int i = 0; i<favorites.Count; i++)
            {
                if(LoveList[favorites[i]][6] >= 60)
                {
                    SixtyUp.Add(favorites[i]);
                }
        }
        }
        
        Debug.Log(SixtyUp.Count);
    }

    void SetTempLover()
    { //최종러버 후보들 저장
      //SixtyUp 중에 나를 향한 호감도가 똑같은 캐릭터가 여러명일 경우 떄문에

        if (SixtyUp.Count == 0)
        {
            DataController.Instance.gameData.finalLover = 6; //나를 향한 호감도가 60 이상인 사람이 아무도 없을 때
            DataController.Instance.gameData.endingNum = 1; //1번 엔딩(배드)로 결정
        }
        else
        {
            int max = 0;
            for (int i = 0; i < SixtyUp.Count; i++)
            {

                if (LoveList[SixtyUp[i]][6] > LoveList[max][6]) 
                //i번째 캐릭터의 코이를 향한 호감도가 현재 저장되어있는 캐릭터의 호감도보다 높은 경우
                {
                    max = SixtyUp[i]; //맥스 변경
                    tempLover.Clear(); //최종러버 후보 배열 비우기
                    tempLover.Add(SixtyUp[i]); //새로운 후보 넣기
                }
                else if (LoveList[SixtyUp[i]][6] == LoveList[max][6])
                //i번째 캐릭터의 코이를 향한 호감도가 현재 저장되어있는 캐릭터의 호감도와 같은 경우
                {
                    max = SixtyUp[i];
                    tempLover.Add(SixtyUp[i]); //새로운 후보 추가
                }
            }
        }

        Debug.Log(tempLover.Count);
    }

    void SetEndingNew()
    {
        if (tempLover.Count == 0){ //아무도 코이를 안좋아하는 경우
            EndingButton.SetActive(true); //엔딩 이동 버튼만 띄움
        }
        else
        {//후보가 여러명인 경우
            EndingButton.SetActive(false);
            for (int i = 0; i < characters.Count; i++)
            {
                if (tempLover.Contains(i))
                { //후보들 화면에 띄우기
                    characters[i].SetActive(true);
                    LoverSelecttext.SetActive(true);
                }
            }
        }
    }

    /*
    void SetEnding(){ //엔딩 종류 결정
        if(tempLover.Count == 1){ //최종러버 후보가 한명인 경우 바로 호감도에 따라 엔딩 결정
            DataController.Instance.gameData.finalLover = tempLover[0];
            int like = LoveList[tempLover[0]][6];
            int endingNum;
            if(like < 50) endingNum = 6;
            else if(like>=50 && like<70){
                if(DataController.Instance.gameData.myLover == DataController.Instance.gameData.finalLover){
                    endingNum = 2;
                }
                else endingNum = 5;
            }
            else if(like>=70 && like<90){
                if(DataController.Instance.gameData.myLover == DataController.Instance.gameData.finalLover){
                    endingNum = 1;
                }
                else endingNum = 4;
            }
            else{
                if(DataController.Instance.gameData.myLover == DataController.Instance.gameData.finalLover){
                    endingNum = 0;
                }
                else endingNum = 3;
            }

            DataController.Instance.gameData.endingNum = endingNum;
            Debug.Log(endingNum);
        }
        else if(tempLover.Count == 0) return; //아무도 날 안좋아하면 리턴
        else{//후보가 여러명인 경우
            EndingButton.SetActive(false);
            for(int i=0; i<characters.Count; i++){
                if(tempLover.Contains(i)){ //후보들 화면에 띄우기
                    characters[i].SetActive(true);
                }
            }
        }
    }
    */
    public void LoadEnding(){
        SceneManager.LoadScene("Ending_PSY");
    }




}
