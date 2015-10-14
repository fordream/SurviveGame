using UnityEngine;
using System.Collections;
using System;
/*UI周りをいじるとき必要*/
using UnityEngine.UI;


public class Player : MonoBehaviour {
	public Text HP_text;
	/*Playerの時間を取得*/	
	private float p_time;

	private static int Max_HP = 5;
	private int Current_HP = Max_HP;
	private int MP = 10;


	private GameObject attack;

	// Use this for initialization
	void Start () {
		//Attack_managerからプログラムを取得する
		attack = GameObject.Find ("Attack_manager");
	}

	// Update is called once per frame
	void Update () {
		p_time += Time.deltaTime;
		//現在位置を取得
		Vector3 position = transform.position;

		/*attackプログラムに渡す引数をまとめる*/
		attack_information atk = new attack_information();
		atk.g_time = p_time;
		atk.position = position;
		atk.P_or_E = "P";
		atk.name = gameObject;
		atk.Scriptname = "Player";

		player_attack (atk);
		player_move (position);
		Player_HP_Update ();

	}
	/*Player attack*/
	private void player_attack(attack_information atk) {
		if (Input.GetKey (KeyCode.Z)) {
			/*ファイア周囲1を起動*/
			attack.GetComponent<Attack>().fire_attack(atk);
		}
	}
	/*Player move*/
	private void player_move (Vector3 position) {
		/*矢印キーによる操作のコード　斜め移動も対応している*/
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			position.x += 50f;
		} 
		else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			position.x -= 50f;
		} 
		else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			position.y += 50f;
		} 
		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			position.y -= 50f;
		} 
		gameObject.transform.position = position;
	}
	private void Player_HP_Update () {
		HP_text.text = "P1 HP " + Current_HP + "/" + Max_HP;
	}
	public int get_p_HP() {
		return Current_HP;
	}
	public int get_p_MP() {
		return MP;
	}
	public void change_p_time(float time) {
		p_time = time;
	}
	/*被ダメ判定　被ダメエフェクト*/
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag("e_attackCube") || col.gameObject.CompareTag("Enemy") ||col.gameObject.CompareTag("damage_area") ) {
			Current_HP -= 1;
			if(Current_HP == 0) {
				//Instantiate(explosionPrehab,transform.position,transform.rotation);
				GameOver();
				Destroy(gameObject);
			}
		}
	}
	void GameOver() {
		Invoke("GameOverScene",0);
	}

	void GameOverScene() {
		Application.LoadLevel ("GameOver");
	}
}





