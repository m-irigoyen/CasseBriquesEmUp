﻿using UnityEngine;
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
	
	/*	-----
		Return :
			speed (float) : the current ball speed
		Parameters :
		Function behavior : return the current speed value
	*/
	public float getSpeed()
	{
		return m_currentSpeed;
	}
	
	/*	-----
		Return :
		Parameters :
			p_speed (float) : the new speed
		Function behavior : set a new speed value
	*/
	public void setSpeed(float p_speed)
	{
		m_currentSpeed = p_speed;
	}
	
	/*	-----
		Return :
		Parameters :
			p_v3 (Vector3) : the new direction of the ball 
		Function behavior : Add a force to the ball with the input v3 direction
	*/
	public void setForce(Vector3 p_v3)
	{
		m_rigidbody.velocity = Vector3.zero;
		m_rigidbody.AddForce (p_v3 * m_currentSpeed);
	}
	
	//TODO: loseLife : Remove a life to the player, maybe prepare a new ball or end the game
	//public void loseLife()
	void onTriggerEnter(Collider other)
	{
		if (other.CompareTag (Tags.m_floor)) 
		{// Trigger with the left boundary --> lose a life
			m_gameMode.setHealthPlayer(-1);
			Destroy(gameObject);
		}
	}
}
