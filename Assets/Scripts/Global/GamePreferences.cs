using UnityEngine;
using System.Collections;

public class GamePreferences : MonoBehaviour {

	public const string m_firstLaunch = "FirstGameLaunch";

	public const string m_highScore = "HighScore";


	/*	-----
		Return :
		Parameters :
		Function behavior : For the first launch of the game, this function is used to initialize all player preferences that will be needed.
	*/
	public void initPlayerPreferences()
	{
		PlayerPrefs.SetInt (GamePreferences.m_firstLaunch, 1);
	}

	/*	-----
		Return :
			int - get the high score saved in the memory
		Parameters :
		Function behavior : Returns the high score that is saved in the player preferences
	*/
	public int getHighScore()
	{
		return PlayerPrefs.GetInt(GamePreferences.m_highScore);
	}

}
