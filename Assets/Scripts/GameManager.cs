using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum GameStates {inTitle,inGame,paused};
    public GameStates state2 = GameStates.inTitle;
    public string state =  "inTitle";

    public Pause pauseMenu;

    private float pauseCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "inGame")
        {
            pauseCounter += Time.deltaTime;
            if (pauseCounter > 90)
            {
                GoToTitle();
                pauseCounter = 0;
            }


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.ToggleActive();
                /*if (pauseMenu.gameObject.activeSelf)
                {
                    pauseMenu.gameObject.SetActive(false);
                }
                else
                {
                    pauseMenu.gameObject.SetActive(true);
                }
                //pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);*/
            }

        }

        Input.GetKeyDown(KeyCode.Escape);
        //gameObject.activeSelf

    }

    public static void GoToGame()
    {
        SceneManager.LoadScene("Game");
        Instance.state =  "inGame";
        Instance.state2 = GameStates.inGame;
    }

    public static void GoToTitle()
    {
        SceneManager.LoadScene("Title");
        Instance.state =  "inTitle";
        Instance.state2 = GameStates.inTitle;
    }
}
