using UnityEngine;
using UnityEngine.Video;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class ProvaQuadrat : MonoBehaviour
{
    //PROPIETATS DEL SCRIPT
    //Es veuen i es poden editar desde l'editor de unity perquè s'ha posat public
    public float velocitat = 1f;
    public float forcaSalt = 1f;
    public float velocitatSalt = 1f;
    public Rigidbody2D rb; //Es podria posar private perquè es posa el valor a Start i no s'ha de modificar. He deixat public per no introduir més conceptes.

    public int salts = 0;
    public bool terraCheck;

    public Animator animator;
    public SpriteRenderer sprite;

    public bool canMove = true;
    public int vides = 3;
    public bool viu = true;
    public TextMeshProUGUI textVides;
    public String SceneDeathName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Busca el component Rigidbody2D del GameObject on hi ha l'script.
        //Aquest component és el que fa que s'apliquin físiques a l'objecte
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateClasse();
        MouSetmana1();
        textVides.text = "Vides: " + vides.ToString();
        if (vides <= 0 && viu)
        {
            Mort();
        }   
    }

    void MouSetmana1()
    {
        if (!canMove)
            return;
            
        float hInput = 0;
        if (Input.GetKey(KeyCode.D)) hInput = 1;
        else if (Input.GetKey(KeyCode.A)) hInput = -1;

        if (hInput > 0)
        {
            sprite.flipX = true;
            animator.SetBool("run", true);
        }
        else if (hInput < 0)
        {
            sprite.flipX = false;
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }

        //hInput: valor entre -1 i +1. 0 si no s'apreten tecles d'eix horitzontal
        //velocitat: propietat global, es pot modificar a l'editor
        //NO S'HA DE FER SERVIR SI ES POSA VELOCITAT AMB RIGIDBODY!!! Time.deltaTime: temps desde el frame anterior, perquè la velocitat sigui per segon, no per frame
        float horizontalVelocity = hInput * velocitat;
        
        //Posem el valor que tingui, ho calcula el motor de físiques de unity
        float verticalVelocity = rb.linearVelocity.y;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(salts == 0)
            {
                //No està saltant

                //Si apreta espai fem que vagi cap a dalt
                verticalVelocity = velocitatSalt;
                salts = 1;
            }
            else
            {
                //No pot saltar més
                Debug.Log("No tens més força per saltar...");
            }
            //salts es posa = 0 a OnCollisionEnter2D

        }

        if (terraCheck == true)
        {
            salts = 0;
        }
        //Nova velocitat. Si no hi ha input serà (0, el que hi havia en y)
        rb.linearVelocity = new Vector2(horizontalVelocity, verticalVelocity);

    }

    void Mort()
    {
        viu = false;
        canMove = false;
        SceneManager.LoadScene(SceneDeathName);
    }

}
