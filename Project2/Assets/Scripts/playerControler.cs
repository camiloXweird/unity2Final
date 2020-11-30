using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class playerControler : MonoBehaviour
{

    Animator anim;
    public GameObject poder;
    private Vector3 posicion;

    public Text textoContador;

    public int vidaMaxima = 100;

    public int vidaActual;

    public BarraVida barraVida;
    
    public AudioSource sonidoDisparo;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sonidoDisparo = GetComponent<AudioSource>();
        vidaActual = vidaMaxima;
        barraVida.setVidaMaxima(vidaMaxima);
    }

    public void Animar()
    {
        anim.SetBool("Espadazo", true);
        StartCoroutine(Reiniciar());
    }

    public IEnumerator Reiniciar()
    {

        anim.SetBool("Espadazo", true);
        yield return new WaitForSecondsRealtime(2f);
        sonidoDisparo.Play();
        poder.transform.position = transform.position;
        poder.SendMessage("Shoot");
        anim.SetBool("Espadazo", false);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Terreno"))
        {
            StartCoroutine(ReiniciarNivel());
        }

        if (other.gameObject.CompareTag("Enemigo"))
        {
            StartCoroutine(DañoEnemigo());
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Animar();
        }

    }

    public IEnumerator ReiniciarNivel(float tiempo = 5.0f)
    {
        yield return new WaitForSecondsRealtime(tiempo);
        SceneManager.LoadScene("SampleScene");
        textoContador.text = "Puntaje: 0";
        ControlResistencia.contador = 0;
    }

    public IEnumerator DañoEnemigo()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        recibirDaño(20);
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
}
