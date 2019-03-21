using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// класс управления игроком
public class PlayerController : MonoBehaviour {

    [SerializeField] float movementSpeed = 10f;

    Rigidbody myRigidbody;
    GameManager gameManager;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }


	void Update ()
    {
        //можем двигать игрока только пока он жив, иначе морозим
        if (gameManager.GetGameStatus() != 0)
        {
            Movement();
        }
        else
        {
            myRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
        }
    }

    //двигаем игрока в плоскости
    private void Movement() 
    {
        //берем напраление с контроллера
        float horizontal = SimpleInput.GetAxis("Horizontal");

        //вычисляем изменение положения
        float deltaPosX = horizontal * movementSpeed * Time.deltaTime;

        //меняем позицию 
        transform.position = new Vector3(transform.position.x + deltaPosX, transform.position.y, transform.position.z); 

    }

   
}
