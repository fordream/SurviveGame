using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	/*Enemy情報*/
	private int HP = 5;
	public float e_time;


	//command
	private const int UP = 0;
	private const int DOWN = 1;
	private const int RIGHT = 2;
	private const int LEFT = 3;
	private GameObject player;
	private GameObject attack_manager;
	bool isRunningBehave = false;
	bool isRunningMove = false;
	bool isRunningAttack = false;
	bool flag;
	
	
	//public Attack attack; //攻撃用メソッドAttack()
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		attack_manager = GameObject.Find ("Attack_manager");
	}
	
	// Update is called once per frame
	void Update () {
		e_time += Time.deltaTime;
		flag = isRunningBehave | isRunningMove | isRunningAttack;
		if(!flag) behave();
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
				//Application.LoadLevel ("ClearResult");
			}
		}
	}
	//どの動作を選ぶか
	void behave (){
		int range = 1; //攻撃範囲
		Vector3 position = transform.position;
		Vector3 PlayerPosition = player.transform.position;
		Vector3 delta_position = PlayerPosition - position;
		
		isRunningBehave = true;
		
		//Enemyの動作
		
		//足場が崩れる->移動(ネガティブ)
		//if(足場が崩れる間際) まわりの安全な場所に移動;
		
		
		if((int)System.Math.Abs (delta_position.x) <= range*50 
		   && (int)System.Math.Abs (delta_position.y) <= range*50){
			//敵が近い->攻撃
			isRunningAttack = true;
			attack(delta_position);
			isRunningAttack = false;
		}else {
			//敵が遠く安全->移動(ポジティブ)
			move (delta_position);
		}
		
		isRunningBehave = false;
	}
	
	void attack(Vector3 delta_Position){
		Vector3 position = transform.position;
		attack_information atk = new attack_information();
		atk.g_time = e_time;
		atk.position = position;
		atk.P_or_E = "E";
		atk.name = gameObject;
		atk.Scriptname = "Enemy";
		attack_manager.GetComponent<Attack>().fire_attack(atk);
	}
	
	//最短移動距離の計算
	void move(Vector3 delta_position){
		
		if ((int)delta_position.x > 0) {
			print("right");
			StartCoroutine(step (RIGHT));
		} else if ((int)delta_position.x < 0) {
			print("left");
			StartCoroutine(step (LEFT));
		}else{
			if ((int)delta_position.y > 0) {
				print("up");
				StartCoroutine(step (UP));
			} else if ((int)delta_position.y < 0) {
				print("down");
				StartCoroutine( step (DOWN));
			}
		}
	}
	
	//1歩移動
	//int direction ; 方向(UP, DOWN, RIGHT, LEFT)
	IEnumerator step(int direction){
		Vector3 position = transform.position;
		
		isRunningMove = true;
		
		switch (direction) {
		case UP:
			if (position.y < 0)
				position.y += 50f;
			break;
		case DOWN:
			if (position.y > -350)
				position.y -= 50f;
			break;
		case RIGHT:
			if (position.x < 250)
				position.x += 50f;
			break;
		case LEFT:
			if (position.x > 0)
				position.x -= 50f;
			break;
		}
		gameObject.transform.position = position;
		yield return new WaitForSeconds (1.0f);
		//print("position: "+ position);
		isRunningMove = false;
	}
}
