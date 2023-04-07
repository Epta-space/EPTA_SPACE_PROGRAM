using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    #if UNITY_IOS
        string gameId = "4582056";
    #else
        string gameId = "4582057";
    #endif
    void Start()
    {
        Advertisement.Initialize(gameId);
        ShowBanner();
    }

    public void ShowBanner(){
        if(Advertisement.IsReady("banner")){
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            Advertisement.Banner.Show("banner");
            Debug.Log("Banner pronto");
        } else {
            StartCoroutine(RepeatShowBanner());
            Debug.Log("Banner Carregando");
        }
    }

    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(1);
        ShowBanner();
    }
}
