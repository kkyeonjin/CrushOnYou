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

public class HN : MonoBehaviour
{
    static HN _instance = null;
    //public static string myrole;

    public static HN Instance()
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



    public static string myrole = DataController.Instance.gameData.roles[4];
    //public static int mylover = DataController.Instance.gameData.loveWho[4];
    public static int myCount;

    static int mytype;

    static string[] _TMI = new string[] { "하나 TMI1", "하나 TMI2", "하나 TMI3" };

    static string[] _5A = new string[] { "하나A_1", "하나A_2", "하나A_3" };  //A 일때
    static string[] _5B = new string[] { "하나B_1", "하나B_2", "하나B_3" };  //B 일때
    static string[] _5C = new string[] { "하나C_1", "하나C_2", "하나C_3" };  //C 일때
    static string[] _5D = new string[] { "하나D_1", "하나D_2", "하나D_3" };  //D 일때
    static string[] _5E = new string[] { "하나E_1", "하나E_2", "하나E_3" };  //E 일때
    static string[] _5F = new string[] { "하나F_1", "하나F_2", "하나F_3" };  //F 일때


    static string[] _LoveKY = new string[] { "하나-가영1", "하나-가영2", "하나-가영3" };  //1
    static string[] _LoveSJ = new string[] { "하나-서준1", "하나-서준2", "하나-서준3" };  //2
    static string[] _LoveTO = new string[] { "하나-테오1", "하나-테오2", "하나-테오3" };  //3
    static string[] _LoveYI = new string[] { "하나-유이1", "하나-유이2", "하나-유이3" };  //4
    static string[] _LoveJH = new string[] { "하나-지후1", "하나-지후2", "하나-지후3" };  //6

    public static bool[] talk = new bool[] { false, false, false, false, false, false, false, false, false, false };

    public static string TMI()
    {

        if (DataController.Instance.gameData.TMIcount[4] == 5)
        {
            DataController.Instance.gameData.TMIcount[4] = -1;
        }

        DataController.Instance.gameData.TMIcount[4]++;
        print("TMI COUNT : " + DataController.Instance.gameData.TMIcount[4]);
        return _TMI[DataController.Instance.gameData.TMIcount[4]];
    }

    public static bool isTalk()
    { //돌발대사 여부 리턴(false일 때 돌발대사)

        Debug.Log("isTalk 실행");

        int day = DataController.Instance.gameData.Gday;
        if (day > 2)
        {
            if (HN.talk[day - 1] == false && HN.talk[day - 2] == false && HN.talk[day - 3] == false)
            {
                HN.talk[day - 1] = true;
                return false;
            }
        }
        HN.talk[day - 1] = true;
        return true;

    }

    public static string Ans5()
    {
        if (DataController.Instance.gameData.Ans5Count[4] == 5)
        {
            DataController.Instance.gameData.Ans5Count[4] = -1;
        }

        DataController.Instance.gameData.Ans5Count[4]++;
        string defaultstr = "";

        switch (myrole)
        {
            case "A":
                return _5A[DataController.Instance.gameData.Ans5Count[4]];

            case "B":
                return _5B[DataController.Instance.gameData.Ans5Count[4]];

            case "C":
                return _5C[DataController.Instance.gameData.Ans5Count[4]];

            case "D":
                return _5D[DataController.Instance.gameData.Ans5Count[4]];

            case "E":
                return _5E[DataController.Instance.gameData.Ans5Count[4]];

            case "F":
                return _5F[DataController.Instance.gameData.Ans5Count[4]];

            default:
                return defaultstr;

        }
    }

    public static string myLove()
    {

        if (DataController.Instance.gameData.LoveCount[4] == 5)
        {
            DataController.Instance.gameData.LoveCount[4] = -1;
        }

        DataController.Instance.gameData.LoveCount[4]++;
        string defaultstr = "";

        switch (DataController.Instance.gameData.loveWho[4])
        {
            case 1:
                return _LoveKY[DataController.Instance.gameData.LoveCount[4]];

            case 2:
                return _LoveSJ[DataController.Instance.gameData.LoveCount[4]];

            case 3:
                return _LoveTO[DataController.Instance.gameData.LoveCount[4]];

            case 4:
                return _LoveYI[DataController.Instance.gameData.LoveCount[4]];

            case 6:
                return _LoveJH[DataController.Instance.gameData.LoveCount[4]];

            default:
                return defaultstr;

        }
    }

    public static void updateQ()
    {

        myCount = DataController.Instance.gameData.QTimes[4];

        if (myCount == 4)
        {
            DataController.Instance.gameData.CutSceneQueue.Enqueue(4);
            Q_Check.PrintQ();
        }

    }

}
