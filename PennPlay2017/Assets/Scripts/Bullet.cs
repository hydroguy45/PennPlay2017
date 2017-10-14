using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed;
	public float xPos; 
	private BoxCollider2D bulletCollider;
	private int blockLayer;
	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3(xPos, -4.34f, 0);
		bulletCollider = GetComponentInChildren<BoxCollider2D> ();
		blockLayer = LayerMask.NameToLayer ("Blocks");

	}
	// Update is called once per frame
	void Update () {
		if (bulletCollider.IsTouchingLayers (blockLayer)) {
			Debug.Log ("YAYAYA");
		}

		gameObject.transform.position = new Vector3 (xPos , gameObject.transform.position.y + speed * Time.deltaTime, 0);
		if (gameObject.transform.position.y > 7.5f) {
			DestroyImmediate (gameObject);
		}
	}
}
