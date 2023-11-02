using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject congratulationsManager; // Arrastra el objeto que contiene el script de felicitaciones
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            gameObject.SetActive(false); // Desactiva el coleccionable cuando se recolecta
            congratulationsManager.GetComponent<CongratulationsMessage>().CollectibleCollected();
        }
    }
}