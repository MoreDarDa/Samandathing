using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasedInfo : MonoBehaviour
{
    public int HP;
	public float speed;
	
	//start is calling at first framerate update
	void Start(){
		
	}
	
	//update is calling at every framerate
	void Update(){
		DestroyObject();
		transform.Translate(Vector2.left * speed * Time.deltaTime, Camera.main.transform);
		transform.Translate(Vector2.right * speed * Time.deltaTime, Camera.main.transform);
	}
	
	void DestroyObject(){
		if(HP <= 0) Destroy(this, 5);
	}
}