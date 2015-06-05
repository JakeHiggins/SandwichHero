using UnityEngine;
using System.Collections;

public class KitchenButtons : MonoBehaviour {

    [Header("System")]
    public GameObject loadoutManager;

    [Header("Food Items")]
    public GameObject breadContainer;
    public GameObject cheeseContainer;
    public GameObject meatContainer;

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
                    Vector2 position = new Vector2(touch.position.x, touch.position.y);
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
        }
        
        if(hit.transform.gameObject == cheeseContainer)
        {
            // Do cheese stuff
        }

        if(hit.transform.gameObject == meatContainer)
        {
			Application.LoadLevel ("Meat_Loadout");
        }
    }
}
