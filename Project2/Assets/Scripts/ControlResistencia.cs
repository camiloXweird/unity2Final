using System.Collections;
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


    public AudioSource sonidoObjeto;


    public int resistencia;

    public Text textoContador;
    public static int contador = 0;
    public static int contador2 = 0;

    Animator anim;




    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        contador2 = 0;
        sonidoObjeto = GetComponent<AudioSource>();
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

    public void OnParticleCollision(GameObject other){
        Debug.Log("coliision cubito");
        particulasImpacto.position = transform.position;
        systemaParticulasRomper.Play();
        
        resistencia--;

        
        if (resistencia <= 0)
        {
             if (gameObject.CompareTag("Destruible"))
            {
             StartCoroutine(sonido());
            }else if (gameObject.CompareTag("Enemigo")){
                StartCoroutine(animarMuerte());
                
            
            }
        }
        

            // transform.gameObject.SetActive(false);

    }

        public IEnumerator sonido()
    {

        sonidoObjeto.Play();
        yield return new WaitForSecondsRealtime(1f);
        contador2++;
        textoContador.text = "Puntaje: " + contador2.ToString();
        Destroy(transform.gameObject);              
        
       
    }

    // Update is called once per frame
    void Update()
    {
        // sonidoObjeto.Play();
       
    }

    public IEnumerator animarMuerte() 
    {
        anim.SetBool("Muerte", true);
        yield return new WaitForSecondsRealtime(3.0f);
        anim.SetBool("Muerte", false);
        Destroy(transform.gameObject);
        contador += 2;
    }

    public IEnumerator animarMuerte2() 
    {
        yield return new WaitForSecondsRealtime(3.0f);
        Destroy(transform.gameObject);
        contador2 += 2;
        textoContador.text = "Puntaje: " + contador2.ToString();

    }
}
