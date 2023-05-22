using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//red, green, blue, ourple, pink, yellow
public static class Extensions
{
    public static T[] RemoveAt<T>(this T[] source, int index)
    {
        var dest = new List<T>(source);
        dest.RemoveAt(index);
        return dest.ToArray();
    }
}

public class SetLoveStat : MonoBehaviour
{
    public static SetLoveStat  instance;

    public static int[] lovewho;
    public static int[] redCanLove;
    public static int[] greenCanLove;
    public static int[] blueCanLove;
    public static int[] purpleCanLove;
    public static int[] pinkCanLove;
    public static int[] yellowCanLove;
    public static int noLove;

    public static int[] CharCan;

    public void Start()
    {
        
        if(DataController.Instance.gameData.GPlayedBefore == true || DataController.Instance.gameData.WPlayedBefore == true)
        {
            return;
        }
        
        {
           SetRole();
        }
        
        
    }
    
    public void SetRole() 
    {

        string[] Roles = new string[]{"A", "B", "C", "D", "E", "F"};
        CharCan = new int[] {1, 2, 3, 4, 5, 6};


        int A_char = Random.Range(0,6);
        RoleManager.A = CharCan[A_char];
        CharCan = CharCan.RemoveAt(A_char);

        int B_char = Random.Range(0,5);
        RoleManager.B = CharCan[B_char];
        CharCan = CharCan.RemoveAt(B_char);

        int C_char = Random.Range(0,4);
        RoleManager.C = CharCan[C_char];
        CharCan = CharCan.RemoveAt(C_char);

        int D_char = Random.Range(0,3);
        RoleManager.D = CharCan[D_char];
        CharCan = CharCan.RemoveAt(D_char);

        int E_char = Random.Range(0,2);
        RoleManager.E = CharCan[E_char];
        CharCan = CharCan.RemoveAt(E_char);

        RoleManager.F = CharCan[0];

        RoleManager.set();

        print("A : " + RoleManager.A);
        print("B : " + RoleManager.B);
        print("C : " + RoleManager.C);
        print("D : " + RoleManager.D);
        print("E : " + RoleManager.E);
        print("F : " + RoleManager.F);

        

    }
    
    
}