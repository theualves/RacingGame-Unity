using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;  // Referência ao Canvas de Game Over

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o carro colidiu com um objeto do jogo
        if (collision.gameObject.CompareTag("Untagged"))
        {
            // Ativa o Canvas de Game Over
            gameOverCanvas.SetActive(true);

            // Opcional: Pausar o jogo
            Time.timeScale = 0f;
        }
    }
}
