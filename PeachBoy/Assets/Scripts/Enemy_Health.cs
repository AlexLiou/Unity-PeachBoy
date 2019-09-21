using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour {
	
	public AudioClip DeathExplosion;
    private AudioSource source;
    private float volLowRange = 0.5f;
    private float volHighRange = 1.0f;
	

	public GameObject health;
	//public Player_Health_Segmented PHS;

	void Start(){
		health.SetActive(true);
		GetComponent<Animator>().SetBool("IsDying", false);
		source = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.CompareTag("Shoot")){
			TakeDamage();
			source.PlayOneShot(DeathExplosion, 1.0f);
			Destroy(collision.gameObject, 0.2f);
		}
		if (collision.collider.CompareTag("Slash")){
			TakeDamage();
			source.PlayOneShot(DeathExplosion, 1.0f);
		}

	}

	private void TakeDamage(){
		if (health.activeInHierarchy){
			health.SetActive(false);
			Update();
		}
	}

	void Update () {
		//PHS = GetComponent<Player_Health_Segmented>();
		if (!health.activeInHierarchy || gameObject.transform.position.y < -10) {
			GetComponent<Patrol>().speed = 0f;
			GetComponent<Animator>().SetBool("IsDying", true);
            Destroy(gameObject,0.3f);
			
        }
	}
}
