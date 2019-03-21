using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSettings : MonoBehaviour {

    [SerializeField] GameObject settingsWindow;

    public void OpenSettings()
    {
        settingsWindow.SetActive(true);
    }

    //TODO make menu different way
      
}
