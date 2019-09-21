using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {


    public AudioClip CheckPointGetto;
    private AudioSource source;
    private float volLowRange = 0.5f;
    private float volHighRange = 1.0f;
    // Attach this to your checkpoints. Checkpoints should have a collider 2D set to trigger.
    // If you want to make a sprite animate on activating the checkpoint, let me know! It shouldn't be too hard to program.
    private GameObject respawn;
    public GameObject Flag0;
    public GameObject Flag1;
    private bool activated = false;

	void Start () {
        respawn = GameObject.FindGameObjectWithTag("Respawn");
        Flag0.SetActive(true);
        Flag1.SetActive(false);
        source = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated)
        {
            if (collision.CompareTag("Player"))
            {
                source.PlayOneShot(CheckPointGetto, 1.0f);
                respawn.transform.position = transform.position;
                Flag0.SetActive(false);
                Flag1.SetActive(true);
                activated = true;
            }
        }
    }

}
