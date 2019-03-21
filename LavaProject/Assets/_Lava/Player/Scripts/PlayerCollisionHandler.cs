using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//класс для реализации колиженов игрока
public class PlayerCollisionHandler : MonoBehaviour {

    GameManager gameManager;
    AudioSource myAudioSource;
    [SerializeField] AudioClip ouch;

        
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //проверяем столкновение с врагом
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.TakeLife();
            myAudioSource.clip = ouch;
            myAudioSource.PlayOneShot(ouch);
            
        }
    }
    //TODO uasio should be separated
}
