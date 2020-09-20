using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameTimeTxt = null;
    [SerializeField] private GameObject gamePlayUI = null;
    [SerializeField] private GameObject gameOverUI = null;
    [SerializeField] private TextMeshProUGUI gameOverTimeTxt = null;

    private int minute = 0;
    private float seconds = 0f;
    private bool called = false;

    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        seconds = 0f;
        called = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.isGameOver)
        {
            seconds += Time.deltaTime;
            if (seconds > 59)
            {
                seconds = 0;
                minute++;
            }
            gameTimeTxt.SetText((minute.ToString().Length > 1 ? minute.ToString() : "0" + minute.ToString()) + ":" + (((int)seconds).ToString().Length > 1 ? ((int)seconds).ToString() : "0" + ((int)seconds).ToString()));
        }
        else if (!called)
        {
            gameOverUI.SetActive(true);
            gamePlayUI.SetActive(false);
            gameOverTimeTxt.SetText("Time: "+gameTimeTxt.GetParsedText());
            int bestMinute = PlayerPrefs.GetInt("Minute");
            int bestSeconds = PlayerPrefs.GetInt("Seconds");

            if (minute > bestMinute)
            {
                PlayerPrefs.SetInt("Minute", minute);
                PlayerPrefs.SetInt("Seconds", (int)seconds);
            }
            else if (minute >= bestMinute && seconds > bestSeconds)
            {
                PlayerPrefs.SetInt("Minute", minute);
                PlayerPrefs.SetInt("Seconds", (int)seconds);               
            }
            Invoke("AdsCall", 3f);
            called = true;
        }
    }

    private void AdsCall()
    {
        AdsManager.instance.DisplayAd();
    }
}
