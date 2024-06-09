using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class CurveTriggerScript : MonoBehaviour
{
    public TextMeshProUGUI curveMessage; // Refer�ncia ao componente de texto
    public Image curveImage1; // Refer�ncia � primeira imagem
    public Image curveImage2; // Refer�ncia � segunda imagem
    public float messageDuration = 5.0f; // Dura��o da mensagem em segundos

    private void Start()
    {
        // Garantir que a mensagem e as imagens estejam invis�veis no in�cio
        curveMessage.gameObject.SetActive(false);
        curveImage1.gameObject.SetActive(false);
        curveImage2.gameObject.SetActive(false);
    }

    // Quando o carro entra no trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assumindo que o carro tem a tag "Player"
        {
            curveMessage.gameObject.SetActive(true);
            curveImage1.gameObject.SetActive(true);
            curveImage2.gameObject.SetActive(true);
            StartCoroutine(HideMessageAfterDelay(messageDuration));
        }
    }

    // Coroutine para esconder a mensagem e as imagens ap�s um tempo
    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        curveMessage.gameObject.SetActive(false);
        curveImage1.gameObject.SetActive(false);
        curveImage2.gameObject.SetActive(false);
    }
}
