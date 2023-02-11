using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using GoogleMobileAds.Api;
using UnityEngine.Events;
using System;
//using GoogleMobileAds.Common;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    public GameObject Exit;
    public GameObject Bottle;
    public Sprite Sound_on;
    public Sprite Sound_off;
    public GameObject[] lvl = new GameObject[2];

   /* private InterstitialAd interstitial;
    string adUnitId = "ca-app-pub-9572656335524853/3401553450";
    public UnityEvent OnAdOpeningEvent;
    public UnityEvent OnAdClosedEvent;*/
    bool return_ads;
    bool Next_ads;
    bool Exit_main_ads;
    private void Awake()
    {
        IronSource.Agent.init("12b877e2d");
        IronSource.Agent.init("12b877e2d", IronSourceAdUnits.INTERSTITIAL);
    }
    private void Start()
    {
        IronSource.Agent.loadInterstitial();
        IronSourceEvents.onInterstitialAdClosedEvent += InterstitialAdClosedEvent;
        IronSourceEvents.onInterstitialAdOpenedEvent += InterstitialAdOpenedEvent;
       /* this.interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        this.interstitial.LoadAd(request);*/


        if (PlayerPrefs.GetInt("Music") == 0)
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled = false;
            GameObject.Find("Button_Music").GetComponent<Image>().sprite = Sound_off;
        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled = true;
            GameObject.Find("Button_Music").GetComponent<Image>().sprite = Sound_on;
        }
        if (!PlayerPrefs.HasKey("Music")) 
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled = true;
            GameObject.Find("Button_Music").GetComponent<Image>().sprite = Sound_on;
        }
        if (!PlayerPrefs.HasKey("LVL")) { PlayerPrefs.SetInt("LVL", 1); }
    }
    public void Play() { if (PlayerPrefs.GetInt("LVL") <= 150) { Application.LoadLevel(PlayerPrefs.GetInt("LVL")); } else Application.LoadLevel(150); }
    public void Button_Return() 
    {
        if (Application.loadedLevel % 2 == 0)
        {
            if (IronSource.Agent.isInterstitialReady())
            {
                return_ads = true;
                IronSource.Agent.showInterstitial();
                //this.interstitial.Show();
            }
            else
            {
                Banner.destroy = true;
                Count_active_anim.All_Color = 0; Stop_anim.Finish = false; Count_active_anim.Return_move = false; Count_active_anim.Start_move = false; Application.LoadLevel(Application.loadedLevel);
            }
        }
        else
        {
            Banner.destroy = true;
            Count_active_anim.All_Color = 0; Stop_anim.Finish = false; Count_active_anim.Return_move = false; Count_active_anim.Start_move = false; Application.LoadLevel(Application.loadedLevel);
        }
    }
    public void Button_Menu() 
    {
        if (Application.loadedLevel % 2 == 0)
        {
            if (IronSource.Agent.isInterstitialReady())
            {
                Exit_main_ads = true;
                IronSource.Agent.showInterstitial();
                //this.interstitial.Show();
            }
            else
            {
                Banner.destroy = true;
                Count_active_anim.All_Color = 0; Stop_anim.Finish = false; Count_active_anim.Return_move = false; Count_active_anim.Start_move = false; Application.LoadLevel(0);
            }
        }
        else
        {
            Banner.destroy = true;
            Count_active_anim.All_Color = 0; Stop_anim.Finish = false; Count_active_anim.Return_move = false; Count_active_anim.Start_move = false; Application.LoadLevel(0);
        }
    }
    public void Button_Next() 
    {
        if (Application.loadedLevel % 2 == 0)
        {
            if (IronSource.Agent.isInterstitialReady())
            {
                Next_ads = true;
                IronSource.Agent.showInterstitial();
                //this.interstitial.Show();
            }
            else 
            { 
                Banner.destroy = true; 
                if (PlayerPrefs.GetInt("LVL") <= 150) 
                {
                    Count_active_anim.All_Color = 0;  Stop_anim.Finish = false;   Count_active_anim.Return_move = false;  Count_active_anim.Start_move = false;  SceneManager.LoadScene(Convert.ToInt32(Application.loadedLevel) + 1);
                } 
                else Application.LoadLevel(150);
            }
        }
        else 
        { 
            Banner.destroy = true; if (PlayerPrefs.GetInt("LVL") <= 150)
            {
                Count_active_anim.All_Color = 0; Stop_anim.Finish = false; Count_active_anim.Return_move = false; Count_active_anim.Start_move = false; SceneManager.LoadScene(Convert.ToInt32(Application.loadedLevel) + 1);
            }
            else Application.LoadLevel(150);
        }

        /*
        Count_active_anim.All_Color = 0; 
        Stop_anim.Finish = false; 
        Count_active_anim.Return_move = false;
        Count_active_anim.Start_move = false; 
        if (PlayerPrefs.GetInt("LVL") <= 150) { Application.LoadLevel(Application.loadedLevel + 1); } else Application.LoadLevel(150); 
        */

    }
    public void Button_Exit() { Application.Quit(); }
    public void Exit_No()   { GameObject.Find("Exit_trigger").SetActive(false);   }
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
               Exit.active=true;
            }
        }
    }
    public void Music()
    {
        if (GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled == true)
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled = false;
            GameObject.Find("Button_Music").GetComponent<Image>().sprite = Sound_off;
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled = true;
            GameObject.Find("Button_Music").GetComponent<Image>().sprite = Sound_on;
            PlayerPrefs.SetInt("Music", 1);
        }
    }
    public void Creat_New_Bottle() { Bottle.SetActive(true); Destroy(GameObject.Find("Button_New_Bottle")); }
    public void Select_lvl() { lvl[0].active = true; lvl[1].active = false;  }
    public void Select_lvl_back() { lvl[1].active = true; lvl[0].active = false; }

    void InterstitialAdClosedEvent() 
    {
        IronSource.Agent.loadInterstitial();
        GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;
        if (Next_ads == true)
        {
            Count_active_anim.All_Color = 0; Stop_anim.Finish = false; Count_active_anim.Return_move = false; Count_active_anim.Start_move = false;
            Banner.destroy = true; 
            SceneManager.LoadScene(Convert.ToInt32(Application.loadedLevel) + 1);
            Next_ads = false;
        }
        if (Exit_main_ads == true)
        {
            Count_active_anim.All_Color = 0; Stop_anim.Finish = false; Count_active_anim.Return_move = false; Count_active_anim.Start_move = false;
            Banner.destroy = true; 
            SceneManager.LoadScene(0);
            Exit_main_ads = false;
        }
        if (return_ads == true)
        {
            Count_active_anim.All_Color = 0; Stop_anim.Finish = false; Count_active_anim.Return_move = false; Count_active_anim.Start_move = false;
            Banner.destroy = true;
            SceneManager.LoadScene(Application.loadedLevel);
            return_ads = false;
        }
    }

    public void InterstitialAdOpenedEvent() 
    {
        GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
    }
   /* public void HandleOnAdOpened(object sender, EventArgs args)
    {
        GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;
        //interstitial.Destroy();
        if (Next_ads == true)
        {
            Count_active_anim.All_Color = 0; Stop_anim.Finish = false; Count_active_anim.Return_move = false; Count_active_anim.Start_move = false;
            Banner.destroy = true; SceneManager.LoadScene(Convert.ToInt32(Application.loadedLevel) + 1);
            Next_ads = false;
        }
        if (Exit_main_ads == true)
        {
            Count_active_anim.All_Color = 0; Stop_anim.Finish = false; Count_active_anim.Return_move = false; Count_active_anim.Start_move = false;
            Banner.destroy = true;  SceneManager.LoadScene(0);
            Exit_main_ads = false;
        }
        if (return_ads == true)
        {
            Count_active_anim.All_Color = 0; Stop_anim.Finish = false; Count_active_anim.Return_move = false; Count_active_anim.Start_move = false; 
            Banner.destroy = true; SceneManager.LoadScene(Application.loadedLevel);
            return_ads = false;
        }


    }*/

}
