using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            scoreUi.SetScore(value.ToString());
        }
    }
    private int _score;

    public Color Color;

    public GameObject UIScorePrefab;
    public Renderer Renderer;
    private UI_Score scoreUi;

    private void Start()
    {
        GameObject obj = Instantiate(UIScorePrefab, GameManager.instance.UIScoreGroup.transform);
        scoreUi = obj.GetComponent<UI_Score>();
        GameManager.instance.Players.Add(this);

        Score = 0;
        Color = new Color(Random.value, Random.value, Random.value, 1);
        Renderer.material.color = Color;
        scoreUi.Color = Color;
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.gameObject.CompareTag("ColorPlatform"))
        {
            ColorPlatform platform = collision.gameObject.GetComponent<ColorPlatform>();
            if (platform.CurrentOwner != this)
            {
                // If platform has been stolen, subtract from other player score
                if (platform.CurrentOwner is not null)
                    platform.CurrentOwner.Score--;

                platform.SetOwner(this);
                Score++;
            }
        }
    }
}