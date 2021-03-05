using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Play;
        AddTransition(Transition.PauseButtonClick, StateID.Menu);
        AddTransition(Transition.HomeButtonClick, StateID.Menu);
    }

    public override void DoBeforeEntering()
    {
        controller.view.ShowGameUI(controller.model.Score,controller.model.BestScore);
        controller.cameraManger.ZoomOut();
        controller.gameManger.StartGame();
    }

    public override void DoBeforeLeaving()
    {
        controller.view.HideGameUI();
        controller.cameraManger.ZoomIn();
        controller.gameManger.PauseGame();
        controller.view.ShowRestartButton();
    }

    public void OnPauseButtonClick()
    {
        controller.audioManger.PlayButtonClickAudio();
        fsm.PerformTransition(Transition.PauseButtonClick);
    }

    public void OnHomeButtonClick()
    {
        controller.audioManger.PlayButtonClickAudio();
        controller.view.HideGameOverUI();
        controller.model.RestartGame();
        fsm.PerformTransition(Transition.HomeButtonClick);
    }

    public void OnRestartButtonClick()
    {
        controller.audioManger.PlayButtonClickAudio();
        controller.model.RestartGame();
        controller.view.HideGameOverUI();
        controller.view.UpdateScoreUI(controller.model.Score, controller.model.BestScore);
        controller.gameManger.StartGame();
    }
}
