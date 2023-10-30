using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesaparecerAlTocar : MonoBehaviour
{
    public GameObject sistemaParticulas;
    private ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = sistemaParticulas.GetComponent<ParticleSystem>();
        particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destruir()
    {
        gameObject.SetActive(false);
        particleSystem.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destruir();
        }
    }
}
