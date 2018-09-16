using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    [SerializeField]
    private healthManager health;
    [SerializeField]
    private float holdTime;
    
    public bool playerDown = false;
    public GameObject[] gameOver;

    private void Start()
    {
        playerDown = false;
        holdTime = 0;
    }

    private void Update()
    {
        holdTime += Time.deltaTime;
        if (playerDown || health.getHealth() <= 0)
        {
            for (int i = 0; i < gameOver.Length; i++)
            {
                gameOver[i].SetActive(true);
                if (gameOver[i].GetComponent<Text>() != null)
                    gameOver[i].GetComponent<Text>().text = "Game Over!\n record: " + Mathf.CeilToInt(holdTime).ToString();
            }


            Time.timeScale = 0;
        }

    }

    public void exitScene()
    {
        Application.Quit();
    }
}
