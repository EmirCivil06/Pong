using UnityEngine;
using UnityEngine.UI;

public class DeadZoneScript : MonoBehaviour
{

    [SerializeField] private Text scoreText;
    private int score;

    void Update()
    {
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Respawn"))
        {
            score++;
        }
    }    
}
