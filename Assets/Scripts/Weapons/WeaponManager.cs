using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Enum
    public enum Person
    {
        Friend,
        Foe
    };


    // Variables
    [Header("Weapon Info")]
    public Person personRole;
    [Header("Script Variables")]
    public bool isFiring = false;
    public float fireRate;
    public float fireRateCooldown = 0.0f;
    public bool isReloading = false;
    public float reloadDuration;
    [Header("Pellet Components")]
    public GameObject muzzlePelletSpawnPoint;
    public GameObject pelletPrefab;
    [Range(0f, 10f)]
    public float pelletVelocity = 3f;
    [Range(1f, 10f)]
    public float pelletVelocityMultiplier = 5;
    [Header("Shell Components")]
    public GameObject shellPrefab;
    public GameObject shellHidden;
    public Vector3 shellHiddenScale;
    [Range(0f, 10f)]
    public float shellExitChamberVelocity = 5f;
    [Range(1f, 10f)]
    public float shellExitChamberVelocityMultiplier = 5f;
    [Header("Animations Components")]
    public Animator animator;
    public AnimationClip idle;
    public AnimationClip firing;
    public AnimationClip reloading;
    [Header("Audio Components")]
    public AudioSource audioSource;
    public AudioClip fire;
    public AudioClip reload;
    public List<AudioClip> bulletshell;

    // Start is called before the first frame update
    void Start()
    {
        isFiring = false;
        fireRate = firing.length;

        reloadDuration = reload.length;

        shellHiddenScale = shellHidden.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Functions
    public void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClip);
    }

    public void Shoot()
    {
        if (!isFiring)
        {
            animator.Play("Firing");
            PlayAudioClip(fire);
        }
    }

    public void SpawnShell()
    {
        GameObject shellSpawned = Instantiate(shellPrefab, shellHidden.transform.position, shellHidden.transform.rotation);
        shellSpawned.transform.localScale = shellHiddenScale * 10;
        //shellSpawned.GetComponent<Rigidbody>().AddRelativeForce(shellHidden.transform.right.normalized * (shellExitChamberVelocity * (shellExitChamberVelocityMultiplier * 500)) * Time.deltaTime);
    }

    public void ShootPellet()
    {
        // Instanciating the pellet
        GameObject pelletSpawned = Instantiate(pelletPrefab, muzzlePelletSpawnPoint.transform.position, Quaternion.identity);
        // Changing the scale of the pellet
        pelletSpawned.transform.localScale = (pelletSpawned.transform.localScale)/32;
        // Assigning the weapontag and who shot
        pelletSpawned.GetComponent<AmmoProperties>().personWhoShot = (AmmoProperties.Person)personRole;
        // Adding the impulse to the pellet
        pelletSpawned.GetComponent<Rigidbody>().AddForce(muzzlePelletSpawnPoint.transform.forward.normalized * (pelletVelocity * (pelletVelocityMultiplier * 500)) * Time.deltaTime, ForceMode.Impulse);
    }

    public void Reload()
    {
        if (!isReloading)
        {
            animator.Play("Reloading");
            PlayAudioClip(reload);
        }
    }

    public AudioClip GetRandomizeBulletShellSound()
    {
        int n = bulletshell.Count;
        System.Random rng = new System.Random();
        int k = rng.Next(n);
        AudioClip audioClip = bulletshell[k];
        return audioClip;
    }

    // Coroutines
    /*IEnumerator FireRateCooldown(float time)
    {
        float fireRateCooldown = fireRate;
        while (fireRateCooldown > 0)
        {
            yield return new WaitForSeconds(1f);
            fireRateCooldown--;
        }
        isFiring = false;
        Debug.Log("Player can fire again...");
    }*/
}
