using UnityEngine;
using System.Collections;

public class RoueLock : MonoBehaviour {
    public float xSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Activate()
    {
        GetComponent<MeshCollider>().enabled = true;
    }

    public void Desactivate()
    {
        GetComponent<MeshCollider>().enabled = false;
    }

    void OnMouseDrag()
    {
        float x = Input.GetAxis("Mouse X") * xSpeed;
        //float y = Input.GetAxis("Mouse Y") * ySpeed;
        transform.RotateAround(GetComponent<MeshRenderer>().bounds.center, Vector3.down, x);
        //transform.RotateAround(GetComponent<MeshRenderer>().bounds.center, Vector3.left, y);
    }
}
