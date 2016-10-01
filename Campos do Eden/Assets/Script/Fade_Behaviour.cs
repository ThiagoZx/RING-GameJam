using UnityEngine;
using System.Collections;

public class Fade_Behaviour : MonoBehaviour {

	public float fadeSpeed = 1.23f;
	public string FadeTo;
	public int Scene;
	public GameObject instantiateNext;

	void Awake () {

		GetComponent<GUITexture>().pixelInset = new Rect(Screen.width, Screen.height	, Screen.width, Screen.height);
		if (FadeTo == "Black") {
			GetComponent<GUITexture>().color = Color.clear;
		} else if (FadeTo == "Clear") {
			GetComponent<GUITexture>().color = Color.black;
		}
	}


	void Update () {
		if (FadeTo == "Black") {
			FadeToBlack();
		} else if (FadeTo == "Clear") {
			FadeToClear();
		}

	}


	void FadeToClear () {
		GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, fadeSpeed * Time.deltaTime);

		if (GetComponent<GUITexture>().color.a <= 0.0005f) {
			GetComponent<GUITexture>().color = Color.clear;
			GetComponent<GUITexture>().enabled = false;
			Destroy(gameObject);
		}
	}


	void FadeToBlack () {

		GetComponent<GUITexture>().enabled = true;
		GetComponent<GUITexture>().color = Color.Lerp (GetComponent<GUITexture>().color, Color.black, fadeSpeed * Time.deltaTime);

		if (GetComponent<GUITexture>().color.a >= 0.9999f) {
			GetComponent<GUITexture>().color = Color.black;

			if (instantiateNext != null) {
				Instantiate (instantiateNext);
			} else if (Scene == -1) {
				return;
			}

			Application.LoadLevel(Scene);
		}
	}
}