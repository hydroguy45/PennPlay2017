using UnityEngine;
using System.Collections;

public class mainGame : MonoBehaviour {
	public Camera MainCamera;
	public player Player;
	protected Vector3 cameraOffset;
	public npc NPC;
	// Use this for initialization
	void Start () {
		if (Player == null) {
			Debug.Log ("You forgot to attach a player...");
		} 
		if (MainCamera == null) {
			Debug.Log ("You forgot to attach a MainCamera...");
		}
		cameraOffset = MainCamera.transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		ResolveInput ();
		ResolveNPCs ();
	}

	protected void LateUpdate(){
		RepositionCamera ();
	}

	protected void ResolveNPCs(){
		NPC.lookAt (Player.transform);	
	}

	protected void ResolveInput(){
		OnKeyDown ();
		HandleInputAxis ();
	}

	protected void RepositionCamera(){
		MainCamera.transform.position = new Vector3 (Player.transform.position.x + cameraOffset.x, cameraOffset.y, Player.transform.position.z + cameraOffset.z);
	}

	protected void HandleInputAxis(){
		float x = Input.GetAxisRaw ("Horizontal") * Time.deltaTime;
		float z = Input.GetAxisRaw ("Vertical") * Time.deltaTime;

		if (x != 0 || z != 0) {
			Player.Move (x, z);
		}
	}

	protected void OnKeyDown (){
		if (Input.GetKeyDown (KeyCode.Space)) {
			Player.Jump ();
		}
	}
}
