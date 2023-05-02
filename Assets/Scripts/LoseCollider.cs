using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	private LevelManager levelManager;
	void Start()
	{
		levelManager=GameObject.FindObjectOfType<LevelManager>();
	}
	void OnTriggerEnter2D(Collider2D x)
	{
		Brick.breakableCount=0;
		print ("Trigger: " + x);
		levelManager.LoadLevel ("Lose Screen");
		
	}
}
