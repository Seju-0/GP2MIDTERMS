using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class PlayerLose : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameOverText.text = "GAME OVER";
 
        }
    }
}
