using System.Collections;
using System.Collections.Generic;
using Combat.BenProto;
using UnityEngine;

public class PlayerLineOffSight : MonoBehaviour
{
    private void FixedUpdate()
    {/*
        foreach (var enemy in CombatManager.instance.GetEnemies())
        {
            if (enemy != null)
            {
                RaycastHit2D ray = Physics2D.Raycast(transform.position, enemy.transform.position-transform.position);
                if(ray.collider != null)
                {
                    bool hasLineOffSight = ray.collider.CompareTag("Enemy");
                    Vector3 distance = enemy.transform.position - transform.position;
                    if (hasLineOffSight && distance.magnitude<=PlayerManager.instance.GetCurrentPlayer().ActiveWeapon.BaseRange)
                    {
                        Debug.DrawRay(transform.position, enemy.transform.position - transform.position, Color.green);
                        if(enemy.GetComponent<testEnemye>().GetClicked()) 
                        {
                            enemy.GetComponent<testEnemye>().Damage(CalculateTotalDamage());
                        }
                    }
                    else
                    {
                        Debug.DrawRay(transform.position, enemy.transform.position - transform.position, Color.red);
                    }
                }
            }
            
        }*/
        
    }

    private int CalculateTotalDamage()
    {
        Character player = PlayerManager.instance.GetCurrentPlayer();

        return Mathf.RoundToInt(player.ActiveWeapon.BaseDamage * player.RangedDamageBonus);
    }
}
