using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	//public int currentLevel;
	private void Start()
	{
	//	currentLevel=1;
	}
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
//		if(Application.loadedLevel<= 0|| Application.loadedLevel!=3||Application.loadedLevel!=4)
//		{
//			currentLevel=Application.loadedLevel+1;
//		}
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	public static void LoadNextLevel()
	{
		Application.LoadLevel (Application.loadedLevel+1);
	}
//	public void LoadSameLevel()
//	{
//		Application.LoadLevel (currentLevel);
//	}
	public static void BrickDestroyed()
	{
		if(Brick.breakableCount<=0){
			LoadNextLevel ();
			}
	}
}
