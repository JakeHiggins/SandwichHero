using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private static GameManager _instance;

	public bool mouseOverride = false;
	
	public static GameManager instance {
		get {
			if(_instance == null) {
				_instance = GameObject.FindObjectOfType<GameManager>();
			}
			
			return instance;
		}
	}
	
	void Awake() {
		if(_instance == null) {
			_instance = this;
		}
		else {
			if(this != _instance)
				Destroy (this.gameObject);
		}
	}
	// Start in landscape mode
	void Start () {
		Screen.orientation = ScreenOrientation.Portrait;
	}

	public static bool MouseOverride {
		get{ return _instance.mouseOverride; }
	}
}
