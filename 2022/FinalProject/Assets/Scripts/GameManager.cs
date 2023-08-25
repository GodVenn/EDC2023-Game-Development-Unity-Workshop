using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    // This class is a singleton
    public static GameManager instance;
    //

    #region Inputs
    public InputActionAsset InputActions;
    private InputActionMap _playerInputMap;
    private InputActionMap _UIInputMap;
    private bool _menuToggledOn = false;
    private bool _gameIsRunning = false;
    #endregion

    #region Game
    [Tooltip("The total remaining time of the game (s)")]
    public float TimeLeft = 60f;
    public GameObject UIScoreGroup;
    public List<Player> Players;
    #endregion

    #region Sound
    private AudioSource _audioSource;
    #endregion

    private void Awake()
    {
        if (instance is null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        if (InputActions is null)
        {
            Debug.LogError("CRITICAL FAIL: No input actions registered to game manager");
#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(1);
#endif
        }

        _playerInputMap = InputActions.FindActionMap("Player");
        _UIInputMap = InputActions.FindActionMap("UI");

        ActivatePlayerInput();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_gameIsRunning)
        {
            TimeLeft -= Time.deltaTime;

            if (TimeLeft <= 0)
            {
                EndGame();
            }
        }
    }

    private void EndGame()
    {
        TimeLeft = 0;
        _playerInputMap.Disable();
        int highestScore = Players.Max(p => p.Score);
        List<Player> winners = Players.Where(p => p.Score == highestScore).ToList();
        foreach (Player winner in winners)
        {
            winner.transform.localScale *= 10f;
        }
        _gameIsRunning = false;
        _audioSource.Play();
    }

    private void ActivatePlayerInput()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _playerInputMap.Enable();
        _UIInputMap.Disable();
    }

    private void ActivateUIInput()
    {
        Cursor.lockState = CursorLockMode.None;
        _playerInputMap.Disable();
        _UIInputMap.Enable();
    }

    private void ToggleControlInput(bool isMenu)
    {
        if (isMenu)
            ActivateUIInput();
        else
            ActivatePlayerInput();
    }

    public void OnMenuButtonPress(InputAction.CallbackContext context)
    {
        _menuToggledOn = !_menuToggledOn;
        ToggleControlInput(_menuToggledOn);
    }

    public void OnPlayerJoin()
    {
        _gameIsRunning = true;
    }
}
