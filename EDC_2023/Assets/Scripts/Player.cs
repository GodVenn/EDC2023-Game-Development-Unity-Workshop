using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private int _score;
    public int Score { 
        get { return _score; } 
        set
        {
            _score = value;
            UiScore.text = value.ToString();
        } 
    }
    public Label UiScore;

    #region Attack
    public Transform ProjectileSpawnPoint;
    public GameObject ProjectilePrefab;
    #endregion

    public void Attack()
    {
        Instantiate(ProjectilePrefab, ProjectileSpawnPoint.position, transform.rotation);
    }

    public void OnHitByProjectile(Projectile projectile)
    {
        Score--;
    }

    // Called by Input System
    private void OnAttack()
    {
        Attack();
    }
}
