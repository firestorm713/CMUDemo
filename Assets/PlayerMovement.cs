using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    public float MovementSpeed = 10;    // Part 1
    public float PlayerHeight;          // Part 1
    public Camera mainCamera;           // Part 1
    public float RotationSpeed = 10;
    public Rigidbody myRigidBody;

	// Use this for initialization
	void Start () {
        PlayerHeight = transform.position.y;
        myRigidBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(0))
        {
            Ray MouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(MouseRay, out hit))
            {
                if (hit.transform != transform)
                {
                    MovePlayerTowardPoint(hit.point);
                    //if (hit.transform.tag == "Enemy")
                    //    hit.transform.GetComponent<EnemyHealth>().DoDamage(Damage);
                }
            }
        }
	}

    public void MovePlayerTowardPoint(Vector3 point)
    {
        Vector3 Movement = Vector3.Lerp(transform.position, new Vector3(point.x, PlayerHeight, point.z), Time.deltaTime * MovementSpeed);
        Debug.Log("Hit Something!");

        Vector3 Direction = transform.position - point;
        Quaternion lookRotation = Quaternion.LookRotation(Direction);
        transform.localEulerAngles = Vector3.Slerp(transform.localEulerAngles, new Vector3(0, lookRotation.eulerAngles.y, 0), RotationSpeed * Time.deltaTime);

        transform.position = Movement;
    }

    public void OnDamageTaken()
    {
        myRigidBody.AddForce(0, 100, 0);
    }
    /// <summary>
    /// Part 3
    /// </summary>
    /// <param name="other"></param>
    public void OnCollisionEnter(Collision collision)
    {
    }
}
