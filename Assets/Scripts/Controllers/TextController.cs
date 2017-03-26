using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextController : MonoBehaviour {
    
    public Text output;
    //public Text UI;

    public IEnumerator PrintOutput(string text)
    {
        output.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            output.text = output.text + text[i].ToString();
            yield return new WaitForSeconds(0.1f);
            
        }
        yield return new WaitForSeconds(2f);
        for (int i = text.Length; i > 0; i--)
        {
            output.text = "";
            for (int j = 0; j < i; j++) { output.text += text[j].ToString(); }
            yield return new WaitForSeconds(0.1f);

        }
    }
}
