using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using GoogleMobileAds.Api;
public class Banner : MonoBehaviour
{
    //private BannerView bannerView;
    //string adUnitId = "ca-app-pub-9572656335524853/7992014087";
    public static bool destroy;
    private void Awake()
    {
        IronSource.Agent.init("12b877e2d");
        IronSource.Agent.init("12b877e2d", IronSourceAdUnits.BANNER);
    }
    void Start()
    {
        LoadBanner();
           //MobileAds.Initialize(initStatus => { });
           //this.RequestBanner();
    } /*
    private void RequestBanner()
    {
            this.bannerView = new BannerView(adUnitId, AdSize.IABBanner, AdPosition.Bottom);
            AdRequest request = new AdRequest.Builder().Build();
            this.bannerView.LoadAd(request);
            if (SceneManager.sceneCount >= 1) { this.bannerView.Show(); }
            if (SceneManager.sceneCount == 0) { this.bannerView.Hide(); }

    }*/
    private void LoadBanner()
    {
        IronSource.Agent.loadBanner(IronSourceBannerSize.SMART, IronSourceBannerPosition.BOTTOM);
    }
   /* private void Update()
    {
        if (destroy == true) 
        {
            //bannerView.Destroy();
            destroy = false; }
    }*/

}
