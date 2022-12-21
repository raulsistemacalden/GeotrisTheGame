using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour, IUnityAdsListener
{
    private string googlePlayID = "3861797";
    private string appleStoreID = "3861796";

    private string normalVideo = "video";
    private string rewardedVideo = "rewardedVideo";

    [SerializeField] bool test = true;
    [SerializeField] bool android = true;

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(googlePlayID, false);

    }

    public void ShowNormalVideo()
    {
        Advertisement.Show(normalVideo);
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //throw new System.NotImplementedException();
        switch (showResult) {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if (placementId == normalVideo)
                {
                    Debug.Log("Completado");
                }
                else if (placementId == rewardedVideo) {
                    Debug.Log("Dar Recompensa");
                }
                break;
        }

    }
}
