using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject gameOverScreen; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")) 
        {
            ShowGameOverScreen();
        }
    }

    private void ShowGameOverScreen()
    {
        // Ativa a tela de fim de jogo
        gameOverScreen.SetActive(true);

        // Opcional: Parar o tempo no jogo
        Time.timeScale = 0;
    }
}
