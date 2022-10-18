using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealbar;

    private void Start()
    {
        
    }

    private void Update()
    {
        currentHealbar.fillAmount = playerHealth.currentHealth / 10;
    }
}
