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

public class SJ : MonoBehaviour
{
    static SJ _instance = null;

    public static SJ Instance()
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

    public static string myrole = DataController.Instance.gameData.roles[1];
    //public static int mylover = DataController.Instance.gameData.loveWho[1];
    public static int myCount;

    static int mytype;

    static string[] _TMI = new string[] { "서준 TMI1", "서준 TMI2", "서준 TMI3" };

    static string[] _5A = new string[] { "서준A_1", "서준A_2", "서준A_3" };  //A 일때
    static string[] _5B = new string[] { "서준B_1", "서준B_2", "서준B_3" };  //B 일때
    static string[] _5C = new string[] { "서준C_1", "서준C_2", "서준C_3" };  //C 일때
    static string[] _5D = new string[] { "서준D_1", "서준D_2", "서준D_3" };  //D 일때
    static string[] _5E = new string[] { "서준E_1", "서준E_2", "서준E_3" };  //E 일때
    static string[] _5F = new string[] { "서준F_1", "서준F_2", "서준F_3" };  //F 일때


    static string[] _LoveKY = new string[] { "서준-가영1", "서준-가영2", "서준-가영3" };  //1
    static string[] _LoveTO = new string[] { "서준-테오1", "서준-테오2", "서준-테오3" };  //3
    static string[] _LoveYI = new string[] { "서준-유이1", "서준-유이2", "서준-유이3" };  //4
    static string[] _LoveHN = new string[] { "서준-하나1", "서준-하나2", "서준-하나3" };  //5
    static string[] _LoveJH = new string[] { "서준-지후1", "서준-지후2", "서준-지후3" };  //6

    public static string TMI()
    {

        if (DataController.Instance.gameData.TMIcount[1] == 5)
        {
            DataController.Instance.gameData.TMIcount[1] = -1;
        }

        DataController.Instance.gameData.TMIcount[1]++;
        print("TMI COUNT : " + DataController.Instance.gameData.TMIcount[1]);
        return _TMI[DataController.Instance.gameData.TMIcount[1]];
    }

    public static bool Talk(int query)
    {
        if (query == 0)
        {
            DataController.Instance.gameData.SJCount5 = 0;
            DataController.Instance.gameData.SJCount10 = 0;
            return true;
        }
        else if (query == 1)
        {
            DataController.Instance.gameData.SJCount5++;
            DataController.Instance.gameData.SJCount10 = 0;
            if (DataController.Instance.gameData.SJCount5 % 2 == 0) return false;
        }
        else if (query == 2)
        {
            DataController.Instance.gameData.SJCount10++;
            DataController.Instance.gameData.SJCount5 = 0;
            if (DataController.Instance.gameData.SJCount10 % 2 == 0) return false;
        }
        return true;
    }

    public static string Ans5()
    {
        if (DataController.Instance.gameData.Ans5Count[1] == 5)
        {
            DataController.Instance.gameData.Ans5Count[1] = -1;
        }

        DataController.Instance.gameData.Ans5Count[1]++;
        string defaultstr = "";

        switch (myrole)
        {
            case "A":
                return _5A[DataController.Instance.gameData.Ans5Count[1]];

            case "B":
                return _5B[DataController.Instance.gameData.Ans5Count[1]];

            case "C":
                return _5C[DataController.Instance.gameData.Ans5Count[1]];

            case "D":
                return _5D[DataController.Instance.gameData.Ans5Count[1]];

            case "E":
                return _5E[DataController.Instance.gameData.Ans5Count[1]];

            case "F":
                return _5F[DataController.Instance.gameData.Ans5Count[1]];

            default:
                return defaultstr;

        }

    }

    public static string myLove()
    {

        if (DataController.Instance.gameData.LoveCount[1] == 5)
        {
            DataController.Instance.gameData.LoveCount[1] = -1;
        }

        DataController.Instance.gameData.LoveCount[1]++;
        string defaultstr = "";

        switch (DataController.Instance.gameData.loveWho[1])
        {
            case 1:
                return _LoveKY[DataController.Instance.gameData.LoveCount[1]];

            case 3:
                return _LoveTO[DataController.Instance.gameData.LoveCount[1]];

            case 4:
                return _LoveYI[DataController.Instance.gameData.LoveCount[1]];

            case 5:
                return _LoveHN[DataController.Instance.gameData.LoveCount[1]];

            case 6:
                return _LoveJH[DataController.Instance.gameData.LoveCount[1]];

            default:
                return defaultstr;

        }
    }

    public static void updateQ()
    {

        myCount = DataController.Instance.gameData.QTimes[1];

        if (myCount == 4)
        {
            DataController.Instance.gameData.CutSceneQueue.Enqueue(1);
            Q_Check.PrintQ();
        }

    }

}
