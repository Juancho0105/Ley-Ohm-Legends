using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
    public GameObject handPoint, luzRoja, luzVerde;

    public GameObject pickedObject = null;

    private ColocarObjeto colocarObjeto;
    private ColocarObjeto1 colocarObjeto1; 
    private ColocarObjeto2 colocarObjeto2; 
    private ColocarObjeto3 colocarObjeto3; 

    

    // Update is called once per frame
    void Update()
    {
        if (pickedObject != null)
        {
            if (Input.GetKey("r"))
            {
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;
            }
        }
        
        if (colocarObjeto.hasResis == true && colocarObjeto1.hasResis == true && colocarObjeto2.hasResis == true && colocarObjeto3.hasResis == true)
        {
            luzVerde.SetActive(true);
            luzRoja.SetActive(false);
        }
        else
        {
            luzVerde.SetActive(false);
            luzRoja.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("1k"))
        {
            if (Input.GetKey("e") && pickedObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);

                pickedObject = other.gameObject;
                
                colocarObjeto = FindObjectOfType<ColocarObjeto>();
                colocarObjeto.hasResis = false;
            }
        }
        
        if (other.gameObject.CompareTag("10k"))
        {
            if (Input.GetKey("e") && pickedObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);

                pickedObject = other.gameObject;
                
                colocarObjeto1 = FindObjectOfType<ColocarObjeto1>();
                colocarObjeto1.hasResis = false;
                
            }
        }
        
        if (other.gameObject.CompareTag("20k"))
        {
            if (Input.GetKey("e") && pickedObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);

                pickedObject = other.gameObject;
                
                colocarObjeto2 = FindObjectOfType<ColocarObjeto2>();
                colocarObjeto2.hasResis = false;
                
            }
        }
        
        if (other.gameObject.CompareTag("6k"))
        {
            if (Input.GetKey("e") && pickedObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);

                pickedObject = other.gameObject;
                
                colocarObjeto3 = FindObjectOfType<ColocarObjeto3>();
                colocarObjeto3.hasResis = false;
            }
        }
        
        if (other.gameObject.CompareTag("2k") || other.gameObject.CompareTag("40k"))
        {
            if (Input.GetKey("e") && pickedObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);

                pickedObject = other.gameObject;
            }
        }
    } 
}
