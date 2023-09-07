using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour
{
    private Button _button;
    private Label _title1, _title2, _title3, _title4, _title5;
    private AudioSource _audioSource;

    public AudioClip MenuBang;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        var root = GetComponent<UIDocument>().rootVisualElement;
        _button = root.Q<Button>("StartButton");
        _button.clicked += OnClickStart;
        _title1 = root.Q<Label>("Title1");
        _title2 = root.Q<Label>("Title2");
        _title3 = root.Q<Label>("Title3");
        _title4 = root.Q<Label>("Title4");
        _title5 = root.Q<Label>("Title5");
    }

    private void Start()
    {
        StartCoroutine(ShowDelayed(_title1, 0.5f));
        StartCoroutine(ShowDelayed(_title2, 1.0f));
        StartCoroutine(ShowDelayed(_title3, 3.0f));
        StartCoroutine(ShowDelayed(_title4, 3.5f));
        StartCoroutine(ShowDelayed(_title5, 4.0f));
    }

    private void OnClickStart()
    {
        SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
    }

    private IEnumerator ShowDelayed(Label label, float delay)
    {
        label.visible = false;
        yield return new WaitForSeconds(delay);
        label.visible = true;
        StartCoroutine(ScaleUp(label));
    }

    private IEnumerator ScaleUp(Label label) 
    {
        _audioSource.PlayOneShot(MenuBang);
        var originalScale = label.transform.scale.x;
        float scale = 0f;
        while (scale < originalScale)
        {
            label.transform.scale = new Vector3(scale, scale, scale);
            scale += 0.05f;
            yield return null;
        }
    }
}
