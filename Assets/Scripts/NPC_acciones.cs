using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_acciones : MonoBehaviour
{
    public Animator animator; 
    public GameObject objetivo;
    public float velocidad;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    void FixedUpdate()
    {
        float fixedspeed = velocidad * Time.deltaTime;

        Vector3 objetivoPos = objetivo.transform.position;
        Vector3 objetivo_seguir = transform.position;
        Vector3 actual = transform.position;
        objetivo_seguir.x=objetivoPos.x;
        //Debug.Log(objetivo_seguir);

        if (objetivo_seguir.x!=actual.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, objetivo_seguir, fixedspeed);
            animator.SetBool("run",true);
        }
        else{
            animator.SetBool("run",false);
        }

    }
    
}
