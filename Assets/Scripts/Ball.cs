using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    //Para almacenar la direccion de la pelota
    private Vector2 direction;
    private Vector2 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        //Accede a la lista de componentes del objeto al cual este asignado y te devuelve el componente el que esta en "<>"
       rb = GetComponent<Rigidbody2D>();
        //rb = gameObject.GetComponent<Rigidbody2D>(); 

        direction.x = Random.Range(-1, 2);
        do
        {
            direction.x = Random.Range(-1, 2);

        } while (direction.x == 0);

        direction.y = Random.Range(-1, 2);
    }

    // Update is called once per frame
    public void ResetPosition()
    {
        transform.position = initialPosition;
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    //El parametro de collision es con quien me he chocado
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PalaMovememt>())
        {
            direction.x *= -1; // direction.x = direction.x * -1;
            direction.y = Random.Range(-1, 2);
            
        }
        else
        {
            //Solo hay techo o suelo
            direction.y *= -1;
        }


    }
}
