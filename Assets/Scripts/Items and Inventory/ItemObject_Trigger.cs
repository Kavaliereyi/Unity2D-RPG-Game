using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject_Trigger : MonoBehaviour
{
    private ItemObject myItemObject => GetComponentInParent<ItemObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerManager.instance.player.GetComponent<PlayerStats>().isDead) return;

        if (collision.GetComponent<Player>() != null)
        {
            myItemObject.PickUpItem();
        }
    }
}
