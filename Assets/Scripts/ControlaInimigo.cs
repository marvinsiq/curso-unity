using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject jogador;
    public float velocidade = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Faz o inimigo ir em direção do jogador até ficar a uma distância mínima de 2.5 quadros
        float distanciaEntreJogadorEInimigo = Vector3.Distance(transform.position, jogador.transform.position);
        if (distanciaEntreJogadorEInimigo > 2.5)
        {
            Vector3 direcao = jogador.transform.position - transform.position;
            direcao = direcao.normalized * velocidade * Time.deltaTime;
            GetComponent<Rigidbody>()
                .MovePosition(GetComponent<Rigidbody>().position + direcao);

            Quaternion novaRotacao = Quaternion.LookRotation(direcao);
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }
    }
}
