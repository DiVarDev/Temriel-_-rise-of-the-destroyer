using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Variables
    [Header("Script Variables")]
    public bool isFiring = false;
    public float fireRate = 2f;
    public float fireRateCooldown = 0.0f;
    [Header("Animations Components")]
    public Animator animator;
    public AnimationClip idle;
    public AnimationClip firing;
    [Header("Audio Components")]
    public AudioSource audioSource;
    public AudioClip fire;
    public AudioClip reload;
    public List<AudioClip> bulletshell;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
    public void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void Shoot()
    {
        //animator.SetTrigger("isWeaponShooting");
        //animator.SetBool("isWeaponFiring", true);
        //animator.SetTrigger("isWeaponShooting");
        //animator.SetBool("isWeaponFiring", false);
        
        StartCoroutine(FireRateCooldown());
    }

    public void Reload()
    {
        PlayAudioClip(reload);
    }

    public AudioClip GetRandomizeBulletShellSound()
    {
        int n = bulletshell.Count;
        System.Random rng = new System.Random();
        int k = rng.Next(n + 1);
        AudioClip audioClip = bulletshell[k];
        return audioClip;
    }

    // Coroutines
    IEnumerator FireRateCooldown()
    {
        isFiring = true;
        fireRateCooldown = fireRate;
        animator.Play("Firing");
        PlayAudioClip(fire);
        while (fireRateCooldown > 0)
        {
            yield return new WaitForSeconds(1f);
            fireRateCooldown--;
        }
        isFiring = false;
        Debug.Log("Player can fire again...");
    }
}
