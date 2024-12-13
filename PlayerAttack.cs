using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float cooldown = 0.5f; 
    [SerializeField] private Transform shootPoint;  // where the bullet spawns
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private AudioClip shootSound;  
    private AudioSource audioSource;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float coolDownTimer = Mathf.Infinity; 

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        // check for input and cooldown
        if (Keyboard.current.spaceKey.wasPressedThisFrame && coolDownTimer >= cooldown)
        {
            Attack();
        }

        // update cooldown timer
        coolDownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        // reset the cooldown
        coolDownTimer = 0f;

        // get the direction based on player facing
        float bulletDirection = transform.localScale.x > 0 ? 1 : -1;

        // spawn the bullet
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        // play the shooting sound
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

        // pass the direction to the bullet
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(bulletDirection);
        }


    }
}
