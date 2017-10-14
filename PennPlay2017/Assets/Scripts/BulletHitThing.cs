using UnityEngine;
using System.Collections;

public class BulletHitThing : MonoBehaviour {
	private GameObject parent;
	private bool timeToDie = false;
	void Start(){
		parent = gameObject.transform.parent.gameObject;
	}
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Block") {
			//Take away from block's health
			collision.gameObject.BroadcastMessage("dealDamage");
			timeToDie = true;
		}
	}
	void Update(){
		if (timeToDie) {
			DestroyImmediate (parent);
		}
	}
}
