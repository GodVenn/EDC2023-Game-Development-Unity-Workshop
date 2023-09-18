using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public VisualTreeAsset ScoreTemplate;
    public UIDocument UI;

    public float delayInSeconds = 10;

    public static GameManager Instance;

    void Awake()
    {
        GameManager.Instance = this;
    }

    public void OnTokenCapture(Token token)
    {
        StartCoroutine(ReactivateWithDelay(token.gameObject, delayInSeconds));
    }

    private IEnumerator ReactivateWithDelay(GameObject gameObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(true);
    }

    public void SpawnPlayerUI(PlayerInput playerInput)
    {
        var scoreElement = ScoreTemplate.Instantiate();
        UI.rootVisualElement.Q("ScoresContainer").Add(scoreElement);

        playerInput.gameObject.GetComponent<Player>().ScoreUI = scoreElement.Q<Label>("ScoreValue");
    }
}
