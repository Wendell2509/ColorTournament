using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootMoviment : MonoBehaviour
{
    //tiro vai para esquerda? senao direita
    public bool LeftShoot;
    public bool EncostarMorre;

    //CODIGO QUE FAZ COM QUE A BULLET CONSIGA EMPURRAR O JOGADOR E CONSERTAR O ERRO DE COLISAO ENTRE COLLIDER
    private Rigidbody2D rb2;
    private Renderer rend;
    public int force;
    public float dieTime;

    //SETA AS CORES PADRÕES
    private Color WhiteC = Color.white;
    private Color RedC = Color.red;
    private Color BlueC = Color.blue;
    private Color GreenC = Color.green;

    //EFFECT ARRAY
    [Header("Effect List")]
    public GameObject hitSmall_Effect;

    //SOUND CLIPS
    private AudioSource source;
    public AudioClip hit_clip;
    private float volume_clip = 0.03f;

    //VARIAVEIS PRIVADAS-------------------------

    // Start is called before the first frame update
    private void Start()
    {
        //GET AUDIO SOURCE
        source = GetComponent<AudioSource>();

        //MINHA POSICAO PEGA DIRETAMENTE PELO GETCOMPONENT
        rend = GetComponent<Renderer>();

        //DESTROY AFTER 10S
        Destroy(gameObject, dieTime);

        //CHANGE COLORS BASED ON TAG IN THE START >> PLAYER CHANGES THE COLOR IN THE CODE SHOOTANDCOLLIDE**
        if (gameObject.tag == "s_white")
        {
            rend.material.color = WhiteC;
        } else if (gameObject.tag == "s_red")
        {
            rend.material.color = RedC;
        } else if (gameObject.tag == "s_blue")
        {
            rend.material.color = BlueC;
        } else if (gameObject.tag == "s_green")
        {
            rend.material.color = GreenC;
        }

        rb2 = GetComponent<Rigidbody2D>();

        if (LeftShoot)
        {
            rb2.AddForce(Vector2.left * force);
        } else
        {
            rb2.AddForce(Vector2.right * force);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void HitSmallEffect()
    {
        Instantiate(hitSmall_Effect, transform.position, transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        source.PlayOneShot(hit_clip, volume_clip);
        HitSmallEffect();

        if (EncostarMorre)
        {
            Destroy(gameObject, 0.2f);
        }
    }
}