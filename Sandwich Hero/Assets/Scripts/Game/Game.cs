using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private static Game _instance;

	public MusicManager musicMan;
	public GameObject background;

	public bool paused;

	public static Game instance {
		get {
			if(_instance == null) {
				_instance = GameObject.FindObjectOfType<Game>();
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

	public static MusicManager Music {
		get{return _instance.musicMan;}
	}

	public static bool Paused {
		get { return _instance.paused; }
		set { _instance.paused = value; }
	}

	public static void Pause() {
		_instance.paused = true;
		Game.Music.Pause();
	}

	public static void Unpause() {
		_instance.paused = false;
		Game.Music.Play();
	}

	public static void Play() {
		//Do something here
		_instance.background.GetComponent<Renderer>().enabled = false;
	}

	public static void ToggleBaseBeat() {
		if(_instance.gameObject.GetComponent<AudioSource>().isPlaying)
			_instance.gameObject.GetComponent<AudioSource>().Stop ();
		else
			_instance.gameObject.GetComponent<AudioSource>().Play();
	}
}
