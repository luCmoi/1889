using UnityEngine;
using System.Collections;

public class ItemZoomControle : MonoBehaviour {
    public float xSpeed;
    public float ySpeed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDrag()
    {
        float x = Input.GetAxis("Mouse X") * xSpeed;
        float y = Input.GetAxis("Mouse Y") * ySpeed;
        transform.RotateAround(GetComponent<MeshRenderer>().bounds.center, Vector3.down, x);
        transform.RotateAround(GetComponent<MeshRenderer>().bounds.center, Vector3.left,y);
    }
}
