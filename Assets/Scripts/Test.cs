using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		FadeScript.FadeFromBlack ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Go(int num)
	{
		//UnityEngine.SceneManagement.SceneManager.LoadScene ("ARS");

		switch (num) {
		case 1:
			FadeScript.FadeToBlack ();
			Invoke ("PlayGame", 1);
			break;
		case 2:
			FadeScript.FadeToBlack ();
			Invoke ("QuitGame", 1);
			break;
		}
	}

	void PlayGame()
	{
		SceneNavigator.NewSceneRoute ("Interlude_0");
	}

	void QuitGame()
	{
		Application.Quit ();
	}
}
