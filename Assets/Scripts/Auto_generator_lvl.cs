using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Auto_generator_lvl : MonoBehaviour
{
    public GameObject[] Bottle;
    public int Count_Bottle;
    public int Red;         //1
    public int Bluy;        //2
    public int Green;       //3
    public int Yellow;      //4
    public int All_color;

    public Sprite[] Color = new Sprite[4];
    int color;

    void Start()
    {
        All_color = Count_Bottle * 4;
        Red = Count_Bottle;
        Bluy= Count_Bottle;
        Green= Count_Bottle;
        Yellow= Count_Bottle;
        for (int i = 0; i < Count_Bottle; i++) 
        {
            if (Red <= 0 && Bluy <= 0 && Green <= 0 && Yellow <= 0) { break; }
            for (int j = 1; j < 5; j++)
            {
            Ret:
                if (Red <= 0 && Bluy <= 0 && Green <= 0 && Yellow <= 0) {break;}
                color = Random.Range(1, 5);
                if (color == 1 && Red != 0) 
                {
                    if (j == 4 && Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite == Bottle[i].transform.Find("1").GetComponent<Image>().sprite && Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite == Bottle[i].transform.Find("2").GetComponent<Image>().sprite && Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite == Bottle[i].transform.Find("3").GetComponent<Image>().sprite ) 
                    {
                        goto Ret;
                    }
                    Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite = Color[0];
                    Red--; 
                }
                else if (color == 1 && Red == 0) { goto Ret; }

                if (color == 2 && Bluy != 0) 
                {
                    if (j == 4 && Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite == Bottle[i].transform.Find("1").GetComponent<Image>().sprite && Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite == Bottle[i].transform.Find("2").GetComponent<Image>().sprite && Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite == Bottle[i].transform.Find("3").GetComponent<Image>().sprite)
                    {
                        goto Ret;
                    }
                    Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite = Color[1]; 
                    Bluy--; 
                }
                else if (color == 2 && Bluy == 0) { goto Ret; }

                if (color == 3 && Green != 0)
                {
                    if (j == 4 && Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite == Bottle[i].transform.Find("1").GetComponent<Image>().sprite && Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite == Bottle[i].transform.Find("2").GetComponent<Image>().sprite && Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite == Bottle[i].transform.Find("3").GetComponent<Image>().sprite)
                    {
                        goto Ret;
                    }
                    Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite = Color[2]; 
                    Green--;
                }
                else if (color == 3 && Green == 0) { goto Ret; }

                if (color == 4 && Yellow != 0) 
                {
                    if (j == 4 && Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite == Bottle[i].transform.Find("1").GetComponent<Image>().sprite && Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite == Bottle[i].transform.Find("2").GetComponent<Image>().sprite && Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite == Bottle[i].transform.Find("3").GetComponent<Image>().sprite)
                    {
                        goto Ret;
                    }
                    Bottle[i].transform.Find(System.Convert.ToString(j)).GetComponent<Image>().sprite = Color[3]; 
                    Yellow--;
                }
                else if (color == 4 && Yellow == 0) { goto Ret; }

            }
        }

    }

  
}
