using UnityEngine;
using System.Collections;

public class Moviment_Behaviour : MonoBehaviour {

	public float StartWait;
	bool deliverHeart = false;
	bool walkTo = false;
	GameObject fader;

	void Start() {
		fader = GameObject.Find ("Fader");
		StartCoroutine ("EnterJudgment");
	}

	void Update () {
		if (walkTo) {
			ComeAtOsiris ();
		}
		if (deliverHeart) {
			HeartToOsiris ();
		}
	}

	IEnumerator EnterJudgment(){
		GetComponent<Animator> ().enabled = false;
		yield return new WaitForSeconds (StartWait);
		GetComponent<Animator> ().enabled = true;
		walkTo = true;
	}

	IEnumerator LookAtOsiris(){
		GetComponent<Animator> ().enabled = false;
		yield return new WaitForSeconds (2);
		if (gameObject.name == "Anubis") {
			walkTo = false;
			deliverHeart = true;
		}
	}

	void ComeAtOsiris(){
		if (transform.position.y > -1.02f && gameObject.name != "Balança") {
			transform.position = new Vector2 (transform.position.x, transform.position.y - 0.01f);
			transform.localScale = new Vector2 (transform.localScale.x + 0.0012f, transform.localScale.y + 0.0012f);
		} else if (transform.position.y > 2 && gameObject.name == "Balança") {
			transform.position = new Vector2 (transform.position.x, transform.position.y - 0.01f);
		} else {
			StartCoroutine ("LookAtOsiris");
		}
	}

	void HeartToOsiris(){
		GetComponent<Animator> ().enabled = true;
		if (transform.position.x < 2.8f) {
			transform.position = new Vector2 (transform.position.x + 0.015f, transform.position.y);
		} else {
			StartCoroutine ("AnubisAtWill");		
		}
			//GetComponent<Animator> ().enabled = false;
			//StartCoroutine (fader.GetComponent<Fade_Behaviour>().FadeOut());
		
	}

	IEnumerator AnubisAtWill(){
		GetComponent<Animator>().Play("Anubis_Smash");
		yield return new WaitForSeconds (1.4f);
		GetComponent<Animator> ().enabled = false;
	}
}
