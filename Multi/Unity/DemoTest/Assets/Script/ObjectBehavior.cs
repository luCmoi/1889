using UnityEngine;
using System.Collections;

public class ObjectBehavior : MonoBehaviour
{
    public Camera cam;
    public float timerFirstMax;

    private bool firstClick = false;
    private bool active = false;
    private float timerFirst;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active && !Controller1.Instance.inPuzzle)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                active = false;
                GetComponent<BoxCollider>().enabled = true;
                Controller1.Instance.DesactivateObject();
                cam.gameObject.SetActive(false);
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
        if (!active && !Controller1.Instance.inPuzzle)
        {
            if (!firstClick)
            {
                firstClick = true;
                timerFirst = timerFirstMax;
            }
            else
            {
                active = true;
                cam.gameObject.SetActive(true);
                GetComponent<BoxCollider>().enabled = false;
                Controller1.Instance.ActivateObject(this);
            }
        }
    }
}
