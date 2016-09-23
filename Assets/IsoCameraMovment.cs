using UnityEngine;
using System.Collections;

public class IsoCameraMovment : MonoBehaviour {

    public Camera myCamera;

    public float CameraSpeed = 10;

    public float CameraScrollSpeed = 10;

    public float CameraMinDistance = 0.25f;

    public float CameraMaxDistance = 17f;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 Movement = Vector3.zero;
        Movement = transform.right * Input.GetAxis("Horizontal") + 
            transform.forward * Input.GetAxis("Vertical");
        Movement.Normalize();
        Movement *= Time.deltaTime * CameraSpeed;
        transform.position += Movement;

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (myCamera.orthographicSize > 10)
                myCamera.nearClipPlane = -100;
            else
                myCamera.nearClipPlane = -1;

            if (Input.GetAxis("Mouse ScrollWheel") < 0 && myCamera.orthographicSize < CameraMaxDistance)
                myCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * CameraScrollSpeed;
            else if (Input.GetAxis("Mouse ScrollWheel") > 0 && myCamera.orthographicSize > CameraMinDistance)
                myCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * CameraScrollSpeed;
        }
    }
}
