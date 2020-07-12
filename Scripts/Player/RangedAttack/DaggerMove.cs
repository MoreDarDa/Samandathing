using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerMove : MonoBehaviour
{
	public float speed = 10f;
	public bool Movingleft;
	
	private Rigidbody2D rb;
	private PlayerStats Stat;
    // Start is called before the first frame update
    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
        Stat = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Movingleft){
			rb.AddForce(Vector2.left * speed * Time.deltaTime);
		}
		else {
			rb.AddForce(Vector2.right * speed * Time.deltaTime);
		}
    }
	
	//calls When hits something
	void OnCollisionEnter2D(Collision2D coll){
		//if it is enemy
		if(coll.gameObject.tag == "Enemy"){
			//deals damage
			coll.gameObject.GetComponent<BasedInfo>().HP -= Stat.ATP;
		}
		//Destory Dagger
		Destroy(gameObject);
	}
}
