using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlayers : MonoBehaviour
{
    public GameObject player1, player2, player3, player4;
    public GameObject enterP1, enterP2, enterP3, enterP4;
    //public GameObject hudp1, hudp2, hudp3, hudp4;
    public Text placarP1, placarP2, placarP3, placarP4;

    // Start is called before the first frame update
    private void Start()
    {
        //SHOWS WHO IS THE PLAYER 1 , PLAYER 2 ...
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        player3 = GameObject.Find("player3");
        player4 = GameObject.Find("player4");

        //FIND THE UI "JOIN  PLAYER "
        enterP1 = GameObject.Find("JoinP1");
        enterP2 = GameObject.Find("JoinP2");
        enterP3 = GameObject.Find("JoinP3");
        enterP4 = GameObject.Find("JoinP4");

        //FIND THE UI HUD OF EACH PLAYER
        //hudp1 = GameObject.Find("hudp1");
        //hudp2 = GameObject.Find("hudp2");
        //hudp3 = GameObject.Find("hudp3");
        //hudp4 = GameObject.Find("hudp4");

        //////////////////////////////////MiraE = this.gameObject.transform.GetChild(1);

        //DISABLE ALL PLAYERS UNTIL THEY PRESS THE BUTTON
        //player1.SetActive(false);
        //player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        #region HUD PLAYER CHECKER

        //ACTIVE PLAYER ONE
        if (player1)
        {
            if (!player1.active)// IF THE PLAYER IS NOT IN
            {
                enterP1.SetActive(true);//SHOWS THE MESSAGE TO JOIN
                //hudp1.SetActive(false);//HIDE THE HUD OF THE PLAYER
                if (Input.GetKeyDown(KeyCode.W))
                {
                    player1.SetActive(true);
                }
            } else// IF THE PLAYER JOIN HIDE THE MESSAGE
            {
                enterP1.SetActive(false);//HIDE THE MESSAGE TO JOIN
              //  hudp1.SetActive(true);//SHOW THW HUD OF THE PLAYER
            }
        }

        //ACTIVE PLAYER TWO
        if (player2)
        {
            if (!player2.active)
            {
                enterP2.SetActive(true);//SHOWS THE MESSAGE TO JOIN
               // hudp2.SetActive(false);//HIDE THE HUD OF THE PLAYER
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    player2.SetActive(true);
                }
            } else// IF THE PLAYER JOIN HIDE THE MESSAGE
            {
                enterP2.SetActive(false);//HIDE THE MESSAGE TO JOIN
              //  hudp2.SetActive(true);//SHOW THW HUD OF THE PLAYER
            }
        }

        //ACTIVE PLAYER THREE
        if (player3)
        {
            if (!player3.active)
            {
                enterP3.SetActive(true);//SHOWS THE MESSAGE TO JOIN
               // hudp3.SetActive(false);//HIDE THE HUD OF THE PLAYER
                if (Input.GetKeyDown(KeyCode.I))
                {
                    player3.SetActive(true);
                }
            } else// IF THE PLAYER JOIN HIDE THE MESSAGE
            {
                enterP3.SetActive(false);//HIDE THE MESSAGE TO JOIN
              //  hudp3.SetActive(true);//SHOW THW HUD OF THE PLAYER
            }
        }

        //ACTIVE PLAYER FOUR
        if (player4)
        {
            if (!player4.active)
            {
                enterP4.SetActive(true);//SHOWS THE MESSAGE TO JOIN
               // hudp4.SetActive(false);//HIDE THE HUD OF THE PLAYER
                if (Input.GetKeyDown(KeyCode.Keypad8))
                {
                    player4.SetActive(true);
                }
            } else// IF THE PLAYER JOIN HIDE THE MESSAGE
            {
                enterP4.SetActive(false);//HIDE THE MESSAGE TO JOIN
                //hudp4.SetActive(true);//SHOW THW HUD OF THE PLAYER
            }
        }

        #endregion HUD PLAYER CHECKER

        #region uPDATE SCORE UI

        placarP1.text = "" + GameManager_.scoreW;
        placarP2.text = "" + GameManager_.scoreR;
        placarP3.text = "" + GameManager_.scoreB;
        placarP4.text = "" + GameManager_.scoreK;

        #endregion uPDATE SCORE UI
    }
}