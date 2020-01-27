using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaBala : MonoBehaviour
{

    public float velocidade = 30;

    void FixedUpdate()
    {
        GetComponent<Rigidbody>()
            .MovePosition(GetComponent<Rigidbody>().position
            + transform.forward * velocidade * Time.deltaTime
            ); ;
    }

    void OnTriggerEnter(Collider objetoDeColisao)
    {
        if (objetoDeColisao.tag == "Inimigo")
        {
            Destroy(objetoDeColisao.gameObject);
            Destroy(gameObject);
        }
    }
}
