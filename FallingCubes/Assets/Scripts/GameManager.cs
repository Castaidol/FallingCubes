using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI coinText;

    public int seconds;
    public int coinCount;
    float timer;

	void Start () {

        timerText = GameObject.FindGameObjectWithTag("TimerText").GetComponent<TextMeshProUGUI>();
        coinText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<TextMeshProUGUI>();
        PlayerPrefs.SetInt("Coin", 0);
        coinCount = PlayerPrefs.GetInt("Coin");
        coinText.text = coinCount.ToString();
        timer = 31;
	}


    void Update()
    {
        timer -= Time.deltaTime;
        seconds = (int)timer % 60;

        timerText.text = seconds.ToString();

        if(seconds == 0)
        {
            Time.timeScale = 0.2f;
        }
    }

    public void GetCoin()
    {
        seconds += 5;
        coinCount = PlayerPrefs.GetInt("Coin");
        coinCount++;
        coinText.text = coinCount.ToString();
        PlayerPrefs.SetInt("Coin", coinCount);
    }
}
