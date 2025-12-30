using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal effect", menuName = "Data/Item effect/Heal effect")]
public class Heal_Effect : ItemEffect
{
    [Range(0, 1f)]
    [SerializeField] private float healPercentage;

    public override void ExecuteItemEffect(Transform _enemyPosition)
    {
        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();

        int healAmount = Mathf.RoundToInt(playerStats.GetMaxHealthValue() * healPercentage);

        playerStats.IncreaseHealthBy(healAmount);
    }
}
