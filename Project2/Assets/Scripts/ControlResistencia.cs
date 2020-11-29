using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ControlResistencia : MonoBehaviour
{

    public Transform particulasImpacto;
    private ParticleSystem systemaParticulasRomper;

    public string objetosResistencia;

    public int resistencia;

    public Text textoContador;
    public static int contador = 0;


    // Start is called before the first frame update
    void Start()
    {
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
                contador += 2;
            }
            else if (gameObject.CompareTag("Destruible"))
            {
                contador++;
            }
            Destroy(transform.gameObject);
            textoContador.text = "Puntaje: " + contador.ToString();
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
