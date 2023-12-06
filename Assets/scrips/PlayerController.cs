using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public AudioSource coinAudioSource;
    public AudioSource jumpAudioSource;
    public AudioSource goverAudioSource;
    public float walkSpeed = 8f;
    public float jumpSpeed = 7f;

    // Para mantener nuestro rigid body
    Rigidbody rb;

    // Para mantener el objeto colisionador
    SphereCollider coll;

    // Bandera para llevar un seguimiento de si se ha iniciado un salto
    bool pressedJump = false;

private GameController Puntoscontrol; 

private void Awake()
    {
        Puntoscontrol= (GameController)FindObjectOfType(typeof(GameController));
    }

    // Use this for initialization
    void Start()
    {
        // Obtener el componente de rigid body para su uso posterior
        rb = GetComponent<Rigidbody>();

        // Obtener el colisionador del jugador
        coll = GetComponent<SphereCollider>();
   
    }

    // Actualización se llama una vez por cuadro
    void Update()
    {
        // Manejar el movimiento del jugador
        WalkHandler();

        // Manejar el salto del jugador
        JumpHandler();
    }

    // Hacer que el jugador camine de acuerdo con la entrada del usuario
    void WalkHandler()
    {
        // Establecer las velocidades x y z a 
        rb.velocity = new Vector3(0, rb.velocity.y, 0);

        // Distancia ( velocidad = distancia / tiempo --> distancia = velocidad * tiempo)
        float distance = walkSpeed * Time.deltaTime;

        // Entrada en x ("Horizontal"))
        float hAxis = Input.GetAxis("Horizontal");

        // Entrada en z ("Vertical")
        float vAxis = Input.GetAxis("Vertical");

        // Vector de movimiento
        Vector3 movement = new Vector3(hAxis * distance, 0f, vAxis * distance);

        // Posición actual
        Vector3 currPosition = transform.position;

        //Nueva posición
        Vector3 newPosition = currPosition + movement;

        // Mover el cuerpo rígido
        rb.MovePosition(newPosition);
    }

    // Comprobar si el jugador puede saltar y hacerlo saltar
    void JumpHandler()
    {
        // Jump axis
        float jAxis = Input.GetAxis("Jump");

        // Is grounded
        bool isGrounded = CheckGrounded();

        // Check if the player is pressing the jump key
        if (jAxis > 0f)
        {
            // Make sure we've not already jumped on this key press
            if (!pressedJump && isGrounded)
            {
                // We are jumping on the current key press
                pressedJump = true;

                // Jumping vector
                Vector3 jumpVector = new Vector3(0f, jumpSpeed, 0f);

                // Make the player jump by adding velocity
                rb.velocity = rb.velocity + jumpVector;
                
                //sonido del salto
                //jumpAudioSource.Play();
            }
        }
        else
        {
            // Update flag so it can jump again if we press the jump key
            pressedJump = false;
        }
    }

    // Comprobar si el objeto está en el suelo
    bool CheckGrounded()
    {
        // Object size in x
        float radius = coll.radius;
        
        // Posición de los 4 puntos inferiores del objeto
     
        var pos1 = transform.position + new Vector3(0.01f, 0 , 0.01f);
        var pos2 = transform.position + new Vector3(-0.01f,0 , -0.01f);
        var pos3 = transform.position + new Vector3(-0.01f,0 , 0.01f);
        var pos4 = transform.position + new Vector3(0.01f,0 , -0.01f);
        
        // Send a short ray down the cube on all 4 corners to detect ground
        bool grounded1 = Physics.Raycast(pos1, new Vector3(0, -1, 0), 0.01f+radius);
        bool grounded2 = Physics.Raycast(pos2, new Vector3(0, -1, 0), 0.01f+radius);
        bool grounded3 = Physics.Raycast(pos3, new Vector3(0, -1, 0), 0.01f+radius);
        bool grounded4 = Physics.Raycast(pos4, new Vector3(0, -1, 0), 0.01f+radius);

        bool grounded = grounded1 | grounded2 | grounded3 | grounded4;
        
        //print("Is grounded: "+grounded);
        
        // If any corner is grounded, the object is grounded
        return (grounded);
    }

    void OnTriggerEnter(Collider collider)
    {
        // Comprobar si hemos recogido una moneda
        if (collider.gameObject.tag == "Coin")
        {
            print("Recogiendo moneda..");
            
            // Reproducir sonido de recogida de moneda
            coinAudioSource.Play();

            // Destruir la moneda
            Destroy(collider.gameObject);
            
            //FindObjectOfType<ScoreManager>().AddScore(25);

            Puntoscontrol.AddScore(25);
         

           
            
            // Start coroutine
            //StartCoroutine(waitAndLoad(2.0F));
        }
        else if (collider.gameObject.tag == "Enemy")
        {
            // Fin del juego
            print("Juego terminado");
            //goverAudioSource.Play();

            
        }
    }

 }