using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CongratulationsMessage : MonoBehaviour
{
    public int totalCollectibles = 4; // Define el total de coleccionables
    private int collectedCount = 0;
    public Text congratsText;
    public string congratulationsMessage = "¡Felicidades! Has recolectado todos los coleccionables.";

    void Start()
    {
        congratsText.text = ""; // Inicialmente, no se mostrará ningún mensaje
    }

    public void CollectibleCollected()
    {
        collectedCount++;

        if (collectedCount == totalCollectibles)
        {
            congratsText.text = congratulationsMessage;
        }
    }
}