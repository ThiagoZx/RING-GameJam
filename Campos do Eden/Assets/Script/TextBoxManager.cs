using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextBoxManager : MonoBehaviour
{

    public GameObject textBox;
    //public Text theText = null;
    public Text_Writer writer;

    public int currentLine = 0;
    public int endAtLine;

    public TextAsset textFile;
    public string[] textLines;

    // Use this for initialization
    void Start()
    {
        textBox.SetActive(true);

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        writer.Write(textLines[currentLine]);
    }

    // Update is called once per frame
    void Update()
    {
        //theText.text = textLines[currentLine];
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(writer.trySkip())
            {
                currentLine += 1;
                if (currentLine > endAtLine)
                {
                    textBox.SetActive(false);
                    writer.Write(string.Empty);
                    writer.StopAllCoroutines();
                }
                else
                {
                    writer.Write(textLines[currentLine]);
                }
            }
        }
        
    }
}
