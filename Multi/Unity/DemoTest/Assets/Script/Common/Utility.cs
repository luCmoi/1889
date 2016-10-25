using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour {
    public static Utility Instance;
    public Texture2D cursorTexture;
    // Use this for initialization
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
        // Update is called once per frame
        void Update () {
	
	}
}
