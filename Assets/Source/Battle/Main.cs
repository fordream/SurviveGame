using UnityEngine;
using System.Collections;
/*UI周りをいじるとき必要*/
using UnityEngine.UI;

public class Main : MonoBehaviour {
	public t_box t;
	/*触っちゃいけない方　小数点以下を評価するときに使う　読み取り専用*/
	private float main_game_time;
	/*Time表示用の時間計測変数　秒ごとを数える*/
	private float main_game_time2;
	public float p_time;
	public float e_time;

	/*Time用,Stage用のcount変数*/
	public Text Time_text;
	public Text Stage_text;
	private int second_time = 0;
	private int minute_time = 0;

	/*Mode change用にCube_managerを取得しておく*/
	public GameObject cubemanager;

	// Use this for initialization
	void Start () {
		cubemanager = GameObject.Find ("Cube_manager");
		/*mode change*/
		cubemanager.GetComponent<Cube_manager> ().change_mode ("hard");

	}
	
	// Update is called once per frame
	void Update () {
		main_game_time += Time.deltaTime;
		main_game_time2 += Time.deltaTime;
		p_time += Time.deltaTime;
		e_time += Time.deltaTime;

		Update_Timetext ();
	}

	public void Update_Timetext() {
		second_time = (int)main_game_time2;
		if(second_time >= 60) {
			minute_time ++;
			second_time = 0;
			main_game_time2 = 0;
		}
		if (second_time <= 9) {
			Time_text.text = "Time " + minute_time + ":0" + second_time;
		}
		else {
			Time_text.text = "Time " + minute_time + ":" + second_time;
		}
	}
	public float get_m_time() {
		return main_game_time;
	}
	public float get_e_time() {
		return e_time;
	}
	public void change_e_time(float time) {
		e_time = time;
	}
}








