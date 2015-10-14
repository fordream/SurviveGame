using UnityEngine;
using System.Collections;

public class Stop_button : MonoBehaviour {
	private int count = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClick() {
		if(count % 2 == 0) {
		 Time.timeScale = 0;
		}
		else {
			Time.timeScale = 1;
		}
		count++;
	}
}
