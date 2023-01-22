using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door2 : MonoBehaviour
{
    private PlayerMovment thePlayer;

    public SpriteRenderer theSR;
    public Sprite doorOpenSprite;

    public bool doorOpen, waitingToOpen;

    public GameObject collectEffect;
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovment>();
    }

    void Update()
    {
        if (waitingToOpen)
        {
            if (Vector3.Distance(thePlayer.followingKey.transform.position, transform.position) < 0.1f)
            {
                waitingToOpen = false;
                doorOpen = true;
                theSR.sprite = doorOpenSprite;
                thePlayer.followingKey.gameObject.SetActive(false);
                thePlayer.followingKey = null;

                collectEffect.SetActive(true);
            }
        }

        if (doorOpen && Vector3.Distance(thePlayer.transform.position, transform.position) < 1f && Input.GetAxis("Vertical") > 0.1f)
        {
            int nextlevel = SceneManager.GetActiveScene().buildIndex + 2;
            if (nextlevel == 13)
            {
                SceneManager.LoadScene(0);
            }
            if (PlayerPrefs.GetInt("ReachedLevel", 1) < nextlevel)
            {
                PlayerPrefs.SetInt("ReachedLevel", nextlevel);
            }
            SceneManager.LoadScene(nextlevel);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (thePlayer.followingKey != null)
            {
                thePlayer.followingKey.followTarget = transform;
                waitingToOpen = true;
            }
        }
    }
}
