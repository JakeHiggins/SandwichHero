using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	private static Game _instance;

	public MusicManager musicMan;
	public GameObject background;
	public GameObject sandwichContainer;

	public Vector3 sandwichPosition;

	public bool paused;
	private bool _canAdd = false;

	public Text costText;
	public Text walletText;

	private int _ingredientCount = 0;
	private GameObject _currentSandwichContainer;
	private List<GameObject> _currentSandwichSlices;

	private Ingredient _currentBreadType;

	private float _sandwichCost = 0.00f;
	public float wallet = 100.00f;

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
			_instance._currentSandwichSlices = new List<GameObject>();
		}
		else {
			if(this != _instance)
				Destroy (this.gameObject);
		}
	}

	public static Ingredient CurrentBread {
		get { return _instance._currentBreadType; }
		set { _instance._currentBreadType = value; }
	}

	public static Text WalletText {
		get { return _instance.walletText; }
		set { _instance.walletText = value; }
	}

	public static Text CostText {
		get { return _instance.costText; }
		set { _instance.costText = value; }
	}

	public static int IngredientCount {
		get { return _instance._ingredientCount; }
		set { _instance._ingredientCount = value; }
	}

	public static float SandwichCost {
		get { return _instance._sandwichCost; }
		set { _instance._sandwichCost = value; }
	}

	public static float Wallet {
		get { return _instance.wallet; }
		set { _instance.wallet = value; }
	}

	public static GameObject CurrentSandwichContainer {
		get { return _instance._currentSandwichContainer; }
		set { _instance._currentSandwichContainer = value; }
	}

	public static List<GameObject> CurrentSandwichSlices {
		get { return _instance._currentSandwichSlices; }
		set { _instance._currentSandwichSlices = value; }
	}

	public static void AddSandwichSlice(GameObject slice) {
		_instance._currentSandwichSlices.Add (slice);
	}

	public static GameObject SandwichContainer {
		get { return _instance.sandwichContainer; }
	}

	public static Vector3 SandwichPosition {
		get { return _instance.sandwichPosition; }
	}

	public static MusicManager Music {
		get { return _instance.musicMan; }
	}

	public static bool Paused {
		get { return _instance.paused; }
		set { _instance.paused = value; }
	}

	public static bool CanAdd {
		get { return _instance._canAdd; }
		set { _instance._canAdd = value; }
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

	public static void ToggleBaseBeat(AudioClip clip) {
		if(_instance.gameObject.GetComponent<AudioSource>().isPlaying)
			_instance.gameObject.GetComponent<AudioSource>().Stop ();
		else
			_instance.gameObject.GetComponent<AudioSource>().Play();
	}
}
