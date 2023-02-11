using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Language_lvl : MonoBehaviour
{
    public TextMeshProUGUI[] text = new TextMeshProUGUI[4];

    void Awake()
    {
        if (PlayerPrefs.GetInt("Language") == 0)
        {
            text[0].text = "Victory";
            text[1].text = "Exit?";
            text[2].text = "Next";
            text[3].text = "Menu";
        }
        if (PlayerPrefs.GetInt("Language") == 1)
        {
            text[0].text = "Перемога";
            text[1].text = "Вийти?";
            text[2].text = "Продовжити";
            text[3].text = "Меню";
        }
        if (PlayerPrefs.GetInt("Language") == 2)
        {
            text[0].text = "Победа";
            text[1].text = "Выйти?";
            text[2].text = "Продолжить";
            text[3].text = "Меню";
        }
    }

    
}
