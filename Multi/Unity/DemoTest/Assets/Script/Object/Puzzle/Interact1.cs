using UnityEngine;
using System.Collections;

public class Interact1 : MonoBehaviour {

    public Transform camPosition;
    public float timerFirstMax;
    public ExitAreaPuzzle[] exitArea;
    public float movementSpeed;

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
        GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update () {
	    if (active && !Controller1.Instance.block && !Controller1.Instance.inZoomItem)
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
                Controller1.Instance.ActivatePuzzle(this);
                GetComponent<BoxCollider>().enabled = false;
                Controller1.Instance.mainCam.GetComponent<CameraBehavior1>().LaunchMovement(camPosition,movementSpeed);
                foreach (ExitAreaPuzzle ex in exitArea)
                {
                    ex.gameObject.SetActive(true);
                }
            }
        }
    }
}
