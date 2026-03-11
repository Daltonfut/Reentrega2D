using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JugadorScript : MonoBehaviour
{
    [Header("Movimiento")]
    public float movimientoX; //1. 
    public float velocidad = 5f; 
    private Rigidbody2D rb; //1. 

    [Header("Salto")]
    public float fuerzaSalto = 4; //2. 

    [Header("Suelo")]
    private bool estaEnSuelo; //3. 
    public LayerMask layerSuelo; //3
    public float radioEsferaSuelo = 0.1f; //3
    public Transform compruebaSuelo; //3

    [Header("Animacion")]
    private Animator animator; //4. 

    //Sonido
    public AudioSource audioSource; //5. 
    public AudioClip getManzana; //5
    public AudioClip sonidoMuerto; //5
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //1.
        animator = GetComponent<Animator>(); //4. 
    }

    void FixedUpdate()
        {
            estaEnSuelo = Physics2D.OverlapCircle(compruebaSuelo.position, radioEsferaSuelo, layerSuelo); //2. 
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(movimientoX * velocidad, rb.linearVelocity.y); //1.
        if(movimientoX == 0)
        {
            animator.SetBool("estaCorriendo", false); //4. 
        }
        animator.SetBool("estaEnSuelo", estaEnSuelo); //4. 

    }
    void OnMove(InputValue inputValue)
    {
        movimientoX = inputValue.Get<Vector2>().x; //1. 
        animator.SetBool("estaCorriendo", true); //4.
        if (movimientoX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movimientoX),1,1); //1. 
        }
    }
    void OnJump(InputValue inputJump)
    {
        if (estaEnSuelo) // 3
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto); //2. 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("coleccionable"))
        {
            audioSource.PlayOneShot(getManzana); //5. 

            Destroy(collision.gameObject); // Destruye la manzana al colisionar con el jugador
            Puntos.instance.SumaPuntos(); // Llama al método para sumar puntos
        }
        if (collision.transform.CompareTag("enemigo"))
        {
            audioSource.PlayOneShot(sonidoMuerto);
            Invoke(nameof(ReiniciarEscena), sonidoMuerto.length);
        }
        if (collision.CompareTag("suelo"))
        {
            audioSource.PlayOneShot(sonidoMuerto);
            Invoke(nameof(ReiniciarEscena), sonidoMuerto.length);
        }
            if (collision.CompareTag("meta"))
        {
            SceneManager.LoadScene("Victoria");
        }
    }
    void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}