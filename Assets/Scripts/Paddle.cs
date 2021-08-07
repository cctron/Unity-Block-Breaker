using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screeWithUnits = 16f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screeWithUnits;
        Vector2 vector2 = new Vector2(x: mousePosInUnits, y: transform.position.y);
        transform.position = vector2;
    }
}
