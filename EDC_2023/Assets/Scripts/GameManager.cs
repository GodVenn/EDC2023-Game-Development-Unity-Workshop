using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public UIDocument UIScoresContainer;
    public VisualTreeAsset UIScoreTemplate;

    private VisualElement _scoresContainer;

    public float MinRespawnTime = 5f;
    public float MaxRespawnTime = 20f;
    public static GameManager instance;

    private int playerCount = 0;

    private void Awake()
    {
        if (instance is not null)
            Destroy(this);

        instance = this;

        _scoresContainer = UIScoresContainer.rootVisualElement.Q("ScoreContainer");
    }

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnTokenCaptured(Token token)
    {
        StartCoroutine(ReActivateAtRandomTime(token));
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        playerCount++;
        Player player = playerInput.gameObject.GetComponent<Player>();
        var newScore = UIScoreTemplate.Instantiate();
        _scoresContainer.Add(newScore);
        player.UiScore = newScore.Q<Label>("ScoreValue");
        player.Score = 0;
        var playerName = newScore.Q<Label>("PlayerName");
        playerName.text = "Player " + playerCount + ": ";
    }

    private IEnumerator ReActivateAtRandomTime(Token token)
    {
        float delay = Random.Range(MinRespawnTime, MaxRespawnTime);
        yield return new WaitForSeconds(delay);
        token.gameObject.SetActive(true);
    }
}
