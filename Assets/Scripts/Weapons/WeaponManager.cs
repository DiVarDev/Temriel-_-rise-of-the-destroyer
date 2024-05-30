using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Variables
    [Header("Script Variables")]
    public bool isFiring = false;
    public float fireRate;
    public float fireRateCooldown = 0.0f;
    public bool isReloading = false;
    public float reloadDuration;
    public GameObject muzzlePelletSpawnPoint;
    public GameObject pelletPrefab;
    public float pelletVelocity = 15f;
    public GameObject shellPrefab;
    public GameObject shellHidden;
    public Vector3 shellHiddenScale;
    public float shellExitChamberVelocity = 15f;
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
        //shellSpawned.GetComponent<Rigidbody>().AddRelativeForce(shellHidden.transform.right.normalized * shellExitChamberVelocity * Time.deltaTime);
    }

    public void ShootPellet()
    {
        GameObject pelletSpawned = Instantiate(pelletPrefab, muzzlePelletSpawnPoint.transform.position, Quaternion.identity);
        pelletSpawned.transform.localScale = (pelletSpawned.transform.localScale)/32;
        //pelletSpawned.GetComponent<Rigidbody>().AddForce(pelletPrefab.transform.forward.normalized * pelletVelocity * Time.deltaTime, ForceMode.Impulse);
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
        int k = rng.Next(n + 1);
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
