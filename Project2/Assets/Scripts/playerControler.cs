using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{

    Animator anim;
    public GameObject poder; 
    private Vector3 posicion;



  

    public int lol; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();

    }

    public void Animar(){
            Debug.Log("jolaaaaaaaaaaaaa");
            anim.SetBool ("Espadazo", true);
            StartCoroutine (Reiniciar());
    }

    public IEnumerator Reiniciar(){
       
		anim.SetBool ("Espadazo", true );
        yield return new WaitForSecondsRealtime (1.5f);
        poder.transform.position = transform.position;
        poder.SendMessage("Shoot");
		anim.SetBool ("Espadazo", false );

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Q)){
            Animar();
				
	    }
        
    }


}
