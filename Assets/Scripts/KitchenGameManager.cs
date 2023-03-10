using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{
    public static KitchenGameManager Instance { get; private set; }

    public event EventHandler OnStateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameResumed;

    private enum State
    {
        WaitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver,
    }

    private State state;
    private float waititngToStartTimer = 1f;
    private float countDownToStartTimer = 3f;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 10f;

    private bool isGamePause = false;

    private void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }

    private void Start(){
      GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waititngToStartTimer -= Time.deltaTime;
                if (waititngToStartTimer < 0f)
                {
                    state = State.CountDownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountDownToStart:
                countDownToStartTimer -= Time.deltaTime;
                if (countDownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                    gamePlayingTimer = gamePlayingTimerMax;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;
        }
        Debug.Log(state);
    }

    private void GameInput_OnPauseAction(object sender, System.EventArgs e){
        TogglePauseGame();
    }


    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
    public bool IsCountDownToStartActive()
    {
        return state == State.CountDownToStart;
    }
    public bool IsGameOver()
    {
        return state == State.GameOver;
    }


    public float GetCountDownToStartTimer()
    {
        return countDownToStartTimer;
    }
    public float GetGamePlayingTimerNormilized()
    {
        return 1 - (gamePlayingTimer / gamePlayingTimerMax);
    }

    public void TogglePauseGame(){
      isGamePause = !isGamePause;
      if (isGamePause)
      {
        Time.timeScale = 0f;
        OnGamePaused?.Invoke(this, EventArgs.Empty);
      }else {
        Time.timeScale = 1f;
        OnGameResumed?.Invoke(this, EventArgs.Empty);
      }
    }

}
