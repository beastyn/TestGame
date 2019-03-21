using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// снимаем очки жизки с врага и сопутствующие эффекты тут же. Колижены в EnemyCollisionHandler
public class EnemyHealthHandler : MonoBehaviour {

    int enemyLives = 2;
    bool isBlinking = false;

    TextMesh enemyLivesText;
    Renderer myRenderer;
   
    private void Awake()
    {
        enemyLivesText = GetComponentInChildren<TextMesh>();
        myRenderer = GetComponent<Renderer>();

    }

    private void Start()
    {
        // задаем рандомно количество жизней врага
        enemyLives = Random.Range(2, 10);
        
        // выводим жизни на ярлык врага
        enemyLivesText.text = enemyLives.ToString();
    }

    //при столкновении с частицами убираем жизнь, запускаем корутину мигания и убиваем, если жизней не осталось
    public void ProcessHit()
    {
        if (enemyLives > 1)
        {
            HealthDecrease();

        }
        else
        {
            EnemyDeath();
        }

    }

    private void HealthDecrease()
    {
        //уменьшаем жизни на 1
        enemyLives -= 1;

        //обновляем тект на враге
        enemyLivesText.text = enemyLives.ToString();

        //проверяем, надо ли запускать мигание. Если враг еще не вышел из цикла мигания, повторно не запускаем. Запускаем корутину мигания
        if (!isBlinking) { StartCoroutine(EnemyBlinking()); }
    }

    //Мигание врага при столкновении с частицами
    IEnumerator EnemyBlinking()
    {
        // определяем количество миганий
        int i = 0;

        // мигаем, включая и выключая компненты рендеринга с задержкой по времени
        while (i < 3)
        {
            isBlinking = true;
            enemyLivesText.gameObject.SetActive(false);
            myRenderer.enabled = false;

            yield return new WaitForSeconds(0.2f);

            myRenderer.enabled = true;
            enemyLivesText.gameObject.SetActive(true);

            yield return new WaitForSeconds(0.2f);

            i++;
            isBlinking = false;
        }
    }

    // убиваем врага, если жизней 0
    void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
