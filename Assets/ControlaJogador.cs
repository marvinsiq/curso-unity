using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    public float velocidade = 10;

    public enum Axis
    {
        Horizontal,
        Vertical
    }

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis(Axis.Horizontal.ToString());
        float eixoZ = Input.GetAxis(Axis.Vertical.ToString());

        Vector3 direcao = new Vector3(eixoX, 0, eixoZ);

        transform.Translate(direcao * velocidade * Time.deltaTime);
    }
}