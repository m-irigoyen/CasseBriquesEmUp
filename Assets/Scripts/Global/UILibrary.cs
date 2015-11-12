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

    // On clicked buttonNewGame
    public void newGame()
    {
		Application.LoadLevel (2);
    }

    // On clicked buttonNewGame
    public void options()
    {
		Application.LoadLevel (1);
    }

    // On clicked buttonNewGame
    public void quitGame()
    {
        Application.Quit();
    }
}
