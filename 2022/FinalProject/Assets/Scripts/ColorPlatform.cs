using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class ColorPlatform : MonoBehaviour
{
    public Player CurrentOwner { get; private set; }

    // Object coloring
    public float Intensity
    {
        get => _intensity;
        set
        {
            _intensity = value;
            UpdateHdrColor();
        }
    }
    [SerializeField]
    private float _intensity;
    [SerializeField]
    private Color _baseColor;
    private Color _hdrColor;
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    private int _baseColorId;
    private int _emissionColorId;

    // Animation
    private Animator _animator;
    private int _animationPopTrigger;

    // Sound effects
    private AudioSource _audioSource;
    private readonly float _audioCooldown = 0.3f;
    private DateTime _lastPlayOff = DateTime.Now;

    private void OnValidate()
    {
        Intensity = _intensity;
        SetColor(_baseColor);
    }

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _animationPopTrigger = Animator.StringToHash("PopColor");

        _renderer = GetComponent<Renderer>();
        _baseColorId = _renderer.material.shader.GetPropertyNameId(_renderer.material.shader.FindPropertyIndex("_BaseColor"));
        _emissionColorId = _renderer.material.shader.GetPropertyNameId(_renderer.material.shader.FindPropertyIndex("_EmissionColor"));
    }

    // Update is called once per frame
    private void Update()
    {
        OnValidate();
        UpdateColorsInMaterial();
    }

    /// <summary>
    /// Change owner of the platform. Also updates the platform color to that of the player
    /// </summary>
    /// <param name="color"></param>
    public void SetOwner(Player player)
    {
        CurrentOwner = player;
        SetColor(player.Color);
        _animator.SetTrigger(_animationPopTrigger);
        if (_lastPlayOff.AddSeconds(_audioCooldown) < DateTime.Now)
        {
            _audioSource.pitch = 0.5f + 0.5f * player.Color.r;
            _audioSource.Play();
            _lastPlayOff = DateTime.Now;
        }
    }

    /// <summary>
    /// Private method to update the base and HDR version of the colors
    /// </summary>
    /// <param name="color"></param>
    private void SetColor(Color color)
    {
        _baseColor = color;
        UpdateHdrColor();
    }

    private void UpdateHdrColor()
    {
        _hdrColor = _baseColor * (1 + Mathf.Pow(2, _intensity));
    }

    private void UpdateColorsInMaterial()
    {
        // If null, create a new one
        _propBlock ??= new MaterialPropertyBlock();

        // Get the current value of the material properties in the renderer
        _renderer.GetPropertyBlock(_propBlock);

        // Assign new value
        _propBlock.SetColor(_baseColorId, _baseColor);
        _propBlock.SetColor(_emissionColorId, _hdrColor);

        // Apply the edited values to the renderer
        _renderer.SetPropertyBlock(_propBlock);
    }
}
