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
    private bool canChangeLevel = true;
    public GameObject currentLevel;

    void Start () {
        gameControl = this;
        playerControl = player.GetComponent<PlayerController>();
        townControl = gameObject.GetComponent<TownController>();
        meteorControl = gameObject.GetComponent<MeteorController>();
        textControl = gameObject.GetComponent<TextController>();
        
        currentLevel = Instantiate((GameObject)Resources.Load("Levels/Level" + GetString(level)));
        StartCoroutine(textControl.PrintOutput(" Press Space"));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canChangeLevel)
        {
            canChangeLevel = false;
            textControl.output.text = "";
            StartCoroutine(NextLevel());
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private IEnumerator NextLevel()
    {
        level++;
        Destroy(currentLevel);
        playerControl.Reset();
        currentLevel = Instantiate((GameObject)Resources.Load("Levels/Level" + GetString(level)));
        StartCoroutine(textControl.PrintOutput(" Level " + GetString(level)));
        yield return new WaitForSeconds(2.2f);

        meteorControl.Begin();
    }

    public IEnumerator Win()
    {
        if(level < 4)
        {
            StartCoroutine(NextLevel());
        }
        else
        {
            StartCoroutine(textControl.PrintOutput(" You Win!"));
            yield return new WaitForSeconds(2.2f);
            StartCoroutine(textControl.PrintOutput(" Press ESC!"));
        }
    }

    public IEnumerator Lose()
    {
        level = 0;
        Destroy(currentLevel);
        StartCoroutine(textControl.PrintOutput(" You Lose!"));
        yield return new WaitForSeconds(2.2f);
        StartCoroutine(textControl.PrintOutput(" Press Space"));
        yield return new WaitForSeconds(2.2f);

        canChangeLevel = true;
    }



    string[] words = { "Zero", "One", "Two", "Three", "Four", "Five", "Six" };
    private string GetString(int number)
    {
        return words[number];
    }

}
