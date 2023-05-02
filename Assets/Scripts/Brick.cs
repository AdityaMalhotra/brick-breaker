using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int timesHit;
	private LevelManager levelManager;
	bool isBreakable;
	
	public GameObject smoke;
	public AudioClip destruction;
	public AudioClip crackSound;
	public static int breakableCount=0;
	public Sprite[] hitSprites;
	
	void Start () {
		isBreakable= (this.tag=="Breakable");
		//keep track of total breakable bricks
		if(isBreakable)
		{
			breakableCount++;
		}
		timesHit=0;
		levelManager=GameObject.FindObjectOfType<LevelManager>();
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		
		if(isBreakable)
		{
			HandleHits();
		}
		else 
		{
			AudioSource.PlayClipAtPoint(crackSound,transform.position);
		}
	}
	void HandleHits()
	{	
		timesHit++;
		int maxHits=hitSprites.Length+1;
		if(timesHit>=maxHits)
		{
			AudioSource.PlayClipAtPoint(destruction,transform.position);
			breakableCount--;
			PuffSmoke ();
			Destroy (gameObject);
			LevelManager.BrickDestroyed();
		}
		else 
		{
			AudioSource.PlayClipAtPoint(crackSound,transform.position);
			LoadSprites();
		}
	}
	void PuffSmoke()
	{
		GameObject smokePuff= Object.Instantiate (smoke,gameObject.transform.position,Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor=gameObject.GetComponent<SpriteRenderer>().color;
	}
	void LoadSprites()
	{
		int spriteIndex=timesHit-1;
		if(hitSprites[spriteIndex]){
		this.GetComponent<SpriteRenderer>().sprite=hitSprites[spriteIndex];
		}
		else{
			Debug.LogError ("Sprites not chosen!");
		}
	}
}
