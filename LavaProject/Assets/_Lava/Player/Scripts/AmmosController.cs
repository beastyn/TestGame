using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// класс для контроля поведения частиц
public class AmmosController : MonoBehaviour {


    //скорость и частоту частиц выносим отдельно
    [SerializeField] float firingSpeed = 15f;
    [SerializeField] float firingFrequency = 5f;

    ParticleSystem myParticleSystem;
    ParticleSystem.EmissionModule emissionModule;
    ParticleSystem.MainModule mainModule;
    GameManager gameManager;

    private void Awake()
    {
        
        myParticleSystem = GetComponent<ParticleSystem>();
        emissionModule = myParticleSystem.emission;
        mainModule = myParticleSystem.main;
        gameManager = FindObjectOfType<GameManager>();
    }

    
    
	void Update () {
        
        //для возможности настройки частиц в рантайме
        mainModule.startSpeed = firingSpeed;
        emissionModule.rateOverTime = firingFrequency;

        //выключаем при окончании игры
        if (gameManager.GetGameStatus() == 0)
        {
            gameObject.SetActive(false);
        }

    }
}
