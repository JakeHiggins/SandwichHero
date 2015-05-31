using UnityEngine;
using System.Collections;

public class SlideOffScreen : MonoBehaviour {

	private bool _isActive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(_isActive) {
			transform.position = transform.position + new Vector3(1, 0, 0);
			if(transform.position.x >= 150) {
				GameObject.Destroy (this.gameObject);
			}
		}
	}

	public void SlideOff() {
		_isActive = true;
	}
}
