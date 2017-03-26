using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController gameControl;
    public static TownController townControl;
    public static MeteorController meteorControl;
    public static TextController textControl;

    private int level = 1;

    GameObject currentLevel = null;

    public void Win()
    {
        level++;
        meteorControl.Stop();
        switch (level)
        {
            case 2:
                LevelTwo();
                break;
            case 3:
                LevelThree();
                break;
            default:
                break;
        }
    }

    public void Lose()
    {
        meteorControl.Stop();
    }

    private IEnumerator LevelOne()
    {
        if (currentLevel != null) { Destroy(currentLevel); }
        if (currentLevel == null) { currentLevel = Instantiate((GameObject)Resources.Load("Levels/LevelOne")); }
        level = 1;
        textControl.PrintOutput(" Level " + GetString(level));
        yield return new WaitForSeconds(2.2f);
        meteorControl.Begin();
    }
    private IEnumerator LevelTwo()
    {
        if (currentLevel != null) { Destroy(currentLevel); }
        if (currentLevel == null) { currentLevel = Instantiate((GameObject)Resources.Load("Levels/LevelTwo")); }
        level = 2;
        textControl.PrintOutput(" Level " + GetString(level));
        yield return new WaitForSeconds(2.2f);
        meteorControl.Begin();
    }
    private IEnumerator LevelThree()
    {
        if (currentLevel != null) { Destroy(currentLevel); }
        if (currentLevel == null) { currentLevel = Instantiate((GameObject)Resources.Load("Levels/LevelThree")); }
        level = 3;
        textControl.PrintOutput(" Level " + GetString(level));
        yield return new WaitForSeconds(2.2f);
        meteorControl.Begin();
    }


    void Start () {
        gameControl = this;
        townControl = gameObject.GetComponent<TownController>();
        meteorControl = gameObject.GetComponent<MeteorController>();
        textControl = gameObject.GetComponent<TextController>();

        StartCoroutine(textControl.PrintOutput(" Press Space"));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LevelOne());
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
