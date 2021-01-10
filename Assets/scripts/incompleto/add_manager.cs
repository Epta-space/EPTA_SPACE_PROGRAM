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
    string banner_id = "ca-app-pub-9840334616422494/5009213163";
    // string intersticial_id = "ca-app-pub-9840334616422494/4891639570";

    //! Objects declaration
    private BannerView banner_ad;
    private InterstitialAd interstitial_ad;
    
    // Start is called before the first frame update
    void Start()
    {
        Create_the_banner(app_id , banner_id);
    }

    private void Create_the_banner(string App , string banner)
    {
        // Create a 320x50 banner at the top of the screen.
        banner_ad = new BannerView(App, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        banner_ad.LoadAd(request);
    }
}
