using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	private float mousePosInBlocks;
	private Vector3 paddlePos;
	private Ball ball;
	public bool autoPlay=false;
	
	public float maxPaddleX=29f;
	public float minPaddleX=11f;
	// Use this for initialization
	
	void Start () {
		paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		ball=GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(autoPlay==false)
		{
			MoveWithMouse ();
		}		
		else 
		{
			AutoPlay();
		}
					
	}
	void AutoPlay()
	{
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minPaddleX, maxPaddleX);
		this.transform.position = paddlePos;
	}
	void MoveWithMouse()
	{
		mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks+12, minPaddleX, maxPaddleX);
		
		this.transform.position = paddlePos;
	}
}