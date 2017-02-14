using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour {

	public static FadeScript Instance;

	void Awake()
	{
		if (!Instance == this)
			Instance = this;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void FadeToBlack()
	{
		Instance.GetComponent<Image> ().CrossFadeAlpha (1, 1, false);
	}

	public static void FadeFromBlack()
	{
		Instance.GetComponent<Image> ().CrossFadeAlpha (0, 1, false);
	}
}
