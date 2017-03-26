using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController gameControl;
    public static TownController townControl;
    public static MeteorController meteorControl;
    public static TextController textControl;

    private int level = 0;
    private bool canChangeLevel = true;
    public GameObject currentLevel;

    void Start () {
        gameControl = this;
        townControl = gameObject.GetComponent<TownController>();
        meteorControl = gameObject.GetComponent<MeteorController>();
        textControl = gameObject.GetComponent<TextController>();
        
        currentLevel = Instantiate((GameObject)Resources.Load("Levels/LevelOne"));
        StartCoroutine(textControl.PrintOutput(" Press Space"));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canChangeLevel)
        {
            canChangeLevel = false;
            meteorControl.Begin();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }



    string[] words = { "Zero", "One", "Two", "Three", "Four", "Five", "Six" };
    private string GetString(int number)
    {
        return words[number];
    }

}
