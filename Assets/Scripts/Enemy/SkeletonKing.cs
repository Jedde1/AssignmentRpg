using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonKing : Enemy
{
 
    [Header("King Stats")]
    public float curStamina;
    public float maxStamina;

    public override void Attack()
    {
        Debug.Log("Action 1");
        base.Attack();

        Debug.Log("Action 2");
    }
    public void skel_king_attack1()
    {
        int critChance = Random.Range(0, 21);
        float critDamage = 0;
        if (critChance == 20)
        {
            critDamage = Random.Range(baseDamage / 2, baseDamage * difficulty);
        }
        Debug.Log("Bite");
        player.GetComponent<PlayerHandler>().DamagePlayer(baseDamage * difficulty + critDamage);
    }

}


