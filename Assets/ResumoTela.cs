using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResumoTela : MonoBehaviour
{
    public TextMeshProUGUI textoDiamantes;
    public TextMeshProUGUI textoTempo;

    public void AtualizarTela(int diamantes, float tempo)
    {
        textoDiamantes.text = "Diamantes coletados: " + diamantes;
        textoTempo.text = "Tempo da volta: " + tempo.ToString("F2"); // Exibe o tempo com 2 casas decimais
    }
}