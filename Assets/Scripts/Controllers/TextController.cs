using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextController : MonoBehaviour {

    string[] words = { "Zero", "One", "Two", "Three", "Four", "Five", "Six" };
    private string GetString(int number)
    {
        return words[number];
    }

    public static int level = 1;
    public Text levelText;

    public void Start()
    {
        StartCoroutine(PrintLevel());
    }

    public IEnumerator PrintLevel()
    {
        string endText = " Level " + GetString(level);
        for (int i = 0; i < endText.Length; i++) {
            levelText.text = levelText.text + endText[i].ToString();
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);
        for (int i = endText.Length; i > 0; i--)
        {
            levelText.text = "";
            for (int j = 0; j < i; j++) { levelText.text += endText[j].ToString(); }
            yield return new WaitForSeconds(0.1f);

        }

        gameObject.GetComponent<MeteorController>().Begin();

    }
    

}
