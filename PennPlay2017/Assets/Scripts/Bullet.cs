using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed;
	public float xPos; 
	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3(xPos, -4.34f, 0);

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3 (xPos , gameObject.transform.position.y + speed * Time.deltaTime, 0);
		if (gameObject.transform.position.y > 7.5f) {
			DestroyImmediate (gameObject);
		}
	}
}
