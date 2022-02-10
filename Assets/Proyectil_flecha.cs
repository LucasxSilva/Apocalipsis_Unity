using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil_flecha : MonoBehaviour
{

    public GameObject objetivo;

    public string faccion; //indicar si pertenece a player o enemigo
    public float velocidad;
    public int daño;
    


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.tag="Player_ataque";
    }

    // Update is called once per frame
    void Update()
    {
        float fixedspeed = velocidad * Time.deltaTime;

        Vector3 objetivoPos = objetivo.transform.position;
        Vector3 objetivo_seguir = transform.position;
        Vector3 actual = transform.position;
        objetivo_seguir.x=objetivoPos.x;

        transform.position = Vector3.MoveTowards(transform.position, objetivo_seguir, fixedspeed);

        
    }


 void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Enemigo" && faccion=="Player")   //detecta enemigo
        {
            col.SendMessage("Recibo_daño",daño);
            Debug.Log("enemigo atacado");
            Destroy(transform.parent.gameObject);
        }   
        if (col.gameObject.tag == "Player" && faccion=="Enemigo")   //detecta enemigo
        {
            col.SendMessage("Recibo_daño",daño);
            Debug.Log("player atacado");
            Destroy(transform.parent.gameObject);
        }

    }






}
