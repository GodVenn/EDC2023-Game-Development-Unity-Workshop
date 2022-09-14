using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UI_Score : MonoBehaviour
{
    public Color Color;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI scoreValue;

    // This OnValidate method is just here so we can check that it works in the editor
    private void OnValidate()
    {
        scoreText.color = Color;
        scoreValue.color = Color;
    }

    // Start is called before the first frame update
    private void Start()
    {
        scoreText.color = Color;
        scoreValue.color = Color;
    }

    public void SetScore(string score)
    {
        scoreValue.text = score;
    }
}
