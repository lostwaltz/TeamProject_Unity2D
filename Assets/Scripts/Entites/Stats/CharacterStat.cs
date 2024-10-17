using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StatsChangeType
{
    Add,
    Multple,
    Override
}


[System.Serializable]
public class CharacterStat
{
    public StatsChangeType statsChangeType;
    [Range(1, 100f)] public int maxHealth;
    [Range(1, 20f)] public float speed;
    [Range(15, 40f)] public float jumpPower;
}

