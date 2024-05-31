using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntityProperties : MonoBehaviour
{
    // Enum
    public enum Person
    {
        Friend,
        Foe
    };

    // Variables
    [Header("Entity Components")]
    public CharacterController characterController;
    public Person role;
    public bool isEntityAlive = true;
    [Header("Script Variables")]
    public int life = 100;
    public int pelletDamage = 64;
    [Header("Audio Components")]
    public AudioSource audioSource;
    public AudioClip melee;
    public AudioClip laugh;
    public int painSoundSelected;
    public List<AudioClip> friendlyFire;
    public List<AudioClip> pain;
    public AudioClip death;
    [Header("User Interface and In-Game")]
    public TMP_Text interfaceHealthBar;
    public TMP_Text inGameHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
        UpdateHealthValue();

        painSoundSelected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Coroutines
    public IEnumerator WaitForFriendlyFireAudio(AudioClip painAudio, AudioClip friendlyAudio)
    {
        audioSource.PlayOneShot(painAudio);
        yield return new WaitForSeconds(painAudio.length);
        audioSource.PlayOneShot(friendlyAudio);
    }

    public IEnumerator EntityDead()
    {
        audioSource.PlayOneShot(death);
        yield return new WaitForSeconds(death.length);
        gameObject.SetActive(false);
    }

    // Functions
    public void CheckLife()
    {
        if (life <= 0)
        {
            isEntityAlive = false;
            StartCoroutine(EntityDead());
        }
        else
        {
            isEntityAlive = true;
        }
    }

    public void UpdateHealthValue()
    {
        if (interfaceHealthBar != null)
        {
            if (life > 0)
            {
                interfaceHealthBar.text = life.ToString();
            }
            else
            {
                interfaceHealthBar.text = "0";
            }
        }
        
        if (inGameHealthBar != null)
        {
            if (life > 0)
            {
                inGameHealthBar.text = life.ToString();
            }
            else
            {
                inGameHealthBar.text = "0";
            }
        }
    }

    public AudioClip GetRandomAudioClip(List<AudioClip> list)
    {
        int n = list.Count;
        System.Random rng = new System.Random();
        int k = rng.Next(n);
        AudioClip audioClip = list[k];
        painSoundSelected = k;
        return audioClip;
    }

    // OnCollision
    public void OnCollisionEnter(Collision collision)
    {
        // if the pellet collides with the entity 
        if (collision.gameObject.tag.Equals("Pellet"))
        {
            AudioClip painAudio = GetRandomAudioClip(pain);
            AudioClip friendlyAudio = GetRandomAudioClip(friendlyFire);

            if (isEntityAlive && life > 0)
            {
                if (role == (Person)collision.gameObject.GetComponent<AmmoProperties>().personWhoShot)
                {
                    if (!audioSource.isPlaying)
                    {
                        StartCoroutine(WaitForFriendlyFireAudio(painAudio, friendlyAudio));
                    }
                    life -= pelletDamage / 8;
                }
                else
                {
                    life -= pelletDamage;
                    if (!audioSource.isPlaying)
                    {
                        audioSource.PlayOneShot(painAudio);
                    }
                }
            }
            UpdateHealthValue();
            CheckLife();
            Destroy(collision.gameObject);
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        
    }

    public void OnCollisionExit(Collision collision)
    {
        
    }

    // OnTrigger
    public void OnTriggerEnter(Collider other)
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        
    }

    public void OnTriggerExit(Collider other)
    {
        
    }
}
