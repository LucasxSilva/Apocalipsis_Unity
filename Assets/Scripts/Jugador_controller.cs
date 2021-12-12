using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_controller : MonoBehaviour
{
    void Update()
        {
            if (Input.GetMouseButtonDown(0)) {
                Vector3 mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                Vector3 objetivoPos = transform.position;
                objetivoPos.x=mousePos.x;
                transform.position=objetivoPos;
                //Debug.Log(transform.position);
            }
        }

}
