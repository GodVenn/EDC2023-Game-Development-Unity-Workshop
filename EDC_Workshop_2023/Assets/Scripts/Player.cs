using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform ProjectileSpawnPoint;

    private int _score;
    public int Score { 
            get 
            { 
                return _score; 
            }
            set
            {
                _score = value;
                ScoreUI.text = value.ToString();
            }
        }

    public Label ScoreUI;

    private void Start()
    {
        Score = 0;
    }

    private void OnAttack()
    {
        Instantiate(ProjectilePrefab, ProjectileSpawnPoint.position, transform.rotation);
    }

    public void OnHitByProjectile(Projectile projectile)
    {
        Score--;
    }
}
