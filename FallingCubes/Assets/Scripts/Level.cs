using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Level : ScriptableObject {

    public new string name;
    public string description;
    public bool isUnlocked;
    public int unlockCost;
    public int levelIndex;

    public Sprite levelImage;

}
