using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBullet : MonoBehaviour
{
    public int speed;

    //SETA AS CORES PADRÕES
    private Color WhiteC = Color.white;
    private Color RedC = Color.red;
    private Color BlueC = Color.blue;
    private Color BlackC = Color.black;

    //VARIAVEIS PRIVADAS-------------------------
    private Renderer rend;

    // Start is called before the first frame update
    private void Start()
    {
        //MINHA POSICAO PEGA DIRETAMENTE PELO GETCOMPONENT
        rend = GetComponent<Renderer>();

        //DESTROY AFTER 10S
        Destroy(gameObject, 10f);

        //CHANGE COLORS BASED ON TAG IN THE START >> PLAYER CHANGES THE COLOR IN THE CODE SHOOTANDCOLLIDE**
        if (gameObject.tag == "white")
        {
            rend.material.color = WhiteC;
        } else if (gameObject.tag == "red")
        {
            rend.material.color = RedC;
        } else if (gameObject.tag == "blue")
        {
            rend.material.color = BlueC;
        } else if (gameObject.tag == "black")
        {
            rend.material.color = BlackC;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        Destroy(gameObject, 0.01f);
    }
}