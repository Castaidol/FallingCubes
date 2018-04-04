using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI coinText;
    public GameObject gameOverPanel;

    [HideInInspector]
    public int seconds;
    int oldCoinCount;
    int coinCount;
    float timer;
    bool isGameOver;

    GameObject[] fallingCubes;

	void Start () {
        
        timerText = GameObject.FindGameObjectWithTag("TimerText").GetComponent<TextMeshProUGUI>();
        coinText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<TextMeshProUGUI>();
        coinCount = PlayerPrefs.GetInt("Coin");
        oldCoinCount = coinCount;
        coinText.text = coinCount.ToString();
        isGameOver = false;
        timer = 41;
	}


    void Update()
    {
        timer -= Time.deltaTime;
        seconds = (int)timer;
        coinCount = PlayerPrefs.GetInt("Coin");
        if(coinCount > oldCoinCount)
        {
            timer = timer + 5;
            oldCoinCount = coinCount;
        }
        coinText.text = coinCount.ToString();
        timerText.text = seconds.ToString();

        if(seconds == 0 && !isGameOver)
        {
            isGameOver = true;
            Time.timeScale = 0.2f;
            StartCoroutine(GameOver());
        }

        fallingCubes = GameObject.FindGameObjectsWithTag("FallingCube");

        foreach(GameObject cube in fallingCubes)
        {
            bool hitPlayer = cube.GetComponent<FallingCube>().hitPlayer;
            if(hitPlayer) StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        Debug.Log("Game Over");
        yield return new WaitForSeconds(0.25f);
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);

    }
}
