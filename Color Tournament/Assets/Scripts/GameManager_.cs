using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_ : MonoBehaviour
{
    //INFO TO VERIFY THE PLAYERS
    public static int gameMode;//0 classic / 1 other** <<GAME MANAGER PASS THE INFO TO THE PLAYERS
    public static bool p1win, p2win, p3win, p4win;
    private int playersCount; //COUNT HOW MANY PLAYERS IN THE SCENE
    private int p1Alive, p2Alive, p3Alive, p4Alive; //SHOWS WHICH PLAYERS ARE ALIVE
    private bool win = false;

    [Header("Points to Win")]
    public int scoreToWin = 5;
    public static int scoreW, scoreR, scoreB, scoreK; //STATIC BECAUSE IT DONT DESTROY ON LOAD

    //SOUND CLIPS
    [Header("Sound Config")]
    private AudioSource source;
    public AudioClip WinRound_clip;
    public float volume_clip = 0.03f;

    //INT TOTAL PLAYERS == FIND PLAYER 1 + FIND PLAYER 2 + FIND PLAYER 3 + FIND PLAYER 4

    public enum MODES
    {
        Classic,
        FreeRules
    }

    //PUBLIC MODE TO BE SELECTED IN THE INSPECTOR
    public MODES modes;

    //START________________________________________________________________________________________
    public void Start()
    {
        //GET AUDIO SOURCE
        source = GetComponent<AudioSource>();

        //BASED IN THE SELECTION IN THE INSPECTOR OF THE LEVEL WILL CHANGE THE GAME MODE
        if (modes == MODES.Classic)
        {
            gameMode = 0;
        } else if (modes == MODES.FreeRules)
        {
            gameMode = 1;
        }
    }

    //UPDATE________________________________________________________________________________________
    public void Update()
    {
        #region FindPlayers

        //SHOWS WHO IS THE PLAYER 1 , PLAYER 2 ...
        GameObject p1 = GameObject.Find("player1");
        GameObject p2 = GameObject.Find("player2");
        GameObject p3 = GameObject.Find("player3");
        GameObject p4 = GameObject.Find("player4");

        #endregion FindPlayers

        #region VerifyAlive

        //VERIFY WHICH PLAYERS ARE ALIVE

        if (p1) { p1Alive = 1; } else { p1Alive = 0; }
        if (p2) { p2Alive = 1; } else { p2Alive = 0; }
        if (p3) { p3Alive = 1; } else { p3Alive = 0; }
        if (p4) { p4Alive = 1; } else { p4Alive = 0; }

        #endregion VerifyAlive

        #region ColorLenght

        //VERIFY HOW MUCH WHITE,RED,... PLAYERS ARE IN THE SCENE
        GameObject[] WhitePlayers = GameObject.FindGameObjectsWithTag("white");
        GameObject[] RedPlayers = GameObject.FindGameObjectsWithTag("red");
        GameObject[] BluePlayers = GameObject.FindGameObjectsWithTag("blue");
        GameObject[] GreenPlayers = GameObject.FindGameObjectsWithTag("green");

        #endregion ColorLenght

        #region WinVerify

        //CALCULATE HOW MUCH PLAYERS ARE ALIVE
        playersCount = p1Alive + p2Alive + p3Alive + p4Alive;

        //VERIFY IF SOME PLAYER WON THE MATCH /
        //WIN BY BEING THE LAST ONE OR TO BE THE ONE COLOR RESTING

        if (gameMode == 0) //CLASSIC MODE
        {
            if ((WhitePlayers.Length >= playersCount) && !win)
            {
                win = true; //SHOWS THAT THE GAME IS OVER, SOME COLOR WON THE GAME
                scoreW++; //ADD THE SCORE TO THE WINNER
                for (int i = 0; i < WhitePlayers.Length; i++)
                {
                    Destroy(WhitePlayers[i]);
                }
                PontuarW();

                //----------------------------------------WHITE
            } else if ((RedPlayers.Length >= playersCount) && !win)
            {
                win = true; //SHOWS THAT THE GAME IS OVER, SOME COLOR WON THE GAME
                scoreR++; //ADD THE SCORE TO THE WINNER
                for (int i = 0; i < RedPlayers.Length; i++)
                {
                    Destroy(RedPlayers[i]);
                }
                PontuarR();

                //----------------------------------------RED
            } else if ((BluePlayers.Length >= playersCount) && !win)
            {
                win = true; //SHOWS THAT THE GAME IS OVER, SOME COLOR WON THE GAME
                scoreB++; //ADD THE SCORE TO THE WINNER
                for (int i = 0; i < BluePlayers.Length; i++)
                {
                    Destroy(BluePlayers[i]);
                }
                PontuarB();

                //----------------------------------------BLUE
            } else if ((GreenPlayers.Length >= playersCount) && !win)
            {
                win = true; //SHOWS THAT THE GAME IS OVER, SOME COLOR WON THE GAME
                scoreK++; //ADD THE SCORE TO THE WINNER
                for (int i = 0; i < GreenPlayers.Length; i++)
                {
                    Destroy(GreenPlayers[i]);
                }
                PontuarK();

                //----------------------------------------green
            }
        }

        #endregion WinVerify

        #region Debug

        //Debug.Log("WhitePlayers: " + WhitePlayers.Length);
        //Debug.Log("RedPlayers: " + RedPlayers.Length);
        //Debug.Log("BluePlayers: " + BluePlayers.Length);
        //Debug.Log("GreenPlayers: " + GreenPlayers.Length);

        Debug.Log("WhiteScore: " + scoreW);
        Debug.Log("RedScore: " + scoreR);
        Debug.Log("BlueScore: " + scoreB);
        Debug.Log("greenScore: " + scoreK);

        //PRINT ***********************
        //print("GameMode: " + gameMode);

        #endregion Debug
    }

    #region SCORES

    private void PontuarW()
    {
        if (scoreW >= scoreToWin)
        {
            p1win = true;
            StartCoroutine(GoToVictoryScene());
        } else
        {
            StartCoroutine(ReloadScene());
        }
    }

    private void PontuarR()
    {
        if (scoreR >= scoreToWin)
        {
            p2win = true;
            StartCoroutine(GoToVictoryScene());
        } else
        {
            StartCoroutine(ReloadScene());
        }
    }

    private void PontuarB()
    {
        if (scoreB >= scoreToWin)
        {
            p3win = true;
            StartCoroutine(GoToVictoryScene());
        } else
        {
            StartCoroutine(ReloadScene());
        }
    }

    private void PontuarK()
    {
        if (scoreK >= scoreToWin)
        {
            p4win = true;
            StartCoroutine(GoToVictoryScene());
        } else
        {
            StartCoroutine(ReloadScene());
        }
    }

    #endregion SCORES

    private IEnumerator ReloadScene()
    {
        source.PlayOneShot(WinRound_clip, volume_clip);
        int index = UnityEngine.Random.Range(3, 9); //CHECK IF IT IS THE GAME SCENES
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(index);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator GoToVictoryScene()
    {
        source.PlayOneShot(WinRound_clip, volume_clip);
        yield return new WaitForSeconds(1.5f);
        resetScore();
        SceneManager.LoadScene(2); //CHECK IF IT IS THE VICTORY SCENE
    }

    private void resetScore()
    {
        scoreW = 0;
        scoreR = 0;
        scoreB = 0;
        scoreK = 0;
    }
}