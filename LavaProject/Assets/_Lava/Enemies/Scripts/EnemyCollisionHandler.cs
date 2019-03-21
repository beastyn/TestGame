using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//рассматриваем случаи столкновения.
public class EnemyCollisionHandler : MonoBehaviour {


    AudioSource myAudioSource;
    [SerializeField] AudioClip boom;


    private void Awake()
    {
       
        myAudioSource = GetComponent<AudioSource>();
    }

    //столкновение со стеной и игроком
    private void OnCollisionEnter(Collision collision)
    {
        SendMessage("ChangeDirection");
        
        myAudioSource.clip = boom;
        myAudioSource.PlayOneShot(boom);

    }

    //столкновение с частицами
    private void OnParticleCollision(GameObject other)

    {
        SendMessage("ProcessHit");
        
    }

    //TODO make audio in other script


}
