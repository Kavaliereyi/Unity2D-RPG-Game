using UnityEngine;

public class EnemyStats : CharacterStats
{
    private Enemy enemy;
    private ItemDrop myDropSystem;
    [SerializeField] private Stats soulsDropAmount;

    [Header("Level")]
    [SerializeField] private int level;

    [Range(0f, 1f)]
    [SerializeField] private float percentageModifier = .4f;

    protected override void Start()
    {
        //soulsDropAmount.SetDefaultValue(100);
        ApplyLevelModifiers();

        base.Start();

        enemy = GetComponent<Enemy>();
        myDropSystem = GetComponent<ItemDrop>();
    }

    private void ApplyLevelModifiers()
    {
        //Modify(strength);
        //Modify(agility);
        //Modify(intelligence);
        //Modify(vitality);

        Modify(damage);
        //Modify(critPower);
        //Modify(critChance);

        Modify(armor);
        Modify(maxHealth);
        //Modify(evasion);
        Modify(magicResistance);

        Modify(fireDamage);
        Modify(iceDamage);
        Modify(lightningDamage);

        Modify(soulsDropAmount);
    }

    private void Modify(Stats _stats)
    {
        for (int i = 1; i < level; i++)
        {
            float modifier = _stats.GetValue() * percentageModifier;

            _stats.AddModifier(Mathf.RoundToInt(modifier));
        }
    }

    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);
    }

    protected override void Die()
    {
        base.Die();
        enemy.DieAnim();

        PlayerManager.instance.currency += soulsDropAmount.GetValue();
        myDropSystem.GenerateDrop();

        Destroy(gameObject, 5f);
    }
}
