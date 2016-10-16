﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Controller1 : MonoBehaviour {

    public static Controller1 Instance;

    public Camera mainCam;
    public bool inObjet;
    public bool inPuzzle;
    public GameObject panelCommande;
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
	
	}

    public void ActivatePuzzle(Interact1 puzzle)
    {
        this.puzzle = puzzle;
        Camera.SetupCurrent(puzzle.cam);
        inPuzzle = true;
    }

    public void DesactivatePuzzle()
    {
        this.puzzle = null;
        inPuzzle = false;
        Camera.SetupCurrent(objet.cam);
    }

    public void ActivateObject(ObjectBehavior objet)
    {
        this.objet = objet;
        Camera.SetupCurrent(objet.cam);
        inObjet = true;
    }

    public void DesactivateObject()
    {
        this.objet = null;
        inObjet = false;
        Camera.SetupCurrent(mainCam);
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            panelCommande.SetActive(!panelCommande.activeInHierarchy);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(0);
        }
    }
}
