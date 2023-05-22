using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneManager : MonoBehaviour
{
    public static CutSceneManager instance;
    public GameObject cutScenePanel;
    public Image cutSceneImage;
    public Sprite[] cutScenes;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject);
    }

    public void CutSceneOff()
    {
        cutScenePanel.gameObject.SetActive(false);
    }

    public void CutSceneChange()
    {
        if (DataController.Instance.gameData.CutSceneQueue.Count != 0)
        {
            int Qout = DataController.Instance.gameData.CutSceneQueue.Dequeue();

            if (Qout == 0)
            {
                cutSceneImage.sprite = cutScenes[0];
            }

            else if (Qout == 1)
            {
                cutSceneImage.sprite = cutScenes[1];
            }

            else if (Qout == 2)
            {
                cutSceneImage.sprite = cutScenes[2];
            }

            else if (Qout == 3)
            {
                cutSceneImage.sprite = cutScenes[3];
            }

            else if (Qout == 4)
            {
                cutSceneImage.sprite = cutScenes[4];
            }

            else if (Qout == 5)
            {
                cutSceneImage.sprite = cutScenes[5];
            }

            cutScenePanel.gameObject.SetActive(true);

        }
    }
}
