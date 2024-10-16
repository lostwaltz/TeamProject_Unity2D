using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;

public class HealthSystem : MonoBehaviour
{
    public GameObject prefabsTest;


    [SerializeField] private float healthChangeDelay = 0.5f;

    private float timeSinceLastChange = float.MaxValue;

    private CharacterStatsHandler statHandler;
    
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OninvinciblilityEnd;

    [SerializeField] public float CurrentHealth { get; private set; }
    public bool IsAttacked { get; private set; }

    private int MaxHealth => statHandler.CurrentStat.maxHealth;

    private void Awake()
    {
        statHandler = GetComponent<CharacterStatsHandler>();

    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        if(true == IsAttacked && timeSinceLastChange < healthChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;

            if(timeSinceLastChange >= healthChangeDelay )
            {
                OninvinciblilityEnd?.Invoke();
                IsAttacked = false;
            }
        }
    }


    public void ChangeHealth(float change)
    {
        if (false == CheackHealthChangeDelayEnd())
            return;// false;

        CurrentHealth += change;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        timeSinceLastChange = 0f;

        if(CurrentHealth == 0)
            OnDeath?.Invoke();

        if(change > 0)
            OnHeal?.Invoke();

        if(change < 0)
        {
            OnDamage?.Invoke();
            IsAttacked = true;
        }

        return;// true;
    }

    private bool CheackHealthChangeDelayEnd()
    {
        return timeSinceLastChange >= healthChangeDelay;
    }
}
