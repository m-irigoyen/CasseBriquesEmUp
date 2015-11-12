using UnityEngine;
using System.Collections;

public class CommonEnemy : MonoBehaviour {

	public int m_healthPoints;
	public int m_scoreValue; //amount of points earned by destroying this enemy
	public float m_speed;
	private GameObject m_GameMode ;
	private Rigidbody2D m_rb;
	private BoxCollider2D m_hitBox;

	// Use this for initialization
	void Start () {
		m_GameMode = GameObject.FindGameObjectWithTag ("GameMode");
		m_rb = GetComponent<Rigidbody2D>();
		m_hitBox = GetComponent<BoxCollider2D>();
	}
	// Update is called once per frame
	void Update()
	{
		if (m_healthPoints <= 0) {
			//Call GameMode and give the amount of points earned by destroying the enemy
			Destroy (gameObject);
		}
	}
	// FixedUpdate is called regulary
	void FixedUpdate () {
		move ();//Move of the enemy
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.LogWarning("Collision");

		if (other.gameObject.tag == "Player") {
			//Call GameMode
			Debug.LogWarning("Player");
		}

		if (other.gameObject.tag == "Ball") {
			//Call GameMode
			Debug.LogWarning("Ball");
			m_healthPoints --;
		}
	}

	void move()
	{
		m_rb.velocity = new Vector2(-m_speed , 0);
	}
}