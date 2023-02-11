using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stop_anim : MonoBehaviour
{
    public static bool Stop;
    public static bool Disable;
    public static bool Finish;

    public RuntimeAnimatorController clip_first;
    public void Start()
    {
        clip_first = gameObject.GetComponent<Animator>().runtimeAnimatorController;
        if (gameObject.name == "Line_left" || gameObject.name == "Line_right") { GetComponent<Animator>().enabled = false; }
    }
    public void Anim() { if (Stop == true) { gameObject.GetComponent<Animator>().enabled = false; Count_active_anim.Active = false; } }
    public void Disabled() { if (Disable == true) { gameObject.GetComponent<Animator>().enabled = false; Count_active_anim.Active = false; GetComponent<Animator>().runtimeAnimatorController = Count_active_anim.clip_first; Count_active_anim.Return_move = false; } }

    public void Return() { Count_active_anim.Start_move = false; Count_active_anim.Return_move = true; }
    public void Stop_zoom() { gameObject.GetComponent<Animator>().enabled = false; GetComponent<Image>().enabled = false; }
    public void Stop_zoom_() 
    { 
        gameObject.GetComponent<Animator>().enabled = false;  
        if (gameObject.GetComponentInParent<Select_>().Finish_bottle == true) 
        {
            gameObject.GetComponentInParent<Select_>().Particle[0].Play();
            gameObject.GetComponentInParent<Select_>().Particle[1].Play();
            gameObject.GetComponentInParent<Select_>().Korok.SetActive(true);
            GameObject.Find("Number_lvl").GetComponent<AudioSource>().Play();
        }
        if (Count_active_anim.Count_Finish_Bottle >= Count_active_anim.All_Bottle_in_lvl_to_finish)
        {
            Finish = true;
        }
    }
    public void Retunt_first_anim() { gameObject.GetComponent<Animator>().runtimeAnimatorController = clip_first; gameObject.GetComponent<Animator>().enabled = false; }

    public void Start_Line() 
    {
        if (Count_active_anim.Current_Bottle.transform.Find("Line_left"))
        {
            if (Count_active_anim.Current_color == "Bluy")
            {
                gameObject.transform.Find("Line_left").GetComponent<Image>().sprite = Select_.color2[0];
            }
            if (Count_active_anim.Current_color == "Red")
            {
                gameObject.transform.Find("Line_left").GetComponent<Image>().sprite = Select_.color2[1];

            }
            if (Count_active_anim.Current_color == "Green")
            {
                gameObject.transform.Find("Line_left").GetComponent<Image>().sprite = Select_.color2[2];
            }
            if (Count_active_anim.Current_color == "Yellow")
            {
                gameObject.transform.Find("Line_left").GetComponent<Image>().sprite = Select_.color2[3];
            }
            gameObject.transform.Find("Line_left").GetComponent<Animator>().enabled = true;
        }
        if (Count_active_anim.Current_Bottle.transform.Find("Line_right"))
        {
            if (Count_active_anim.Current_color == "Bluy")
            {
                gameObject.transform.Find("Line_right").GetComponent<Image>().sprite = Select_.color2[0];
            }
            if (Count_active_anim.Current_color == "Red")
            {
                gameObject.transform.Find("Line_right").GetComponent<Image>().sprite = Select_.color2[1];

            }
            if (Count_active_anim.Current_color == "Green")
            {
                gameObject.transform.Find("Line_right").GetComponent<Image>().sprite = Select_.color2[2];
            }
            if (Count_active_anim.Current_color == "Yellow")
            {
                gameObject.transform.Find("Line_right").GetComponent<Image>().sprite = Select_.color2[3];
            }
            gameObject.transform.Find("Line_right").GetComponent<Animator>().enabled = true;
        }
    }
    public void Stop_Line() { gameObject.GetComponent<Image>().fillAmount=0;  gameObject.GetComponent<Animator>().enabled = false; }
    public void Stop_Anim_Number_lvl() { gameObject.GetComponent<Animator>().enabled = false; }
    public void Start_Sound_Water() { GameObject.Find("Canvas").GetComponent<AudioSource>().Play(); }

}
