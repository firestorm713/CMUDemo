using UnityEngine;
using System.Collections;

public class FPSMouseLookHandler : MonoBehaviour {

    [HideInInspector]public Transform myTransform;
    public float yRotationSpeed = 1000;
    public float MinYAngle = -90;
    public float MaxYAngle = 90;
    private Quaternion myRotation;
    private Vector3 rotAngles;
    float rotationY = 0.0f;
    // Use this for initialization
    void Start () {
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
        rotationY += Input.GetAxis("Mouse Y") * yRotationSpeed * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, MinYAngle, MaxYAngle);
        myTransform.localEulerAngles = new Vector3(-rotationY, 0, 0);
	}
}
