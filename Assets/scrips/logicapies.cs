using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicapies : MonoBehaviour
{

    public logicajugador lj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        lj.puedoSaltar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        lj.puedoSaltar = false;
    }
}
