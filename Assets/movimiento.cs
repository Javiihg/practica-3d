using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movimiento : MonoBehaviour
{
    public float speed = 3.0f;
    public float alturaSalto = 10.0f;
    private bool enSuelo = true;
    private bool juegoPausado = false;

    private Rigidbody rb;
    private float initialFixedTimeScale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        initialFixedTimeScale = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (juegoPausado)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                juegoPausado = false;
                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = initialFixedTimeScale;
            }
        }

        if (!juegoPausado)
        {
            float movimientoHorzizontal = Input.GetAxis("Horizontal");
            float movimientoVertical = Input.GetAxis("Vertical");

            Vector3 movimiento = new Vector3(movimientoHorzizontal, 0.0f, movimientoVertical);
            movimiento = movimiento.normalized * speed * Time.deltaTime;

            transform.Translate(movimiento);

            if (Input.GetButtonDown("Jump") && enSuelo)
            {
                rb.AddForce(Vector3.up * alturaSalto, ForceMode.Impulse);
                enSuelo = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }

        if (collision.gameObject.CompareTag("ObjetoColisionable"))
        {
            Debug.Log("Colisión Juego pausado. Presiona la barra espaciadora para reiniciar");
            juegoPausado = true;
        }
    }
}
