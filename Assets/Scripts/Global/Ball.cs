using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	public float m_baseSpeed;

	GameMode m_gameMode;
	float m_currentSpeed;
	Rigidbody m_rigidbody;

	void Start () 
	{
		m_rigidbody = GetComponent<Rigidbody> ();
		m_gameMode = GameObject.FindGameObjectWithTag (Tags.m_gameMode).GetComponent<GameMode>();
		m_currentSpeed = m_baseSpeed;
		m_rigidbody.AddForce (new Vector3(1, 1, 0) * m_currentSpeed);
	}

	void Update ()
	{
		m_rigidbody.velocity = m_rigidbody.velocity.normalized * m_currentSpeed;
	}

	public float getSpeed()
	{
		return m_currentSpeed;
	}

	public void setSpeed(float p_speed)
	{
		m_currentSpeed = p_speed;
	}
	
	//TODO: loseLife : Remove a life to the player, maybe prepare a new ball or end the game
	//public void loseLife()
	void onTriggerEnter(Collider other)
	{
		if (other.CompareTag (Tags.m_floor)) 
		{// Trigger with the left boundary --> lose a life
			m_gameMode.loseLife();
			Destroy(gameObject);
		}
	}
	
	//TODO: killEnemy : Kill an enemy : update the score, end the level ?, pop new wayve, ...
	//public void killEnemy()
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag (Tags.m_enemies)) 
		{// Collision with enemis --> destroy enemis
			m_gameMode.killEnemy();
			Destroy(collision.gameObject);
		}
	}
}
