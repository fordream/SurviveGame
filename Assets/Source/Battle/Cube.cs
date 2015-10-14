using UnityEngine;
using System.Collections;

/*Cubeに渡す情報構造体　現在の時間と前の時間を記録する*/
public class t_box {
	public float current_time = 0;
	public float old_time  = 0;
	public string flag = ""; 
}


public class Cube : MonoBehaviour {
	public t_box t;

	/*Cubeの時間を*/
	public float c_time = 0;

	private static int endtime = 3;
	private static int returntime = endtime + 2;
	private int end_damage = returntime - endtime;
	private int count = 0;
	
	public GameObject damage_area;

	//
	public int danger = 0;

	private Color Cube_color1;
	private Color Cube_color2;
	private Color Cube_color3;

	// Use this for initialization
	void Start () {
		/*Cube用情報構造体*/
		t = new t_box ();

		//元の透明
		Cube_color1 = new Color(255f,255f,255f,0f);
		Cube_color1.a = 0f;

		//赤色
		Cube_color2 = new Color(1f,0f,0f,0f);
		Cube_color2.a = 0.4f;

		//黒色
		Cube_color3 = new Color(0f,0f,0f,0f);
		Cube_color3.a = 0.8f;
	}
	
	// Update is called once per frame
	void Update () {
		if(danger == 1) {
			c_time += Time.deltaTime;
			Changecolor (gameObject,c_time);
		}
	}

	/*ダメージ床実装*/
	public float Changecolor(GameObject Cube , float c_time) {
		GameObject damage_block;
		float time = c_time;
		t.current_time = time;

		/*print ("count:" + count);
		print("current_time:" + t.current_time);
		print("old_time:" + t.old_time);
		print ("SUB:" + (t.current_time - t.old_time));*/
		
		if(t.current_time - t.old_time > 0.3f) {
			t.old_time = time;
			if(t.flag == "red") {
				t.flag = "black";
			}
			else {
				t.flag = "red";
			}
		}

		if(time >= returntime) {
			Cube.GetComponent<Renderer>().material.color = Cube_color1;
			/*interval用の時間*/
			//change_c_time(-2.0f);
			change_c_time(0f);
			t.current_time = 0;
			t.old_time = 0;
			count = 0;
			danger = 0;

			return 2222f;
		}
		else if (time >= endtime) {
			Cube.GetComponent<Renderer>().material.color = Cube_color3;
			if(count == 0) {
				damage_block = (GameObject)Instantiate (damage_area, Cube.transform.position, Cube.transform.rotation);
				Destroy(damage_block,end_damage);
				count++;
			}
			else {
				count++;
			}
		} 
		else if (t.flag == "red") {
			Cube.GetComponent<Renderer>().material.color = Cube_color1;
		} else {
			Cube.GetComponent<Renderer>().material.color = Cube_color2;
		}
		return time;
	}

	public void change_c_time(float time) {
		c_time = time;
	}
	public void change_danger(int OK) {
		danger = OK;
	}
	public float get_c_time() {
		return c_time;
	}
}
