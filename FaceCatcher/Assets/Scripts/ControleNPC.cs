using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleNPC : MonoBehaviour
{
    private Vector3 target;
	private float speed = 1.0f;

    void Start()
    {
        novaDirecao();
    }                      
    void novaDirecao(){
	    target = new Vector3(Random.Range(-1000,1000),0,Random.Range(-1000,1000));
        transform.rotation = Quaternion.LookRotation(target);
	    
    }
    // Update is called once per frame
    void Update()
    {    
        float step = speed*Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
    void OnCollisionEnter(Collision col) {
        novaDirecao();
        transform.position = new Vector3(0, 100, 0);
    }
}
