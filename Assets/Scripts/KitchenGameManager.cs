using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{
    public static KitchenGameManager Instance { get; private set; }

    public event EventHandler OnStateChanged;

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

    public void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }

    public void Update()
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

}
