using UnityEngine;
using System.Collections;

public class Interact1 : MonoBehaviour {

    public Camera cam;
    public float timerFirstMax;
    public ExitAreaPuzzle[] exitArea;

    private bool firstClick = false;
    private bool active = false;
    private float timerFirst;
	// Use this for initialization
	void Start () {
	
	}

    public void Exit()
    {
        active = false;
        Controller1.Instance.DesactivatePuzzle();
        foreach (ExitAreaPuzzle ex in exitArea)
        {
            ex.gameObject.SetActive(false);
        }
        cam.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	    if (active)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                Exit();
            }
        }
        if (firstClick)
        {
            timerFirst -= Time.deltaTime;
            if (timerFirst < 0)
            {
                firstClick = false;
                timerFirst = 0;
            }
        }
	}

    void OnMouseDown()
    {
        if (!active)
        {
            if (!firstClick)
            {
                firstClick = true;
                timerFirst = timerFirstMax;
            }
            else
            {
                active = true;
                cam.gameObject.SetActive(true);
                foreach (ExitAreaPuzzle ex in exitArea)
                {
                    ex.gameObject.SetActive(true);
                }
                Controller1.Instance.ActivatePuzzle(this);
            }
        }
    }
}
