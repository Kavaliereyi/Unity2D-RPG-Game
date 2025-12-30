using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockStrikeAnimationTrigger : MonoBehaviour
{
    private ShockStrike_Controller shockController;

    void Start()
    {
        shockController = GetComponentInParent<ShockStrike_Controller>();
    }
    private void ShockDamage()
    {
        shockController.Target.ApplyShock(true);
        shockController.Target.TakeDamage(shockController.Damage);
    }

    private void SelfDestroy() => Destroy(shockController.gameObject);
}
