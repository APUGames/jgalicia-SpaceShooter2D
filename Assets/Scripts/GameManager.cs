using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private PlayerHealthController playerHealthController;
    [SerializeField]
    private GameObject playerScoreText;
    [SerializeField]
    private GameObject playerWonText;
    [SerializeField]
    private int playerWinPoints;

    private bool playerWon = false;
    private bool playerDead = false;

    private int playerPoints = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    // Start is called before the first frame update
    private void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerHealthController.GetHealth() <= 0)
        {
            playerDead = true;
        }

        if (playerPoints >= playerWinPoints)
        {
            playerWon = true;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        playerScoreText.GetComponent<Text>().text = $"{playerPoints}/{playerWinPoints}";

        if (playerWon)
        {
            playerWonText.SetActive(true);
        }
        else
        {
            playerWonText.SetActive(false);
        }
    }

    public void SetPlayerPoints(int points)
    {
        playerPoints += points;
    }

    public void SetPlayerWon(bool won)
    {
        playerWon = won;
    }

    public bool GetPlayerDead()
    {
        return playerDead;
    }

    public bool GetPlayerWon()
    {
        return playerWon;
    }
}
