using UnityEngine;
using System.Collections;

public class Cube_manager : MonoBehaviour {
	//main_game_time
	private float main_game_time;

	//Mode change
	public static float easy_mode = 1.1f;
	public static float normal_mode = 0.8f;
	public static float hard_mode = 0.8f;
	public float mode = easy_mode;

	//ランダムにCubeを決定する
	int y1 = 1;
	int x1 = 1;
	private t_box t1;

	/*連想配列テーブル*/
	public Hashtable table;

	/*Cubeオブジェクト*/
	private GameObject cube;
	
	/*mainオブジェクト*/
	private GameObject main;

	/*CubeObject*/
	public GameObject Cube11;
	public GameObject Cube12;
	public GameObject Cube13;
	public GameObject Cube14;
	public GameObject Cube15;
	public GameObject Cube16;
	
	public GameObject Cube21;
	public GameObject Cube22;
	public GameObject Cube23;
	public GameObject Cube24;
	public GameObject Cube25;
	public GameObject Cube26;
	
	public GameObject Cube31;
	public GameObject Cube32;
	public GameObject Cube33;
	public GameObject Cube34;
	public GameObject Cube35;
	public GameObject Cube36;
	
	public GameObject Cube41;
	public GameObject Cube42;
	public GameObject Cube43;
	public GameObject Cube44;
	public GameObject Cube45;
	public GameObject Cube46;
	
	public GameObject Cube51;
	public GameObject Cube52;
	public GameObject Cube53;
	public GameObject Cube54;
	public GameObject Cube55;
	public GameObject Cube56;
	
	public GameObject Cube61;
	public GameObject Cube62;
	public GameObject Cube63;
	public GameObject Cube64;
	public GameObject Cube65;
	public GameObject Cube66;
	
	public GameObject Cube71;
	public GameObject Cube72;
	public GameObject Cube73;
	public GameObject Cube74;
	public GameObject Cube75;
	public GameObject Cube76;
	
	public GameObject Cube81;
	public GameObject Cube82;
	public GameObject Cube83;
	public GameObject Cube84;
	public GameObject Cube85;
	public GameObject Cube86;

	void BirthCube() {
		table = new Hashtable ();
		table.Add ("Cube11", Cube11);
		table.Add ("Cube12", Cube12);
		table.Add ("Cube13", Cube13);
		table.Add ("Cube14", Cube14);
		table.Add ("Cube15", Cube15);
		table.Add ("Cube16", Cube16);
		
		table.Add ("Cube21", Cube21);
		table.Add ("Cube22", Cube22);
		table.Add ("Cube23", Cube23);
		table.Add ("Cube24", Cube24);
		table.Add ("Cube25", Cube25);
		table.Add ("Cube26", Cube26);
		
		table.Add ("Cube31", Cube31);
		table.Add ("Cube32", Cube32);
		table.Add ("Cube33", Cube33);
		table.Add ("Cube34", Cube34);
		table.Add ("Cube35", Cube35);
		table.Add ("Cube36", Cube36);
		
		table.Add ("Cube41", Cube41);
		table.Add ("Cube42", Cube42);
		table.Add ("Cube43", Cube43);
		table.Add ("Cube44", Cube44);
		table.Add ("Cube45", Cube45);
		table.Add ("Cube46", Cube46);
		
		table.Add ("Cube51", Cube51);
		table.Add ("Cube52", Cube52);
		table.Add ("Cube53", Cube53);
		table.Add ("Cube54", Cube54);
		table.Add ("Cube55", Cube55);
		table.Add ("Cube56", Cube56);
		
		table.Add ("Cube61", Cube61);
		table.Add ("Cube62", Cube62);
		table.Add ("Cube63", Cube63);
		table.Add ("Cube64", Cube64);
		table.Add ("Cube65", Cube65);
		table.Add ("Cube66", Cube66);

		table.Add ("Cube71", Cube71);
		table.Add ("Cube72", Cube72);
		table.Add ("Cube73", Cube73);
		table.Add ("Cube74", Cube74);
		table.Add ("Cube75", Cube75);
		table.Add ("Cube76", Cube76);
		
		table.Add ("Cube81", Cube81);
		table.Add ("Cube82", Cube82);
		table.Add ("Cube83", Cube83);
		table.Add ("Cube84", Cube84);
		table.Add ("Cube85", Cube85);
		table.Add ("Cube86", Cube86);
	}
	// Use this for initialization
	void Start () {
		/*Mainクラスのオブジェクトを作成しておく*/
		main = GameObject.Find ("Main_manager");
		t1 = new t_box ();
		BirthCube();
	}
	
	// Update is called once per frame
	void Update () {
		Produce_damagefloor ();
	}

	/*ダメージ床生成関数*/
	private void Produce_damagefloor () {
		/*mainからゲームタイムを取得する*/
		main_game_time = main.GetComponent<Main> ().get_m_time();
		t1.current_time = main_game_time;
		
		/*ランダムで場所を選択し,そこをダメージ床に設定*/
		if(t1.current_time - t1.old_time > mode) {
			x1 = Random.Range (1,7);
			y1 = Random.Range (1,9);
			
			string name_cube= ("Cube" + ((y1 * 10 + x1).ToString()));
			cube = (GameObject)table[name_cube];
			cube.GetComponent<Cube> ().change_danger(1);
			t1.old_time = t1.current_time;
		}
	}
	public float get_cube_time(int x,int y) {
		string name_cube= ("Cube" + ((y * 10 + x).ToString()));
		cube = (GameObject)table[name_cube];
		return cube.GetComponent<Cube> ().get_c_time();
	}
	public void change_mode(string mode) {
		if (mode == "easy") {
			this.mode = easy_mode;
		} else if (mode == "normal") {
			this.mode = normal_mode;
		} else if (mode == "hard") {
			this.mode = hard_mode;
		}

	}
}










