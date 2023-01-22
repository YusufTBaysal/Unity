using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    Transform target;
    public Transform groundCheck;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(0.3f, 0.3f);
        }
        else
        {
            transform.localScale = new Vector2(-0.3f, 0.3f);
        }
    }
    
}
