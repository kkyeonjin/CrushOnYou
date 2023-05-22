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

public class KY : MonoBehaviour
{
    static KY _instance = null;

    public static KY Instance()
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

    public static string myrole = DataController.Instance.gameData.roles[0];
    //public static int mylover = DataController.Instance.gameData.loveWho[0];
    public static int myCount;

    static int mytype;

    static string[] _TMI = new string[] { "가영 TMI1", "가영 TMI2", "가영 TMI3" };

    static string[] _5A = new string[] { "가영A_1", "가영A_2", "가영A_3" };  //A 일때
    static string[] _5B = new string[] { "가영B_1", "가영B_2", "가영B_3" };  //B 일때
    static string[] _5C = new string[] { "가영C_1", "가영C_2", "가영C_3" };  //C 일때
    static string[] _5D = new string[] { "가영D_1", "가영D_2", "가영D_3" };  //D 일때
    static string[] _5E = new string[] { "가영E_1", "가영E_2", "가영E_3" };  //E 일때
    static string[] _5F = new string[] { "가영F_1", "가영F_2", "가영F_3" };  //F 일때

    static string[] _LoveSJ = new string[] { "갸영-서준1", "가영-서준2", "가영-서준3" };  //2
    static string[] _LoveTO = new string[] { "가영-테오1", "가영-테오2", "가영-테오3" };  //3
    static string[] _LoveYI = new string[] { "가영-유이1", "가영-유이2", "가영-유이3" };  //4
    static string[] _LoveHN = new string[] { "가영-하나1", "가영-하나2", "가영-하나3" };  //5
    static string[] _LoveJH = new string[] { "가영-지후1", "가영-지후2", "가영-지후3" };  //6


    static bool[] isTalk = new bool[] { false, false, false, false, false, false, false, false, false, false }; //코이와 대화 주기

    public static bool Talk(int query)
    {
        if (query == 0)
        {
            DataController.Instance.gameData.KYCount5 = 0;
            DataController.Instance.gameData.KYCount10 = 0;
            return true;
        }
        else if (query == 1)
        {
            DataController.Instance.gameData.KYCount5++;
            DataController.Instance.gameData.KYCount10 = 0;
            if (DataController.Instance.gameData.KYCount5 % 2 == 0) return false;
        }
        else if (query == 2)
        {
            DataController.Instance.gameData.KYCount10++;
            DataController.Instance.gameData.KYCount5 = 0;
            if (DataController.Instance.gameData.KYCount10 % 2 == 0) return false;
        }
        return true;
    }

    public static string TMI()
    {

        if (DataController.Instance.gameData.TMIcount[0] == 5)
        {
            DataController.Instance.gameData.TMIcount[0] = -1;
        }

        DataController.Instance.gameData.TMIcount[0]++;
        print("TMI COUNT : " + DataController.Instance.gameData.TMIcount[0]);
        return _TMI[DataController.Instance.gameData.TMIcount[0]];
    }


    public static string Ans5()
    {
        if (DataController.Instance.gameData.Ans5Count[0] == 5)
        {
            DataController.Instance.gameData.Ans5Count[0] = -1;
        }

        DataController.Instance.gameData.Ans5Count[0]++;
        string defaultstr = "";

        switch (myrole)
        {
            case "A":
                return _5A[DataController.Instance.gameData.Ans5Count[0]];

            case "B":
                return _5B[DataController.Instance.gameData.Ans5Count[0]];

            case "C":
                return _5C[DataController.Instance.gameData.Ans5Count[0]];

            case "D":
                return _5D[DataController.Instance.gameData.Ans5Count[0]];

            case "E":
                return _5E[DataController.Instance.gameData.Ans5Count[0]];

            case "F":
                return _5F[DataController.Instance.gameData.Ans5Count[0]];

            default:
                return defaultstr;

        }

    }


    public static string myLove()
    {

        if (DataController.Instance.gameData.LoveCount[0] == 5)
        {
            DataController.Instance.gameData.LoveCount[0] = -1;
        }

        DataController.Instance.gameData.LoveCount[0]++;
        string defaultstr = "";

        switch (DataController.Instance.gameData.loveWho[0])
        {
            case 2:
                return _LoveSJ[DataController.Instance.gameData.LoveCount[0]];

            case 3:
                return _LoveTO[DataController.Instance.gameData.LoveCount[0]];

            case 4:
                return _LoveYI[DataController.Instance.gameData.LoveCount[0]];

            case 5:
                return _LoveHN[DataController.Instance.gameData.LoveCount[0]];

            case 6:
                return _LoveJH[DataController.Instance.gameData.LoveCount[0]];

            default:
                return defaultstr;

        }
    }

    public static void updateQ()
    {

        myCount = DataController.Instance.gameData.QTimes[0];

        if (myCount == 4)
        {
            DataController.Instance.gameData.CutSceneQueue.Enqueue(0);
            Q_Check.PrintQ();
        }

    }

}
