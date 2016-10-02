using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Text_Writer : MonoBehaviour {

    private enum TextState { Writting, Finished }
    private float currentSpeed;

    public float speed;

    public AudioClip typeSound1, typeSound2;
    
    private TextState currentState;

    string message;
    public Text textComp;
           
	public void Write (string text) {
        StopCoroutine("TypeText");
        message = text;
        StartCoroutine("TypeText");
    }

    public bool trySkip()
    {
        switch (currentState)
        {
            case TextState.Writting:
                currentState = TextState.Finished;
                StopCoroutine("TypeText");
                textComp.text = message;
                break;

            case TextState.Finished:
                return true;
        }
        return false;
    }

    IEnumerator TypeText()
    {
        currentSpeed = speed;
        textComp.text = string.Empty;
        currentState = TextState.Writting;

        foreach(char letter in message.ToCharArray()){
            textComp.text += letter;
            if (typeSound1 && typeSound2)
                //SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
                yield return 0;


            yield return new WaitForSeconds(currentSpeed);
        }
        textComp.text = message;
        currentState = TextState.Finished;
    }
}
