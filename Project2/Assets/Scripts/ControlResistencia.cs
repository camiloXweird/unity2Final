using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ControlResistencia : MonoBehaviour
{

    // public Transform particulasImpacto;
    // private ParticleSystem systemaParticulasRomper;

    public string objetosResistencia;

    public int resistencia;

    public Text textoContador;
    // public Text textoGanar;

    public static int contador = 0;


    // Start is called before the first frame update
    void Start()
    {
        textoContador.text = "Puntaje: " + contador.ToString();
        // systemaParticulasRomper = particulasImpacto.GetComponent<ParticleSystem>();
        // systemaParticulasRomper.Stop();

    }

    public void RegistrarImpacto(Vector3 puntoImpacto)
    {
        // particulasImpacto.position = puntoImpacto;
        // systemaParticulasRomper.Play(); 

        if (objetosResistencia == "objetosResistencia")
        {
            resistencia--;
            if (resistencia <= 0)
            {
                Destroy(transform.gameObject);
                contador++;
                textoContador.text = "Puntaje: " + contador.ToString();

            }
        }
        else
        {
            Destroy(transform.gameObject);
            contador++;
            textoContador.text = "Puntaje: " + contador.ToString();

        }
    }


    // Update is called once per frame
    void Update()
    {
        //  systemaParticulasRomper.Play();

        // systemaParticulasRomper.Play();

    }
}
