using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject finishScreen; // Novo GameObject para a tela de término do segundo round
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI finishTimeText; // Texto para exibir o tempo na tela de término
    public TextMeshProUGUI finishDiamondsText;
    public GameObject inventoryUI;
    public float timeLimit = 90f; // Tempo limite em segundos (1:30 = 90 segundos)
    private bool playerFinished = false;
    private float timeRemaining;
    private int lapsCompleted = 0;
    private float finishTime; // Variável para armazenar o tempo de término do segundo round

    void Start()
    {
        timeRemaining = timeLimit;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lapsCompleted++;

            if (lapsCompleted == 1) // Primeira volta: desabilitar inventoryUI
            {
                inventoryUI.SetActive(false);
                StartTimer();
            }
            else if (lapsCompleted == 2) // Segunda volta: mostrar tela de fim do segundo round
            {
                finishTime = timeLimit - timeRemaining; // Calcular o tempo de término
                ShowFinishScreen();
            }

        }
    }

    private void StartTimer()
    {
        // Iniciar o timer
        InvokeRepeating("UpdateTime", 0f, 1f); // Chamar UpdateTime a cada segundo

        // Verificar se o tempo zerou
        Invoke("CheckTime", timeLimit); // Chamar CheckTime após o tempo limite
    }

    private void UpdateTime()
    {
        timeRemaining -= 1f; // Reduzir o tempo em 1 segundo
        UpdateTimerText();

        // Se o tempo zerar antes que o jogador complete a volta
        if (timeRemaining <= 0)
        {
            ShowGameOverScreen();
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void CheckTime()
    {
        // Se o jogador não completar a volta dentro do tempo
        if (!playerFinished)
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

    // Nova função para mostrar a tela de término do segundo round
    private void ShowFinishScreen()
    {
        // Ativa a tela de término
        finishScreen.SetActive(true);

        // Formata o tempo de término como "minutos:segundos"
        int minutes = Mathf.FloorToInt(finishTime / 60);
        int seconds = Mathf.FloorToInt(finishTime % 60);
        finishTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        finishDiamondsText.text =  InventoryUI.TotalDiamonds.ToString();

        // Opcional: Parar o tempo no jogo
        Time.timeScale = 0;
    }
}