using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Slider hpBar;
    private int currentScore;
    PlayerController playerController;
    private void Awake()
    {
        currentScore = 0;
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        hpBar.value = playerController.playerHp;
    }
    public void GetScore(int enemyScore)
    {
        currentScore += enemyScore;
    }
}
