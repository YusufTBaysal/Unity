using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealt;

    public GameObject lootDrop;

    void Start()
    {
        currentHealt = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealt -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealt <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject, 0f);
        Instantiate(lootDrop, transform.position, Quaternion.identity);
    }


}
