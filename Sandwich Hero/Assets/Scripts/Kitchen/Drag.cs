using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Drag : MonoBehaviour
{
	public GameObject ingredientStack;

    private Vector3 _startPosition;
    private Vector2 _dimensions;
	private bool _canDrop = false;
	private GameObject _dropZone = null;

    // Use this for initialization
    void Start()
    {
        _startPosition = this.transform.position;
        _dimensions = GetDimensionInPX(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (DragDropManager.DragTarget == null || DragDropManager.DragTarget == this.gameObject)
        {
            if (GameManager.MouseOverride && Input.GetMouseButton(0))
            {
                // Only if it is a new drag
                if (DragDropManager.DragTarget == null)
                {
                    Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
                    if (hit.transform.gameObject != null)
                    {
                        if (hit.transform.gameObject == this.gameObject)
                        {
                            if (!DragDropManager.Dragging)
                            {
                                DragDropManager.Dragging = true;
                                DragDropManager.DragTarget = this.gameObject;
                            }
                            Move(position);
                        }
                    }
                }
                // Otherwise don't have to check raycast
                else
                {
                    Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Move(position);
                }
            }
            else if (GameManager.MouseOverride && !Input.GetMouseButton(0))
            {
                Release();
            }
            else if (!GameManager.MouseOverride && Input.touches.Length > 0)
            {
                Touch touch = Input.touches[0];
                //if (touch.phase == TouchPhase.Stationary)
                //{
                // Only if it is a new drag
                if (DragDropManager.DragTarget == null)
                {
                    Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);
                    RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
                    if (hit != null)
                    {
                        if (hit.transform.gameObject == this.gameObject)
                        {
                            DragDropManager.Dragging = true;
                            DragDropManager.DragTarget = this.gameObject;
                            Move(position);
                        }
                    }
                }
                // Otherwise don't have to check raycast
                else
                {
                    Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);
                    Move(position);
                }
                //}
                if (touch.phase == TouchPhase.Ended)
                {
                    Release();
                }
            }
        }
    }

    private void Move(Vector3 position)
    {
        position.z = -1;
        Vector3 clampedPos = ClampPosition(position);
        this.transform.position = clampedPos;
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Loadout-Slot") 
		{
			if(_dropZone == null)
			{
				if(!other.gameObject.GetComponent<Drop>().Filled)
				{
					_dropZone = other.gameObject;
					_dropZone.GetComponent<SpriteRenderer>().sprite = DragDropManager.OverSprite;
					_canDrop = true;
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Loadout-Slot") 
		{
			if(other.gameObject == _dropZone) 
			{
				_dropZone.GetComponent<Drop>().Filled = false;
				_dropZone.GetComponent<Drop>().Ingredient = null;
				_dropZone.GetComponent<SpriteRenderer>().sprite = DragDropManager.EmptySprite;
				_dropZone = null;
			}
			_canDrop = false;
		}
	}

    private Vector3 ClampPosition(Vector3 position)
    {
        Vector3 updatedPos = position;
        float leftBounds = -(Camera.main.pixelWidth / 2) / 4;
        float rightBounds = (Camera.main.pixelWidth / 2) / 4;
        float topBounds = -(Camera.main.pixelHeight / 2) / 4;
        float bottomBounds = (Camera.main.pixelHeight / 2) / 4;
        if (updatedPos.x <= leftBounds)
        {
            updatedPos.x = leftBounds;
        }
        else if (updatedPos.x >= rightBounds)
        {
            updatedPos.x = rightBounds;
        }

        if (updatedPos.y <= topBounds)
        {
            updatedPos.y = topBounds;
        }
        else if (updatedPos.y >= bottomBounds)
        {
            updatedPos.y = bottomBounds;
        }

        return updatedPos;
    }

    private Vector2 GetDimensionInPX(GameObject obj)
    {
        Vector2 dimensions;

        dimensions.x = obj.transform.localScale.x / obj.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        dimensions.y = obj.transform.localScale.y / obj.GetComponent<SpriteRenderer>().sprite.bounds.size.y;

        return dimensions;
    }

    private void Release()
    {
        if (DragDropManager.Dragging)
        {
            DragDropManager.Dragging = false;
            DragDropManager.DragTarget = null;
        }

        if (!_canDrop)
			this.transform.position = _startPosition;
		else 
		{
			if(_dropZone != null) 
			{
				Vector3 targetPos = _dropZone.transform.position;
				targetPos.z = -1;
				this.transform.position = targetPos;
				_dropZone.GetComponent<SpriteRenderer>().sprite = DragDropManager.FullSprite;
				Drop drop = _dropZone.GetComponent<Drop>();
				drop.Filled = true;
				drop.Ingredient = this.gameObject;
				_dropZone = null;
				DragDropManager.CheckLoadout();
			}
		}
    }
}
