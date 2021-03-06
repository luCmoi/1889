﻿using UnityEngine;
using System.Collections;

public class CameraBehavior1 : MonoBehaviour
{

    public Transform target;
    public float fRadius;

    public float speedHorizontal;
    public float speedVertical;
    public float speedScroll;

    public float yMax;
    public float yMin;
    public float zoomMin;
    public float zoom;
    public float zoomMax;

    public float xSpeed = 250;
    public float ySpeed = 120;

    private double x = 0;
    private double y = 0;

    private float distance;
    private float movX;
    private float movY;


    private Transform pivot;
    private float lastZoom;

    private bool movement;
    private Transform destination;
    private float speedMovement;

    void Start()
    {
        pivot = target;
        transform.parent = pivot;
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
        else
        {
            if (!Controller1.Instance.inPuzzle && Controller1.Instance.inObjet && !Controller1.Instance.block && !Controller1.Instance.inZoomItem)
            {
                if (Input.GetAxis("Horizontal") != 0)
                {
                    transform.RotateAround(pivot.position, Vector3.up, -Input.GetAxisRaw("Horizontal") * speedHorizontal);
                }
                if (Input.GetAxis("Vertical") != 0)
                {
                    transform.Translate(Vector3.up * Input.GetAxisRaw("Vertical") * speedVertical);
                    transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, yMin, yMax), transform.position.z);
                }

                if (Input.GetMouseButton(0))
                {
                    x = Input.GetAxis("Mouse X") * xSpeed;
                    y = transform.position.y - Input.GetAxis("Mouse Y") * ySpeed;
                    y = Mathf.Clamp((float)y, yMin, yMax);
                    transform.position = new Vector3(transform.position.x, (float)y, transform.position.z);
                    transform.RotateAround(pivot.position, Vector3.up, (float)x);
                }
                else
                {
                    x = 0;
                    y = 0;
                }
                if (Input.GetAxis("Mouse ScrollWheel") != 0)
                {
                    zoom += Input.GetAxis("Mouse ScrollWheel") * speedScroll;
                    if (zoom <= zoomMax && zoom >= zoomMin)
                    {
                        transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * speedScroll);
                    }
                    else
                    {
                        if (zoom > zoomMax && lastZoom < zoomMax)
                        {
                            transform.Translate(Vector3.forward * (zoomMax - lastZoom));
                        }
                        if (zoom < zoomMin && lastZoom > zoomMin)
                        {
                            transform.Translate(Vector3.forward * (zoomMin - lastZoom));
                        }
                        zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);
                    }
                    lastZoom = zoom;
                }
            }
        }
    }

    public void LaunchMovement(Transform destination, float duration)
    {
        this.transform.rotation = destination.rotation;
        this.destination = destination;
        this.speedMovement = duration;
        movement = true;
        Controller1.Instance.block = true;
        zoom = 0;
    }
    static float ClampAngle(float angle,float min,float max) {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max); }
}
