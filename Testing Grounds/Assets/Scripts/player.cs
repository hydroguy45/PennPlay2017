using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public Rigidbody RigidBody;
	protected float speed = 6f;
	protected Vector3 movementDirection;
	public void Move(float x, float z){
		movementDirection.Set (x * speed, 0f, z * speed);
		RigidBody.MoveRotation (Quaternion.LookRotation (movementDirection));
		RigidBody.MovePosition (gameObject.transform.position + movementDirection);
	}
	public void Jump(){
		RigidBody.AddForce (gameObject.transform.up * 5f, ForceMode.Impulse);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
