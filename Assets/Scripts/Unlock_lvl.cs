using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock_lvl : MonoBehaviour
{
    public Sprite[] sprite_lvl = new Sprite[2];
    int i, j;
    void Start()
    {
        j = PlayerPrefs.GetInt("LVL");
        i = System.Convert.ToInt32(gameObject.name);
        if (i < j) { GetComponent<Image>().sprite = sprite_lvl[0]; GetComponent<Button>().enabled = true; } // розблокований рівень
        if (i == j) { GetComponent<Image>().sprite = sprite_lvl[1]; GetComponent<Button>().enabled = true; } // наступний рівень 

    }
    public void Start_lvl() 
    {
        if (i <= j) { Application.LoadLevel(i); }
    }
}
