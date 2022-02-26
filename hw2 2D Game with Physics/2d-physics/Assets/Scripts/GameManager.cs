using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Text timeScore;

    
    
    static GameManager instance;

    public GameObject gameOverPanel;
    private void Awake()
    {
        if(instance!=null)
            Destroy(gameObject);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        timeScore.text ="Time:"+ Time.timeSinceLevelLoad.ToString("00");
    }

    public static void GameOver(bool dead)
    {
      if(dead) {
              instance.gameOverPanel.SetActive(true);
              Time.timeScale = 0;
        }
    }

    public void ExitGame()
    {
      // only work when build
        Application.Quit();
    }
    public void RestartGame()
    {
      // reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

}
