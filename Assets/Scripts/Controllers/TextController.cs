using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextController : MonoBehaviour {
    
    public Text output;

    public void PrintOutput(string text)
    {
        output.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            output.text = output.text + text[i].ToString();
            Sleep(0.1f);
            
        }
        Sleep(2f);
        for (int i = text.Length; i > 0; i--)
        {
            output.text = "";
            for (int j = 0; j < i; j++) { output.text += text[j].ToString(); }
            Sleep(0.1f);

        }
    }

    public void Sleep(float time)
    {
        float endTime = Time.time + time;
        while (Time.time < endTime) { /*do literally nothing*/ }
    }

    


}
