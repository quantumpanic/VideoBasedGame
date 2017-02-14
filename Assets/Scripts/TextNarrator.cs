using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNarrator : MonoBehaviour {

	public List<Text> textPages = new List<Text>();

	// Use this for initialization
	void Start () {
		foreach (Text page in textPages) {
			page.CrossFadeAlpha (0, 0, false);
		}
		FadeScript.FadeFromBlack ();
		Invoke ("BeginScene", 1);
	}

	// Update is called once per frame
	void Update () {
	}

	void BeginScene()
	{
		StartCoroutine (NarrateAllPages());
	}

	void EndScene()
	{
		SceneNavigator.GoToScene(nextScene);
	}

	public bool wasClicked = false;

	public void ClickNext()
	{
		wasClicked = true;
	}

	public int currentPage;
	public string nextScene;

	IEnumerator NarrateAllPages()
	{
		currentPage = 0;
		foreach (Text page in textPages) {
			if (currentPage > 0) {
				FadePreviousPage (textPages [currentPage - 1]);
				yield return new WaitForSeconds (1);
			}

			StartCoroutine (NarratePage (page));
			while (!wasClicked)
				yield return null;
			
			if (currentPage == textPages.Count - 1) {
				FadePreviousPage (page);
				yield return new WaitForSeconds (1);
			}
			currentPage++;
		}
			
		// go next scene
		FadeScript.FadeToBlack ();
		Invoke("EndScene", 2);
	}

	IEnumerator NarratePage (Text page)
	{
		wasClicked = false;
		page.CrossFadeAlpha (1, 1f, false);

		while (page.color.a > 0)
			yield return null;
	}

	void FadePreviousPage(Text page)
	{
		page.CrossFadeAlpha (0, 1f, false);
	}
}
