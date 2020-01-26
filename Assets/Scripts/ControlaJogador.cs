using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    public float velocidade = 10;
    private Vector3 direcao;

    public static class Axis
    {
        public const string Horizontal = "Horizontal";
        public const string Vertical = "Vertical";
    }

    public static class Parameters
    {
        public const string Movendo = "Movendo";
    }

    // Update is called once per frame
    void Update()
    {
        // Inputs do Jogador - Guardando teclas apertadas
        float eixoX = Input.GetAxis(Axis.Horizontal);
        float eixoZ = Input.GetAxis(Axis.Vertical);

        direcao = new Vector3(eixoX, 0, eixoZ);

        // Animações do Jogador - Movimento
        if (direcao != Vector3.zero)
        {
            GetComponent<Animator>().SetBool(Parameters.Movendo, true);
        }
        else
        {
            GetComponent<Animator>().SetBool(Parameters.Movendo, false);
        }
    }

    void FixedUpdate()
    {
        //Movimentação do Jogador por segundo
        Vector3 direcaoMovimento = direcao * velocidade * Time.deltaTime;
        GetComponent<Rigidbody>()
            .MovePosition(GetComponent<Rigidbody>().position + direcaoMovimento);
    }
}