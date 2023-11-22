using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Random.Range(-0.5f,0.25f), Random.Range(-0.5f,0.25f), Random.Range(-0.25f,0.5f));
    }
}
