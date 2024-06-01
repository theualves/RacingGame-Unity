
using UnityEngine;
using UnityEngine.UI;

public class CarFlipDetector : MonoBehaviour
{
    public GameObject gameOverCanvas;  // Refer�ncia ao Canvas de Game Over

    // Limite de �ngulo para considerar o carro capotado
    private float flipThreshold = 45f;

    void Update()
    {
        // Verifica se o carro est� capotado
        if (IsCarFlipped())
        {
            // Ativa o Canvas de Game Over
            gameOverCanvas.SetActive(true);

            // Opcional: parar o carro ou reiniciar o jogo
            Time.timeScale = 0; // Pausa o jogo
        }
    }

    bool IsCarFlipped()
    {
        // Verifica a rota��o do carro em rela��o ao eixo X e Z
        float xRotation = Mathf.Abs(transform.rotation.eulerAngles.x);
        float zRotation = Mathf.Abs(transform.rotation.eulerAngles.z);

        // Normaliza a rota��o para o intervalo [0, 180]
        if (xRotation > 180)
            xRotation = 360 - xRotation;
        if (zRotation > 180)
            zRotation = 360 - zRotation;

        // Verifica se a rota��o ultrapassa o limite de capotagem
        if (xRotation > flipThreshold || zRotation > flipThreshold)
        {
            return true;
        }

        return false;
    }
}
