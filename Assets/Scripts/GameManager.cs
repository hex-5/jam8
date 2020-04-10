﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float SecondsPerCycle = 10.0f;
    [SerializeField] float WordsPerSecond = 0.33333f;
    [SerializeField] GameObject WordSpawner = null;
    public enum RESULTS
    {
        GOOD,
        BAD_ENDING_1,
        BAD_ENDING_2
    }
    //[SerializeField] ...

    class GameCycle
    {
        public float Countdown
        {
            get; set;
        }
        public float WordCountdown
        {
            get; set;
        }
    }

    GameCycle currentCycle;

    public void StartNewCycle()
    {
        if(currentCycle == null)
        {
            currentCycle = new GameCycle();
            currentCycle.Countdown = SecondsPerCycle;
            currentCycle.WordCountdown = 1.0f / WordsPerSecond;
            //currentCycle.Points = 0;
        }
        //Todo: Reset everything for a new cycle

        Debug.Log("Resetted everything and started a new cycle with new points.");
    }
    public void StartNextCycle()
    {
        //only reset countdown
        currentCycle.Countdown = SecondsPerCycle;
        currentCycle.WordCountdown = 1.0f / WordsPerSecond;
        //Todo: reset words
        Debug.Log("Resetted words and started a new cycle with existing points. [todo: getPointsFromSomewhere()]");
    }
    public void EndCurrentCycle(RESULTS result)
    {
        Debug.Log("Cycle ended with [todo: getPointsFromSomewhere()] Points.");
        switch (result)
        {
            case RESULTS.BAD_ENDING_1:
            case RESULTS.BAD_ENDING_2:
                //Todo: Script Endings and reset to start
            case RESULTS.GOOD:
            default:
                StartNextCycle();
                break;
        }
    }
    public void UpdateRunningCycle()
    {
        currentCycle.Countdown -= Time.unscaledDeltaTime;
        if(currentCycle.Countdown < 0)
        {
            //countdown is over, cycle isnt stopped anywhere else in the game, so it was successful.
            EndCurrentCycle(RESULTS.GOOD);
        }
        currentCycle.WordCountdown -= Time.unscaledDeltaTime;
        if (currentCycle.WordCountdown < 0)
        {
            currentCycle.WordCountdown = 1.0f / WordsPerSecond;
            SpawnWord();
        }
    }

    public void SpawnWord()
    {
        Debug.Log("Spawned new word!");
        //WordSpawner.GetComponent<Spawner>().Spawn(); or sth
        //Todo: Spawn Word
    }

    // Start is called before the first frame update
    void Start()
    {
        StartNewCycle();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRunningCycle();
    }
}