using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine = 0;
    public int endAtLine;
    public bool printingText = false;
    public char[] tempString;

    public bool fileDoneReading = false;

    //add player object and disable movement.
    // Use this for initialization

    void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        endAtLine = textLines.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //needs to be modifying for NPC interaction
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
