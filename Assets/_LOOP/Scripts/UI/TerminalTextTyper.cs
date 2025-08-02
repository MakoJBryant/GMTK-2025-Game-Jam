/*
PURPOSE: 
Writes a string to the screen to mimic a terminal UI.
*/

using System.Collections;
using TMPro;
using UnityEngine;

public class TerminalTextTyper : MonoBehaviour
{
    public TextMeshProUGUI terminalText;
    public float typingSpeed = 0.03f;

    private string[] lines = new string[]
    {
        "> INITIALIZING SYSTEM...",
        "> LOADING MODULES...",
        "> WELCOME TO PROJECT LOOP",
        ">",
        "> [ START GAME ]",
        "> [ QUIT ]"
    };

    void Start()
    {
        StartCoroutine(TypeLines());
    }

    IEnumerator TypeLines()
    {
        foreach (string line in lines)
        {
            foreach (char c in line)
            {
                terminalText.text += c;
                yield return new WaitForSeconds(typingSpeed);
            }
            terminalText.text += "\n";
            yield return new WaitForSeconds(0.2f);
        }
    }
}
