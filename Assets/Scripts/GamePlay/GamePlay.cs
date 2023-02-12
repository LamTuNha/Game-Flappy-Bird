using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
public class GamePlay : MonoBehaviour
{
    public static GamePlay instance;

    [SerializeField]
    private Button gamePlay;

    [SerializeField]
    private Text txtScore, txtBestScore, txtEndScore;

    [SerializeField]
    private GameObject gameOver, options, sound, OnSound;
    [SerializeField]
    private Image medalImage;

    private GameObject FB,IMG;


    void _MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
        FB = GameObject.Find("FB_Flap");
        FB.SetActive(false);
        _MakeInstance();
    }
    public void _GamePlay() 
    {
        Time.timeScale = 1;
        gamePlay.gameObject.SetActive(false);
        FB.SetActive(true);
        IMG = GameObject.Find("Image");
        IMG.SetActive(false);
    }

    public void _SetScore(int score)
    {
        txtScore.text = "" + score;
    }
    public void _GameOverPanel(int score)
    {
        gameOver.SetActive(true);
        txtEndScore.text = "" + score;
        if(score > ManagerGame.instance.GetHighScore())
        {
            ManagerGame.instance.SetHighScore(score);
        }
        txtBestScore.text = "" + ManagerGame.instance.GetHighScore();
        if (score <= 20)
        {
            Sprite medal = Resources.Load<Sprite>("Bronze");
            medalImage.GetComponent<Image>().sprite = medal;
        }
        else if (score > 20 && score <= 50)
        {
            Sprite medal = Resources.Load<Sprite>("Silver");
            medalImage.GetComponent<Image>().sprite = medal;
        }
        else if (score >50  && score <= 200)
        {
            Sprite medal = Resources.Load<Sprite>("Gold");
            medalImage.GetComponent<Image>().sprite = medal;
        }
        else if (score > 200 )
        {
            Sprite medal = Resources.Load<Sprite>("Platinum");
            medalImage.GetComponent<Image>().sprite = medal;
        }
    }

    public void _MenuButton()
    {
        Application.LoadLevel("Menu");

    }
    public void _RePlayButton()
    {
        Application.LoadLevel("GamePlay");
    }
    public void _OptionsButton()
    {
        Time.timeScale = 0;
        options.SetActive(true);
    }
    public void _ResumeButton()
    {
        
        options.SetActive(false);
        _GamePlay();
    }
    public void _SoundsButton()
    {
        Sprite OnSounds = Resources.Load<Sprite>("btnOnSounds");
        Sprite MuteSounds = Resources.Load<Sprite>("btnMuteSounds");
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            OnSound.GetComponent<Image>().sprite = OnSounds;
        } else if(AudioListener.volume == 1)
        {
            OnSound.GetComponent<Image>().sprite = MuteSounds;
            AudioListener.volume = 0;
        }
    }
}
