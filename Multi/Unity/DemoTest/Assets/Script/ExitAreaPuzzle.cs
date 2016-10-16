using UnityEngine;
using System.Collections;

public class ExitAreaPuzzle : MonoBehaviour {
    public Interact1 container;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        container.Exit();
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(Utility.Instance.cursorTexture, Vector2.zero, CursorMode.Auto);
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
