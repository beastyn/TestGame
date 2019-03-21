using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//менедлжер для контроля за основными параметрами
public class GameManager : MonoBehaviour {

    [SerializeField] int playerHealth = 3;
    [SerializeField] Text playerLiveText;
    [SerializeField] GameObject GameOver;

    int gameState = 1; //игра идет -1, игра окончена - 0


    // устанавливает статус игры
    private void SetGameState(int state)
    {
        gameState = state;
    }

    //передаем статус игры
    public int GetGameStatus()
    {
        return gameState;
    }

    //меняем здоровье игрока
    public void TakeLife()
    {
        if (playerHealth > 1)
        {
            playerHealth -= 1;
            playerLiveText.text = playerHealth.ToString();
        }
        else
        {
            playerLiveText.text = "0";
            SetGameState(0);
            ShowGameOver();
        }
    }

    //показываем окно окончания игры
    void ShowGameOver()
    {
        GameOver.SetActive(true);
    }

}
