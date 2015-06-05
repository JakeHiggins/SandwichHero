using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour
{

    private bool _filled = false;
    private GameObject _ingredient;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool Filled
    {
        get { return _filled; }
        set { _filled = value; }
    }

    public GameObject Ingredient
    {
        get { return _ingredient; }
        set { _ingredient = value; }
    }
}
