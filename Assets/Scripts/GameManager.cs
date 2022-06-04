using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public string sceneName;
    public int point, score, level;
    private UIManager uiManager;
    [SerializeField] ParticleSystem finishParticles;
    [SerializeField] GameObject gate, gateLocation, enemy;

    // Start is called before the first frame update
    void Start()
    {
        point = 0;
        score = 0;
        isGameActive = false;
        enemy = GameObject.Find("TowerEnemy");
        sceneName = SceneManager.GetActiveScene().name;
        gateLocation = GameObject.Find("GateLocation");
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        if(sceneName == "Level1")
        {
            uiManager.UpdateScore(score);
        }
        else
        {
            score = DataManager.instance.score;
            uiManager.UpdateScore(score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameControl();
    }

    //Game flow control:
    private void GameControl()
    {
        if (sceneName == "Level1")
        {
            if (point == 96)
            {
                OpenGate();
                Destroy(enemy);
            }
            else if(point == 131)
            {
                PlayParticleSystem();
                score = 100;
                isGameActive = true;
                uiManager.level = 1;
                uiManager.UpdateScore(score);         
                uiManager.NextLevelActive();
            }
            uiManager.UpdateSectionInfo(1, 2);            
        }
        else if (sceneName == "Level2")
        {
            if (point == 20)
            {
                OpenGate();
                Destroy(enemy); 
            }
            else if (point == 86)
            {
                PlayParticleSystem();
                score = 200;
                isGameActive = true;
                uiManager.level = 0;           
                uiManager.UpdateScore(score);
                uiManager.NextLevelActive();
            }
            uiManager.UpdateSectionInfo(2, 3);
        }
    }

    //Add one point to point value:
    public void AddPoint()
    {
        point++;
        if(sceneName == "Level1")
        {
            uiManager.UpdateProgress(96, point);
        }
        else if (sceneName == "Level2")
        {
            uiManager.UpdateProgress(20, point);
        }
    }

    //Finish game:
    public void GameOver()
    {
        isGameActive = true;
        uiManager.GameOverActive();
    }

    //Open automatically bridge gate:
    public void OpenGate()
    {
        var step = 2.0f * Time.deltaTime;
        gate.transform.position = Vector3.MoveTowards(gate.transform.position, gateLocation.transform.position, step);
    }

    //Play particle system:
    private void PlayParticleSystem()
    {
        if (!isGameActive)
        {
            finishParticles.Play();
        }
    }
}
