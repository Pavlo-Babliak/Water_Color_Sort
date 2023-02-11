using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Number_lbl : MonoBehaviour
{
    
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(Application.loadedLevel);
    }

   
}
