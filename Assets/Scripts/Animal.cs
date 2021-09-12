using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] GameManager gm;
    [SerializeField] int PuntosVida;
    int Cantpoder = 1;
    int copia2;
    
    float TimeScale = 5;
    bool Contador = true;
    int copia;
    float tiempo = 0;
    float minX, maxX;


    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;
        copia = PuntosVida;
        copia2 = Cantpoder;
    }
    void Update()
        
    {
        if(Contador == true)
        {
            TiempoPower();
        }
        if (movingRight)
        {
            Vector2 movimiento = new Vector2(speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        else
        {
            Vector2 movimiento = new Vector2(-speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        if (transform.position.x >= maxX)
        {
            movingRight = false;
        }
        else if (transform.position.x <= minX)
        {
            movingRight = true;
        }

    }
    void TiempoPower()
    {
            if (Input.GetKeyDown(KeyCode.R) && Time.unscaledTime >= tiempo)
            {
            
            Time.timeScale = 0.5f;
            tiempo = Time.unscaledTime + TimeScale ;
             PuntosVida = 1;
            copia2 ++;
            }
            if (tiempo <= Time.unscaledTime)
            {
           Time.timeScale = 1;
            PuntosVida = copia;
              if (copia2 == 4)
              {
                Contador = false;
              }
            }
    }
private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;
        string etiqueta = objeto.tag;

        if ( etiqueta == "DISPARO") 
        {
            PuntosVida--;
            if (PuntosVida == 0)
            {
                (GameObject.Find("GameManager").GetComponent<GameManager>()).ReducirNumEnemigos();
                Destroy(this.gameObject);
            }
        }
    }
  
}
