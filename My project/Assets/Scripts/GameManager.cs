using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public List<Color> colors;

    public GameObject ScoreTable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Player player = playerInput.gameObject.GetComponent<Player>();
        player.Color = colors[playerInput.playerIndex];
        player.ScoreTable = ScoreTable;
    }
}
