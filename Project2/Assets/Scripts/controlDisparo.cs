using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlDisparo : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;

    public float TiempoEntreDisparos =  1f;
    public float rango =  10f;


    float timer;
    Ray shootRay; //controla el rayo 
    RaycastHit shootHit; // el impacto de rayo 
    int  shootableMask;
    LineRenderer gunLine; 
    Light gunLight;

     float effectsDisplayTime = 1.2f;
     

     
    
    void Shoot(){
        Vector3 ubicacion = new Vector3 (Player.transform.position.x,Player.transform.position.y+ 0.6f,Player.transform.position.z);
        timer = 0f;
        gunLine.enabled = true;
        gunLight.enabled = true;
        shootRay.origin = ubicacion;
        shootRay.direction = transform.forward; 
        gunLine.SetPosition (0,ubicacion);

        if(Physics.Raycast(shootRay, out shootHit, rango, shootableMask)){
 
             // Destroy(shootHit.collider.gameObject);
            ControlResistencia resistencia = shootHit.collider.gameObject.GetComponent<ControlResistencia>();
            if(resistencia!= null){
                resistencia.RegistrarImpacto(shootHit.point);

                gunLine.SetPosition(1, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);
 
        }else{
            Debug.Log("No se impacto ningun objeto"); 
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * rango);
        }
    }

    void Awake(){
        shootableMask = LayerMask.GetMask("Shootable");
        gunLine= GetComponent<LineRenderer> ();
        gunLight= GetComponent<Light> ();
    }

    public void DisableEffects(){
        gunLine.enabled  = false;
        gunLight.enabled = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if(timer >= TiempoEntreDisparos * effectsDisplayTime){

                DisableEffects();
        }
    }
}
