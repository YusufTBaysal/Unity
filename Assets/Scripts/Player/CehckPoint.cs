using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CehckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerManager.checkPoint = transform.position;
        }
    }
}
