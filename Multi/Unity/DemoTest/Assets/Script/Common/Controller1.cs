using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Controller1 : MonoBehaviour {

    public static Controller1 Instance;

    public Camera mainCam;
    public Transform FirstCamPos;
    private Transform secondCamPos;
    public bool inObjet;
    public bool inPuzzle;
    public bool inZoomItem;
    public GameObject panelCommande;
    public Camera zoomItemCam;
    public bool block;

    private Camera lastCam;
    private Interact1 puzzle;
    private ObjectBehavior objet;
	// Use this for initialization
	void Start () {
	    if(Instance == null)
        {
            Instance = this;
        }else
        {
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            panelCommande.SetActive(!panelCommande.activeInHierarchy);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!inZoomItem)
            {
                ZoomItem();
            }
            else
            {
                DeZoomItem();
            }
        }
    }

    public void ActivatePuzzle(Interact1 puzzle)
    {
        this.puzzle = puzzle;
        inPuzzle = true;
    }

    public void DesactivatePuzzle()
    {
        mainCam.GetComponent<CameraBehavior1>().LaunchMovement(secondCamPos, this.puzzle.movementSpeed);
        this.puzzle = null;
        inPuzzle = false;
    }

    public void ActivateObject(ObjectBehavior objet)
    {
        this.objet = objet;
        inObjet = true;
        secondCamPos = objet.camPos;
    }

    public void DesactivateObject()
    {
        mainCam.GetComponent<CameraBehavior1>().LaunchMovement(FirstCamPos, this.objet.speed);
        secondCamPos = null;
        this.objet = null;
        inObjet = false;
    }
    void FixedUpdate()
    {

    }

    public void ZoomItem()
    {
        inZoomItem = true;
        lastCam = Camera.current;
        zoomItemCam.gameObject.SetActive(true);
        Camera.SetupCurrent(zoomItemCam);
    }

    public void DeZoomItem()
    {
        inZoomItem = false;
        Camera.SetupCurrent(lastCam);
        zoomItemCam.gameObject.SetActive(false);
    }
}
