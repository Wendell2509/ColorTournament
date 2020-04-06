using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool Menupause;

    public GameObject[] UiA;
    public GameObject[] UiB;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            showTutorial();
        }
    }

    public void showTutorial()
    {
        // Part A: loop with for and access count.
        for (int i = 0; i < UiA.Length; i++)
        {
            // Part B: access element with index.
            (UiA[i]).SetActive(true);
        }

        // Part A: loop with for and access count.
        for (int i = 0; i < UiB.Length; i++)
        {
            // Part B: access element with index.
            (UiB[i]).SetActive(false);
        }
        Time.timeScale = 0.0f;
    }

    public void hideTutorial()
    {
        // Part A: loop with for and access count.
        for (int i = 0; i < UiA.Length; i++)
        {
            // Part B: access element with index.
            (UiA[i]).SetActive(false);
        }

        // Part A: loop with for and access count.
        for (int i = 0; i < UiB.Length; i++)
        {
            // Part B: access element with index.
            (UiB[i]).SetActive(true);
        }
        Time.timeScale = 1.0f;
    }
}