using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarObjeto2 : MonoBehaviour
{
    
    public GameObject resPoint;
    public bool hasResis = false;
    
    private CogerObjeto cogerObjeto;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("1k") || other.gameObject.CompareTag("2k") || other.gameObject.CompareTag("6k") || other.gameObject.CompareTag("10k") || other.gameObject.CompareTag("20k") || other.gameObject.CompareTag("40k"))
        {
            if (Input.GetKey("f"))
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = resPoint.transform.position;
                other.transform.rotation = resPoint.transform.rotation;
                other.gameObject.transform.SetParent(resPoint.gameObject.transform);

                cogerObjeto = FindObjectOfType<CogerObjeto>();
                cogerObjeto.pickedObject = null;
                if (other.gameObject.CompareTag("20k"))
                {
                    hasResis = true; 
                }
            }
                
        } 
    }
}
