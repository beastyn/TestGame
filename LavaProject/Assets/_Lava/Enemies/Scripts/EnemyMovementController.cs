using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//класс для управления движением врага
public class EnemyMovementController : MonoBehaviour {

    [SerializeField] float startDownSpeed = 10f;
    [SerializeField] float minAngleDelta = -5f;
    [SerializeField] float maxAngleDelta = 5f;

    Vector3 movementDirection;

    Rigidbody myRigidbody;
    GameManager gameManager;


    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start () {

        movementDirection = new Vector3(0f, -1f, 0);
        
	}
	

	void Update ()
    {
        //Двигаем только пока игра идет
        if (gameManager.GetGameStatus() != 0)
        {
            MoveDown();
        }
        else
        {
            //морозим все
            myRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
                
        }
    }

    //кидаем круги вниз
    private void MoveDown()
    {
        //задаем изменение позиции с учетом времени с предыдущего фрема в заданном направлении
        Vector3 deltaPosition = movementDirection * Time.deltaTime* startDownSpeed;
        
        //меняем позицию
        transform.position = transform.position + deltaPosition;
        
    }

    // при столкновении меняем направление на противоположное с небольшим отклонением, для динамики 
    public void ChangeDirection()
    {
        //случайное отклонение
        float randomAngle = Random.Range(minAngleDelta, maxAngleDelta);

        //смена направления
        movementDirection = Quaternion.Euler(0, 0, randomAngle) * movementDirection *(-1) ; 
      
    }
}
