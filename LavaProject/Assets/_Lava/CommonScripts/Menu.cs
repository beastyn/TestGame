using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Основные функции для кнопок меню. Не оптимально.
public class Menu : MonoBehaviour {
   
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
      
    }

    public void BackToMenu()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);

    }
}
