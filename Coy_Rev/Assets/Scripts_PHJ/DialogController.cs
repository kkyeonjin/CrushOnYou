using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogController : MonoBehaviour
{

    public static DialogController instance;

    //public GameObject Today, tomorrow;
    public GameObject Dialog;
    public GameObject SelectAct;
    public GameObject boxDialog;
    public GameObject boxName;
    [SerializeField]
    public Image red, green, blue, purple, pink, yellow;
    public TMP_Text dialogueText;
    public TMP_Text nameText;
    public int talkIndex;
    public static bool done = false;

    public GameObject energy; //0221

    public static Dictionary<int, Dictionary<int, string[]>> dialogList = new Dictionary<int, Dictionary<int, string[]>>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject);
    }

    public string GetSpeaker(int sceneId, int id)
    {
        return dialogList[sceneId][id][0];
    }

    public void DialogStart()
    {
        energy.SetActive(false); //0221

        if (dialogList[0][talkIndex][0] == "%END%")
        {
            energy.SetActive(true); //0221

            if (DataController.Instance.gameData.Gturn == 0)
            {
                talkIndex = 0;
                DataController.Instance.gameData.Gturn = 4;
                DataController.Instance.gameData.Genergy = 20;
                DataController.Instance.gameData.Gday += 1;
                dialogList.Remove(0);

                if (DataController.Instance.gameData.Gday == 11)
                {
                    return;
                }
                else
                {
                    CutSceneManager.instance.CutSceneChange();
                    SelectAct.gameObject.SetActive(true);
                    Dialog.gameObject.SetActive(false);
                    BackgroundMgr.instance.BackgroundChange();
                }
            }
            else
            {
                talkIndex = 0;
                //DataController.Instance.gameData.Gturn -= 1;
                SelectAct.gameObject.SetActive(true);
                Dialog.gameObject.SetActive(false);
                BackgroundMgr.instance.BackgroundChange();
                dialogList.Remove(0);
            }
            red.gameObject.SetActive(false);
            green.gameObject.SetActive(false);
            blue.gameObject.SetActive(false);
            purple.gameObject.SetActive(false);
            pink.gameObject.SetActive(false);
            yellow.gameObject.SetActive(false);
        }
        else
        {
            nameText.text = dialogList[0][talkIndex][0];
            dialogueText.text = dialogList[0][talkIndex][1];

            if (dialogList[0][talkIndex][0] == "가영")
            {
                red.gameObject.SetActive(true);
            }
            else if (dialogList[0][talkIndex][0] == "서준")
            {
                green.gameObject.SetActive(true);
            }
            else if (dialogList[0][talkIndex][0] == "테오")
            {
                blue.gameObject.SetActive(true);
            }
            else if (dialogList[0][talkIndex][0] == "유이")
            {
                purple.gameObject.SetActive(true);
            }
            else if (dialogList[0][talkIndex][0] == "하나")
            {
                pink.gameObject.SetActive(true);
            }
            else if (dialogList[0][talkIndex][0] == "시우")
            {
                yellow.gameObject.SetActive(true);
            }
        }

    }


    public void DictClear()
    {
        dialogList.Remove(0);
    }

    public void SkipText()
    {

        talkIndex++;

    }

    void Start()
    {

        talkIndex = 0;
        //Talk();

    }

    void Update()
    {

        //DialogStart();

    }

    public static void GenerateScript(int qnum)
    {
        Dictionary<int, string[]> talkData = new Dictionary<int, string[]>();
        int pick;

        if (qnum == 1)
        {
            KY.updateQ();

            do
            {
                pick = Random.Range(0, 6);

            } while (!(pick != DataController.Instance.gameData.loveWho[0] && pick != 0));

            if (KY.Talk(0) == false)
            {
                talkData.Add(0, new string[] { "가영", "가영 돌발대사1" });
                talkData.Add(1, new string[] { "가영", "가영 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "가영", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "가영", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "가영", "글쎄... 난 " + CharProfileforDialog.instance.chars[pick].personality[Random.Range(0, 2)]
                //+ " 사람과는 잘 맞지 않는 것 같아."});
                talkData.Add(3, new string[] { "가영", KY.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "가영", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "가영", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "가영", "글쎄... 난 " + CharProfileforDialog.instance.chars[pick].personality[Random.Range(0, 2)]
                //+ " 사람과는 잘 맞지 않는 것 같아."});
                talkData.Add(3, new string[] { "가영", KY.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "가영", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "가영", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "가영", "글쎄... 난 " + CharProfileforDialog.instance.chars[pick].personality[Random.Range(0, 2)]
                //+ " 사람과는 잘 맞지 않는 것 같아."});
                talkData.Add(3, new string[] { "가영", KY.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "가영", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "가영", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "가영", "글쎄... 난 " + CharProfileforDialog.instance.chars[pick].personality[Random.Range(0, 2)]
                //+ " 사람과는 잘 맞지 않는 것 같아."});
                talkData.Add(3, new string[] { "가영", KY.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
        }
        else if (qnum == 2)
        {
            KY.updateQ();

            do
            {
                pick = Random.Range(0, 6);


            } while (!(DataController.Instance.gameData.loveWho[pick] != 7 && pick != 0 && DataController.Instance.gameData.loveWho[pick] != 0));

            if (KY.Talk(1) == false)
            {
                talkData.Add(0, new string[] { "가영", "가영 돌발대사1" });
                talkData.Add(1, new string[] { "가영", "가영 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "가영", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "가영", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "가영", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "가영", KY.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "가영", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "가영", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "가영", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "가영", KY.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "가영", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "가영", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "가영", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "가영", KY.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "가영", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "가영", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "가영", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "가영", KY.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
        }
        else if (qnum == 3)
        {
            KY.updateQ();

            if (KY.Talk(2) == false)
            {
                talkData.Add(0, new string[] { "가영", "가영 돌발대사1" });
                talkData.Add(1, new string[] { "가영", "가영 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "가영", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "가영", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "가영", KY.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });


                dialogList.Add(0, talkData);

            }

            else if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "가영", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "가영", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "가영", KY.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });


                dialogList.Add(0, talkData);
            }

            else if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "가영", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "가영", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "가영", KY.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }

            else if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "가영", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "가영", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "가영", KY.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }

        }
        else if (qnum == 4)
        {
            SJ.updateQ();

            do
            {
                pick = Random.Range(0, 6);

            } while (!(pick != DataController.Instance.gameData.loveWho[1] && pick != 1));

            if (SJ.Talk(0) == false)
            {
                talkData.Add(0, new string[] { "서준", "서준 돌발대사1" });
                talkData.Add(1, new string[] { "서준", "서준 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "서준", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "서준", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                //    talkData.Add(3, new string[] { "서준", "글쎄... 난 " + CharProfileforDialog.instance.chars[pick].personality[Random.Range(0, 2)]
                //+ " 사람과는 잘 맞지 않는 것 같아."});
                talkData.Add(3, new string[] { "서준", SJ.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "서준", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "서준", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                //    talkData.Add(3, new string[] { "서준", "글쎄... 난 " + CharProfileforDialog.instance.chars[pick].personality[Random.Range(0, 2)]
                //+ " 사람과는 잘 맞지 않는 것 같아."});
                talkData.Add(3, new string[] { "서준", SJ.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "서준", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "서준", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                //    talkData.Add(3, new string[] { "서준", "글쎄... 난 " + CharProfileforDialog.instance.chars[pick].personality[Random.Range(0, 2)]
                //+ " 사람과는 잘 맞지 않는 것 같아."});
                talkData.Add(3, new string[] { "서준", SJ.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "서준", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "서준", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                //    talkData.Add(3, new string[] { "서준", "글쎄... 난 " + CharProfileforDialog.instance.chars[pick].personality[Random.Range(0, 2)]
                //+ " 사람과는 잘 맞지 않는 것 같아."});
                talkData.Add(3, new string[] { "서준", SJ.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
        }
        else if (qnum == 5)
        {
            SJ.updateQ();

            do
            {
                pick = Random.Range(0, 6);


            } while (!(DataController.Instance.gameData.loveWho[pick] != 7 && pick != 1 && DataController.Instance.gameData.loveWho[pick] != 1));

            if (SJ.Talk(1) == false)
            {
                talkData.Add(0, new string[] { "서준", "서준 돌발대사1" });
                talkData.Add(1, new string[] { "서준", "서준 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "서준", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "서준", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "서준", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "서준", SJ.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "서준", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "서준", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "서준", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "서준", SJ.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "서준", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "서준", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "서준", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "서준", SJ.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "서준", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "서준", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "서준", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "서준", SJ.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
        }
        else if (qnum == 6)
        {
            SJ.updateQ();

            if (SJ.Talk(2) == false)
            {
                talkData.Add(0, new string[] { "서준", "서준 돌발대사1" });
                talkData.Add(1, new string[] { "서준", "서준 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "서준", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "서준", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "서준", SJ.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }
            else if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "서준", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "서준", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "서준", SJ.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }

            else if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "서준", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "서준", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "서준", SJ.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }
            else if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "서준", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "서준", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "서준", SJ.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }
        }
        else if (qnum == 7)
        {
            TO.updateQ();

            do
            {
                pick = Random.Range(0, 6);

            } while (!(pick != DataController.Instance.gameData.loveWho[2] && pick != 2));

            if (TO.isTalk() == false)
            {

                talkData.Add(0, new string[] { "테오", "테오 돌발대사1" });
                talkData.Add(1, new string[] { "테오", "테오 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);

                return;
            }

            if (TO.isTalk() == false)
            {

                talkData.Add(0, new string[] { "테오", "테오 돌발대사1" });
                talkData.Add(1, new string[] { "테오", "테오 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);

                return;
            }


            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "테오", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "테오", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "테오", TO.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "테오", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "테오", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "테오", TO.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "테오", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "테오", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "테오", TO.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "테오", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "테오", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "테오", TO.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
        }
        else if (qnum == 8)
        {
            TO.updateQ();

            do
            {
                pick = Random.Range(0, 6);


            } while (!(DataController.Instance.gameData.loveWho[pick] != 7 && pick != 1 && DataController.Instance.gameData.loveWho[pick] != 2));

            if (TO.isTalk() == false)
            {

                talkData.Add(0, new string[] { "테오", "테오 돌발대사1" });
                talkData.Add(1, new string[] { "테오", "테오 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);

                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "테오", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "테오", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "테오", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "테오", TO.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "테오", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "테오", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "테오", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "테오", TO.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "테오", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "테오", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "테오", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "테오", TO.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "테오", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "테오", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "테오", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "테오", TO.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
        }
        else if (qnum == 9)
        {
            TO.updateQ();

            if (TO.isTalk() == false)
            {

                talkData.Add(0, new string[] { "테오", "테오 돌발대사1" });
                talkData.Add(1, new string[] { "테오", "테오 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);

                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "테오", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "테오", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "테오", TO.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }
            else if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "테오", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "테오", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "테오", TO.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }

            else if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "테오", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "테오", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "테오", TO.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }
            else if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "테오", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "테오", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "테오", TO.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }
        }
        else if (qnum == 10)
        {
            YI.updateQ();

            do
            {
                pick = Random.Range(0, 6);

            } while (!(pick != DataController.Instance.gameData.loveWho[3] && pick != 3));

            if (YI.isEven() == true)
            {

                talkData.Add(0, new string[] { "유이", "유이 돌발대사1" });
                talkData.Add(1, new string[] { "유이", "유이 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);

                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "유이", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "유이", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "유이", YI.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "유이", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "유이", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "유이", YI.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "유이", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "유이", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "유이", YI.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "유이", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "유이", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "유이", YI.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
        }
        else if (qnum == 11)
        {
            YI.updateQ();

            do
            {
                pick = Random.Range(0, 6);


            } while (!(DataController.Instance.gameData.loveWho[pick] != 7 && pick != 3 && DataController.Instance.gameData.loveWho[pick] != 3));

            if (YI.isEven() == true)
            {

                talkData.Add(0, new string[] { "유이", "유이 돌발대사1" });
                talkData.Add(1, new string[] { "유이", "유이 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);

                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "유이", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "유이", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "유이", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "유이", YI.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "유이", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "유이", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "유이", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "유이", YI.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "유이", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "유이", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "유이", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "유이", YI.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "유이", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "유이", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "유이", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "유이", YI.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
        }
        else if (qnum == 12)
        {
            YI.updateQ();

            if (YI.isEven() == true)
            {

                talkData.Add(0, new string[] { "유이", "유이 돌발대사1" });
                talkData.Add(1, new string[] { "유이", "유이 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);

                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "유이", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "유이", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "유이", YI.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }
            else if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "유이", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "유이", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "유이", YI.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }

            else if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "유이", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "유이", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "유이", YI.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }
            else if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "유이", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "유이", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "유이", YI.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }

        }
        else if (qnum == 13)
        {
            HN.updateQ();

            do
            {
                pick = Random.Range(0, 6);

            } while (!(pick != DataController.Instance.gameData.loveWho[4] && pick != 4));

            if (HN.isTalk() == false)
            {

                talkData.Add(0, new string[] { "하나", "하나 돌발대사1" });
                talkData.Add(1, new string[] { "하나", "하나 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);

                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "하나", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "하나", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "하나", HN.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "하나", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "하나", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "하나", HN.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "하나", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "하나", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "하나", HN.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "하나", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "하나", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "하나", HN.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
        }
        else if (qnum == 14)
        {
            HN.updateQ();

            do
            {
                pick = Random.Range(0, 6);


            } while (!(DataController.Instance.gameData.loveWho[pick] != 7 && pick != 4 && DataController.Instance.gameData.loveWho[pick] != 4));

            if (HN.isTalk() == false)
            {

                talkData.Add(0, new string[] { "하나", "하나 돌발대사1" });
                talkData.Add(1, new string[] { "하나", "하나 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);

                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "하나", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "하나", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "하나", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "하나", HN.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "하나", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "하나", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "하나", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "하나", HN.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "하나", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "하나", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "하나", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "하나", HN.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "하나", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "하나", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "하나", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "하나", HN.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
        }
        else if (qnum == 15)
        {
            HN.updateQ();

            if (HN.isTalk() == false)
            {

                talkData.Add(0, new string[] { "하나", "하나 돌발대사1" });
                talkData.Add(1, new string[] { "하나", "하나 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);

                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "하나", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "하나", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "하나", HN.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }
            else if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "하나", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "하나", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "하나", HN.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }

            else if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "하나", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "하나", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "하나", HN.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }
            else if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "하나", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "하나", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "하나", HN.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }
        }
        else if (qnum == 16)
        {
            JH.updateQ();

            do
            {
                pick = Random.Range(0, 6);

            } while (!(pick != DataController.Instance.gameData.loveWho[5] && pick != 5));

            if (JH.isOdd() == true)
            {

                talkData.Add(0, new string[] { "시우", "지후 돌발대사1" });
                talkData.Add(1, new string[] { "지후", "지후 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);

                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "지후", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "지후", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "지후", JH.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "지후", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "지후", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "지후", JH.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "지후", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "지후", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "지후", JH.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);

            }
            else if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "지후", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "지후", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(좋아하지 않는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "지후", JH.TMI() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
        }
        else if (qnum == 17)
        {
            JH.updateQ();

            do
            {
                pick = Random.Range(0, 6);


            } while (!(DataController.Instance.gameData.loveWho[pick] != 7 && pick != 1 && DataController.Instance.gameData.loveWho[pick] != 5));

            if (JH.isOdd() == true)
            {

                talkData.Add(0, new string[] { "시우", "지후 돌발대사1" });
                talkData.Add(1, new string[] { "지후", "지후 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);

                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "지후", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "지후", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "지후", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "지후", JH.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "지후", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "지후", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "지후", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "지후", JH.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "지후", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "지후", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "시우", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "지후", JH.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
            if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "지후", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "지후", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(수상해보이는 사람들에 대해 물어보았다.)" });
                //talkData.Add(3, new string[] { "시우", CharProfileforDialog.instance.chars[pick].name + "랑 " +
                //CharProfileforDialog.instance.chars[DataController.Instance.gameData.loveWho[pick]].name + " 둘이 많이 친해보이지 않아?"});
                talkData.Add(3, new string[] { "지후", JH.Ans5() });
                talkData.Add(4, new string[] { "%END%", "" });

                dialogList.Add(0, talkData);
            }
        }
        else if (qnum == 18)
        {
            JH.updateQ();

            if (JH.isOdd() == true)
            {

                talkData.Add(0, new string[] { "시우", "지후 돌발대사1" });
                talkData.Add(1, new string[] { "지후", "지후 돌발대사2" });

                talkData.Add(2, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);

                return;
            }

            if (DataController.Instance.gameData.Gturn == 4)
            {
                talkData.Add(0, new string[] { "지후", "오늘도 좋은 아침!" });
                talkData.Add(1, new string[] { "지후", "늦겠다, 얼른 가자." });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "지후", JH.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }
            else if (DataController.Instance.gameData.Gturn == 3)
            {
                talkData.Add(0, new string[] { "지후", "아 배고파~ 오늘 급식 뭐지?" });
                talkData.Add(1, new string[] { "지후", "나랑 매점 갔다올래?" });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "지후", JH.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }

            else if (DataController.Instance.gameData.Gturn == 2)
            {
                talkData.Add(0, new string[] { "지후", "내일 봐~ 어? 나한테 물어볼 거 있다고?" });
                talkData.Add(1, new string[] { "지후", "나 바쁜데... 빨리 물어봐." });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "지후", JH.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }
            else if (DataController.Instance.gameData.Gturn == 1)
            {
                talkData.Add(0, new string[] { "지후", "너 아직도 집에 안 갔어? 나랑 같이 가자!" });
                talkData.Add(1, new string[] { "지후", "야자 하기 싫다... " });
                talkData.Add(2, new string[] { "", "(좋아하는 사람에 대해 물어보았다.)" });
                talkData.Add(3, new string[] { "지후", JH.myLove() });
                talkData.Add(4, new string[] { "%END%", "" });
                dialogList.Add(0, talkData);
            }
        }

    }




}

