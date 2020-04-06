using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winnerText : MonoBehaviour
{
    public Text winText;

    // Start is called before the first frame update
    private void Start() { }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager_.p1win)
        {
            winText.text = "PLAYER 1 WON";
        } else if (GameManager_.p2win)
        {
            winText.text = "PLAYER 2 WON";
        } else if (GameManager_.p3win)
        {
            winText.text = "PLAYER 3 WON";
        } else if (GameManager_.p4win)
        {
            winText.text = "PLAYER 4 WON";
        }
    }
}