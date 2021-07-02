using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class add_manager : MonoBehaviour
{
    //! Identifications for add identification
    string app_id = "ca-app-pub-9840334616422494~6513866522";
    string banner_id = "ca-app-pub-9840334616422494/7827292355";

    //! Objects declaration
    private BannerView banner_ad;
    private InterstitialAd interstitial_ad;
    
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        Create_the_banner(app_id , banner_id);
    }

    private void Create_the_banner(string App , string banner)
    {
        // Create a 320x50 banner at the top of the screen.
        banner_ad = new BannerView(App, AdSize.Banner, AdPosition.Top);

        // Called when an ad request has successfully loaded.
        this.banner_ad.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.banner_ad.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.banner_ad.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.banner_ad.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.banner_ad.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        banner_ad.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

}
