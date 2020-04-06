using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour
{
    public void _Menu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void _ModeSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void _ClassicMode()
    {
        int index = UnityEngine.Random.Range(2, 6);
        SceneManager.LoadScene(index);
    }

    public void _BonusMode()
    {
        //SceneManager.LoadScene(3);
    }
}