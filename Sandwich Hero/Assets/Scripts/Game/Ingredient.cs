using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Ingredient : MonoBehaviour {

	public GameObject ingredient;
	public AudioClip audio;
	public float ingredientOffset;
	public bool isBread;
	public float cost;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateSandiwchContainer() {
		if(Game.CurrentSandwichContainer == null) {
			Game.CurrentBread = this;
			Game.Music.ToggleBaseBeat(audio);
			ClearCost (); 
			Game.IngredientCount = 0;
			Game.CurrentSandwichSlices.Clear ();
			Vector3 position = Game.SandwichPosition;
			Game.CurrentSandwichContainer = Instantiate (Game.SandwichContainer, position, Quaternion.identity) as GameObject;
			Game.CanAdd = true;
			AddToSandwich();
		}
		else {
			if(Game.CurrentBread == this) {
				Game.Music.ToggleBaseBeat(audio);
				GameObject currentContainer = Game.CurrentSandwichContainer;
				currentContainer.GetComponent<SlideOffScreen>().SlideOff ();
				Game.CanAdd = false;
				Game.CurrentBread = null;
				AddToSandwich();
			}
		}
	}

	public void AddIngredient() {
		if (isBread) {
			CreateSandiwchContainer ();
		} else {
			if(Game.CanAdd) {
				gameObject.GetComponent<AudioSource> ().PlayOneShot (audio);
				AddToSandwich();
			}
		}
	}

	public void AddToSandwich() {
		AddCost ();
		Game.IngredientCount++;
		Vector3 position = Game.SandwichPosition + new Vector3 (0, Game.IngredientCount, -Game.IngredientCount);
		GameObject clone = Instantiate (ingredient, position, ingredient.transform.rotation) as GameObject;
		if (!isBread)
			clone.transform.Rotate (Vector3.forward, Random.Range (0, 360));
		clone.transform.parent = Game.CurrentSandwichContainer.transform;
		Game.AddSandwichSlice (clone);
	}

	public void AddCost() {
		Game.SandwichCost += cost;
		Game.Wallet -= cost;
		//string price = Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(yourString))).ToString();
		Game.CostText.text = "Sandwich Cost: " + Game.SandwichCost.ToString ("C");
		Game.WalletText.text = Game.Wallet.ToString ("C");
	}

	public void ClearCost() {
		Game.SandwichCost = 0.00f;
		Game.CostText.text = "Sandwich Cost: $0.00";
		Game.WalletText.text = Game.Wallet.ToString ("C");
	}
}
