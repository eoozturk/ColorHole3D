using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    public int level;
    public TextMeshProUGUI startText;
    [SerializeField] Slider pointSlider1, pointSlider2;
    [SerializeField] GameObject gameOverPanel, nextLevelPanel;
    [SerializeField] TextMeshProUGUI scoreText, sectionText1, sectionText2;

    void Start()
    {
        StartCoroutine("StartText", 2.0f);
    }

    IEnumerator StartText(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        startText.gameObject.SetActive(false);
    }

    //Active game over uı elements:
    public void GameOverActive()
    {
        gameOverPanel.gameObject.SetActive(true);
    }

    //Reload level screen:
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Update progress sliders:
    public void UpdateProgress(int range, int x)
    {
        if(x <= range)
        {
            pointSlider1.value = x;

        }
        else if(x > range)
        {
            pointSlider2.value = x;
        }
    }

    //Active next level uı elements:
    public void NextLevelActive()
    {
        nextLevelPanel.gameObject.SetActive(true);
    }

    //Pass another new level:
    public void PassNewLevel()
    {
        SceneManager.LoadScene(level);
    }

    //Update score:
    public void UpdateScore(int xScore)
    {
        DataManager.instance.score = xScore;
        scoreText.text = DataManager.instance.score.ToString();
    }

    //Modify section info texts:
    public void UpdateSectionInfo(int x, int y)
    {
        sectionText1.text = x.ToString();
        sectionText2.text = y.ToString();
    }

    //Exit game:
    public void ExitGame()
    {
        #if UNITY_EDITOR
        
                EditorApplication.ExitPlaymode();
        
        #else
                Application.Quit();
                Debug.Log("Exit");
        #endif
    }
}
