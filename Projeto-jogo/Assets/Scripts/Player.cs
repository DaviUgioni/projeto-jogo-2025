using Mono.Cecil.Cil;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 posicaoInicial;
    public GameManager GameManager;

    public Animator anim;

    private Rigidbody2D rig;

    public float speed;

    public float jumpforce = 10f;
    private bool isground;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        posicaoInicial = transform.position; // pega posição inicial

    }

    public void ReiniciarPosicao()
    {
        transform.position = posicaoInicial;
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        Jump();

    }

    void Move()
    {  // aqui a variavel tecla é criada para fazer as movimentações
        float teclas = Input.GetAxis("Horizontal");
        rig.linearVelocity = new Vector2(teclas * speed, rig.linearVelocity.y);

        if (teclas > 0 && isground == true)
        {
            transform.eulerAngles = new Vector2(0, 0);
            anim.SetInteger("transition1", 1);
        }
        if (teclas < 0 && isground == true)
        {
            transform.eulerAngles = new Vector2(0, 180);
            anim.SetInteger("transition1", 1);
        }
        if (teclas == 0)
        {
            anim.SetInteger("transition1", 0);
        }

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isground == true)
        {
            rig.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            anim.SetInteger("transition1", 2);
            isground = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tagground")
        {
            isground = true;
            Debug.Log("esta no chão");
        }
    }
}

