using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Language_menu : MonoBehaviour
{
    public TextMeshProUGUI [] text = new TextMeshProUGUI[8];
    public Sprite[] Flag = new Sprite[3];
    public GameObject flag;
    int i;
    // 0 - Eng
    // 1 - Ukr
    // 2 - Rus
    void Start()
    {
        if (!PlayerPrefs.HasKey("Language"))
        {
            PlayerPrefs.SetInt("Language", 0);

        }
        if (PlayerPrefs.GetInt("Language") == 0) 
        {
            text[0].text = "Level " + System.Convert.ToString(PlayerPrefs.GetInt("LVL"));
            text[1].text = "Play";
            text[2].text = "Levels";
            text[3].text = "Music";
            text[4].text = "Language";
            text[5].text = "Exit";
            text[6].text = "Exit?";
            text[7].text = "Back";
            flag.GetComponent<Image>().sprite= Flag[0];
            
        }
        if (PlayerPrefs.GetInt("Language") == 1)
        {
            text[0].text = "Рівень " + System.Convert.ToString(PlayerPrefs.GetInt("LVL"));
            text[1].text = "Грати";
            text[2].text = "Рівні";
            text[3].text = "Музика";
            text[4].text = "Мова";
            text[5].text = "Вихід";
            text[6].text = "Вийти?";
            text[7].text = "Назад";
            flag.GetComponent<Image>().sprite = Flag[1];

        }
        if (PlayerPrefs.GetInt("Language") == 2)
        {
            text[0].text = "Уровень " + System.Convert.ToString(PlayerPrefs.GetInt("LVL"));
            text[1].text = "Играть";
            text[2].text = "Уровни";
            text[3].text = "Музыка";
            text[4].text = "Язык";
            text[5].text = "Выход";
            text[6].text = "Выйти?";
            text[7].text = "Назад";
            flag.GetComponent<Image>().sprite = Flag[2];

        }
    }

    public void Select_level() 
    {
        i = PlayerPrefs.GetInt("Language");
        i++;
        if (i >= 3) { i = 0; }
        PlayerPrefs.SetInt("Language", i);
        PlayerPrefs.Save();

        if (PlayerPrefs.GetInt("Language") == 0)
        {
            text[0].text = "Level " + System.Convert.ToString(PlayerPrefs.GetInt("LVL"));
            text[1].text = "Play";
            text[2].text = "Levels";
            text[3].text = "Music";
            text[4].text = "Language";
            text[5].text = "Exit";
            text[6].text = "Exit?";
            text[7].text = "Back";
            flag.GetComponent<Image>().sprite = Flag[0];
        }
        if (PlayerPrefs.GetInt("Language") == 1)
        {
            text[0].text = "Рівень " + System.Convert.ToString(PlayerPrefs.GetInt("LVL"));
            text[1].text = "Грати";
            text[2].text = "Рівні";
            text[3].text = "Музика";
            text[4].text = "Мова";
            text[5].text = "Вихід";
            text[6].text = "Вийти?";
            text[7].text = "Назад";
            flag.GetComponent<Image>().sprite = Flag[1];
        }
        if (PlayerPrefs.GetInt("Language") == 2)
        {
            text[0].text = "Уровень " + System.Convert.ToString(PlayerPrefs.GetInt("LVL"));
            text[1].text = "Играть";
            text[2].text = "Уровни";
            text[3].text = "Музыка";
            text[4].text = "Язык";
            text[5].text = "Выход";
            text[6].text = "Выйти?";
            text[7].text = "Назад";
            flag.GetComponent<Image>().sprite = Flag[2];
        }
    }
}
