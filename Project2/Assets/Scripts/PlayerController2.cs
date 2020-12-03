using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    // public GameObject poder;

    public ParticleSystem poderPiso;
    public AudioSource sonidoDisparo;
    public Text textoContador;


    public int vidaMaxima = 100;

    public int vidaActual;

    public BarraVida barraVida;


    void Start()
    {
        anim = GetComponent<Animator>();
        sonidoDisparo = GetComponent<AudioSource>();
        poderPiso.Stop();
        sonidoDisparo.Stop();
        vidaActual = vidaMaxima;
        barraVida.setVidaMaxima(vidaMaxima);


        
    }

     public void Animar()
    { 
        StartCoroutine(EjecutarPoderPiso());
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Enemigo"))
        {
            StartCoroutine(DañoEnemigo());
        }
    }

    public IEnumerator DañoEnemigo()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        recibirDaño(20);
    }


    public IEnumerator EjecutarPoderPiso()
    {
        anim.SetBool("Podersito", true);
        yield return new WaitForSecondsRealtime(2f);
        poderPiso.Play();
        sonidoDisparo.Play();
        StartCoroutine(DetenerPoder());
        anim.SetBool("Podersito", false);
    }

     public IEnumerator ReiniciarNivel(float tiempo = 5.0f)
    {
        yield return new WaitForSecondsRealtime(tiempo);
        SceneManager.LoadScene("Escena2");
        textoContador.text = "Puntaje: 0";
        ControlResistencia.contador2 = 0;
    }

     public IEnumerator DetenerPoder(){
        yield return new WaitForSecondsRealtime (1.0f);
        poderPiso.Stop();
    
    }

    public void recibirDaño(int daño)
    {
        vidaActual -= daño;
        barraVida.setVida(vidaActual);
        if (vidaActual <= 0)
        {
            StartCoroutine(animarMuerte());
        }
    }

    public IEnumerator animarMuerte()
    {
        anim.SetBool("Muerte", true);
        yield return new WaitForSecondsRealtime(2.0f);
        StartCoroutine(ReiniciarNivel(0.5f));
        anim.SetBool("Muerte", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("entre");
            Animar();
        }
    }
}
