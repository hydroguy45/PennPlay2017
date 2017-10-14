using UnityEngine;
using System.Collections;

public class npc : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void lookAt(Transform target){
		gameObject.transform.LookAt (target);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
