using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {

	/*Rigidbody用の変数を作成する*/
	public Rigidbody myrigidbody;
	/*自分参照用*/
	public GameObject mybody;
	/*enemy1_HP*/
	private int HP = 5;
	/*attack_hit_time_effect*/
	private Color damage_color;
	private Color normal_color;
	private Renderer _renderer;
	
	
	// Use this for initialization
	void Start () {
		//_renderer = GetComponent<Renderer>();
		//normal_color = mybody.renderer.material.color;

		damage_color = new Color(1f,0f,0f,0f);
		damage_color.a = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		//_renderer.material.color = Color.blue;
		
	}

	/*被ダメ判定　被ダメエフェクト*/
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag("p_attackCube")) {
			HP -= 1;
			if(HP == 0) {
				//Instantiate(explosionPrehab,transform.position,transform.rotation);
				Destroy(gameObject);
				Application.LoadLevel ("ClearResult");
			}
		}
	}
}
