using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int Score;
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
        Debug.Log("Hit");
    }

    // Called by Input System
    private void OnAttack()
    {
        Attack();
    }
}
