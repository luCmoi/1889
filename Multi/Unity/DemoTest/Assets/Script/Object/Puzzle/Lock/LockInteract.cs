using UnityEngine;
using System.Collections;

public class LockInteract : MonoBehaviour {
    public bool movement;
    public bool active;
    public Transform destination;
    public float speedMovement;
    public RoueLock[] roueLocks;
    public Vector3 origine;

	// Use this for initialization
	void Start () {
        origine =transform.position;
	}

    void Update()
    {
        if (active && Controller1.Instance.block && Controller1.Instance.inPuzzle)
            {
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
                {
                movement = true;
                }
            }
        if (movement)
        {
            if (!active)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination.position, speedMovement);
                if (transform.position == destination.position)
                {
                    movement = false;
                    active = true;
                    foreach (RoueLock roue in roueLocks)
                    {
                        roue.Activate();
                    }
                }
            }else
            {
                transform.position = Vector3.MoveTowards(transform.position, origine, speedMovement);
                if (transform.position == origine)
                {
                    movement = false;
                    active = false;
                    foreach (RoueLock roue in roueLocks)
                    {
                        roue.Desactivate();
                        Controller1.Instance.block = false;
                    }
                }
            }
        }
    }

        void OnMouseDown()
        {
            if (Controller1.Instance.inPuzzle && !Controller1.Instance.block && !Controller1.Instance.inZoomItem)
            {
                movement = true;
                Controller1.Instance.block = true;
            } 
        }
}
