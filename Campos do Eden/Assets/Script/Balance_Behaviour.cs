using UnityEngine;
using System.Collections;

public class Balance_Behaviour : MonoBehaviour {

	bool start = false;

	void Start () {
		GetComponent<Animator> ().enabled = false;
		StartCoroutine ("BalanceDown");
	}
	
	IEnumerator BalanceDown(){
		yield return new WaitForSeconds (16);
		start = true;
	}

	void Update() {
		if (start) {
			MoveDown ();
		}
	}

	void MoveDown(){
		if (transform.position.y > 2.14) {
			transform.position = new Vector2 (transform.position.x, transform.position.y - 0.01f);
		} else {
			GetComponent<Animator> ().enabled = true;
		}
	}
}
