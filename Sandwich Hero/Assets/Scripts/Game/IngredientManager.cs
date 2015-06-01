using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IngredientManager : MonoBehaviour {
	void Start() {
	}

	void Update() {
		if(!Game.Paused) {
			if(GameManager.MouseOverride && Input.GetMouseButtonDown(0)) {
				Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast (position, Vector2.zero);
				Debug.Log (hit.transform);
				if(hit) {
					hit.transform.gameObject.GetComponent<Ingredient>().AddIngredient();
				}
			}
			else {
				foreach(Touch touch in Input.touches) {
					if(touch.phase == TouchPhase.Began) {
						Vector2 position = new Vector2(touch.position.x, touch.position.y);
						RaycastHit2D hit = Physics2D.Raycast (position, Vector2.zero);
						if(hit) {
							hit.transform.gameObject.GetComponent<Ingredient>().AddIngredient();
						}
					}
				}
			}
		}
	}
}
