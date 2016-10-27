using UnityEngine;
using System.Collections;

public class ObjectBehavior : MonoBehaviour
{
    public Transform camPos;
    public float timerFirstMax;
    public float speed;

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
        if (active && !Controller1.Instance.inPuzzle && !Controller1.Instance.inZoomItem && !Controller1.Instance.block)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                active = false;
                GetComponent<BoxCollider>().enabled = true;
                Controller1.Instance.DesactivateObject();
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
        if (!active && !Controller1.Instance.inPuzzle && !Controller1.Instance.block)
        {
            if (!firstClick)
            {
                firstClick = true;
                timerFirst = timerFirstMax;
            }
            else
            {
                active = true;
                Controller1.Instance.ActivateObject(this);
                Controller1.Instance.mainCam.GetComponent<CameraBehavior1>().LaunchMovement(camPos, speed);
                GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
