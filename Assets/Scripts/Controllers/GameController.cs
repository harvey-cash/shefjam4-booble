using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    TownController townControl;
    MeteorController meteorControl;
    TextController textControl;

    private int level = 1;

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

    private void LevelOne()
    {
        textControl.PrintOutput(" Level " + GetString(level));
        meteorControl.Begin();
    }
    private void LevelTwo()
    {

    }
    private void LevelThree()
    {

    }


    void Start () {
        townControl = gameObject.GetComponent<TownController>();
        meteorControl = gameObject.GetComponent<MeteorController>();
        textControl = gameObject.GetComponent<TextController>();

        textControl.PrintOutput(" Press Space");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LevelOne();
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
