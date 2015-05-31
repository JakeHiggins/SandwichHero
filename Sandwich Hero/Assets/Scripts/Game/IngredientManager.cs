using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IngredientManager : MonoBehaviour {

	[Header("Bread Game Objects")]
	public GameObject whiteBreadStack;

	[Header("Cheese Game Objects")]
	public GameObject americanCheeseStack;

	[Header("Meat Game Objects")]
	public GameObject hamStack;

	[Header("Veggie Game Objects")]
	public GameObject lettuceStack;

	[Header("Dressing Game Objects")]
	public GameObject italianBottle;

	[Header("Sandwich Game Objects")]
	public GameObject sandwichContainer;
	public GameObject whiteBreadSlice;
	public GameObject americanCheeseSlice;
	public GameObject hamSlice;
	public GameObject lettuceSlice;
	public GameObject italianSlice;

	public Vector3 startPosition;

	private GameObject _currentSandwichContainer;
	private List<GameObject> _currentSandwichSlices;

	private List<GameObject> _lastSandwichContainers;
	private List<List<GameObject>> _lastSandwichSlices;

	private int _ingredientCount = 0;

	void Start() {
		_currentSandwichSlices = new List<GameObject>();
		_lastSandwichSlices = new List<List<GameObject>>();
	}

	void Update() {
		if(!Game.Paused) {
			if(GameManager.MouseOverride && Input.GetMouseButtonDown(0)) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if(Physics.Raycast (ray, out hit)) {
					UpdateLoop (hit);
				}
			}
			else {
				foreach(Touch touch in Input.touches) {
					if(touch.phase == TouchPhase.Began) {
						Ray ray = Camera.main.ScreenPointToRay (touch.position);
						RaycastHit hit;
						if(Physics.Raycast (ray, out hit)) {
							UpdateLoop (hit);
						}
					}
				}
			}
		}
	}

	public void UpdateLoop(RaycastHit hit) {
		if(hit.transform.gameObject.Equals (whiteBreadStack)) {
			Game.Music.ToggleBaseBeat();
			CreateSandwichContainer();
		}
		if(Game.Music.GetComponent<AudioSource>().isPlaying) {
			if(hit.transform.gameObject.Equals (americanCheeseStack)) {
				Game.Music.AddBeat(Game.Music.cheese, Time.time);
				AddIngredient (americanCheeseSlice, 1, true);
			}
			if(hit.transform.gameObject.Equals (hamStack)) {
				Game.Music.AddBeat(Game.Music.meat, Time.time);
				AddIngredient (hamSlice, 2, true);
			}
			if(hit.transform.gameObject.Equals (lettuceStack)) {
				Game.Music.AddBeat(Game.Music.veggie, Time.time);
				AddIngredient (lettuceSlice, 2, true);
			}
			if(hit.transform.gameObject.Equals (italianBottle)) {
				Game.Music.AddBeat(Game.Music.dressing, Time.time);
				AddIngredient (italianSlice, 3, true);
			}
		}
	}

	public void CreateSandwichContainer() {
		if(_currentSandwichContainer == null) {
			_ingredientCount = 0;
			_currentSandwichSlices.Clear ();
			Vector3 position = startPosition;
			_currentSandwichContainer = Instantiate (sandwichContainer, position, Quaternion.identity) as GameObject;
			AddIngredient (whiteBreadSlice, 4, false);
		}
		else {
			if(Game.Music.GetComponent<AudioSource>().isPlaying) {
				for(int i = 0; i < _currentSandwichSlices.Count; i++) {
					Destroy(_currentSandwichSlices[i]);
				}
				Destroy (_currentSandwichContainer);

				_ingredientCount = 0;
				_currentSandwichSlices.Clear ();
				Vector3 position = startPosition;
				_currentSandwichContainer = Instantiate (sandwichContainer, position, Quaternion.identity) as GameObject;
				AddIngredient (whiteBreadSlice, 4, false);
			}
			else {
				AddIngredient (whiteBreadSlice, 4, false);
				GameObject currentContainer = _currentSandwichContainer;
				currentContainer.GetComponent<SlideOffScreen>().SlideOff ();
				List<GameObject> currentSlices = _currentSandwichSlices;
				foreach(GameObject slice in currentSlices) {
					slice.GetComponent<SlideOffScreen>().SlideOff();
				}
			}
		}
	}



	public void AddIngredient(GameObject ingredient, float offsetDistance, bool rotate) {
		_ingredientCount++;
		Vector3 position = startPosition + new Vector3(0, _ingredientCount * offsetDistance, -_ingredientCount*offsetDistance);
		GameObject clone = Instantiate (ingredient, position, Quaternion.identity) as GameObject;
		if(rotate)
			clone.transform.Rotate (Vector3.up, Random.Range (0, 360));
		clone.transform.parent = _currentSandwichContainer.transform;
		_currentSandwichSlices.Add (clone);
	}
}
