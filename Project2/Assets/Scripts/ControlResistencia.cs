﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlResistencia : MonoBehaviour
{

    public Transform particulasImpacto;
    private ParticleSystem systemaParticulasRomper;

    public string objetosResistencia;

    public int resistencia;

    public Text textoContador;
    public static int contador = 0;
    Animator anim;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        textoContador.text = "Puntaje: " + contador.ToString();
        systemaParticulasRomper = particulasImpacto.GetComponent<ParticleSystem>();
        systemaParticulasRomper.Stop();
    }

    public void RegistrarImpacto(Vector3 puntoImpacto)
    {
        systemaParticulasRomper.Play();
        particulasImpacto.position = puntoImpacto;

        resistencia--;
        if (resistencia <= 0)
        {
            if (gameObject.CompareTag("Enemigo"))
            {
                StartCoroutine(animarMuerte());
            }
            else if (gameObject.CompareTag("Destruible"))
            {
                contador++;
                Destroy(transform.gameObject);
            if(contador > 9){
                SceneManager.LoadScene(1);
            }
            }
            textoContador.text = "Puntaje: " + contador.ToString();
        }
    }


    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator animarMuerte()
    {
        anim.SetBool("Muerte", true);
        yield return new WaitForSecondsRealtime(3.0f);
        anim.SetBool("Muerte", false);
        Destroy(transform.gameObject);
        contador += 2;
    }
}
