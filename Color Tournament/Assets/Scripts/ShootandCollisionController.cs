﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootandCollisionController : MonoBehaviour
{
    //MIRAS ESQ E DIR
    private Transform MiraE, MiraD;
    private Transform minhaPos;

    //PRIVATE VARIABLES-------------------------
    private Renderer rend;
    private Renderer CRend;
    private int NumBullet;

    //mode_ OPTIONS
    private int mode_; //0 classic / 1 other** <<GAME MANAGER PASS THE INFO
    private bool fallDeath;
    private bool changeColor;

    //SETA AS CORES PADRÕES
    private Color WhiteC = Color.white;
    private Color RedC = Color.red;
    private Color BlueC = Color.blue;
    private Color GreenC = Color.green;

    //PUBLIC VARIABLES-------------------------
    [Header("Shoot Public Variables")]
    public float coolDownFire = 0.5f;
    public float coolDownFireTimer;

    //ARRAY DE OBJETOS ATIRAVEIS ESQ E DIR
    [Header("GameObjects Shoot List")]
    public GameObject[] shoot;

    //EFFECT ARRAY
    [Header("Effect List")]
    public GameObject hit_effect;

    //SOUND CLIPS
    [Header("Sound Config")]
    private AudioSource source;
    public AudioClip shoot_clip;
    private float volume_clip = 0.15f;

    // START///////////////////////////////////////////////////////////
    private void Start()
    {
        //GET AUDIO SOURCE
        source = GetComponent<AudioSource>();

        //MINHA POSICAO PEGA DIRETAMENTE PELO GETCOMPONENT
        minhaPos = GetComponent<Transform>();
        rend = GetComponent<Renderer>();

        //PEGA OS FILHOS DO OBJETO COMO MIRA E/D
        MiraE = this.gameObject.transform.GetChild(1);
        MiraD = this.gameObject.transform.GetChild(2);

        #region InitialConfig

        //INITIAL COLOR/TAG/CONFIG BY NAME
        if (gameObject.name == "player1")
        {
            //print("player1 Join");
            MudarWhite();
        } else if (gameObject.name == "player2")
        {
            //print("player2 Join");
            MudarRed();
        } else if (gameObject.name == "player3")
        {
            //print("player3 Join");
            MudarBlue();
        } else if (gameObject.name == "player4")
        {
            //print("player4 Join");
            MudarGreen();
        }

        #endregion InitialConfig
    }

    // UPDATE/////////////////////////////////////////////////////
    private void Update()
    {
        #region ModeConfig

        //RECEIVES FROM THE GAME MANAGER THE TYPE OF THE GAME
        mode_ = GameManager_.gameMode;

        //print(mode_);

        //MANAGES THE OPTIONS OF THE MATCH (FALL DEATH , COLOR CHANGE, ...)
        if (mode_ == 0)
        {
            fallDeath = true;
            changeColor = true;
        } else
        {
            fallDeath = false;
            changeColor = false;
        }

        //print("fallDeath" + fallDeath);
        //print("changeColor" + changeColor);

        #endregion ModeConfig

        #region player1

        //pegar inputs de acordo com o player e suas funcoes de acordo com o input
        if (gameObject.name == "player1")
        {
            #region FireCoolDown

            if (coolDownFireTimer > 0)
            {
                coolDownFireTimer -= Time.deltaTime;
            }

            if (coolDownFireTimer <= 0)
            {
                coolDownFireTimer = 0;
            }

            #endregion FireCoolDown

            #region AtirarInput

            if (Input.GetButtonDown("Fire1E") && coolDownFireTimer == 0)
            {
                //atirar
                AtirarE();
                coolDownFireTimer = coolDownFire;

                source.PlayOneShot(shoot_clip, volume_clip);
            }

            if (Input.GetButtonDown("Fire1D") && coolDownFireTimer == 0)
            {
                //atirar
                AtirarD();
                coolDownFireTimer = coolDownFire;

                source.PlayOneShot(shoot_clip, volume_clip);
            }

            #endregion AtirarInput
        }

        #endregion player1

        #region player2

        //pegar inputs de acordo com o player e suas funcoes de acordo com o input
        if (gameObject.name == "player2")
        {
            #region FireCoolDown

            if (coolDownFireTimer > 0)
            {
                coolDownFireTimer -= Time.deltaTime;
            }

            if (coolDownFireTimer <= 0)
            {
                coolDownFireTimer = 0;
            }

            #endregion FireCoolDown

            #region AtirarInput

            if (Input.GetButtonDown("Fire2E") && coolDownFireTimer == 0)
            {
                //atirar
                AtirarE();
                coolDownFireTimer = coolDownFire;

                source.PlayOneShot(shoot_clip, volume_clip);
            }

            if (Input.GetButtonDown("Fire2D") && coolDownFireTimer == 0)
            {
                //atirar
                AtirarD();
                coolDownFireTimer = coolDownFire;

                source.PlayOneShot(shoot_clip, volume_clip);
            }

            #endregion AtirarInput
        }

        #endregion player2

        #region player3

        //pegar inputs de acordo com o player e suas funcoes de acordo com o input
        if (gameObject.name == "player3")
        {
            #region FireCoolDown

            if (coolDownFireTimer > 0)
            {
                coolDownFireTimer -= Time.deltaTime;
            }

            if (coolDownFireTimer <= 0)
            {
                coolDownFireTimer = 0;
            }

            #endregion FireCoolDown

            #region AtirarInput

            if (Input.GetButtonDown("Fire3E") && coolDownFireTimer == 0)
            {
                //atirar
                AtirarE();
                coolDownFireTimer = coolDownFire;

                source.PlayOneShot(shoot_clip, volume_clip);
            }

            if (Input.GetButtonDown("Fire3D") && coolDownFireTimer == 0)
            {
                //atirar
                AtirarD();
                coolDownFireTimer = coolDownFire;

                source.PlayOneShot(shoot_clip, volume_clip);
            }

            #endregion AtirarInput
        }

        #endregion player3

        #region player4

        //pegar inputs de acordo com o player e suas funcoes de acordo com o input
        if (gameObject.name == "player4")
        {
            #region FireCoolDown

            if (coolDownFireTimer > 0)
            {
                coolDownFireTimer -= Time.deltaTime;
            }

            if (coolDownFireTimer <= 0)
            {
                coolDownFireTimer = 0;
            }

            #endregion FireCoolDown

            #region AtirarInput

            if (Input.GetButtonDown("Fire4E") && coolDownFireTimer == 0)
            {
                //atirar
                AtirarE();
                coolDownFireTimer = coolDownFire;

                source.PlayOneShot(shoot_clip, volume_clip);
            }

            if (Input.GetButtonDown("Fire4D") && coolDownFireTimer == 0)
            {
                //atirar
                AtirarD();
                coolDownFireTimer = coolDownFire;

                source.PlayOneShot(shoot_clip, volume_clip);
            }

            #endregion AtirarInput
        }

        #endregion player4

        #region FallDeath

        if (fallDeath)
        {
            //IF THE PLAYER FALLS HE DIES ***
            if (transform.position.y < -20)
            {
                Destroy(gameObject, 0.1F);
            }
        }

        #endregion FallDeath
    }

    #region Shoot

    private void AtirarE()
    {
        if (gameObject.tag == "white") //VERIFY THE TAG
        {
            shoot[NumBullet].tag = "s_white"; //SET THE TAG FOR THE BULLET BY THE MAIN TAG
            shoot[NumBullet + 1].tag = "s_white"; // SET THE TAG FOR THE SECOND BULLET  ''
            Instantiate(shoot[NumBullet], MiraE.transform.position, MiraE.transform.rotation); // CREATE THE BULLET IN THE LEFT GUN POSITION
        } else if (gameObject.tag == "red")
        {
            shoot[NumBullet].tag = "s_red";
            shoot[NumBullet + 1].tag = "s_red";
            Instantiate(shoot[NumBullet], MiraE.transform.position, MiraE.transform.rotation);
        } else if (gameObject.tag == "blue")
        {
            shoot[NumBullet].tag = "s_blue";
            shoot[NumBullet + 1].tag = "s_blue";
            Instantiate(shoot[NumBullet], MiraE.transform.position, MiraE.transform.rotation);
        } else if (gameObject.tag == "green")
        {
            shoot[NumBullet].tag = "s_green";
            shoot[NumBullet + 1].tag = "s_green";
            Instantiate(shoot[NumBullet], MiraE.transform.position, MiraE.transform.rotation);
        }
    }

    private void AtirarD()
    {
        if (gameObject.tag == "white")
        {
            shoot[NumBullet].tag = "s_white";
            shoot[NumBullet + 1].tag = "s_white";
            Instantiate(shoot[NumBullet + 1], MiraD.transform.position, MiraD.transform.rotation);
        } else if (gameObject.tag == "red")
        {
            shoot[NumBullet].tag = "s_red";
            shoot[NumBullet + 1].tag = "s_red";
            Instantiate(shoot[NumBullet + 1], MiraD.transform.position, MiraD.transform.rotation);
        } else if (gameObject.tag == "blue")
        {
            shoot[NumBullet].tag = "s_blue";
            shoot[NumBullet + 1].tag = "s_blue";
            Instantiate(shoot[NumBullet + 1], MiraD.transform.position, MiraD.transform.rotation);
        } else if (gameObject.tag == "green")
        {
            shoot[NumBullet].tag = "s_green";
            shoot[NumBullet + 1].tag = "s_green";
            Instantiate(shoot[NumBullet + 1], MiraD.transform.position, MiraD.transform.rotation);
        }
    }

    #endregion Shoot

    #region ChangeColors

    private void MudarWhite()
    {
        transform.tag = "white"; //CHANGES THE TAG
        rend.material.color = WhiteC; //CHANGES THE MATERIAL COLOR

        //TYPES OF BULLETS FOR EACH MODE
        if ((mode_ == 0))//CLASSIC MODE - CHANGE COLORS
        {
            shoot[NumBullet].tag = "s_white";
            shoot[NumBullet + 1].tag = "s_white";
            NumBullet = 0;
        }
    }

    private void MudarRed()
    {
        transform.tag = "red";
        rend.material.color = RedC;

        //TIPOS DE BULLET PARA CADA MODALIDADE DE JOGO
        if ((mode_ == 0))        //CLASSIC mode_
        {
            shoot[NumBullet].tag = "s_red";
            shoot[NumBullet + 1].tag = "s_red";
            NumBullet = 0;
        }
    }

    private void MudarBlue()
    {
        transform.tag = "blue";
        rend.material.color = BlueC;

        //TIPOS DE BULLET PARA CADA MODALIDADE DE JOGO
        if ((mode_ == 0))        //CLASSIC mode_
        {
            shoot[NumBullet].tag = "s_blue";
            shoot[NumBullet + 1].tag = "s_blue";
            NumBullet = 0;
        }
    }

    private void MudarGreen()
    {
        transform.tag = "green";
        rend.material.color = GreenC;

        //TIPOS DE BULLET PARA CADA MODALIDADE DE JOGO
        if ((mode_ == 0))        //CLASSIC mode_
        {
            shoot[NumBullet].tag = "s_green";
            shoot[NumBullet + 1].tag = "s_green";
            NumBullet = 0;
        }
    }

    #endregion ChangeColors

    #region Collision

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (changeColor) //IF CHANGE COLOR IS ENABLE
        {
            if ((c.gameObject.name == "bulletL(Clone)" || c.gameObject.name == "bulletR(Clone)") && c.gameObject.tag == "s_white") //TOUCHED THE WHITE BULLET
            {
                Invoke("MudarWhite", 0.1f); // FUNCTION THAT CHANGES THE CONFIG TO WHITE
                HitEffect(); // VISUAL EFFECT - "EXPLOSION"
            }
            if ((c.gameObject.name == "bulletL(Clone)" || c.gameObject.name == "bulletR(Clone)") && c.gameObject.tag == "s_red")
            {
                Invoke("MudarRed", 0.1f);
                HitEffect();
            }
            if ((c.gameObject.name == "bulletL(Clone)" || c.gameObject.name == "bulletR(Clone)") && c.gameObject.tag == "s_blue")
            {
                Invoke("MudarBlue", 0.1f);
                HitEffect();
            }
            if ((c.gameObject.name == "bulletL(Clone)" || c.gameObject.name == "bulletR(Clone)") && c.gameObject.tag == "s_green")
            {
                Invoke("MudarGreen", 0.1f);
                HitEffect();
            }
        }
    }

    #endregion Collision

    public void HitEffect()
    {
        Instantiate(hit_effect, transform.position, transform.rotation);
    }
}