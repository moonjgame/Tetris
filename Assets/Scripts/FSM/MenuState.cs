using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Menu;
        AddTransition(Transition.StartButtonClick, StateID.Play);
        AddTransition(Transition.RestartButtonClick, StateID.Play);
    }

    public override void DoBeforeEntering()
    {
        controller.view.ShowMenuUI();
        controller.cameraManger.ZoomIn();
    }

    public override void DoBeforeLeaving()
    {
        controller.view.HideMenuUI();
    }

    public void OnStartButtonClick()
    {
        controller.audioManger.PlayButtonClickAudio();
        fsm.PerformTransition(Transition.StartButtonClick);
    }

    public void OnRestartButtonClick()
    {
        controller.audioManger.PlayButtonClickAudio();
        controller.model.RestartGame();
        controller.gameManger.ClearCurrentShape();
        fsm.PerformTransition(Transition.RestartButtonClick);
    }

    public void OnSettingButtonClick()
    {
        controller.audioManger.PlayButtonClickAudio();
        controller.view.ShowSettingUI(controller.model.IsMute);
    }

    public void OnSoundButtonClick()
    {
        if (controller.model.IsMute == 0)
        {
            controller.view.ShowMute();
            controller.model.SetMute(1);
            controller.audioManger.PlayButtonClickAudio();
        }
        else
        {
            controller.view.HideMute();
            controller.model.SetMute(0);
            controller.audioManger.PlayButtonClickAudio();
        }
    }

    public void OnCloseSettingButtonClick()
    {
        controller.audioManger.PlayButtonClickAudio();
        controller.view.HideSettingUI();
    }

    public void OnRankButtonClick()
    {
        controller.audioManger.PlayButtonClickAudio();
        controller.view.ShowRankUI(controller.model.Score,controller.model.BestScore,controller.model.NumbersGame);
    }

    public void OnClearHistoryButtonClick()
    {
        controller.audioManger.PlayButtonClickAudio();
        controller.model.ClearHistory();
        controller.view.UpdateRankUI(0, 0, 0);
    }

    public void OnCloseRankButtonClick()
    {
        controller.audioManger.PlayButtonClickAudio();
        controller.view.HideRankUI();
    }
}
