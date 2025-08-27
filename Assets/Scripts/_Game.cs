using UnityEngine;

public class _Game : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    private GameObject ballInstance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballInstance = Instantiate(ballPrefab, new Vector2(0, Random.Range(-3.5f, 3.5f)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (ballInstance == null)
        {
            ballInstance = Instantiate(ballPrefab, new Vector2(0, Random.Range(-3.5f, 3.5f)), Quaternion.identity);
        }
    }
}
