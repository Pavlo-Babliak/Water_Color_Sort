using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count_active_anim : MonoBehaviour
{
    public static bool Active;
    public bool act;
    //public int Count_Buttles;
    public static Vector3 Start_pos;
    public static Vector3 Finish_pos;
    public Vector3 pos;
    public static bool Start_move;
    public int k;
    public static bool Return_move;
    public RuntimeAnimatorController clip_Rotation_Left;
    public RuntimeAnimatorController clip_Rotation_Right;
    public static RuntimeAnimatorController clip_first;
    public static string Current_color;
    public static GameObject Current_Bottle;
    public static RuntimeAnimatorController Zoom;
    public static RuntimeAnimatorController Zoom_;
    public RuntimeAnimatorController zoom;
    public RuntimeAnimatorController zoom_;
    public static int All_Color;
    public static int All_Bottle_in_lvl_to_finish;
    public static int Count_Finish_Bottle;
    public GameObject Win_trigger;
    public int all;
    public int count;
    public int _frameRate = 60;
    private void Start()
    {
        Zoom = zoom;
        Zoom_ = zoom_;
        Start_move = false;
        Return_move = false;
        Active = false;
        All_Bottle_in_lvl_to_finish = 0;
        StartCoroutine(Count());
        // видалити на релізі
        //PlayerPrefs.SetInt("LVL", 150);
        //
    }
    private void Awake()
    {
        Win_trigger.active = false;
        QualitySettings.vSyncCount = 0;
    }
    IEnumerator Count() 
    {
        yield return new WaitForSeconds(0.25f);
        All_Bottle_in_lvl_to_finish = All_Color / 4;
    }
    private void Update()
    {
        if (_frameRate != Application.targetFrameRate)
            Application.targetFrameRate = _frameRate;

        pos = Start_pos;
        act = Active;
        all = All_Bottle_in_lvl_to_finish;
        count = Count_Finish_Bottle;

        if (Start_move == true) 
        {
            if (Start_pos.x > 0 && Start_pos.x >= Finish_pos.x && Finish_pos.x > 0) 
            {
                Current_Bottle.GetComponent<Animator>().runtimeAnimatorController = clip_Rotation_Left;
                Current_Bottle.transform.Find("Line_right").gameObject.active = false;
                Current_Bottle.transform.Find("Line_right").GetComponent<Animator>().enabled = false;
                Current_Bottle.transform.Find("Line_left").gameObject.active = true;
            }
            else if (Start_pos.x < Finish_pos.x)
            {
                Current_Bottle.GetComponent<Animator>().runtimeAnimatorController = clip_Rotation_Left;
                Current_Bottle.transform.Find("Line_right").gameObject.active = false;
                Current_Bottle.transform.Find("Line_right").GetComponent<Animator>().enabled = false;
                Current_Bottle.transform.Find("Line_left").gameObject.active = true;
            }
            else
            {
                Current_Bottle.GetComponent<Animator>().runtimeAnimatorController = clip_Rotation_Right;
                Current_Bottle.transform.Find("Line_right").gameObject.active = true;
                Current_Bottle.transform.Find("Line_left").gameObject.active = false;
                Current_Bottle.transform.Find("Line_left").GetComponent<Animator>().enabled = false;
            }

            Current_Bottle.transform.position = Vector3.Lerp(Current_Bottle.transform.position, new Vector3(Finish_pos.x, Finish_pos.y + 0.5f, Finish_pos.z), Time.deltaTime * 15);
        }
        if (Return_move == true) 
        {
            //Current_Bottle.transform.position = Vector3.Lerp(Current_Bottle.transform.position, Start_pos, Time.deltaTime * 50);
            Current_Bottle.transform.position = Start_pos;
            Current_Bottle.transform.position = Current_Bottle.GetComponent<Select_>().start_pos; Stop_anim.Disable = true;
        }
        /*if (Current_Bottle)
        {
            if (Current_Bottle.transform.position.y <= Start_pos.y + 0.02f && Current_Bottle.transform.position.y >= Start_pos.y - 0.02f) { Current_Bottle.transform.position = Current_Bottle.GetComponent<Select_>().start_pos; Stop_anim.Disable = true; }
        }*/
        if (Stop_anim.Finish == true)
        { 
            Win_trigger.active=true;
            All_Bottle_in_lvl_to_finish = 0;
            Count_Finish_Bottle = 0;
            All_Color = 0;
            if (PlayerPrefs.GetInt("LVL")<=Application.loadedLevel) 
            { 
                PlayerPrefs.SetInt("LVL", Application.loadedLevel + 1); 
            }
        }
        
    }
}
