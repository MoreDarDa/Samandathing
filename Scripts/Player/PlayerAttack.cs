using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	public float AttackDealay;
	public float AttackDealayValue;
	
	public Transform AttackPos;
	public float AttackRangeX;
	public float AttackRangeY;
	public LayerMask Enemies;
	
	private Vector2 AttackRange;
	private PlayerStats Stat;
    // Start is called before the first frame update
    void Start()
    {
		AttackRange = new Vector2(AttackRangeX, AttackRangeY);
		Stat = gameObject.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
		if(AttackDealay <= 0){
			//MeleeAttack default setting is Mouse 0(left click)
			if(Input.GetButtonDown("MeleeAttack")){
				Collider2D[] hitenemies =  Physics2D.OverlapBoxAll(AttackPos.position, AttackRange, 0f, Enemies);
				for (int i = 0; i < hitenemies.Length; i++){
					hitenemies[i].GetComponent<BasedInfo>().HP -= Stat.ATP;
				}
			}
			AttackDealay = AttackDealayValue;
		} else {
			AttackDealay -= Time.deltaTime;
		}
    }
}
