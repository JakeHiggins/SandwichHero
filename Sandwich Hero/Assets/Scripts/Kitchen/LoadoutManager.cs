using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadoutManager : MonoBehaviour
{

    private static LoadoutManager _instance;

	private List<GameObject> _meats;
	private List<GameObject> _cheeses;
	private List<GameObject> _veggies;
	private List<GameObject> _dressings;
	private List<GameObject> _breads;

    public static LoadoutManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<LoadoutManager>();
            }
            return instance;
        }
    }

    void Awake()
    {
		DontDestroyOnLoad(this.gameObject);
        if (_instance == null)
        {
            _instance = this;
			_instance._meats = new List<GameObject>();
			_instance._cheeses = new List<GameObject>();
			_instance._veggies = new List<GameObject>();
			_instance._dressings = new List<GameObject>();
			_instance._breads = new List<GameObject>();
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

	public static List<GameObject> Meats
	{
		get { return _instance._meats; }
		set { _instance._meats = value; }
	}

	public static List<GameObject> Cheeses
	{
		get { return _instance._cheeses; }
		set { _instance._cheeses = value; }
	}

	public static List<GameObject> Veggies
	{
		get { return _instance._veggies; }
		set { _instance._veggies = value; }
	}

	public static List<GameObject> Dressings
	{
		get { return _instance._dressings; }
		set { _instance._dressings = value; }
	}

	public static List<GameObject> Breads
	{
		get { return _instance._breads; }
		set { _instance._breads = value; }
	}
}
