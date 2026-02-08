using UnityEngine;

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
    }

    //Codi fet a classe el 17/12, posat aquí perquè no s'executi
    void UpdateClasse()
    {
        //MODIFICAR TRANSFORMADA.
        //Després fent servir RigidBody per les físiques no s'hauria de fer servir res d'això.
        //He demanat que el codi que facin del moviment NO utilitzi Translate.

        //MODIFICAR POSICIÓ
        //transform.position = new Vector3(0f, 0f, 0f); //nova posició
        //transform.Translate(new Vector3(0.01f, 0f, 0f)); //mou l'objecte

        //MODIFICAR ROTACIÓ
        //transform.Rotate(new Vector3(0f, 0f, 1f)); //rota l'objecte

        //INPUT USUARI - TECLAT
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("HAS APRETAT L'ESPAI!!!");
        }
        */
        //GetKey => Està apretada
        //GetKeyDown => S'acaba d'apretar
        //GetKeyUp => S'acaba d'aixecar

        //Input esquerra (-1) - dreta (+1)
        //AS, fletxa esquerra/dreta, joystick esquerra/dreta...
        float hInput = Input.GetAxis("Horizontal");

        //WS, fletxa adalt/abaix, joystick adalt/abaix...
        float vInput = Input.GetAxis("Vertical");



        //He comentat això però no aplica al joc de plataformes, és per jocs top-down
        /*
        Vector2 direccioMoviment = new Vector2(hInput, vInput);
        direccioMoviment.Normalize();

        float movimentHoritzontal = direccioMoviment.x * Time.deltaTime * velocitat;
        float movimentVertical = direccioMoviment.y * Time.deltaTime * velocitat;
        transform.Translate(new Vector3(movimentHoritzontal, movimentVertical, 0f));
        */


        //Codi per saltar
        //Quan s'apreta la tecla espai fa el if
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("HAS APRETAT L'ESPAI!!!");

            //Manera 1: aplicar una força
            //Pro: té en compte la massa de l'objecte (propietat de rigidbody, inspector)
            //Con: per exemple si està caient salta amb molt poca força
            //rb.AddForce(Vector2.up * forcaSalt);

            //Manera 2: modificar directament la velocitat
            //Pro: control més directe, no hi ha el con de l'altre
            //Con: no es té en compte la massa
            rb.linearVelocity = Vector2.up * velocitatSalt;
        }


        //Mantenir velocitat vertical però posar 0 a la horitzontal
        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);

    }

    //Codi que compleix amb el que es demana a l'enunciat
    //Segurament ho tinguin directament a Update.
    void MouSetmana1()
    {
        //Valor entre -1 i 1 per controlar moviment horitzontal
        float hInput = Input.GetAxis("Horizontal");

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
}
