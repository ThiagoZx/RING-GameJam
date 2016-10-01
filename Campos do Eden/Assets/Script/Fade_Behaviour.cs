using UnityEngine;
using System.Collections;

public class Fade_Behaviour : MonoBehaviour {

	public float aTime;

	void Update() {
		if(Input.GetKeyUp(KeyCode.P)){
			StartCoroutine (FadeOut());
		} else if(Input.GetKeyUp(KeyCode.O)) {
			StartCoroutine (FadeIn());
		}
	}

	public IEnumerator FadeOut(){
		for (float i = 0; i < 1; i += Time.deltaTime / aTime) {
			Color fadingColor = new Color (0, 0, 0, Mathf.Lerp(0, 1, i));
			GetComponent<SpriteRenderer> ().color = fadingColor;
			yield return null;
		}
	}

	public IEnumerator FadeIn(){
		for (float i = 0; i < 1; i += Time.deltaTime / aTime) {
			Color fadingColor = new Color (0, 0, 0, Mathf.Lerp(1, 0, i));
			GetComponent<SpriteRenderer> ().color = fadingColor;
			yield return null;
		}
	}
}