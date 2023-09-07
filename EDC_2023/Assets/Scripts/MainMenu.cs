using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MainMenu : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<UIDocument>().rootVisualElement.Q<Button>("StartButton");
        _button.clicked += OnClickStart;
    }

    private void OnClickStart()
    {
        SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
    }
}
