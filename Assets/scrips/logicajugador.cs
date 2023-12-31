using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicajugador : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
	public float velocidadRotacion = 200.0f;
	private Animator anim;
	public float x, y;

	public Rigidbody rb;
	public float fuerzaSalto = 8;
	public bool puedoSaltar;
    // Start is called before the first frame update
    void Start()
    {
		puedoSaltar = false;
        anim = GetComponent<Animator>();
    }

	void FixedUpdate()
	{
		transform.Rotate(0,x*Time.deltaTime*velocidadRotacion,0);
		transform.Translate(0,0,y*Time.deltaTime*velocidadMovimiento);
	}

    // Update is called once per frame
    void Update()
    {
        x=Input.GetAxis("Horizontal");
		y=Input.GetAxis("Vertical");

		anim.SetFloat("VelX",x);
		anim.SetFloat("VelY",y);

		if(puedoSaltar)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				anim.SetBool("salte",true);
				rb.AddForce(new Vector3(0,fuerzaSalto,0),ForceMode.Impulse);
			}
			anim.SetBool("tocoSuelo",true);
		}
		else
		{
			EstoyCayendo();
		}
    }

	public void EstoyCayendo()
	{
		anim.SetBool("tocoSuelo",false);
		anim.SetBool("salte",false);
	}
}
