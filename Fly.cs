
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fly : MonoBehaviour
{
    [SerializeField] private float velocity,rotationSpeed;
    [SerializeField] private Rigidbody2D rb;
    public GameManager gameManager;
    private bool isStarted= false;
    public static int score = 0;
    private Score scoreScript;

    public AudioClip jumpSound;
    public AudioClip gameOverSound;
    public AudioClip scoreSound;

    void Start()
    {
        Application.targetFrameRate = 60;
        rb.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Başlangıçta yerçekimini devre dışı bırak
        scoreScript = FindObjectOfType<Score>();
        score = 1;
        gameManager = FindObjectOfType<GameManager>(); // GameManager nesnesine erişimi burada yapın
    }

    void Update()
    {
         if (!isStarted && Input.GetMouseButtonDown(0))
        {
            isStarted = true;
            rb.gravityScale = 1; // Tıklandığında yerçekimini etkinleştir
        }
        if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity; //Jump
            SoundManager.instance.PlaySound(jumpSound);
        }
    }

    private void FixedUpdate() 
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }

    
     private void OnCollisionEnter2D(Collision2D other) 
    {   if (other.gameObject.CompareTag ("DeathArea"))
        {
            SoundManager.instance.PlaySound(gameOverSound);
            gameManager.GameOver();
        }
    }
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ScoreArea"))
        {   
            scoreScript.ScoreUp();
            score++;
            Debug.Log(score);
            SoundManager.instance.PlaySound(scoreSound);
        }
    }


}