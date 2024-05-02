using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public TextMeshProUGUI scoreLabel;
    public TextMeshProUGUI EndScoreLabel;

    public Ship ship;
    public UnityEvent OnGameOver = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore( int value)
    {
        score += value;
        scoreLabel.text = "Score\n"+score.ToString();
    }

    public void SetTimeScale ( float scale)
    {
        Time.timeScale = scale;
    }

    public void CheckGameOver()
    {
        //Debug.Log(GameObject.FindGameObjectsWithTag("Meteor").Length - 1);
        if (ship.nbrMeteor == 0 && GameObject.FindGameObjectsWithTag("Meteor").Length - 1 == 0)
        {
            //Debug.Log("Fin de partie");
            EndScoreLabel.text = "Score\n"+ score.ToString();
            OnGameOver.Invoke();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
