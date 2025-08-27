using UnityEngine;

// Script to handle ball movement and collision sound effects.
public class _BallMovement : MonoBehaviour
{
    // Fields for script
    [SerializeField] private float speed;
    private Vector2 _moveDirection, fixedSpeed1, fixedSpeed2;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    private float interval = 1.3f;
    private float Yspeed;
    private void Start()
    {
        // Initialization code 
        Yspeed = speed * Random.Range(0.4f, 1.05f);
        int randomNumber = Random.Range(0, 2);
        if (randomNumber == 1) _moveDirection = new Vector2(speed, Yspeed);
        else _moveDirection = new Vector2(-speed, Yspeed);
        rb.linearVelocity = _moveDirection;
        fixedSpeed1 = new Vector2(rb.linearVelocityX, speed);
        fixedSpeed2 = new Vector2(rb.linearVelocityX, -speed);
    }
    

    private void FixedUpdate()
    {
        if (rb.linearVelocityY > speed)
        {
            rb.linearVelocity = fixedSpeed1;
        }
        else if (rb.linearVelocityY < -speed)
        {
            rb.linearVelocity = fixedSpeed2;
        }
    }

    // Method to destroy the ball game object
    private void DestroyBall()
    {
        Destroy(gameObject);
    }

    // Method to handle collision events
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.clip = audioClips[Random.Range(2, audioClips.Length - 2)];
            audioSource.Play();
        } else if (collision.gameObject.CompareTag("Border"))
        {
            audioSource.clip = audioClips[Random.Range(0, 2)];
            audioSource.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.clip = audioClips[audioClips.Length - 1]; // Select the last clip for scoring
        if (!audioSource.isPlaying) audioSource.PlayOneShot(audioSource.clip);
        Invoke("DestroyBall", interval);
    }

}