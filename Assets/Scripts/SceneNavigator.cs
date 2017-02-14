using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour {

	public static SceneNavigator Instance;

	public static List<int> sceneNums = new List<int> ();

	public static void NewSceneRoute(string scene)
	{
		sceneNums.Clear ();
		GoToScene (scene);
	}

	static void AddScene(Scene scene)
	{
		sceneNums.Add (scene.buildIndex);
	}

	static void AddCurrentScene()
	{
		AddScene (SceneManager.GetActiveScene ());
	}

	public static void GoToScene(string scene)
	{
		AddScene (SceneManager.GetSceneByName (scene));
		SceneManager.LoadScene (scene);
	}

	public static void ReturnToPrevScene()
	{
		sceneNums.RemoveAt (sceneNums.Count - 1);
		SceneManager.LoadScene (sceneNums [sceneNums.Count - 1]);
	}
}
