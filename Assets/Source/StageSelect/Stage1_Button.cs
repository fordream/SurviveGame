using UnityEngine;
using System.Collections;

public class Stage1_Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClick() {
		print ("Clicked");
		Application.LoadLevel ("TheGame");
	}
}
