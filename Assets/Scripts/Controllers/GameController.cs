using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController gameControl;
    public static PlayerController playerControl;
    public static TownController townControl;
    public static MeteorController meteorControl;
    public static TextController textControl;

    public GameObject player;

    private int level = 0;
    private GameObject currentLevel;
    private bool canChangeLevel = true;

    void Start () {
        gameControl = this;
        playerControl = player.GetComponent<PlayerController>();
        townControl = gameObject.GetComponent<TownController>();
        meteorControl = gameObject.GetComponent<MeteorController>();
        textControl = gameObject.GetComponent<TextController>();

        textControl.ProgressOutput("");
        currentLevel = Instantiate((GameObject)Resources.Load("Levels/Level" + GetString(level)));

        StartCoroutine(textControl.PrintOutput(" Boogle. "));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canChangeLevel)
        {
            canChangeLevel = false;
            textControl.output.text = "";
            StartCoroutine(StartLevel());
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private IEnumerator StartLevel()
    {
        level = 1;
        playerControl.Reset();
        Destroy(currentLevel);
        
        currentLevel = Instantiate((GameObject)Resources.Load("Levels/Level" + GetString(level)));
        yield return new WaitForSeconds(2.2f);

        meteorControl.Begin();
        canChangeLevel = true;
    }

    public IEnumerator Win()
    {
        meteorControl.Stop();
        townControl.Stop();
        playerControl.Win();
        textControl.ProgressOutput(" You Win!");
        yield return new WaitForEndOfFrame();
    }

    public IEnumerator Lose()
    {
        level = 0;
        Destroy(currentLevel);
        StartCoroutine(textControl.PrintOutput(" You Lose!"));
        yield return new WaitForSeconds(2.2f);

        canChangeLevel = true;
    }



    string[] words = { "Zero", "One", "Two", "Three", "Four", "Five", "Six" };
    private string GetString(int number)
    {
        return words[number];
    }

}
