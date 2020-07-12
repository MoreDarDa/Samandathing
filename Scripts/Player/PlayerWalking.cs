using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalking : MonoBehaviour
{
    Rigidbody2D rb;
	float dirX;
	public float jumpForce = 600f, moveSpeed = 5f;
	int playerLayer, platformLayer;
	bool jumpOffCoroutineIsRunning = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		playerLayer = LayerMask.NameToLayer ("Player");
		platformLayer = LayerMask.NameToLayer ("Platform");
	}
	
	// Update is called once per frame
	void Update () {
		//Moving X
		dirX = Input.GetAxis ("Horizontal");

		//Jumping
		if (Input.GetButtonDown ("Jump") && !Input.GetKey (KeyCode.DownArrow) && rb.velocity.y == 0) {
			rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Force);

		} else if (Input.GetButtonDown ("Jump") && Input.GetKey (KeyCode.DownArrow) && !jumpOffCoroutineIsRunning) {
			StartCoroutine ("JumpOff");
		}
		
		if (rb.velocity.y > 0)
			Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
		
		else if (rb.velocity.y <= 0 && !jumpOffCoroutineIsRunning)
			Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);			
	}

	// FixedUpdate is called once per FixedFramerate Frame
	void FixedUpdate()
	{
		//Move by side Important! Freez Rotate X at Rigidbody2D.
		rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y);
	}

	IEnumerator JumpOff()
	{
		//Down Jumping at platformLayer
		jumpOffCoroutineIsRunning = true;
		Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
		yield return new WaitForSeconds (0.5f);
		Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
		jumpOffCoroutineIsRunning = false;
	}
}
