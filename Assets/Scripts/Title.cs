using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToGame()
    {
        GameManager.GoToGame();
    }

    public void NewGame()
    {
        Wizard.stats = new Playerstats();
        GameManager.GoToGame();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
