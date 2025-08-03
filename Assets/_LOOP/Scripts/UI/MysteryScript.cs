/*
PURPOSE: 
Writes a string to the screen to mimic a terminal UI.
*/

using System.Collections;
using TMPro;
using UnityEngine;

public class MysteryScript : MonoBehaviour
{
    public TextMeshProUGUI terminalText;
    public float typingSpeed = 0.03f;

    private string[] lines = new string[]
    {
        "> PLAYER CHARACTER DEATH ERROR...",
        "> THIS IS NOT THE END...",
        "> TRY AGAIN?",
        ">",
        "> [ RETRY ]",
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
