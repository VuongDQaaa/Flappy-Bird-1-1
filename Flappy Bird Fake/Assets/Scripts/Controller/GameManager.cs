using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private const string _highScore = "High Score";
    // Start is called before the first frame update
    void Awake()
    {
        _MakeSingleInstance();
        IsFirstTimeStart();
    }

    void _MakeSingleInstance ()
    {
        if (gameManager != null)
        {
            Destroy(gameObject);
        } else 
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IsFirstTimeStart()
    {
        if(!PlayerPrefs.HasKey("IsFirstTimeStart"))
        {
            PlayerPrefs.SetInt(_highScore, 0);
            PlayerPrefs.SetInt("IsFirstTimeStart",0);
        }
    }

    public void _SetHighScore(int score)
    {
        PlayerPrefs.SetInt(_highScore,score);
    }

    public int _GetHighScore()
    {
        return PlayerPrefs.GetInt(_highScore);
    }
}
