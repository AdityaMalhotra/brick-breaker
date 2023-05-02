using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {	


	static MusicPlayer instance=null;
	// Use this for initialization
	void Awake()
	{
		Debug.Log ("Music player AWAKE" + GetInstanceID());
		if(instance!=null)
		{
			Destroy (gameObject);
			print ("Duplicate Player self destructing");
		}
		else{
			instance=this;
			GameObject.DontDestroyOnLoad(gameObject);}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
