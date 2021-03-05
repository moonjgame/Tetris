using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public RectTransform title;
    public RectTransform menuUI;
    public RectTransform gameUI;
    public RectTransform controlButons;
    public Text score;
    public Text bestScore;
    public GameObject gameOverUI;
    public Text gameOverScore;
    public GameObject restartButton;
    public GameObject settingUI;

    public GameObject mute;
    public GameObject rankUI;
    public Text rankScore;
    public Text rankBestScore;
    public Text rankNumbersGame;





    public void ShowRankUI(int score,int bestScore,int numbersGame)
    {
        rankUI.SetActive(true);
        rankScore.text = score.ToString();
        rankBestScore.text = bestScore.ToString();
        rankNumbersGame.text = numbersGame.ToString();

    }

    public void UpdateRankUI(int score, int bestScore, int numbersGame)
    {
        rankScore.text = score.ToString();
        rankBestScore.text = bestScore.ToString();
        rankNumbersGame.text = numbersGame.ToString();
    }
    public void HideRankUI()
    {
        rankUI.SetActive(false);
    }
    public void ShowMute()
    {
        mute.SetActive(true);
    }

    public void HideMute()
    {
        mute.SetActive(false);
    }
    public void ShowSettingUI(int mute)
    {
        if (mute == 0)
        {
            HideMute();
        }
        else
        {
            ShowMute();
        }
        settingUI.SetActive(true);
    }

    public void HideSettingUI()
    {
        settingUI.SetActive(false);
    }
    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }
    public void HideGameOverUI()
    {
        gameOverUI.SetActive(false);
    }
    public void ShowGameOverUI(int score)
    {
        gameOverUI.SetActive(true);
        gameOverScore.text = score.ToString();
    }

    public void UpdateScoreUI(int score, int bestScore)
    {
        this.score.text = score.ToString();
        this.bestScore.text = bestScore.ToString();
    }
    public void ShowGameUI(int score = 0,int bestScore=0)
    {
        gameUI.gameObject.SetActive(true);
        gameUI.DOAnchorPosY(-97.78f, 0.5f);
        controlButons.gameObject.SetActive(true);
        controlButons.DOAnchorPosY(102.2f, 0.5f);
        this.score.text = score.ToString();
        this.bestScore.text = bestScore.ToString();
    }


    public void HideGameUI()
    {
        gameUI.DOAnchorPosY(97.87f, 0.5f).OnComplete(() => gameUI.gameObject.SetActive(false));
        controlButons.DOAnchorPosY(-102.23f, 0.5f).OnComplete(() => controlButons.gameObject.SetActive(false));
    }
    public void ShowMenuUI()
    {
        title.gameObject.SetActive(true);
        title.DOAnchorPosY(-206.9f, 0.5f);
        menuUI.gameObject.SetActive(true);
        menuUI.DOAnchorPosY(102.2f, 0.5f);
    }

    public void HideMenuUI()
    {
        title.DOAnchorPosY(206.94f, 0.5f).OnComplete(()=> title.gameObject.SetActive(false));
        menuUI.DOAnchorPosY(-102.23f, 0.5f).OnComplete(()=> menuUI.gameObject.SetActive(false));

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
