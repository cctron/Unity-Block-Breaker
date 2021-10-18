using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    //statef
    Vector2 paddleToBall;
    bool hasStarted = false;

    //Cached component references
    AudioSource audioSource;
    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBall = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rigidbody2D.velocity = new Vector2(x: xPush, y: yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(x: paddle.transform.position.x, y: paddle.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
            rigidbody2D.velocity += velocityTweak;
        }
    }
}
