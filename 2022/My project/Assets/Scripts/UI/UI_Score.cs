using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class UI_Score : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI scoreValue;

    private void Start()
    {

    }

    public void SetColor(Color color)
    {
        color.a = 1;
        scoreText.color = color;
        scoreValue.color = color;
    }

    public void SetScore(int score)
    {
        scoreValue.text = score.ToString();
    }
}

