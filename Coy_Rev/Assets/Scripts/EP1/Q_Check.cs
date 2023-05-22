using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Q_Check : MonoBehaviour
{

    public static Queue<int> nowQ = DataController.Instance.gameData.CutSceneQueue;


    public static void PrintQ() {

        List<int> backupList = new List<int>(nowQ);

        print("Q프린트!");
        //print(backupList[0]);

        for(int i =0; i < backupList.Count; i++) {
            
            int temp = backupList[i];
            print(i+"번째 : " + temp);

        }

    }



}
