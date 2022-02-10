using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_enemy : MonoBehaviour
{
    /*
    tags:
    Player = colision unidad aliada, usada para recibir daño, ser detectada por enemigo, controlar unidades
    Player_ataque = colision que daña a enemigo


    Enemigo = colision unidad enemiga, usada para recibir daño, ser detectada por player, controlar unidades
    Enemigo_ataque = colision que daña a player

    */
    public int velocidad_ataque; //delay para disparar en segundos
    public Transform npc_summons;
    public Animator animator; 
    public GameObject objetivo;
    public float velocidad;
    public int vida;
    public int daño;

    private Rigidbody2D rb2d;
    private float direccion;
    private bool orden_invocar=false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    	animator = GetComponent<Animator> ();
        //this.transform.position= new Vector3(0,0,0);
    }

    void FixedUpdate()
    {


        /*
        float fixedspeed = velocidad * Time.deltaTime;

        Vector3 objetivoPos = objetivo.transform.position;
        Vector3 objetivo_seguir = transform.position;
        Vector3 actual = transform.position;
        objetivo_seguir.x=objetivoPos.x;
        //Debug.Log(objetivo_seguir);
        //Debug.Log(objetivo_seguir-transform.position);

        //revisa si esta avanzando hacia izquierda o derecha y rota al personaje

        direccion=objetivo_seguir.x-transform.position.x;
        if (direccion > 0f && transform.localScale.x<0){
            transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);

        }
        if (direccion < 0f && transform.localScale.x>0){
            transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }



        if (objetivo_seguir.x!=actual.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, objetivo_seguir, fixedspeed);
            animator.SetBool("run",true);
        }
        else{
            animator.SetBool("run",false);
        }

        */

    }

    
    //GameObject.gameObject.tag="Player";

    void Recibo_daño(int daño){         //usada desde el enemigo cuando colisiona con esta unidad, para reducir cierta cantidad de vida 
        Debug.Log(vida);
        vida=vida-daño;
        Debug.Log(vida);
        //efectos de impacto, ponerlo en rojo, stun?
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Player")   //detecta enemigo
        {
            Debug.Log("disparar");
            Debug.Log(col.gameObject.transform.position);
            if (orden_invocar==false){
                Invoke("invocar",velocidad_ataque);
                orden_invocar=true;
            }
            //object pooling   https://www.youtube.com/watch?v=tdSmKaJvCoA    
            // ataca enemigo
        }   
       
        /*
        if (col.gameObject.tag == "Enemigo_ataque")   //es atacado, recibe daño
        {
            Debug.Log("ouch! daño recibido");
            Debug.Log(col.gameObject.transform.position);
            //object pooling   https://www.youtube.com/watch?v=tdSmKaJvCoA    
            // ataca enemigo
        }
        */   
       /*
        if (col.gameObject.tag == "Daña_Enemigos")
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(transform.parent.gameObject);
        }
        if (col.gameObject.tag == "Dañador_objeto")
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(transform.parent.gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            col.SendMessage("knockback",transform.position.x);
        }
        */
    }
    void invocar(){
        Instantiate(npc_summons, transform.position, Quaternion.identity);
        orden_invocar=false;
    }

    
}
