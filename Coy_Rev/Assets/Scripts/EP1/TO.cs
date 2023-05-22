using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Static 변수
각 캐릭터의 Role

자신이 좋아하는 사람 

TMI 3개 (0번 대답)

Lover 15개 (5*3)
자신을 제외한 캐릭터 5명에 대해

Type 1개
자신의 애착 유형

코이와의 대화 횟수

코이와의 대화 주기 : 며칠 만에 코이와 대화

*/

public class TO : MonoBehaviour
{
    static TO _instance = null;

    public static TO Instance()
    {
        return _instance;
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (this != _instance)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public static string myrole = DataController.Instance.gameData.roles[2];
    //public static int mylover = DataController.Instance.gameData.loveWho[2];
    public static int myCount;

    static int mytype;

    static string[] _TMI = new string[] { "테오 TMI1", "테오 TMI2", "테오 TMI3" };

    static string[] _5A = new string[] { "테오A_1", "테오A_2", "테오A_3" };  //A 일때
    static string[] _5B = new string[] { "테오B_1", "테오B_2", "테오B_3" };  //B 일때
    static string[] _5C = new string[] { "테오C_1", "테오C_2", "테오C_3" };  //C 일때
    static string[] _5D = new string[] { "테오D_1", "테오D_2", "테오D_3" };  //D 일때
    static string[] _5E = new string[] { "테오E_1", "테오E_2", "테오E_3" };  //E 일때
    static string[] _5F = new string[] { "테오F_1", "테오F_2", "테오F_3" };  //F 일때


    static string[] _LoveKY = new string[] { "테오-가영1", "테오-가영2", "테오-가영3" };  //1
    static string[] _LoveSJ = new string[] { "테오-서준1", "테오-서준2", "테오-서준3" };  //2
    static string[] _LoveYI = new string[] { "테오-유이1", "테오-유이2", "테오-유이3" };  //4
    static string[] _LoveHN = new string[] { "테오-하나1", "테오-하나2", "테오-하나3" };  //5
    static string[] _LoveJH = new string[] { "테오-지후1", "테오-지후2", "테오-지후3" };  //6

    public static bool[] talk = new bool[] { false, false, false, false, false, false, false, false, false, false }; //코이와 대화 주기

    public static string TMI()
    {

        if (DataController.Instance.gameData.TMIcount[2] == 5)
        {
            DataController.Instance.gameData.TMIcount[2] = -1;
        }

        DataController.Instance.gameData.TMIcount[2]++;
        print("TMI COUNT : " + DataController.Instance.gameData.TMIcount[2]);
        return _TMI[DataController.Instance.gameData.TMIcount[2]];
    }

    public static bool isTalk()
    { //돌발대사 여부 리턴(false일 때 돌발대사)

        Debug.Log("isTalk 실행");

        Debug.Log("Talk : " + TO.talk[0] + TO.talk[1] + TO.talk[2] + TO.talk[3] + TO.talk[4] + TO.talk[5] + TO.talk[6] + TO.talk[7] + TO.talk[8] + TO.talk[9]);


        int day = DataController.Instance.gameData.Gday;
        if (day > 2)
        {
            if (TO.talk[day - 1] == false && TO.talk[day - 2] == false && TO.talk[day - 3] == false)
            {
                TO.talk[day - 1] = true;
                return false;
            }
        }
        TO.talk[day - 1] = true;
        return true;

    }


    public static string Ans5()
    {
        if (DataController.Instance.gameData.Ans5Count[2] == 5)
        {
            DataController.Instance.gameData.Ans5Count[2] = -1;
        }

        DataController.Instance.gameData.Ans5Count[2]++;
        string defaultstr = "";

        switch (myrole)
        {
            case "A":
                return _5A[DataController.Instance.gameData.Ans5Count[2]];

            case "B":
                return _5B[DataController.Instance.gameData.Ans5Count[2]];

            case "C":
                return _5C[DataController.Instance.gameData.Ans5Count[2]];

            case "D":
                return _5D[DataController.Instance.gameData.Ans5Count[2]];

            case "E":
                return _5E[DataController.Instance.gameData.Ans5Count[2]];

            case "F":
                return _5F[DataController.Instance.gameData.Ans5Count[2]];

            default:
                return defaultstr;

        }

    }


    public static string myLove()
    {

        if (DataController.Instance.gameData.LoveCount[2] == 5)
        {
            DataController.Instance.gameData.LoveCount[2] = -1;
        }

        DataController.Instance.gameData.LoveCount[2]++;
        string defaultstr = "";

        switch (DataController.Instance.gameData.loveWho[2])
        {
            case 1:
                return _LoveKY[DataController.Instance.gameData.LoveCount[2]];

            case 2:
                return _LoveSJ[DataController.Instance.gameData.LoveCount[2]];

            case 4:
                return _LoveYI[DataController.Instance.gameData.LoveCount[2]];

            case 5:
                return _LoveHN[DataController.Instance.gameData.LoveCount[2]];

            case 6:
                return _LoveJH[DataController.Instance.gameData.LoveCount[2]];

            default:
                return defaultstr;

        }
    }

    public static void updateQ()
    {

        myCount = DataController.Instance.gameData.QTimes[2];

        if (myCount == 4)
        {
            DataController.Instance.gameData.CutSceneQueue.Enqueue(2);
            Q_Check.PrintQ();
        }

    }

}