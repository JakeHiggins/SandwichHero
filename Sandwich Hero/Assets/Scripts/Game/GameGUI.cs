using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour
{

    [Header("Main Menu Game Objects")]
    public GameObject background;
    public GameObject optionsButton;
    public GameObject pauseButton;

    [Header("Options Screen Game Objects")]
    public GameObject optionsScreen;
    public GameObject optionsReturnButton;

    [Header("Pause Screen Game Objects")]
    public GameObject pauseScreen;
    public GameObject pauseResumeButton;
    public GameObject pauseCurrentButton;
    public GameObject pauseMenuButton;

    [Header("Quit Screen Game Objects")]
    public GameObject quitScreen;
    public GameObject quitMenuButton;
    public GameObject quitReturnButton;

    void Start()
    {

    }

    void Update()
    {
        if (GameManager.MouseOverride && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                UpdateLoop(hit);
            }
        }
        else
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        UpdateLoop(hit);
                    }
                    //background.renderer.enabled = false;
                }
            }
        }
    }

    private void UpdateLoop(RaycastHit hit)
    {

        if (hit.transform.gameObject.Equals(optionsButton))
        {
            optionsScreen.GetComponent<Renderer>().enabled = true;
            optionsScreen.GetComponent<Collider>().enabled = true;
            optionsReturnButton.GetComponent<Renderer>().enabled = true;
            optionsReturnButton.GetComponent<Collider>().enabled = true;
            Game.Pause();
        }
        if (hit.transform.gameObject.Equals(pauseButton))
        {
            pauseScreen.GetComponent<Renderer>().enabled = true;
            pauseScreen.GetComponent<Collider>().enabled = true;
            pauseResumeButton.GetComponent<Renderer>().enabled = true;
            pauseResumeButton.GetComponent<Collider>().enabled = true;
            pauseCurrentButton.GetComponent<Renderer>().enabled = true;
            pauseCurrentButton.GetComponent<Collider>().enabled = true;
            pauseMenuButton.GetComponent<Renderer>().enabled = true;
            pauseMenuButton.GetComponent<Collider>().enabled = true;
            Game.Pause();
        }
        if (hit.transform.gameObject.Equals(optionsReturnButton))
        {
            optionsScreen.GetComponent<Renderer>().enabled = false;
            optionsScreen.GetComponent<Collider>().enabled = false;
            optionsReturnButton.GetComponent<Renderer>().enabled = false;
            optionsReturnButton.GetComponent<Collider>().enabled = false;
            Game.Unpause();
        }
        if (hit.transform.gameObject.Equals(pauseResumeButton))
        {
            pauseScreen.GetComponent<Renderer>().enabled = false;
            pauseScreen.GetComponent<Collider>().enabled = false;
            pauseResumeButton.GetComponent<Renderer>().enabled = false;
            pauseResumeButton.GetComponent<Collider>().enabled = false;
            pauseCurrentButton.GetComponent<Renderer>().enabled = false;
            pauseCurrentButton.GetComponent<Collider>().enabled = false;
            pauseMenuButton.GetComponent<Renderer>().enabled = false;
            pauseMenuButton.GetComponent<Collider>().enabled = false;
            Game.Unpause();
        }
        if (hit.transform.gameObject.Equals(pauseCurrentButton))
        {

        }
        if (hit.transform.gameObject.Equals(pauseMenuButton))
        {
            pauseScreen.GetComponent<Renderer>().enabled = false;
            pauseScreen.GetComponent<Collider>().enabled = false;
            pauseResumeButton.GetComponent<Renderer>().enabled = false;
            pauseResumeButton.GetComponent<Collider>().enabled = false;
            pauseCurrentButton.GetComponent<Renderer>().enabled = false;
            pauseCurrentButton.GetComponent<Collider>().enabled = false;
            pauseMenuButton.GetComponent<Renderer>().enabled = false;
            pauseMenuButton.GetComponent<Collider>().enabled = false;

            quitScreen.GetComponent<Renderer>().enabled = true;
            quitScreen.GetComponent<Collider>().enabled = true;
            quitMenuButton.GetComponent<Renderer>().enabled = true;
            quitMenuButton.GetComponent<Collider>().enabled = true;
            quitReturnButton.GetComponent<Renderer>().enabled = true;
            quitReturnButton.GetComponent<Collider>().enabled = true;
        }

        if (hit.transform.gameObject.Equals(quitReturnButton))
        {
            quitScreen.GetComponent<Renderer>().enabled = false;
            quitScreen.GetComponent<Collider>().enabled = false;
            quitMenuButton.GetComponent<Renderer>().enabled = false;
            quitMenuButton.GetComponent<Collider>().enabled = false;
            quitReturnButton.GetComponent<Renderer>().enabled = false;
            quitReturnButton.GetComponent<Collider>().enabled = false;

            pauseScreen.GetComponent<Renderer>().enabled = true;
            pauseScreen.GetComponent<Collider>().enabled = true;
            pauseResumeButton.GetComponent<Renderer>().enabled = true;
            pauseResumeButton.GetComponent<Collider>().enabled = true;
            pauseCurrentButton.GetComponent<Renderer>().enabled = true;
            pauseCurrentButton.GetComponent<Collider>().enabled = true;
            pauseMenuButton.GetComponent<Renderer>().enabled = true;
            pauseMenuButton.GetComponent<Collider>().enabled = true;
        }

        if (hit.transform.gameObject.Equals(quitMenuButton))
        {
            Application.LoadLevel("Main_Menu");
        }
    }
}