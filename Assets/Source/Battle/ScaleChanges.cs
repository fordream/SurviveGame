using UnityEngine;
using System.Collections;

public class ScaleChanges : MonoBehaviour {
	public PingPongMove _pingPong;
	public TextMesh _resultText;
	Vector3 defaultScale;
	
	bool isTapped = false;
	float resultValue;
	
	public bool CHANGE_X = false;
	public bool CHANGE_Y = false;
	public bool CHANGE_Z = false;

	// Use this for initialization
	void Start () {
		_pingPong = this.gameObject.GetComponent<PingPongMove>();
		defaultScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isTapped) {
			this.changeSize();
		}
		
		if (Input.GetMouseButtonDown(0)) {
			//resultValue = _pingPong.value;
			//_resultText.text = "RESULT: " + resultValue;
			isTapped = true;
		}
	}
	
	void changeSize() {
		Vector3 newSize = transform.localScale;
		
		if (CHANGE_X) {
			newSize.x = defaultScale.x * _pingPong.value / _pingPong.maxValue;
		}
		if (CHANGE_Y) {
			newSize.y = defaultScale.y * _pingPong.value / _pingPong.maxValue;
		}
		
		if (CHANGE_Z) {
			newSize.z = defaultScale.z * _pingPong.value / _pingPong.maxValue;
		}
		transform.localScale = newSize;
	}
}
