using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float MaxRespawnTime = 10f;
    public static GameManager instance;

    private void Awake()
    {
        if (instance is not null)
            Destroy(this);

        instance = this;
    }

    public void OnTokenDisabled(Token token)
    {
        StartCoroutine(ReActivateAtRandomTime(token));
    }

    private IEnumerator ReActivateAtRandomTime(Token token)
    {
        float delay = Random.Range(0f, MaxRespawnTime);
        Debug.Log(delay);
        yield return new WaitForSeconds(delay);
        Debug.Log("Respawn");
        token.gameObject.SetActive(true);
    }
}
