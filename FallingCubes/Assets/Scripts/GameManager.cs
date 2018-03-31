using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI coinText;

    float timer;

	void Start () {

        timerText = GameObject.FindGameObjectWithTag("TimerText").GetComponent<TextMeshProUGUI>();
        coinText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<TextMeshProUGUI>();
        PlayerPrefs.SetInt("Coin", 9999);
	}
	
	
	void Update () {
        timer += Time.deltaTime;
        int seconds = (int) timer % 60;
        int coinCount = PlayerPrefs.GetInt("Coin");
        coinText.text = coinCount.ToString();
        timerText.text = seconds.ToString();
	}
}
