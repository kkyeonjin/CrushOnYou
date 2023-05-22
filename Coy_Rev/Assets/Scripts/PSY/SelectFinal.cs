using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectFinal : MonoBehaviour
//최종러버 후보 캐릭터들마다 붙어있는 스크립트
{
    public int CharIndex; //캐릭터 인덱스
    public GameObject EndingButton;
    public GameObject characters;
    List<int []> LoveList;

    void Start(){
        LoveList = DataController.Instance.gameData.LoveList;
    }
    public void Select() { //후보 캐릭터 선택했을 때 실행되는 함수

        DataController.Instance.gameData.finalLover = CharIndex; //선택한 캐릭터의 번호 저장
        
        int like = LoveList[DataController.Instance.gameData.finalLover][6]; //최종러버의 나를 향한 호감도
        
        int endingNum; //0:배드A, 1:배드B, 2:노멀A, 3:노멀B, 4:진엔딩

        if (DataController.Instance.gameData.myLover == DataController.Instance.gameData.finalLover) 
        //내가 처음에 선택한 친구인 경우
        {
            if (like >= 100)
            {
                endingNum = 4;
                DataController.Instance.gameData.endingNum = endingNum;
                Debug.Log(endingNum);
            }
            else
            {
                endingNum = 2;
                DataController.Instance.gameData.endingNum = endingNum;
                Debug.Log(endingNum);
            }
        }
        else
        //처음에 선택한 친구가 아닌 경우
        {
            endingNum = 3;
            DataController.Instance.gameData.endingNum = endingNum;
            Debug.Log(endingNum);
        }
     
            
        EndingButton.SetActive(true); //엔딩 화면으로 넘어가는 버튼 활성화
        
    }
}

