using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
  int score;
  public static GameManager inst;

  
  public Text scoreText;

  [SerializeField]
  PlayerMove playerMove;

public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        playerMove.speed += playerMove.speedIncreasePerPoint;
    }

    void Awake()
    {
      inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
