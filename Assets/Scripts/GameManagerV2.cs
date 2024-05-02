using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManagerV2 : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreLabel;
    public TextMeshProUGUI EndScoreLabel;

    public Creator creator;
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

    public void AddScore(int value)
    {
        score += value;
        scoreLabel.text = score.ToString();
    }

    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }

    public void CheckGameOver()
    {
        //Debug.Log(GameObject.FindGameObjectsWithTag("Meteor").Length - 1);
        if (creator.nbrBille == 0 && GameObject.FindGameObjectsWithTag("Bille").Length - 1 == 0)
        {
            //Debug.Log("Fin de partie");
            EndScoreLabel.text = "Score\n" + score.ToString();
            OnGameOver.Invoke();
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
