using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController control;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    public void Guardar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/persistencia.dat");

        DatosJuego datos = new DatosJuego();

        datos.posx = GameObject.Find("ThirdPersonController").transform.position.x;
        datos.posy = GameObject.Find("ThirdPersonController").transform.position.y;
        datos.posz = GameObject.Find("ThirdPersonController").transform.position.z;

        datos.puntaje = GameObject.Find("Puntaje").GetComponent<Text>().text;

        datos.vidaGuardada = GameObject.Find("HealthBar").GetComponent<Slider>().value;
        
        bf.Serialize(file, datos);
        file.Close();
    }

    public void Carfar()
    {
        if (File.Exists(Application.persistentDataPath + "/persistencia.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/persistencia.dat", FileMode.Open);

            DatosJuego datos = (DatosJuego)bf.Deserialize(file);
            file.Close();

            Vector3 posicion = new Vector3(datos.posx, datos.posy, datos.posz);
            float vidaGuardada = datos.vidaGuardada;
            string puntaje = datos.puntaje;

            GameObject.Find("ThirdPersonController").transform.position = posicion;
            GameObject.Find("HealthBar").GetComponent<Slider>().value = vidaGuardada;
            GameObject.Find("Puntaje").GetComponent<Text>().text = puntaje;
        }
    }
}

[Serializable]

class DatosJuego
{
    public float posx;
    public float posy;
    public float posz;

    public float vidaGuardada;

    public string puntaje;
}
