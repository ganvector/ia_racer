using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour{

    private Rigidbody2D rb2d;

    [SerializeField]
    public float forcaAceleracao = 5f;
    [SerializeField]
    public float forcaDirecao = 5f;

    private float qtdDirecao, velocidade, direcao, aceleracao;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {

        qtdDirecao = 0f;
        aceleracao = 0f;
        if(Input.GetKey(KeyCode.A))
            qtdDirecao = -1f;
        else if (Input.GetKey(KeyCode.D))
            qtdDirecao = 1f;

        if(Input.GetKey(KeyCode.W))
            aceleracao = -1f;
        else if (Input.GetKey(KeyCode.S))
            aceleracao = 1f;

        velocidade = aceleracao * forcaAceleracao;

        direcao = Mathf.Sign(Vector2.Dot(rb2d.velocity, rb2d.GetRelativeVector(Vector2.up)));
        rb2d.rotation += qtdDirecao * forcaDirecao * rb2d.velocity.magnitude * direcao;

        rb2d.AddRelativeForce(Vector2.up * velocidade);
        rb2d.AddRelativeForce(-Vector2.right * rb2d.velocity.magnitude * qtdDirecao / 2);
    }

}