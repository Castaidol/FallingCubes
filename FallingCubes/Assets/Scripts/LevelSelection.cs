using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Level[] levels;
    //public Sprite[] levelSprites; 
    public float speed = 0.5f;

    Image currentLevelImage;

    bool isPressed;
    bool canPress;
    float startPosition = 1;
    float t = 0;
    float finalPosition;
    int levelIndex;

	void Start () 
    {
        currentLevelImage = GetComponent<Image>();
        isPressed = false;
        canPress = true;
        levelIndex = PlayerPrefs.GetInt("levelIndex");
        currentLevelImage.sprite = levels[levelIndex].levelImage;
	}
	
	
	void Update () 
    {
        if(isPressed && canPress) StartCoroutine(ChangeLevelSelected(levelIndex));

	}

    public void PressedRightButton()
    {
        if (!canPress) return;

        levelIndex++;
        if (levelIndex > levels.Length - 1) levelIndex = 0;
        PlayerPrefs.SetInt("levelIndex", levelIndex);
        Debug.Log(levelIndex);
        isPressed = true;
    }

    public void PressedLeftButton()
    {
        if (!canPress) return;

        levelIndex--;
        if (levelIndex < 0) levelIndex = levels.Length - 1;
        PlayerPrefs.SetInt("levelIndex", levelIndex);
        Debug.Log(levelIndex);
        isPressed = true;
    }

    IEnumerator ChangeLevelSelected(int levelIndex)
    {
        startPosition = currentLevelImage.fillAmount;
        if (startPosition == 1) finalPosition = 0;
        t += speed * Time.deltaTime;

        currentLevelImage.fillAmount = Mathf.MoveTowards(startPosition, finalPosition, t);

        yield return null;

        if (currentLevelImage.fillAmount == 0)
        {
            t = 0;
            currentLevelImage.fillClockwise = false;
            currentLevelImage.sprite = levels[levelIndex].levelImage;
        } 

        startPosition = currentLevelImage.fillAmount;
        if (startPosition == 0) finalPosition = 1;
        t += speed * Time.deltaTime;

        currentLevelImage.fillAmount = Mathf.MoveTowards(startPosition, finalPosition, t);

        if (currentLevelImage.fillAmount == 1)
        {
            t = 0;
            currentLevelImage.fillClockwise = true;
            isPressed = false;
        }
        yield return null;
        canPress = true;
    }
}
