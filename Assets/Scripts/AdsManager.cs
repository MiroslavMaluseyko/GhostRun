using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{

    static string gameId = "3647585";
    bool testMode = false;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenInitialized());
    }


    static public void ShowRewarded()
    {
        string myPlacementId = "rewardedVideo";
        if (Advertisement.IsReady(myPlacementId))
        {
            Advertisement.Show(myPlacementId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }



    private IEnumerator ShowBannerWhenInitialized()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show("bannerPlacement");
    }
}