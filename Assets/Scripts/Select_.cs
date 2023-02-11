using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Select_ : MonoBehaviour
{
    public Vector3 start_pos;
    public GameObject[] LVL_ridunu = new GameObject[4];
    public RuntimeAnimatorController Eror_anim;
    public Sprite Red;
    public Sprite Bluy;
    public Sprite Green;
    public Sprite Yellow;
    public static Sprite[] color2 = new Sprite[4];
    public string[] color = new string[4];
    //0- синій
    //1- червоний
    //2- зелений
    //3- жовтий
    
    public int CountImage;
    public int CountImage2;
    public bool Finish_bottle;
    public ParticleSystem[] Particle=new ParticleSystem[2];
    public GameObject Korok;
    private void Start()
    {
        color2[0] = Bluy;
        color2[1] = Red;
        color2[2] = Green;
        color2[3] = Yellow;
        Finish_bottle = false;
        LVL_ridunu[0] = gameObject.transform.Find("1").gameObject;
        LVL_ridunu[1] = gameObject.transform.Find("2").gameObject;
        LVL_ridunu[2] = gameObject.transform.Find("3").gameObject;
        LVL_ridunu[3] = gameObject.transform.Find("4").gameObject;
        start_pos = transform.position;

        for (int i = 0; i < 4; i++)
        {
            if (LVL_ridunu[i].GetComponent<Image>().sprite.name == "Bluy") { color[i] = "Bluy"; }
            if (LVL_ridunu[i].GetComponent<Image>().sprite.name == "Red") { color[i] = "Red"; }
            if (LVL_ridunu[i].GetComponent<Image>().sprite.name == "Green") { color[i] = "Green"; }
            if (LVL_ridunu[i].GetComponent<Image>().sprite.name == "Yellow") { color[i] = "Yellow"; }

            if (LVL_ridunu[i].GetComponent<Image>().enabled == true) { Count_active_anim.All_Color++; }
        }
        if (LVL_ridunu[0].GetComponent<Image>().enabled)
        {
            Count_active_anim.Current_color = color[0];
        }
        else if (LVL_ridunu[1].GetComponent<Image>().enabled)
        {
            Count_active_anim.Current_color = color[1];
        }
        else if (LVL_ridunu[2].GetComponent<Image>().enabled)
        {
            Count_active_anim.Current_color = color[2];
        }
        else if (LVL_ridunu[3].GetComponent<Image>().enabled)
        {
            Count_active_anim.Current_color = color[3];
        }

        if (LVL_ridunu[0].GetComponent<Image>().enabled == true && LVL_ridunu[1].GetComponent<Image>().enabled == true && LVL_ridunu[2].GetComponent<Image>().enabled == true && LVL_ridunu[3].GetComponent<Image>().enabled == true && color[0] == color[1] && color[0] == color[2] && color[0] == color[3])
        {
            Particle[0].Play();
            Particle[1].Play();
            Korok.SetActive(true);
            Finish_bottle = true;
            Count_active_anim.Count_Finish_Bottle++;
        }

    }
    public void Stop_Start_anim() 
    {
        if (Count_active_anim.Active == false)
        {
            if (Finish_bottle == false)
            {

                if (LVL_ridunu[0].GetComponent<Image>().enabled == false && LVL_ridunu[1].GetComponent<Image>().enabled == false && LVL_ridunu[2].GetComponent<Image>().enabled == false && LVL_ridunu[3].GetComponent<Image>().enabled == false)
                {
                    gameObject.GetComponent<Animator>().runtimeAnimatorController = Eror_anim;
                    gameObject.GetComponent<Animator>().enabled = true;
                }
                else
                {
                    if (gameObject.GetComponent<Animator>().enabled == false)
                    {
                        Count_active_anim.Current_Bottle = gameObject;
                        Stop_anim.Stop = false;
                        Count_active_anim.Active = true;
                        gameObject.GetComponent<Animator>().enabled = true;
                        Count_active_anim.clip_first = GetComponent<Animator>().runtimeAnimatorController;
                        Count_active_anim.Start_pos = transform.position;



                        for (int i = 0; i < 4; i++)
                        {
                            if (LVL_ridunu[i].GetComponent<Image>().sprite.name == "Bluy") { color[i] = "Bluy"; }
                            if (LVL_ridunu[i].GetComponent<Image>().sprite.name == "Red") { color[i] = "Red"; }
                            if (LVL_ridunu[i].GetComponent<Image>().sprite.name == "Green") { color[i] = "Green"; }
                            if (LVL_ridunu[i].GetComponent<Image>().sprite.name == "Yellow") { color[i] = "Yellow"; }
                        }

                        if (LVL_ridunu[0].GetComponent<Image>().enabled)
                        {
                            Count_active_anim.Current_color = color[0];
                        }
                        else if (LVL_ridunu[1].GetComponent<Image>().enabled)
                        {
                            Count_active_anim.Current_color = color[1];
                        }
                        else if (LVL_ridunu[2].GetComponent<Image>().enabled)
                        {
                            Count_active_anim.Current_color = color[2];
                        }
                        else if (LVL_ridunu[3].GetComponent<Image>().enabled)
                        {
                            Count_active_anim.Current_color = color[3];
                        }

                    }
                }
            }
            else
            {
                gameObject.GetComponent<Animator>().runtimeAnimatorController = Eror_anim;
                gameObject.GetComponent<Animator>().enabled = true;
            }
        }
        else
        {
            if (gameObject.GetComponent<Animator>().enabled == true)
            {
                Stop_anim.Stop = true;
            }
        }


        // Починається анімація переливу.
        if (gameObject.GetComponent<Animator>().enabled == false && Count_active_anim.Active == true && Count_active_anim.Return_move == false && Count_active_anim.Start_move == false)
        {
            CountImage = 0;
            for (int i = 0; i < 4; i++)
            {
                if (LVL_ridunu[i].GetComponent<Image>().enabled == true) { CountImage++; }
            }
            if (CountImage < 4)
            {
                //Якщо бутилка не повна, здійснити перелив 
                Count_active_anim.Finish_pos = gameObject.transform.position;
                Count_active_anim.Start_move = true;

                
                if (Count_active_anim.Current_color == "Bluy") 
                { 
                    if (LVL_ridunu[3 - CountImage].name == "1") 
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Bluy;
                    }
                    if (LVL_ridunu[3 - CountImage].name == "2")
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Bluy;
                    }
                    if (LVL_ridunu[3 - CountImage].name == "3")
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Bluy;
                    }
                    if (LVL_ridunu[3 - CountImage].name == "4")
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Bluy;
                    }
                }
                if (Count_active_anim.Current_color == "Red")
                {
                    if (LVL_ridunu[3 - CountImage].name == "1")
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Red;
                    }
                    if (LVL_ridunu[3 - CountImage].name == "2")
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Red;
                    }
                    if (LVL_ridunu[3 - CountImage].name == "3")
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Red;
                    }
                    if (LVL_ridunu[3 - CountImage].name == "4")
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Red;
                    }
                }
                if (Count_active_anim.Current_color == "Green")
                {
                    if (LVL_ridunu[3 - CountImage].name == "1")
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Green;
                    }
                    if (LVL_ridunu[3 - CountImage].name == "2")
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Green;
                    }
                    if (LVL_ridunu[3 - CountImage].name == "3")
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Green;
                    }
                    if (LVL_ridunu[3 - CountImage].name == "4")
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Green;
                    }
                }
                if (Count_active_anim.Current_color == "Yellow") 
                {
                    if (LVL_ridunu[3 - CountImage].name == "1")
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Yellow;
                    }
                    if (LVL_ridunu[3 - CountImage].name == "2")
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Yellow;
                    }
                    if (LVL_ridunu[3 - CountImage].name == "3")
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Yellow;
                    }
                    if (LVL_ridunu[3 - CountImage].name == "4")
                    {
                        LVL_ridunu[3 - CountImage].GetComponent<Image>().sprite = Yellow;
                    }
                }
                
                for (int i = 3; i >= 0; i--)
                {
                    if (Count_active_anim.Current_Bottle.GetComponent<Select_>().LVL_ridunu[i].GetComponent<Image>().enabled == true) { Count_active_anim.Current_Bottle.GetComponent<Select_>().CountImage2 = i; }

                }
                LVL_ridunu[3 - CountImage].GetComponent<Animator>().runtimeAnimatorController = Count_active_anim.Zoom_;
                LVL_ridunu[3 - CountImage].GetComponent<Animator>().enabled = true;
                LVL_ridunu[3 - CountImage].GetComponent<Image>().enabled = true;

                for (int i = 0; i < 4; i++)
                {
                    if (LVL_ridunu[i].GetComponent<Image>().sprite.name == "Bluy") { color[i] = "Bluy"; }
                    if (LVL_ridunu[i].GetComponent<Image>().sprite.name == "Red") { color[i] = "Red"; }
                    if (LVL_ridunu[i].GetComponent<Image>().sprite.name == "Green") { color[i] = "Green"; }
                    if (LVL_ridunu[i].GetComponent<Image>().sprite.name == "Yellow") { color[i] = "Yellow"; }
                }
                if (LVL_ridunu[0].GetComponent<Image>().enabled)
                {
                    Count_active_anim.Current_color = color[0];
                }
                else if (LVL_ridunu[1].GetComponent<Image>().enabled)
                {
                    Count_active_anim.Current_color = color[1];
                }
                else if (LVL_ridunu[2].GetComponent<Image>().enabled)
                {
                    Count_active_anim.Current_color = color[2];
                }
                else if (LVL_ridunu[3].GetComponent<Image>().enabled)
                {
                    Count_active_anim.Current_color = color[3];
                }
                Count_active_anim.Current_Bottle.GetComponent<Select_>().LVL_ridunu[Count_active_anim.Current_Bottle.GetComponent<Select_>().CountImage2].GetComponent<Animator>().runtimeAnimatorController = Count_active_anim.Zoom;
                Count_active_anim.Current_Bottle.GetComponent<Select_>().LVL_ridunu[Count_active_anim.Current_Bottle.GetComponent<Select_>().CountImage2].GetComponent<Animator>().enabled=true;

                if (LVL_ridunu[0].GetComponent<Image>().enabled == true && LVL_ridunu[1].GetComponent<Image>().enabled == true && LVL_ridunu[2].GetComponent<Image>().enabled == true && LVL_ridunu[3].GetComponent<Image>().enabled == true && color[0] == color[1] && color[0] == color[2] && color[0] == color[3])
                {
                    Finish_bottle = true;
                    Count_active_anim.Count_Finish_Bottle++;
                }

                //Кінець
            }
            else
            {
                gameObject.GetComponent<Animator>().runtimeAnimatorController = Eror_anim;
                gameObject.GetComponent<Animator>().enabled = true;
            }

            
        }
    }

}
