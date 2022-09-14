using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlatform : MonoBehaviour
{
    public Player CurrentOwner;

    public Color BaseColor;
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    private int _baseColorId;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _baseColorId = _renderer.material.shader.GetPropertyNameId(_renderer.material.shader.FindPropertyIndex("_BaseColor"));
        _propBlock = new MaterialPropertyBlock();
        UpdateColorInMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(Color color)
    {
        BaseColor = color;
        UpdateColorInMaterial();
    }

    private void UpdateColorInMaterial()
    {
        _renderer.GetPropertyBlock(_propBlock);

        _propBlock.SetColor(_baseColorId, BaseColor);

        _renderer.SetPropertyBlock(_propBlock);
    }

}
