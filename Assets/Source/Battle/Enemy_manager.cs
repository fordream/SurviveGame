using UnityEngine;
using System.Collections;

public class Enemy_manager : MonoBehaviour {
	/*連想配列テーブル*/
	public Hashtable table;

	/*Enemyscriptを取得するためのオブジェクト*/
	private GameObject enemy_script;

	/*Enemy Object*/
	public GameObject enemy;
	public GameObject goburin;
	/*Enemyは随時追加*/

	void InitEnemy() {
		table = new Hashtable ();
		table.Add ("Enemy", enemy);
		table.Add ("Goburin", goburin);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void change_c_time(float time,GameObject _enemy, string enemy_name) {
		if (enemy_name == "Enemy") {
			_enemy.GetComponent<Enemy>().change_e_time(time);
		} else if (enemy_name == "Goburin") {
			_enemy.GetComponent<Goburin>().change_e_time(time);
		}
			
	}
}






