using UnityEngine;
using System.Collections;

public class RoueLock : MonoBehaviour {
    public float xSpeed;
    public int objectif;
    public int actualPos;

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
        transform.RotateAround(GetComponent<MeshRenderer>().bounds.center, Vector3.down, x);
        actualPos = (int)transform.rotation.eulerAngles.y/36;
    }
}
