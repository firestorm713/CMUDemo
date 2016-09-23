using UnityEngine;
using System.Collections;

public enum FPSPlayerState
{
    PLAYER_GROUNDED,
    PLAYER_JUMPING
}

public class FPSPlayerInputHandler : MonoBehaviour {
    [HideInInspector] public Transform myTransform;
    public float xRotationSpeed = 100;
    public float MoveSpeed = 10;
    public float maxVelocity = 100;
    public float StopTime = 0.1f;
    public float JumpHeight = 500;

    public FPSPlayerState playerState = FPSPlayerState.PLAYER_GROUNDED;

    private Vector3 dampVel = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        myTransform = transform;
        myRigidBody = GetComponent<Rigidbody>();
    }

    public Rigidbody myRigidBody;

    void FixedUpdate()
    {
        float rotationX = myTransform.localEulerAngles.y + Input.GetAxis("Mouse X") * xRotationSpeed * Time.deltaTime;
        myTransform.localEulerAngles = new Vector3(0, rotationX, 0);

        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        Movement = transform.TransformDirection(Movement);
        Movement *= MoveSpeed;

        myRigidBody.AddForce(Movement);
        if(myRigidBody.velocity.magnitude > maxVelocity)
        {
            Vector3 vel = myRigidBody.velocity.normalized;
            vel *= maxVelocity;
            myRigidBody.velocity = vel;
        }

        if(playerState == FPSPlayerState.PLAYER_GROUNDED)
        {
            if (Input.GetButtonDown("Jump"))
            {
                playerState = FPSPlayerState.PLAYER_JUMPING;
                myRigidBody.AddForce(0, JumpHeight, 0);
            }
            if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
            {
                myRigidBody.velocity = Vector3.SmoothDamp(myRigidBody.velocity, Vector3.zero, ref dampVel, StopTime);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5)
                playerState = FPSPlayerState.PLAYER_GROUNDED;
        }
    }
}
