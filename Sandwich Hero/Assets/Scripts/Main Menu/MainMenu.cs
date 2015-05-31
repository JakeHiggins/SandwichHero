using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	[Header("Main Menu Game Objects")]
	public GameObject background;
	public GameObject storyButton;
	public GameObject freestyleButton;
	public GameObject recipesButton;
	public GameObject creditsButton;
	public GameObject optionsButton;

	[Header("Options Screen Game Objects")]
	public GameObject optionsScreen;
	public GameObject optionsReturnButton;

	[Header("Story Alert Game Objects")]
	public GameObject storyAlertScreen;
	public GameObject storyAlertReturnButton;

	[Header("Recipes Alert Game Objects")]
	public GameObject recipesAlertScreen;
	public GameObject recipesAlertReturnButton;

	[Header("Credits Game Objects")]
	public GameObject creditsScreen;
	public GameObject creditsReturnButton;

	void Start() {
	}

	void Update() {
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
					//background.renderer.enabled = false;
				}
			}
		}
	}

	private void UpdateLoop(RaycastHit hit) {
		if(hit.transform.gameObject.Equals(optionsButton)) {
			optionsScreen.GetComponent<Renderer>().enabled = true;
			optionsScreen.GetComponent<Collider>().enabled = true;
			optionsReturnButton.GetComponent<Renderer>().enabled = true;
			optionsReturnButton.GetComponent<Collider>().enabled = true;
		}
		if(hit.transform.gameObject.Equals(storyButton)) {
			storyAlertScreen.GetComponent<Renderer>().enabled = true;
			storyAlertScreen.GetComponent<Collider>().enabled = true;
			storyAlertReturnButton.GetComponent<Renderer>().enabled = true;
			storyAlertReturnButton.GetComponent<Collider>().enabled = true;
		}
		if(hit.transform.gameObject.Equals(recipesButton)) {
			recipesAlertScreen.GetComponent<Renderer>().enabled = true;
			recipesAlertScreen.GetComponent<Collider>().enabled = true;
			recipesAlertReturnButton.GetComponent<Renderer>().enabled = true;
			recipesAlertReturnButton.GetComponent<Collider>().enabled = true;
		}
		if(hit.transform.gameObject.Equals(creditsButton)) {
			creditsScreen.GetComponent<Renderer>().enabled = true;
			creditsScreen.GetComponent<Collider>().enabled = true;
			creditsReturnButton.GetComponent<Renderer>().enabled = true;
			creditsReturnButton.GetComponent<Collider>().enabled = true;
		}
		if(hit.transform.gameObject.Equals(freestyleButton)) {
			Application.LoadLevel ("Game_Screen");
		}
		if(hit.transform.gameObject.Equals(optionsReturnButton) || 
		   hit.transform.gameObject.Equals(storyAlertReturnButton) ||
		   hit.transform.gameObject.Equals(recipesAlertReturnButton) ||
		   hit.transform.gameObject.Equals(creditsReturnButton)){
			optionsScreen.GetComponent<Renderer>().enabled = false;
			optionsScreen.GetComponent<Collider>().enabled = false;
			optionsReturnButton.GetComponent<Renderer>().enabled = false;
			optionsReturnButton.GetComponent<Collider>().enabled = false;
			storyAlertScreen.GetComponent<Renderer>().enabled = false;
			storyAlertScreen.GetComponent<Collider>().enabled = false;
			storyAlertReturnButton.GetComponent<Renderer>().enabled = false;
			storyAlertReturnButton.GetComponent<Collider>().enabled = false;
			recipesAlertScreen.GetComponent<Renderer>().enabled = false;
			recipesAlertScreen.GetComponent<Collider>().enabled = false;
			recipesAlertReturnButton.GetComponent<Renderer>().enabled = false;
			recipesAlertReturnButton.GetComponent<Collider>().enabled = false;
			creditsScreen.GetComponent<Renderer>().enabled = false;
			creditsScreen.GetComponent<Collider>().enabled = false;
			creditsReturnButton.GetComponent<Renderer>().enabled = false;
			creditsReturnButton.GetComponent<Collider>().enabled = false;
		}
	}
}
