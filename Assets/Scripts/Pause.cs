using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pause : MonoBehaviour
{

    void Start()
    {
        GameManager.Instance.pauseMenu = this;
        gameObject.SetActive(false);  
    }

    public void GoToTitle()
    {
        GameManager.GoToTitle();
    }

    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);  
        if (gameObject.activeSelf)
        {
            GameManager.Instance.state2 = GameManager.GameStates.paused;
            Time.timeScale = 0;

            
        }
        else
        {
            GameManager.Instance.state2 = GameManager.GameStates.inGame;
            Time.timeScale = 1;
        }
    }

}
