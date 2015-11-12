using UnityEngine;
using System.Collections;

public class UILibrary : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // On clicked buttonNewGame or PlayAgain
    public void newGame()
    {
		// Load the Game scene
		Application.LoadLevel (2);
    }

    // On clicked option
    public void options()
    {
		Application.LoadLevel (1);
    }

    // On clicked quitGame
    public void quitGame()
    {
        Application.Quit();
    }

	// On clicked Menu
	public void mainMenu()
	{
		// Load the menu scene
		Application.LoadLevel (1);
	}
}
