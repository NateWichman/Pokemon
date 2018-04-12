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
    public int currentLine;
    public int endAtLine;
    public bool printingText = false;
    public char[] tempString;

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
        if (Input.GetKeyDown(KeyCode.Space) && currentLine != endAtLine)
        {
            theText.text = "";
            parseString();
        }

    }

    void parseString()
    {
        printingText = true;
        int currentLine = 0;       
        tempString = textLines[currentLine].ToCharArray();
        for (int i = 0; i < textLines[currentLine].Length; i++)
        {
        theText.text += charToString(tempString[i]);
        StartCoroutine(MyMethod());
        }
        theText.text += "\n";
        tempString = textLines[currentLine+1].ToCharArray();
        for (int i = 0; i < textLines[currentLine].Length; i++)
        {
            theText.text += charToString(tempString[i]);
            StartCoroutine(MyMethod());
        }
        if (currentLine < textLines.Length)
        {
            currentLine += 2;
        }
        endAtLine = textLines.Length;
        //theText.text = textLines[currentLine];
        //currentLine += 1;
        printingText = false;
        Array.Clear(tempString, 0, tempString.Length);
    }
    static string charToString(char value)
    {
        return new string(value, 1);
    }
    IEnumerator MyMethod()
    {
        //parse text slowly
        yield return new WaitForSecondsRealtime(.1f);
    }
}
