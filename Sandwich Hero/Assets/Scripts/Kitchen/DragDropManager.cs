using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragDropManager : MonoBehaviour {

    private static DragDropManager _instance;

    private bool _dragging = false;
    private GameObject _dragTarget;

    public List<GameObject> dropTargets;

	public GameObject submitButton;

    [Header("Sprites")]
    public Sprite empty;
    public Sprite full;
    public Sprite over;

    public static DragDropManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<DragDropManager>();
            }
            return instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

	void Update()
	{
		if (GameManager.MouseOverride && Input.GetMouseButtonDown(0))
		{
			Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
			if (hit.transform.gameObject == DragDropManager.SubmitButton)
			{
				Application.LoadLevel("Kitchen");
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
					if (hit.transform.gameObject == DragDropManager.SubmitButton)
					{
						Application.LoadLevel("Kitchen");
					}
				}
			}
		}
	}

    public static bool Dragging
    {
        get { return _instance._dragging; }
        set { _instance._dragging = value; }
    }

    public static GameObject DragTarget
    {
        get { return _instance._dragTarget; }
        set { _instance._dragTarget = value; }
    }

    public static Sprite EmptySprite
    {
        get { return _instance.empty; }
    }

    public static Sprite FullSprite
    {
        get { return _instance.full; }
    }

    public static Sprite OverSprite
    {
        get { return _instance.over; }
    }

    public static List<GameObject> DropTargets
    {
        get { return _instance.dropTargets; }
        set { _instance.dropTargets = value; }
    }

	public static GameObject SubmitButton
	{
		get { return _instance.submitButton; }
	}

	public static void CheckLoadout()
	{
		bool done = true;
		foreach (GameObject dropObj in _instance.dropTargets) 
		{
			Drop drop = dropObj.GetComponent<Drop>();
			if(drop.Ingredient == null)
				done = false;
		}

		if (done) 
		{
			_instance.submitButton.GetComponent<SpriteRenderer>().enabled = true;
			_instance.submitButton.GetComponent<BoxCollider2D>().enabled = true;
		}
	}

	public static void CheckoutIngredients()
	{
		List<GameObject> ingredients = new List<GameObject> ();
		foreach (GameObject dropObj in _instance.dropTargets) 
		{
			Drop drop = dropObj.GetComponent<Drop>();
			ingredients.Add(drop.Ingredient);
		}
		// Need to make this dynamic
		LoadoutManager.Meats = ingredients;
	}
}
