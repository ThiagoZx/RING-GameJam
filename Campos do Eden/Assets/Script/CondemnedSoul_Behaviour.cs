using UnityEngine;
using System.Collections;

public class CondemnedSoul_Behaviour : MonoBehaviour {

	bool deliverHeart = false;
	GameObject fader;

	void Start() {
		fader = GameObject.Find ("Fader");
	}

	void Update () {
		if (!deliverHeart) {		
			ComeAtOsiris ();
		} else {
			HeartToOsiris ();
		}
	}

	IEnumerator LookAtOsiris(){
		GetComponent<Animator> ().enabled = false;
		yield return new WaitForSeconds (2);
		deliverHeart = true;
	}

	void ComeAtOsiris(){
		if (transform.position.y > -1.4f) {
			transform.position = new Vector2 (transform.position.x, transform.position.y - 0.01f);
		} else {
			StartCoroutine ("LookAtOsiris");
		}
	}

	void HeartToOsiris(){
		GetComponent<Animator> ().enabled = true;
		if (transform.position.x < 5.5f) {
			transform.position = new Vector2 (transform.position.x + 0.015f, transform.position.y);
		} else {
			GetComponent<Animator> ().enabled = false;
			StartCoroutine (fader.GetComponent<Fade_Behaviour>().FadeOut());
		}
	}
}
