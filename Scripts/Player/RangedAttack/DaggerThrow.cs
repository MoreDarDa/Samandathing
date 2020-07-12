using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerThrow : MonoBehaviour
{
	public GameObject Dagger;
	private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("DaggerPosition");
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetButtonDown("ThrowDagger")){
			GameObject bullet = Instantiate(Dagger, Player.transform.position, Quaternion.identity);
		}
    }
}
