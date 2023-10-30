using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir : MonoBehaviour
{
    public Transform player;
    public float speedPersecucion = 5.0f;
    public float saltoFuerza = 8.0f;
    private bool objetoDetenido = false;
    private Vector3 velocidadOriginal;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!objetoDetenido)
        {
            Vector3 direction = player.position - transform.position;
        
            transform.LookAt(player);

            transform.Translate(Vector3.forward * speedPersecucion * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && !objetoDetenido)
        {
            Saltar();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!objetoDetenido)
            {
                objetoDetenido = true;
                velocidadOriginal = GetComponent<Rigidbody>().velocity;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }

    void Saltar()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * saltoFuerza, ForceMode.Impulse);
    }
}
