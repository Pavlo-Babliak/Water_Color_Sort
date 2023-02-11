using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Education : MonoBehaviour
{
    public Vector3 Finish_pos= new Vector3(-0.8547009f,0,1);
    public GameObject Educ;
    public GameObject[] Bottle = new GameObject[2];
    void Start()
    {
        Finish_pos = new Vector3(-0.8547009f, 0, 1);
        if (PlayerPrefs.HasKey("Educ")) { Educ.active = false; }
        else Educ.active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerPrefs.HasKey("Educ")) 
        {
            if (Bottle[0].GetComponent<Animator>().enabled == true) { Educ.transform.position = Finish_pos; }
            else Educ.transform.position = new Vector3(0, 0, 1);
            if (Bottle[0].transform.Find("3").GetComponent<Animator>().enabled == true) { Educ.active = false; PlayerPrefs.SetInt("Educ", 1); }
        }

    }
}
