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

public class JH : MonoBehaviour
{
    static JH _instance = null;

    public static JH Instance()
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

    public static string myrole = DataController.Instance.gameData.roles[5];
    //public static int mylover = DataController.Instance.gameData.loveWho[5];
    public static int myCount;

    static int mytype;

    static string[] _TMI = new string[] { "지후 TMI1", "지후 TMI2", "지후 TMI3" };

    static string[] _5A = new string[] { "지후A_1", "지후A_2", "지후A_3" };  //A 일때
    static string[] _5B = new string[] { "지후B_1", "지후B_2", "지후B_3" };  //B 일때
    static string[] _5C = new string[] { "지후C_1", "지후C_2", "지후C_3" };  //C 일때
    static string[] _5D = new string[] { "지후D_1", "지후D_2", "지후D_3" };  //D 일때
    static string[] _5E = new string[] { "지후E_1", "지후E_2", "지후E_3" };  //E 일때
    static string[] _5F = new string[] { "지후F_1", "지후F_2", "지후F_3" };  //F 일때

    static string[] _LoveKY = new string[] { "지후-가영1", "지후-가영2", "지후-가영3" };  //1
    static string[] _LoveSJ = new string[] { "지후-서준1", "지후-서준2", "지후-서준3" };  //2
    static string[] _LoveTO = new string[] { "지후-테오1", "지후-테오2", "지후-테오3" };  //3
    static string[] _LoveYI = new string[] { "지후-유이1", "지후-유이2", "지후-유이3" };  //4
    static string[] _LoveHN = new string[] { "지후-하나1", "지후-하나2", "지후-하나3" };  //5

    public static string TMI()
    {

        if (DataController.Instance.gameData.TMIcount[5] == 5)
        {
            DataController.Instance.gameData.TMIcount[5] = -1;
        }

        DataController.Instance.gameData.TMIcount[5]++;
        print("TMI COUNT : " + DataController.Instance.gameData.TMIcount[5]);
        return _TMI[DataController.Instance.gameData.TMIcount[5]];
    }
    public static bool isOdd()
    {
        int day = DataController.Instance.gameData.Gday;
        if (day % 2 == 1)
        {
            return true;
        }
        else return false;
    }

    public static string Ans5()
    {
        if (DataController.Instance.gameData.Ans5Count[5] == 5)
        {
            DataController.Instance.gameData.Ans5Count[5] = -1;
        }

        DataController.Instance.gameData.Ans5Count[5]++;
        string defaultstr = "";

        switch (myrole)
        {
            case "A":
                return _5A[DataController.Instance.gameData.Ans5Count[5]];

            case "B":
                return _5B[DataController.Instance.gameData.Ans5Count[5]];

            case "C":
                return _5C[DataController.Instance.gameData.Ans5Count[5]];

            case "D":
                return _5D[DataController.Instance.gameData.Ans5Count[5]];

            case "E":
                return _5E[DataController.Instance.gameData.Ans5Count[5]];

            case "F":
                return _5F[DataController.Instance.gameData.Ans5Count[5]];

            default:
                return defaultstr;

        }
    }

    public static string myLove()
    {

        if (DataController.Instance.gameData.LoveCount[5] == 5)
        {
            DataController.Instance.gameData.LoveCount[5] = -1;
        }

        DataController.Instance.gameData.LoveCount[5]++;
        string defaultstr = "";

        switch (DataController.Instance.gameData.loveWho[5])
        {
            case 1:
                return _LoveKY[DataController.Instance.gameData.LoveCount[5]];

            case 2:
                return _LoveSJ[DataController.Instance.gameData.LoveCount[5]];

            case 3:
                return _LoveTO[DataController.Instance.gameData.LoveCount[5]];

            case 4:
                return _LoveYI[DataController.Instance.gameData.LoveCount[5]];

            case 5:
                return _LoveHN[DataController.Instance.gameData.LoveCount[5]];

            default:
                return defaultstr;

        }
    }


    public static void updateQ()
    {

        myCount = DataController.Instance.gameData.QTimes[5];

        if (myCount == 4)
        {
            DataController.Instance.gameData.CutSceneQueue.Enqueue(5);
            Q_Check.PrintQ();
        }

    }

}