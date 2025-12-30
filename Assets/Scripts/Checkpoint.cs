using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator anim;
    public string ID;
    public bool activationStatus;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    [ContextMenu("Generate checkpoint ID")]
    private void GenerateID()
    {
        ID = System.Guid.NewGuid().ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            if (!activationStatus)
                AudioManager.instance.PlaySFX(6, null);
            ActivateCheckpoint();
        }
    }

    public void ActivateCheckpoint()
    {
        activationStatus = true;
        anim.SetBool("active", true);
    }
}
