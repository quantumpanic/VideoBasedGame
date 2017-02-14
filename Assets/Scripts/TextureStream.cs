using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextureStream : MonoBehaviour {

	public List<Sprite> streamedFrames = new List<Sprite> (30);
	private int frameMarker = 0;
	public Sprite currentFrame;

	public string sampleUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a4/Xacti-AC8EX-Sample_video-001.ogv";

	// Use this for initialization
	void Start () {
		FadeScript.FadeFromBlack ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void NextFrame()
	{
		frameMarker++;
		if (frameMarker >= streamedFrames.Count) {
			frameMarker = 0;
		}

		currentFrame = streamedFrames [frameMarker];
	}

	void ShowCurrentFrame()
	{
	}

	public void SampleButtonClick()
	{
		DoStreamedPlayback (sampleUrl);
	}

	void DoStreamedPlayback(string url)
	{
		StartCoroutine (StreamedPlayback (url));
	}

	//MovieTexture mt;

	IEnumerator StreamedPlayback(string url)
	{
		var www = new WWW(url);
		yield return null;
//		mt = UnityEngine.WWWAudioExtensions.GetMovieTexture (www);
//		while (!mt.isReadyToPlay) {
//			print ("downloading......");
//			yield return www;
//			print (www.size);
//		}
		print ("done downloading");

		if (string.IsNullOrEmpty(www.error))
		{
			//var filebytes = www.bytes;
			//MemoryStream stream = new MemoryStream(filebytes);

			// ADD STREAMING LOGIC HERE
		}
		else
		{
			Debug.Log(string.Format("An error occurred while downloading the file: {0}", www.error));
			CancelPlayback ();
		}
	}

	void DoAfterPlayback()
	{
		FadeScript.FadeToBlack ();
	}

	void CancelPlayback()
	{
	}
}
