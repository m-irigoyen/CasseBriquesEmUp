using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour {

	private int m_score = 0;
	private int m_playerHealth = 3;
	private bool m_isPaused = false;
	private GameObject m_hud;
	private GameObject m_player;
	private GameObject[] m_enemiesSpawner;
	
	/*	-----
		Return :
		Parameters :
		Function behavior : Function called at the creation of the game
	*/
	void Start () 
	{
		m_player = GameObject.FindGameObjectWithTag (Tags.m_player);
	}

	/*	-----
		Return :
		Parameters :
		Function behavior : Function called every frame
	*/
	void Update () 
	{
		if (Input.GetButtonUp(PlayerInputs.m_pause))
		{
			switchPause();
		}
	}

	/*	-----
		Return :
		Parameters :
		Function behavior : Update the hud with all values saved in the game mode
	*/
	void updateHud()
	{

	}

	/*	-----
		Return :
		Parameters :
		Function behavior : Function called to update the health of the player
	*/
	public void setHealthPlayer()
	{
	
	}

	/*	-----
		Return :
		Parameters :
		Function behavior : Function that pause and unpaused the game
	*/
	void switchPause()
	{
		if (m_isPaused)
		{
			m_isPaused = false;
			Time.timeScale = 1.0f;
			//TODO : disable player inputs
		} 
		else
		{
			m_isPaused = true;
			Time.timeScale = 0;
			//TODO : enable player inputs
		}
	}

	/*	-----
		Return :
		Parameters :
			p_score (int) : Amount of points to add to the players score
		Function behavior : Add a certain amount to the current score of the players
	*/
	public void updateScore(int p_score)
	{

	}
}