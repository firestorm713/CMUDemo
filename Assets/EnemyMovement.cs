using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    public float speed = 1.0f;
    public float DistanceThreshold;
    public float Damage = 1;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(transform.position, Player.position) < DistanceThreshold)
        {
            DoDamage(Player);
        }
        else
        {
            Vector3 Position = Vector3.Lerp(transform.position, Player.position, speed * Time.deltaTime);
            transform.position = Position;
        }
	}

    public void DoDamage(Transform Player)
    {
        StartCoroutine(DoDamageCoroutine());
    }

    public IEnumerator DoDamageCoroutine()
    {
        GetComponent<Rigidbody>().AddForce(0, 10, 0);
        yield return new WaitForSeconds(0.5f);
        if (Vector3.Distance(transform.position, Player.position) < DistanceThreshold)
        {
            PlayerHealth health = Player.GetComponent<PlayerHealth>();
            health.TakeDamage(Damage);
        }
    }
}
