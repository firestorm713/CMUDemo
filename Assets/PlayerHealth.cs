using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public UnityEvent DamageTaken;      // Part 3
    public float MaxHealth = 100;
    public float CurrentHealth = 100;

    public float CooldownTime = 0.5f;
    float DamageLastTaken = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void TakeDamage(float amt)
    {
        if (Time.time - DamageLastTaken > CooldownTime)
        {
            DamageTaken.Invoke();
            if (CurrentHealth > 0)
                CurrentHealth -= amt;
            else
                Debug.Log("Game Over Man!");
        }
    }
}
