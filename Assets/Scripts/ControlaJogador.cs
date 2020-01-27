using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{
    public float velocidade = 10;
    private Vector3 direcao;
    public LayerMask mascaraChao;
    public GameObject textoGameOver;
    public bool vivo = true;

    public static class Parameters
    {
        public const string Movendo = "Movendo";
    }
    private void Start()
    {
        Time.timeScale = 1;
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

        if(!vivo)
        {
            if(Input.GetButtonDown(Axis.Fire1))
            {
                SceneManager.LoadScene("game");
                vivo = true;
            }            
        }
    }

    void FixedUpdate()
    {
        //Movimentação do Jogador por segundo
        Vector3 direcaoMovimento = direcao * velocidade * Time.deltaTime;
        GetComponent<Rigidbody>()
            .MovePosition(GetComponent<Rigidbody>().position + direcaoMovimento);

        // Faz com que o jogador rotacione na direção do mouse

        // Cria um raio a artir da posição da camera.
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        // Verifica o ponto de impacto do raio do solo
        RaycastHit impacto;
        if (Physics.Raycast(raio, out impacto, 100, mascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            // iguala a altura
            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }
    }
}