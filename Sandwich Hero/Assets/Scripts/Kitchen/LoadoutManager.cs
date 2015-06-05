using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadoutManager : MonoBehaviour
{

    private static LoadoutManager _instance;

	public List<GameObject> _meats;

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
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
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
}
