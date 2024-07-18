using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float randomRagdollForce;
    public float randomRagdollTorque;

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
            currentHealth = 0;
        }
    }

    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " died.");
        Destroy(gameObject, 3f);
        EnableRagDoll();
    }

    public void EnableRagDoll()
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        Animator anim = GetComponent<Animator>();
        anim.enabled = false;
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = false;
            Vector3 randomDirection = Random.insideUnitSphere;
            rb.AddForce(randomDirection * randomRagdollForce, ForceMode.Impulse);

            Vector3 randomTorqueDirection = Random.insideUnitSphere;
            rb.AddTorque(randomTorqueDirection * randomRagdollTorque, ForceMode.Impulse);
        }
    }
}
