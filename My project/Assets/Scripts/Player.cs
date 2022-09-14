using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            scoreUI.SetScore(value);
        }
    }
    private int _score;

    public UI_Score scoreUI;
    public GameObject ScoreTable;
    public GameObject ScorePrefab;

    public Color Color;
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    private int _baseColorId;

    // Start is called before the first frame update
    void Start()
    {
        //Color = new Color(Random.value, Random.value, Random.value);
        _renderer = GetComponent<Renderer>();
        _baseColorId = _renderer.material.shader.GetPropertyNameId(_renderer.material.shader.FindPropertyIndex("_BaseColor"));
        _propBlock = new MaterialPropertyBlock();
        UpdateColorInMaterial();

        GameObject obj = Instantiate(ScorePrefab, ScoreTable.transform);
        scoreUI = obj.GetComponent<UI_Score>();
        scoreUI.SetColor(Color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Platform"))
        {
            ColorPlatform platform = hit.gameObject.GetComponent<ColorPlatform>();
            platform.SetColor(Color);
        }
    }

    public void SetColor(Color color)
    {
        Color = color;
        UpdateColorInMaterial();
    }

    private void UpdateColorInMaterial()
    {
        _renderer.GetPropertyBlock(_propBlock);

        _propBlock.SetColor(_baseColorId, Color);

        _renderer.SetPropertyBlock(_propBlock);
    }
}
