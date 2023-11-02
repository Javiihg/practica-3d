using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pissar : MonoBehaviour
{
    public Color highlightColor = Color.red;  // Color a aplicar cuando el jugador pase
    private Color originalColor;  // Almacenar el color original
    private bool isPlayerOnGround = false;

    void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;  // Almacenar el color original
    }

    void Update()
    {
        if (isPlayerOnGround)
        {
            // Cambiar el color al color de resaltado
            GetComponent<Renderer>().material.color = highlightColor;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnGround = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnGround = false;
            // Restaurar el color original
            GetComponent<Renderer>().material.color = originalColor;
            // Destruir el objeto del suelo
            Destroy(gameObject);
        }
    }
}
