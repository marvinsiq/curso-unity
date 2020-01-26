﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamera : MonoBehaviour
{
    public GameObject jogador;
    private Vector3 distanciaCompensar;

    void Start()
    {
        distanciaCompensar = transform.position - jogador.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = jogador.transform.position + distanciaCompensar;
    }
}
