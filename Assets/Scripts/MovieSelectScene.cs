using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieSelectScene : MonoBehaviour {

	public bool playOnStart;

	// Use this for initialization
	void Start () {
		if (playOnStart)
			PlayOnStart ();
		FadeScript.FadeFromBlack ();
	}

	// Update is called once per frame
	void Update () {
	}

	public string currentMoviePath;
	public string nextScene;

	void PlayOnStart()
	{
		PlayMovie ();
	}

	public void PlayerChoseMovie(VideoInfo vidInfo)
	{
		currentMoviePath = vidInfo.videoPath;
		nextScene = vidInfo.sceneRoute;
		PlayMovie ();
	}

	void PlayMovie()
	{
		if (currentMoviePath == "")
			return;

		FadeScript.FadeToBlack();
		if (currentMoviePath.Contains ("http")) {
			Invoke ("MovieStreaming", 1);
		} else {
			Invoke ("DoMoviePlayback", 1);
		}
	}

	void MovieStreaming()
	{
		Handheld.PlayFullScreenMovie(currentMoviePath,Color.black, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.AspectFill);

		// Do After Movie
		DoAfterMovie();
	}

	void DoAfterMovie()
	{
		if (nextScene != "") {
			SceneNavigator.GoToScene (nextScene);
		}
	}

	void DoMoviePlayback()
	{
		StartCoroutine (MoviePlayback ());
	}

	IEnumerator MoviePlayback()
	{
		Handheld.PlayFullScreenMovie (currentMoviePath, Color.black, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.AspectFill);

		yield return new WaitForEndOfFrame ();

		// Do After Movie
		DoAfterMovie();
	}
}
