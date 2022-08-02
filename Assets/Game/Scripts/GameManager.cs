using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int whereMove;
    public static bool direction = true;
    private static GameManager _shared;
    private const float XLimit = 0;
    private const float YLimit = 3.08f;
    private const float SpeedUp = 0.002f;
    public static int lives = 3;
    public static bool loselive;
    public static int totalScore = 0;
    public string nextScene;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    void Start()
    {
        _shared = this;
    }

    /**
     * Update each frame the lives, scores, user input
     * and check if the game over or the player won
     */
    void Update()
    {
        if (livesText)
        { livesText.text = lives.ToString(); }

        if (scoreText)
        { scoreText.text = totalScore.ToString(); }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            whereMove = 1;
            direction = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            whereMove = 2;
            direction = true;
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            if (nextScene == "Win")
            {
                InitializedGame();
            }
            SceneManager.LoadScene(nextScene);
        }
        
        if (lives != 0) return;
        InitializedGame();
        SceneManager.LoadScene("GameOver");
    }

    /**
     * Initialized the Game parameter - lives and scores
     */
    private void InitializedGame()
    {
        lives = 3;
        totalScore = 0;
    }
    
    /**
     * Get a game object and move him up to the y limit
     * (needed for the enemy and the bubbles)
     */
    public static void MoveUp(GameObject obj)
    {
        var myPos = obj.transform.position;
        Vector2 pos = new Vector2(myPos.x, YLimit);
        myPos = Vector3.Lerp(myPos, pos, SpeedUp);
        obj.transform.position = myPos;
    }

    /**
     * Get a game object and move him up to the x limit
     * (needed for the enemy and the bubbles)
     */
    public static void MoveTo(GameObject obj)
    {
        var myPos = obj.transform.position;
        Vector2 pos = new Vector2(XLimit, YLimit);
        myPos = Vector3.Lerp(myPos, pos, SpeedUp);
        obj.transform.position = myPos;
    }
}
