using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Material matBlock;
    private MeshRenderer meshRenderer;
    private Camera mainCamera;
    private Enemy enemy;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        matBlock = meshRenderer.material;
        enemy = GetComponentInParent<Enemy>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (enemy != null && enemy.currentHealth <= enemy.maxHealth)
        {
            UpdateParams();
        }
        if(enemy.currentHealth <= 0)
        {
            meshRenderer.enabled = false;
        }
    }

    private void UpdateParams()
    {
        matBlock.SetFloat("_Fill", enemy.currentHealth / enemy.maxHealth);
    }
}
