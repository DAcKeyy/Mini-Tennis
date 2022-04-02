using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine;

namespace UnityProject.Ads
{
    public class AdSettings : MonoBehaviour, IInterstitialAdListener // IRewardedVideoAdListener, IBannerAdListener, IMrecAdListener
    {
        private const string APP_KEY = "090564847401471af28290a0b32b85b6606c1c55f745e88d";

        private void Start()
        {
            int addTypes = Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO | Appodeal.BANNER_BOTTOM | Appodeal.MREC;

            Appodeal.initialize(APP_KEY, addTypes, true);

            Appodeal.setInterstitialCallbacks(this);
            //Appodeal.setRewardedVideoCallbacks(this);
            //Appodeal.setBannerCallbacks(this);
            //Appodeal.setMrecCallbacks(this);
        }

        public void ShowInterstitial()
        {
            if(Appodeal.canShow(Appodeal.INTERSTITIAL) && !Appodeal.isPrecache(Appodeal.INTERSTITIAL))
            {
                Appodeal.show(Appodeal.REWARDED_VIDEO);
            }
        }

        public void onInterstitialLoaded(bool isPrecache)
        {
            throw new System.NotImplementedException();
        }

        public void onInterstitialFailedToLoad()
        {
            throw new System.NotImplementedException();
        }

        public void onInterstitialShowFailed()
        {
            throw new System.NotImplementedException();
        }

        public void onInterstitialShown()
        {
            throw new System.NotImplementedException();
        }

        public void onInterstitialClosed()
        {
            throw new System.NotImplementedException();
        }

        public void onInterstitialClicked()
        {
            throw new System.NotImplementedException();
        }

        public void onInterstitialExpired()
        {
            throw new System.NotImplementedException();
        }
    }
}
