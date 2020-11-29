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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Animar();
        }

    }

    public IEnumerator ReiniciarNivel()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        SceneManager.LoadScene("SampleScene");
        textoContador.text = "Puntaje: 0";
        ControlResistencia.contador = 0;
    }


}
