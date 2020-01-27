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

        // olha para a direção do personagem
        Vector3 direcao = jogador.transform.position - transform.position;
        direcao = direcao.normalized * velocidade * Time.deltaTime;
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(novaRotacao);

        // Faz o inimigo ir em direção do jogador até ficar a uma distância mínima de 2.5 quadros
        float distanciaEntreJogadorEInimigo = Vector3.Distance(transform.position, jogador.transform.position);
        if (distanciaEntreJogadorEInimigo > 2.5)
        {
            GetComponent<Rigidbody>()
                .MovePosition(GetComponent<Rigidbody>().position + direcao);

            GetComponent<Animator>().SetBool("atacando", false);
        } else
        {
            GetComponent<Animator>().SetBool("atacando", true);
        }
    }

    void atacaJogador()
    {
        Time.timeScale = 0;
        jogador.GetComponent<ControlaJogador>().textoGameOver.SetActive(true);
        jogador.GetComponent<ControlaJogador>().vivo = false;
    }
}
