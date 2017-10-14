using UnityEngine;
using System.Collections;

public class BulletHitThing : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log ("hey I hit a thing");
		if (collision.gameObject.tag == "Block") {
			//Take away from block's health
			collision.gameObject.BroadcastMessage("dealDamage");
			DestroyImmediate (gameObject);
		}
	}
}
