using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle;

    //state
    Vector2 paddleToBall;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBall = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(x: paddle.transform.position.x, y: paddle.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }
}
