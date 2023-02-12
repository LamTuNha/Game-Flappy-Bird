using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame instance;

    private const string HighScore = "High Score";
    // Start is called before the first frame update
    void Awake()
    {
        _MakeSingelInstance();
        IsGameStartedForTheFirstTime();
    }

    void IsGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey ("IsGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt (HighScore, 0);
            PlayerPrefs.SetInt ("IsGameStartedForTheFirstTime", 0);
        }
    }

    void _MakeSingelInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HighScore, score);
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScore);
    }

}
