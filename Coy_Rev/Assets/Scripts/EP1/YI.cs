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

public class YI : MonoBehaviour
{
    static YI _instance = null;

    public static YI Instance()
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

    public static string myrole = DataController.Instance.gameData.roles[3];
    //public static int mylover = DataController.Instance.gameData.loveWho[3];
    public static int myCount;

    static int mytype;

    static string[] _TMI = new string[] { "유이 TMI1", "유이 TMI2", "유이 TMI3" };

    static string[] _5A = new string[] { "유이A_1", "유이A_2", "유이A_3" };  //A 일때
    static string[] _5B = new string[] { "유이B_1", "유이B_2", "유이B_3" };  //B 일때
    static string[] _5C = new string[] { "유이C_1", "유이C_2", "유이C_3" };  //C 일때
    static string[] _5D = new string[] { "유이D_1", "유이D_2", "유이D_3" };  //D 일때
    static string[] _5E = new string[] { "유이E_1", "유이E_2", "유이E_3" };  //E 일때
    static string[] _5F = new string[] { "유이F_1", "유이F_2", "유이F_3" };  //F 일때

    static string[] _LoveKY = new string[] { "유이-가영1", "유이-가영2", "유이-가영3" };  //1
    static string[] _LoveSJ = new string[] { "유이-서준1", "유이-서준2", "유이-서준3" };  //2
    static string[] _LoveTO = new string[] { "유이-테오1", "유이-테오2", "유이-테오3" };  //3
    static string[] _LoveHN = new string[] { "유이-하나1", "유이-하나2", "유이-하나3" };  //5
    static string[] _LoveJH = new string[] { "유이-지후1", "유이-지후2", "유이-지후3" };  //6


    public static bool[] talk = new bool[] { false, false, false, false, false, false, false, false, false, false }; //코이와 대화 주기

    public static string TMI()
    {

        if (DataController.Instance.gameData.TMIcount[3] == 5)
        {
            DataController.Instance.gameData.TMIcount[3] = -1;
        }

        DataController.Instance.gameData.TMIcount[3]++;
        print("TMI COUNT : " + DataController.Instance.gameData.TMIcount[3]);
        return _TMI[DataController.Instance.gameData.TMIcount[3]];
    }
    public static bool isEven()
    {
        int day = DataController.Instance.gameData.Gday;
        if (day % 2 == 0)
        {
            return true;
        }
        else return false;
    }

    public static string Ans5()
    {
        if (DataController.Instance.gameData.Ans5Count[3] == 5)
        {
            DataController.Instance.gameData.Ans5Count[3] = -1;
        }

        DataController.Instance.gameData.Ans5Count[3]++;
        string defaultstr = "";

        switch (myrole)
        {
            case "A":
                return _5A[DataController.Instance.gameData.Ans5Count[3]];

            case "B":
                return _5B[DataController.Instance.gameData.Ans5Count[3]];

            case "C":
                return _5C[DataController.Instance.gameData.Ans5Count[3]];

            case "D":
                return _5D[DataController.Instance.gameData.Ans5Count[3]];

            case "E":
                return _5E[DataController.Instance.gameData.Ans5Count[3]];

            case "F":
                return _5F[DataController.Instance.gameData.Ans5Count[3]];

            default:
                return defaultstr;

        }

    }

    public static string myLove()
    {

        if (DataController.Instance.gameData.LoveCount[3] == 5)
        {
            DataController.Instance.gameData.LoveCount[3] = -1;
        }

        DataController.Instance.gameData.LoveCount[3]++;
        string defaultstr = "";

        switch (DataController.Instance.gameData.loveWho[3])
        {
            case 1:
                return _LoveKY[DataController.Instance.gameData.LoveCount[3]];

            case 2:
                return _LoveSJ[DataController.Instance.gameData.LoveCount[3]];

            case 3:
                return _LoveTO[DataController.Instance.gameData.LoveCount[3]];

            case 5:
                return _LoveHN[DataController.Instance.gameData.LoveCount[3]];

            case 6:
                return _LoveJH[DataController.Instance.gameData.LoveCount[3]];

            default:
                return defaultstr;

        }
    }

    public static void updateQ()
    {

        myCount = DataController.Instance.gameData.QTimes[3];

        if (myCount == 4)
        {
            DataController.Instance.gameData.CutSceneQueue.Enqueue(3);
            Q_Check.PrintQ();
        }

    }

}