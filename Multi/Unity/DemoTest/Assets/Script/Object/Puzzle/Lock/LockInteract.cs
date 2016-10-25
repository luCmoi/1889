using UnityEngine;
using System.Collections;

public class LockInteract : MonoBehaviour {
    public bool movement;
    public Transform destination;
    public float speedMovement;

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        if (movement)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination.position, speedMovement);
            if (transform.position == destination.position)
            {
                movement = false;
                Controller1.Instance.block = false;
            }
        }
    }

        void OnMouseDown()
    {
        if (Controller1.Instance.inPuzzle && !Controller1.Instance.block && !Controller1.Instance.inZoomItem)
        {
            movement = true;
            Controller1.Instance.block = false;
        }
        }
}
