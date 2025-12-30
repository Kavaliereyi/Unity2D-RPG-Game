using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStrikeAnimationTrigger : MonoBehaviour
{
    private ThunderStrike_Controller thunderController;

    void Start()
    {
        thunderController = GetComponentInParent<ThunderStrike_Controller>();
    }
    private void SelfDestroy()
    {
        Destroy(thunderController.gameObject);
    }
}
