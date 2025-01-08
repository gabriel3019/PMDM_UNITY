using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{


    public float speed, timeAlive;
    private Vector2 _dir = Vector2.left;
    private Rigidbody2D _rb;
    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= timeAlive)
        {
            currentTime = 0;
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = _dir * speed;
    }

    public void SetDirection(Vector2 value)
    {
        _dir = value;
    }
}
