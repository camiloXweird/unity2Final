using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ControlEnemigo : MonoBehaviour
{
    // Start is called before the first frame update

    Transform posicionJugador;
    NavMeshAgent agente;
    void Start()
    {
        posicionJugador = GameObject.FindGameObjectWithTag("Player").transform;
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(posicionJugador.position, transform.position) <= 5.0f)
        {
            agente.SetDestination(posicionJugador.position);
        }
    }
}

