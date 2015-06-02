using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Ingredient : MonoBehaviour {

	public GameObject ingredient;
	public AudioClip audio;
	public float ingredientOffset;
	public bool isBread;
	public double cost;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateSandiwchContainer() {
		Game.Music.ToggleBaseBeat(audio);
		if(Game.CurrentSandwichContainer == null) {
			ClearCost (); 
			Game.IngredientCount = 0;
			Game.CurrentSandwichSlices.Clear ();
			Vector3 position = Game.SandwichPosition;
			Game.CurrentSandwichContainer = Instantiate (Game.SandwichContainer, position, Quaternion.identity) as GameObject;
		}
		else {
			GameObject currentContainer = Game.CurrentSandwichContainer;
			currentContainer.GetComponent<SlideOffScreen>().SlideOff ();
		}
	}

	public void AddIngredient() {
		if (isBread) {
			CreateSandiwchContainer ();
		} else {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (audio);
		}

		AddCost ();
		Game.IngredientCount++;
		Vector3 position = Game.SandwichPosition + new Vector3 (0, Game.IngredientCount, -Game.IngredientCount);
		GameObject clone = Instantiate (ingredient, position, ingredient.transform.rotation) as GameObject;
		if(!isBread)
			clone.transform.Rotate (Vector3.forward, Random.Range (0, 360));
		clone.transform.parent = Game.CurrentSandwichContainer.transform;
		//clone.GetComponent<MeshCollider> ().enabled = false;
		Game.AddSandwichSlice (clone);
	}

	public void AddCost() {
		Game.SandwichCost += cost;
		Game.CostText.text = "Sandiwch Cost: $" + Game.SandwichCost;
	}

	public void ClearCost() {
		Game.SandwichCost = 0.00;
		Game.CostText.text = "Sandwich Cost: $0.00";
	}
}
