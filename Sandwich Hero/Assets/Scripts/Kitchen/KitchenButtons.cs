using UnityEngine;
using System.Collections;

public class KitchenButtons : MonoBehaviour {

    [Header("System")]
	public GameObject quitContainer;
	public GameObject optionsContainer;

    [Header("Food Items")]
    public GameObject breadContainer;
    public GameObject cheeseContainer;
    public GameObject meatContainer;
	public GameObject veggieContainer;
	public GameObject dressingContainer;

	[Header("Loadout")]
	public GameObject loadoutContainer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (GameManager.MouseOverride && Input.GetMouseButtonDown(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
            if (hit)
            {
                HandleHit(hit);
            }
        }
        else
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
					Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);
					RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
                    if (hit)
                    {
                        HandleHit(hit);
                    }
                }
            }
        }
	}

    private void HandleHit(RaycastHit2D hit) 
    {
        if (hit.transform.gameObject == breadContainer)
        {
            // Do bread stuff
			Application.LoadLevel ("Bread_Loadout");
        }
        
        if(hit.transform.gameObject == cheeseContainer)
        {
            // Do cheese stuff
			Application.LoadLevel ("Cheese_Loadout");
        }

        if(hit.transform.gameObject == meatContainer)
        {
			Application.LoadLevel ("Meat_Loadout");
        }

		if (hit.transform.gameObject == veggieContainer) 
		{
			//Do Veggie stuff
			Application.LoadLevel ("Veggie_Loadout");
		}

		if(hit.transform.gameObject == dressingContainer)
		{
			// Do dressing stuff
			Application.LoadLevel ("Dressing_Loadout");
		}

		if(hit.transform.gameObject == loadoutContainer)
		{
			// Do loadout stuff
		}

		if(hit.transform.gameObject == quitContainer)
		{
			Application.LoadLevel ("Main_Menu");
		}
    }
}
