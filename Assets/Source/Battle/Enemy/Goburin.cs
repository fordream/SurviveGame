using UnityEngine;
using System.Collections;

public class Goburin : MonoBehaviour {
	/*Enemy情報*/
	private int HP = 5;
	public float e_time;
	
	
	//command
	private const int UP = 0;
	private const int DOWN = 1;
	private const int RIGHT = 2;
	private const int LEFT = 3;
	private GameObject attack_manager;
	bool flag;
	
	
	//public Attack attack; //攻撃用メソッドAttack()
	
	// Use this for initialization
	void Start () {
		attack_manager = GameObject.Find ("Attack_manager");
	}
	
	// Update is called once per frame
	void Update () {
		e_time += Time.deltaTime;
		attack();
	}
	public void change_e_time(float time) {
		e_time = time;
	}
	/*被ダメ判定　被ダメエフェクト*/
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag("p_attackCube")) {
			HP -= 1;
			if(HP == 0) {
				//Instantiate(explosionPrehab,transform.position,transform.rotation);
				Destroy(gameObject);
			}
		}
	}

	
	void attack(){
		attack_information atk = new attack_information();
		atk.g_time = e_time;
		atk.position = transform.position;
		atk.P_or_E = "E";
		atk.name = gameObject;
		atk.Scriptname = "Goburin";
		atk.intervaltime2 = 2.0f;
		attack_manager.GetComponent<Attack>().fire_attack(atk);
	}
}
