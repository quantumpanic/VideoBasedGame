using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVid : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (PlayMovie ());
		//DoPlayMovie ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator PlayMovie()
	{
		Handheld.PlayFullScreenMovie ("guitar.mp4");

		yield return new WaitForEndOfFrame ();

		UnityEngine.SceneManagement.SceneManager.LoadScene (0);
	}

	void DoPlayMovie()
	{
		Handheld.PlayFullScreenMovie ("guitar.mp4");
	}
}
