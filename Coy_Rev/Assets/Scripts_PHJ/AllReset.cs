using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllReset : MonoBehaviour
{
    public void Start()
    {

        // AllResetBtn();

    }

    // Start is called before the first frame update
    public void AllResetBtn()
    {
        DataController.Instance.gameData.playedBefore = false;
        DataController.Instance.gameData.WPlayedBefore = false;
        DataController.Instance.gameData.turn = 0;
        DataController.Instance.gameData.GPlayedBefore = false;
        DataController.Instance.gameData.GOver = false;
        DataController.Instance.gameData.Submit = false;
        DataController.Instance.gameData.Gday = 1;
        DataController.Instance.gameData.Gturn = 4;
        DataController.Instance.gameData.Genergy = 20;
        DataController.Instance.gameData.TMIcount = new int[] { -1, -1, -1, -1, -1, -1 };
        DataController.Instance.gameData.Ans5Count = new int[] { -1, -1, -1, -1, -1, -1 };
        DataController.Instance.gameData.LoveCount = new int[] { -1, -1, -1, -1, -1, -1 };
        DataController.Instance.gameData.CharList = new List<int>() { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
        DataController.Instance.gameData.QTimes = new int[] { 0, 0, 0, 0, 0, 0 };

        TO.talk = new bool[] { false, false, false, false, false, false, false, false, false, false };
        HN.talk = new bool[] { false, false, false, false, false, false, false, false, false, false };

        DataController.Instance.gameData.SJCount5 = 0;
        DataController.Instance.gameData.SJCount10 = 0;
        DataController.Instance.gameData.KYCount5 = 0;
        DataController.Instance.gameData.KYCount10 = 0;
    }
}
