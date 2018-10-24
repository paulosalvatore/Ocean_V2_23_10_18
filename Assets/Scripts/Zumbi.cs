using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zumbi : MonoBehaviour {

	Animator animator;
	Rigidbody rb;

	public float velocidade = 0.3f;
	public float delayAndar = 1f;
	bool andando = false;

	GameObject jogador;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();

		jogador = GameObject.Find("Jogador");

		transform.LookAt(jogador.transform);

		Invoke("Andar", delayAndar);
	}

	void Andar()
	{
		andando = true;
	}

	// Update is called once per frame
	void Update () {
		if (andando)
		{
			rb.velocity = (jogador.transform.position - transform.position).normalized * velocidade;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Projétil"))
		{
			Destroy(other.gameObject);
			Morrer();
		}
	}

	private void Morrer()
	{
		animator.SetTrigger("Morrer");
		andando = false;
	}
}
