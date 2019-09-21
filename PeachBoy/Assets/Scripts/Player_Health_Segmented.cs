using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health_Segmented : MonoBehaviour {

    public AudioClip CoinPickup;
    private AudioSource source;
    private float volLowRange = 0.5f;
    private float volHighRange = 1.0f;
    // InstaDeath objects should be tagged "Death" and set as a trigger
    // Enemies (and other 1-damage obstacles) should be tagged "Enemy" and should NOT be set as a trigger

    private GameObject respawn;

    private int playerScore;
   

    [Tooltip("The score value of a coin or pickup.")]
    public int coinValue = 100;
    [Tooltip("The amount of points a player loses on death.")]
    public int deathPenalty = 20;

    public Text scoreText;
    // Feel free to add more! You'll need to edit the script in a few spots, though.
    public GameObject health8;
    public GameObject health7;
    public GameObject health6;
    public GameObject health5;
    public GameObject health4;
    public GameObject health3;
    public GameObject health2;
    public GameObject health1;
    // Use this for initialization
    void Start()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn");
        playerScore = 0;
        scoreText.text = playerScore.ToString("D4");
        source = GetComponent<AudioSource>();
        source.clip = CoinPickup;

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            Respawn();
        }
        else if (collision.CompareTag("Coin"))
        {
            AddPoints(coinValue);
            Destroy(collision.gameObject);
            source.PlayOneShot(CoinPickup, 3.0f);
        }
        else if (collision.CompareTag("Finish"))
        {
            Time.timeScale = 0;
        }
        // else if (collision.CompareTag("Health"))
        // {
        //     AddHealth();
        //     Destroy(collision.gameObject);
        // }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage();
        }
        
    }

    private void TakeDamage()
    {
        // For more health, copy the if block for health3, change health3 to whatever yours is,
        // then change the if statement for health3 to else if
        if (health8.activeInHierarchy){
            health8.SetActive(false);
        }
        else if (health7.activeInHierarchy){
            health7.SetActive(false);
        }
        else if (health6.activeInHierarchy){
            health6.SetActive(false);
        }
        else if (health5.activeInHierarchy){
            health5.SetActive(false);
        }
        else if (health4.activeInHierarchy){
            health4.SetActive(false);
        }
        else if (health3.activeInHierarchy)
        {
            health3.SetActive(false);
        }
        else if (health2.activeInHierarchy)
        {
            health2.SetActive(false);
        }
        else
        {
            health1.SetActive(false);
            Respawn();
        }
    }
     
    private void AddHealth()
    {
        if (!health2.activeInHierarchy)
        {
            health2.SetActive(true);
        }
        else if (!health3.activeInHierarchy)
        {
            health3.SetActive(true);
        }
        else if (!health4.activeInHierarchy)
        {
            health4.SetActive(true);
        }
        else if (!health5.activeInHierarchy)
        {
            health5.SetActive(true);
        }
        else if (!health6.activeInHierarchy)
        {
            health6.SetActive(true);
        }
        else if (!health7.activeInHierarchy)
        {
            health7.SetActive(true);
        }
        else if (!health8.activeInHierarchy)
        {
            health8.SetActive(true);
        }
        // For more health, just copy the else if block for health3 and change the name.
    }

    public void Respawn()
    {
        // For more health, just add another similar line here.
        health8.SetActive(true);
        health7.SetActive(true);
        health6.SetActive(true);
        health5.SetActive(true);
        health4.SetActive(true);
        health3.SetActive(true);
        health2.SetActive(true);
        health1.SetActive(true);
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.transform.position = respawn.transform.position;
        AddPoints(deathPenalty);
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void AddPoints(int amount)
    {
        playerScore += amount;
        scoreText.text = playerScore.ToString("D4");
    }
}
