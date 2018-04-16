using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// This class controls how text is displayed on the screen 
/// </summary>
public class TextBoxManager : MonoBehaviour {

    /// <summary>
    /// The text box
    /// </summary>
    public GameObject textBox;

    /// <summary>
    /// The text
    /// </summary>
    public Text theText;

    /// <summary>
    /// The text file
    /// </summary>
    public TextAsset textFile;

    /// <summary>
    /// The text lines
    /// </summary>
    public string[] textLines;

    /// <summary>
    /// The current line
    /// </summary>
    public int currentLine = 0;

    /// <summary>
    /// The end at line
    /// </summary>
    public int endAtLine;

    /// <summary>
    /// The printing text
    /// </summary>
    public bool printingText = false;

    /// <summary>
    /// The temporary string
    /// </summary>
    public char[] tempString;

    /// <summary>
    /// The file done reading
    /// </summary>
    public bool fileDoneReading = false;

    /// <summary>
    /// Starts this instance.
    /// </summary>
    public void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        endAtLine = textLines.Length;
    }

    /// <summary>
    /// Updates this instance.
    /// </summary>
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !printingText)
        {
            if (currentLine >= endAtLine)
            {
                fileDoneReading = true;
            }

            else
            {
                StartCoroutine(Wait());
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape) && !fileDoneReading)
        {
            fileDoneReading = true;
        }
    }

    /// <summary>
    /// Waits this instance.
    /// </summary>
    /// <returns name="WaitForSecondsRealTime">How long to wait between letter displays</returns>
    IEnumerator Wait()
    {
        printingText = true;
        theText.text = textLines[currentLine][0].ToString();
        for (int i = 1; i < 100; i++)
        {
            if (i < textLines[currentLine].Length)
            {
                yield return new WaitForSecondsRealtime(.03f);
                theText.text += textLines[currentLine][i].ToString();
                if (textLines[currentLine][i] == '\n')
                {
                    break;
                }
            }
        }

        theText.text += "\n";
        currentLine++;
        theText.text += textLines[currentLine][0].ToString();
        for (int i = 1; i < 100; i++)
        {
            if (i < textLines[currentLine].Length)
            {
                yield return new WaitForSecondsRealtime(.03f);
                theText.text += textLines[currentLine][i].ToString();
                if (textLines[currentLine][i] == '\n')
                {
                    break;
                }
            }
        }

        currentLine++;
        yield return new WaitForSecondsRealtime(.03f);
        printingText = false;
    }
}
