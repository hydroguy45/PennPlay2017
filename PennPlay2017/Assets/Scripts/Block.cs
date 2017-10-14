using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public int health;
	public float speed;
	private int lastFrameHealth;
	public Sprite FiveHealth;
	public Sprite FourHealth;
	public Sprite ThreeHealth;
	public Sprite TwoHealth;
	public Sprite OneHealth;
	private SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		health = 5;
		lastFrameHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		move ();
		if (health != lastFrameHealth) {
			handleDamage ();
		}
	}
	public void dealDamage(){
		health--;
	}
	void handleDamage(){
		lastFrameHealth = health;
		switch (health) {
		case 5: 
			sprite.sprite = FiveHealth;
			break;
		case 4:
			sprite.sprite = FourHealth;
			break;
		case 3:
			sprite.sprite = ThreeHealth;
			break;
		case 2:
			sprite.sprite = TwoHealth;
			break;
		case 1:
			sprite.sprite = OneHealth;
			break;
		default:
			DestroyImmediate (gameObject);
			break;
		}
	}
	void move(){
		gameObject.transform.position -= new Vector3 (0, speed * Time.deltaTime, 0);
	}
}
