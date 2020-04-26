using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Enemy Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 150;

    [Header("Enemy Shooting")]
    float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 2f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] GameObject projectile;

    [Header("Enemy Sounds")]
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.75f;
    [SerializeField] [Range(0,1)] float shootSoundVolume = 0.35f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip shootSound;

    [Header("Enemy Visual Effects")]
    [SerializeField] GameObject deathVFX;

    // Start is called before the first frame update
    void Start()
    {
        //Random times enemies shoot
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        // Every frame, shot counter will go down
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        // Make the laser object and move it
        GameObject laser = Instantiate(
            projectile,
            transform.position,
            Quaternion.identity
        ) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage(); 
        //Destroy the laser object if it hits an enemy
        damageDealer.Hit();
        if(health <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 'other' is the object that has just bumped into the enemy
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        // If there is no damage dealer, exit the method
        if(!damageDealer == null)
        {
            return;
        }
        ProcessHit(damageDealer);
    }

    private void Die()
    {
        // Update Score
        FindObjectOfType<GameSession>().AddToScore(scoreValue);

        Destroy(gameObject);
        // Create particle explosion effect where the enemy has died
        GameObject explosion = Instantiate(
            deathVFX, 
            transform.position, 
            transform.rotation);
        Destroy(explosion, durationOfExplosion);
        //Play sound effect
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
    }

}
