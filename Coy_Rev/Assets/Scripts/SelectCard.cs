using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectCard : MonoBehaviour
{
    public Card card;
    public int cardenergy;
    public int qnum;
    public TMP_Text energy;
    public TMP_Text hinttext;
    public GameObject selectQ, dialogue;
    public GameObject hintcard;
    public Image t1, t2, t3, t4;
    public



    void Update()
    {
        energy.text = DataController.Instance.gameData.Genergy.ToString();

        if (DataController.Instance.gameData.Genergy < cardenergy)
        {
            hintcard.GetComponent<BoxCollider2D>().enabled = false;
            hinttext.text = "선택 불가능";
        }
        else
        {
            hintcard.GetComponent<BoxCollider2D>().enabled = true;
        }

    }

    public void Button()
    {
        if (cardenergy <= DataController.Instance.gameData.Genergy)
        {


            SelectMgr.instance.currentCard = card;
            //test
            SelectMgr.instance.Qnum = qnum;
            DataController.Instance.gameData.Genergy -= cardenergy;
            energy.text = DataController.Instance.gameData.Genergy.ToString();
            //turnPass();
            QTimesCount(SelectMgr.instance.Qnum);
            //QAdd();
            DialogController.GenerateScript(SelectMgr.instance.Qnum);
            DataController.Instance.gameData.Gturn -= 1;
            DialogController.instance.DialogStart();
            selectQ.SetActive(false);
            dialogue.SetActive(true);
            Debug.Log("온클릭 실행");

            if (DataController.Instance.gameData.Gturn == 0)
            {
                Debug.Log("reset");
                RandomQuestion.instance.ResetCharList();
            }

            RandomQuestion.instance.RandomIndexMake();
            RandomQuestion.instance.QuestionUpdate();

        }
    }

    public void QTimesCount(int qnum)
    {
        if (qnum >= 1 && qnum <= 3)
        {
            DataController.Instance.gameData.QTimes[0]++;
        }
        else if (qnum >= 4 && qnum <= 6)
        {
            DataController.Instance.gameData.QTimes[1]++;
        }
        else if (qnum >= 7 && qnum <= 9)
        {
            DataController.Instance.gameData.QTimes[2]++;
        }
        else if (qnum >= 10 && qnum <= 12)
        {
            DataController.Instance.gameData.QTimes[3]++;
        }
        else if (qnum >= 13 && qnum <= 15)
        {
            DataController.Instance.gameData.QTimes[4]++;
        }
        else if (qnum >= 16 && qnum <= 18)
        {
            DataController.Instance.gameData.QTimes[5]++;
        }
    }

    public void QAdd()
    {
        if (DataController.Instance.gameData.QTimes[0] == 4)
        {
            DataController.Instance.gameData.CutSceneQueue.Enqueue(0);
            Debug.Log("Enqueued");
        }
        else if (DataController.Instance.gameData.QTimes[1] == 4)
        {
            DataController.Instance.gameData.CutSceneQueue.Enqueue(1);
            Debug.Log("Enqueued");
        }
        else if (DataController.Instance.gameData.QTimes[2] == 4)
        {
            DataController.Instance.gameData.CutSceneQueue.Enqueue(2);
            Debug.Log("Enqueued");
        }
        else if (DataController.Instance.gameData.QTimes[3] == 4)
        {
            DataController.Instance.gameData.CutSceneQueue.Enqueue(3);
            Debug.Log("Enqueued");
        }
        else if (DataController.Instance.gameData.QTimes[4] == 4)
        {
            DataController.Instance.gameData.CutSceneQueue.Enqueue(4);
            Debug.Log("Enqueued");
        }
        else if (DataController.Instance.gameData.QTimes[5] == 4)
        {
            DataController.Instance.gameData.CutSceneQueue.Enqueue(5);
            Debug.Log("Enqueued");
        }
    }

}

