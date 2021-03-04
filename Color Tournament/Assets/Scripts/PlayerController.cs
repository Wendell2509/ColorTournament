using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public para poder escolher manualmente direto da unity
    private Rigidbody2D rb;
    public Transform chaoVerificador;

    [Header("Variáveis")]
    public float speed;
    public float forcaPulo;

    //VARIAVEIS BOOLEANAS
    public bool Nochao;

    //CRIA AS VARIAVEIS VERTICAL E HORIZONTAL
    private float v;
    private float h;

    //EFFECT ARRAY
    [Header("Effect List")]
    public GameObject jump_effect;

    //SOUND CLIPS
    private AudioSource source;
    public AudioClip jump_clip;
    private float volume_clip = 0.05f;

    // START
    private void Start()
    {
        //GET AUDIO SOURCE
        source = GetComponent<AudioSource>();

        //PEGA OS ATRIBUTOS NO START
        rb = GetComponent<Rigidbody2D>();

        //PEGA O VERIFICADOR DE CHAO
        chaoVerificador = this.gameObject.transform.GetChild(0);
    }

    private void FixedUpdate()
    {
        #region Moviment

        //pegar inputs de acordo com o player e suas funcoes de acordo com o input
        if (gameObject.name == "player1")
        {
            h = Input.GetAxis("Horizontal1") * speed * Time.deltaTime;
            v = Input.GetAxis("Vertical1") * Time.deltaTime;

            if (Input.GetAxis("Vertical1") > 0 && Nochao) //VERIFY IF ITS ON THE FLOOR AND BUTTON PRESSED TO JUMP
            {
                //rb.AddForce(Vector2.up * forcaPulo);

                rb.velocity = new Vector3(0, forcaPulo, 0); //JUMP FORCE
                JumpEffect(); // VISUAL EFFECT
                source.PlayOneShot(jump_clip, volume_clip); //JUMP SOUND
            }
        } else if (gameObject.name == "player2")
        {
            h = Input.GetAxis("Horizontal2") * speed * Time.deltaTime;
            v = Input.GetAxis("Vertical2") * Time.deltaTime;

            if (Input.GetAxis("Vertical2") > 0 && Nochao)
            {
                //rb.AddForce(Vector2.up * forcaPulo);

                rb.velocity = new Vector3(0, forcaPulo, 0);
                JumpEffect();
                source.PlayOneShot(jump_clip, volume_clip);
            }
        } else if (gameObject.name == "player3")
        {
            h = Input.GetAxis("Horizontal3") * speed * Time.deltaTime;
            v = Input.GetAxis("Vertical3") * Time.deltaTime;

            if (Input.GetAxis("Vertical3") > 0 && Nochao)
            {
                //rb.AddForce(Vector2.up * forcaPulo);

                rb.velocity = new Vector3(0, forcaPulo, 0);
                JumpEffect();
                source.PlayOneShot(jump_clip, volume_clip);
            }
        } else if (gameObject.name == "player4")
        {
            h = Input.GetAxis("Horizontal4") * speed * Time.deltaTime;
            v = Input.GetAxis("Vertical4") * Time.deltaTime;

            if (Input.GetAxis("Vertical4") > 0 && Nochao)
            {
                //rb.AddForce(Vector2.up * forcaPulo);

                rb.velocity = new Vector3(0, forcaPulo, 0);
                JumpEffect();
                source.PlayOneShot(jump_clip, volume_clip);
            }
        }

        //ATUALIZA A POSICAO DO JOGADOR
        transform.Translate(h, 0, 0);

        #endregion Moviment

        transform.Translate(h * Time.deltaTime, 0, 0); //MOVES THE PLAYER BASED IN THE INPUTS

        //VERIFY THE COLLISION WITH THE FLOOR
        Nochao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Ground"));
    }

    private void Update()
    {
    }

    public void JumpEffect()
    {
        Instantiate(jump_effect, transform.position, transform.rotation);
    }
}