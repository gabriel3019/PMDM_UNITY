using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalaMovememt : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private float y;
    private Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANSDALONE || UNITY_EDITOR
        //ESTO OSLO FUNCIONA CON EL ORDENADOR
        y = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(0,y) * speed * Time.deltaTime);

#elif UNITY_ANDROID || UNITY_IOS


        //Y ESTO SOLO SIRVE PARA EL MOVIL
        //El input del movil es el Touch
        //Para detectar el primer toque de la pantalla hacemos un foreach
        //Por cada toque por todos los toque que ha habido en este frein
        // cuatro fases para tocar el movil: levantalo, dejarlo pulsado, moverlo. el que se queda quieto en un punto
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Moved)
            {
                //touch.position
                Vector2 screenCoords = touch.position;
                Vector3 worldCoords = _cam.ScreenToWorldPoint(screenCoords);

                transform.position = new Vector3(transform.position.x, worldCoords.y, transform.position.z);
            }
            else if(touch.phase == TouchPhase.Ended) 
            {
                GetComponent<SpriteRenderer>().color = new Color(
                    Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);

            }
        }
#endif

    }




    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(0, y) * speed;
    }

}
