using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.XR;
using System.Linq;

public class RandomQuestion : MonoBehaviour
{

    public static RandomQuestion instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject);
    }

    public List<int> index;
    public List<int> c; //너무 길어서 대신하려고
    //public List<int> CharList;
    public Dictionary<int, Dictionary<int, string[]>> QList = new Dictionary<int, Dictionary<int, string[]>>();
    public TMP_Text q1, q2, q3;
    public Sprite[] qCharacters;
    public Image q1p, q2p, q3p;
    public int pick;
    public int x, y, z;
    public SelectCard script1, script2, script3;

    public void ResetCharList()
    {
        //하루 지날 때 마다 CharList 초기화

        DataController.Instance.gameData.CharList = new List<int>() { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
    }

    public void Pick()
    {
        c = DataController.Instance.gameData.CharList;
        DataController.Instance.gameData.temp = DataController.Instance.gameData.CharList.ToList();
        Debug.Log("뽑기 실행");
        for (int i = 0; i < 3; i++)
        {
            pick = Random.Range(0, c.Count);
            if (index.Contains(c[pick]))
            {
                i--;
            }
            else
            {
                index.Add(c[pick]);
                c.RemoveAt(pick);
            }
        }
    }

    public void RandomIndexMake()
    {
        Pick();
        if (c.Count == 3)
        {
            if (c[0] == c[1] || c[0] == c[2] || c[1] == c[2])
            {
                while (c[0] == c[1] || c[0] == c[2] || c[1] == c[2])
                {
                    Debug.Log("다시 뽑기");
                    Pick();
                }
            }

        }

    }
    // 하루 대화 12번 -> 6명이 2번씩 질문 등장


    // Start is called before the first frame update
    void Start()
    {
        if (DataController.Instance.gameData.Gday == 1 && DataController.Instance.gameData.Gturn == 4)
        {
            DataController.Instance.gameData.temp = new List<int>() { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
        }
        DataController.Instance.gameData.CharList = DataController.Instance.gameData.temp.ToList();
        QuestionGenerate();
        RandomIndexMake();

        QuestionUpdate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuestionUpdate()
    {
        x = Random.Range(1, 4);
        y = Random.Range(1, 4);
        z = Random.Range(1, 4);

        Debug.Log(CharProfileforDialog.instance.chars[0].name);

        q1.text = QList[index[0]][x][2] + " (에너지 -" + QList[index[0]][x][1] + ")";
        q1p.sprite = qCharacters[index[0]];
        script1.qnum = int.Parse(QList[index[0]][x][0]);
        script1.cardenergy = int.Parse(QList[index[0]][x][1]);

        q2.text = QList[index[1]][y][2] + " (에너지 -" + QList[index[1]][y][1] + ")";
        q2p.sprite = qCharacters[index[1]];
        script2.qnum = int.Parse(QList[index[1]][y][0]);
        script2.cardenergy = int.Parse(QList[index[1]][y][1]);

        q3.text = QList[index[2]][z][2] + " (에너지 -" + QList[index[2]][z][1] + ")";
        q3p.sprite = qCharacters[index[2]];
        script3.qnum = int.Parse(QList[index[2]][z][0]);
        script3.cardenergy = int.Parse(QList[index[2]][z][1]);

        index.Clear();



    }

    public void Test()
    {
        Debug.Log("Test");
    }

    public void QuestionGenerate()
    {

        script1 = GameObject.Find("1").GetComponent<SelectCard>();
        script2 = GameObject.Find("2").GetComponent<SelectCard>();
        script3 = GameObject.Find("3").GetComponent<SelectCard>();

        Dictionary<int, string[]> QData_red = new Dictionary<int, string[]>();
        QData_red.Add(1, new string[] { "1", "3", "가영" });
        QData_red.Add(2, new string[] { "2", "5", "가영" });
        QData_red.Add(3, new string[] { "3", "10", "가영" });

        QList.Add(0, QData_red);

        Dictionary<int, string[]> QData_green = new Dictionary<int, string[]>();
        QData_green.Add(1, new string[] { "4", "3", "서준" });
        QData_green.Add(2, new string[] { "5", "5", "서준" });
        QData_green.Add(3, new string[] { "6", "10", "서준" });

        QList.Add(1, QData_green);

        Dictionary<int, string[]> QData_blue = new Dictionary<int, string[]>();
        QData_blue.Add(1, new string[] { "7", "3", "테오" });
        QData_blue.Add(2, new string[] { "8", "5", "테오" });
        QData_blue.Add(3, new string[] { "9", "10", "테오" });

        QList.Add(2, QData_blue);

        Dictionary<int, string[]> QData_purple = new Dictionary<int, string[]>();
        QData_purple.Add(1, new string[] { "10", "3", "유이" });
        QData_purple.Add(2, new string[] { "11", "5", "유이" });
        QData_purple.Add(3, new string[] { "12", "10", "유이" });

        QList.Add(3, QData_purple);

        Dictionary<int, string[]> QData_pink = new Dictionary<int, string[]>();
        QData_pink.Add(1, new string[] { "13", "3", "하나" });
        QData_pink.Add(2, new string[] { "14", "5", "하나" });
        QData_pink.Add(3, new string[] { "15", "10", "하나" });

        QList.Add(4, QData_pink);

        Dictionary<int, string[]> QData_yellow = new Dictionary<int, string[]>();
        QData_yellow.Add(1, new string[] { "16", "3", "시우" });
        QData_yellow.Add(2, new string[] { "17", "5", "시우" });
        QData_yellow.Add(3, new string[] { "18", "10", "시우" });

        QList.Add(5, QData_yellow);



    }

}