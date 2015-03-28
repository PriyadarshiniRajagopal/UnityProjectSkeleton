using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed;
	private int count;
	public GUIText CountText;
	public GUIText WinText;
	
	void Start()
	{
		count=0;
		WinText.text="";
		SetCountText();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal=Input.GetAxis ("Horizontal");
		float moveVertical=Input.GetAxis ("Vertical");
		Vector3 movement=new Vector3(moveHorizontal,0.0f,moveVertical);
		
		rigidbody.AddForce(movement * speed *Time.deltaTime);
	
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag=="PickUp")
		{
			other.gameObject.SetActive(false);
			count=count+1;
			SetCountText();
		}
		if(other.gameObject.tag=="Capsule")
		{
			Application.LoadLevel("Roll_A_Ball_Scene2");
		}
	}
	
	void SetCountText()
	{
			CountText.text="Count:"+count.ToString();
			if(count==6)
			WinText.text="Game Over";
	}
        
    
	
	
}
