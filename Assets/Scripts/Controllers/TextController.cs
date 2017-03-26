using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextController : MonoBehaviour {
    
    public Text output;
    public Text screen;

    public IEnumerator PrintOutput(string text)
    {
        output.transform.parent.GetComponent<RectTransform>().position = GameController.townControl.GetTextPos();
        output.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            output.text = output.text + text[i].ToString();
            yield return new WaitForSeconds(0.1f);            
        }
        yield return new WaitForSeconds(1);
        for (int i = text.Length; i > 0; i--)
        {
            output.text = "";
            for (int j = 0; j < i; j++) { output.text += text[j].ToString(); }
            yield return new WaitForSeconds(0.1f);

        }
        output.text = "";
        text = " Press Space";
        for (int i = 0; i < text.Length; i++)
        {
            output.text = output.text + text[i].ToString();
            yield return new WaitForSeconds(0.1f);
        }
    }

    /*
     * 
    */

    public void ProgressOutput(string progress)
    {
        screen.text = progress;
    }
}
