using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    internal static AdsManager instance = null;

    private string gameId = "3632926";
    private bool testMode = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    internal void DisplayAd()
    {
        // Initialize the Ads service:
        Advertisement.Initialize(gameId, testMode);

        // Show an ad:
        Advertisement.Show();
    }
}
