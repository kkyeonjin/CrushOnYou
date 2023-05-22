using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class RoleManager : MonoBehaviour
{
    static RoleManager _instance = null;

    public static RoleManager Instance()
      {
          return _instance;
      }
	  
    void Awake () 
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


    //역할 초기화
    public static int A;
    public static int B;
    public static int C;
    public static int D;
    public static int E;
    public static int F;


    //캐릭터 세팅
    public static void set() {
        
        switch(A)
        {
            case 1 :
                DataController.Instance.gameData.roles[0] = "A";
                DataController.Instance.gameData.loveWho[0] = B;
                break;
            
            case 2 :
                DataController.Instance.gameData.roles[1] = "A";
                DataController.Instance.gameData.loveWho[1] = B;
                break;
            
            case 3 :
                DataController.Instance.gameData.roles[2] = "A";
                DataController.Instance.gameData.loveWho[2] = B;
                break;
            
            case 4 :
                DataController.Instance.gameData.roles[3] = "A";
                DataController.Instance.gameData.loveWho[3] = B;
                break;

            case 5 :
                DataController.Instance.gameData.roles[4] = "A";
                DataController.Instance.gameData.loveWho[4] = B;
                break;

            default :
                DataController.Instance.gameData.roles[5] = "A";
                DataController.Instance.gameData.loveWho[5] = B;
                break;
        }

         switch(B)
        {
            case 1 :
                DataController.Instance.gameData.roles[0] = "B";
                DataController.Instance.gameData.loveWho[0] = A;
                break;
            
            case 2 :
                DataController.Instance.gameData.roles[1] = "B";
                DataController.Instance.gameData.loveWho[1] = A;
                break;
            
            case 3 :
                DataController.Instance.gameData.roles[2] = "B";
                DataController.Instance.gameData.loveWho[2] = A;
                break;
            
            case 4 :
                DataController.Instance.gameData.roles[3] = "B";
                DataController.Instance.gameData.loveWho[3] = A;
                break;

            case 5 :
                DataController.Instance.gameData.roles[4] = "B";
                DataController.Instance.gameData.loveWho[4] = A;
                break;

            default :
                DataController.Instance.gameData.roles[5] = "B";
                DataController.Instance.gameData.loveWho[5] = A;
                break;
        }

         switch(C)
        {
            case 1 :
                DataController.Instance.gameData.roles[0] = "C";
                DataController.Instance.gameData.loveWho[0] = B;
                break;
            
            case 2 :
                DataController.Instance.gameData.roles[1] = "C";
                DataController.Instance.gameData.loveWho[1] = B;
                break;
            
            case 3 :
                DataController.Instance.gameData.roles[2] = "C";
                DataController.Instance.gameData.loveWho[2] = B;
                break;
            
            case 4 :
                DataController.Instance.gameData.roles[3] = "C";
                DataController.Instance.gameData.loveWho[3] = B;
                break;

            case 5 :
                DataController.Instance.gameData.roles[4] = "C";
                DataController.Instance.gameData.loveWho[4] = B;
                break;

            default :
                DataController.Instance.gameData.roles[5] = "C";
                DataController.Instance.gameData.loveWho[5] = B;
                break;
        }

        switch(D)
        {
            case 1 :
                DataController.Instance.gameData.roles[0] = "D";
                DataController.Instance.gameData.loveWho[0] = C;
                break;
            
            case 2 :
                DataController.Instance.gameData.roles[1] = "D";
                DataController.Instance.gameData.loveWho[1] = C;
                break;
            
            case 3 :
                DataController.Instance.gameData.roles[2] = "D";
                DataController.Instance.gameData.loveWho[2] = C;
                break;
            
            case 4 :
                DataController.Instance.gameData.roles[3] = "D";
                DataController.Instance.gameData.loveWho[3] = C;
                break;

            case 5 :
                DataController.Instance.gameData.roles[4] = "D";
                DataController.Instance.gameData.loveWho[4] = C;
                break;

            default :
                DataController.Instance.gameData.roles[5] = "D";
                DataController.Instance.gameData.loveWho[5] = C;
                break;
        }

        switch(E)
        {
            case 1 :
                DataController.Instance.gameData.roles[0] = "E";
                DataController.Instance.gameData.loveWho[0] = C;
                break;
            
            case 2 :
                DataController.Instance.gameData.roles[1] = "E";
                DataController.Instance.gameData.loveWho[1] = C;
                break;
            
            case 3 :
                DataController.Instance.gameData.roles[2] = "E";
                DataController.Instance.gameData.loveWho[2] = C;
                break;
            
            case 4 :
                DataController.Instance.gameData.roles[3] = "E";
                DataController.Instance.gameData.loveWho[3] = C;
                break;

            case 5 :
                DataController.Instance.gameData.roles[4] = "E";
                DataController.Instance.gameData.loveWho[4] = C;
                break;

            default :
                DataController.Instance.gameData.roles[5] = "E";
                DataController.Instance.gameData.loveWho[5] = C;
                break;
        }

        switch(F)
        {
            case 1 :
                DataController.Instance.gameData.roles[0] = "F";
                DataController.Instance.gameData.loveWho[0] = D;
                break;
            
            case 2 :
                DataController.Instance.gameData.roles[1] = "F";
                DataController.Instance.gameData.loveWho[1] = D;
                break;
            
            case 3 :
                DataController.Instance.gameData.roles[2] = "F";
                DataController.Instance.gameData.loveWho[2] = D;
                break;
            
            case 4 :
                DataController.Instance.gameData.roles[3] = "F";
                DataController.Instance.gameData.loveWho[3] = D;
                break;

            case 5 :
                DataController.Instance.gameData.roles[4] = "F";
                DataController.Instance.gameData.loveWho[4] = D;
                break;

            default :
                DataController.Instance.gameData.roles[5] = "F";
                DataController.Instance.gameData.loveWho[5] = D;
                break;
        }
        
    }


}
