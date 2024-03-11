using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private MonsterData _data;

    [Separator(5,2)]
    [SerializeField]
    private int health;

    public MonsterData Data => _data;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Data.RangeOfAwareness);

        Gizmos.color = Color.blue;
        Vector3 direction = transform.forward * Data.RangeOfAwareness;
        Gizmos.DrawRay(transform.position, direction);

    }
}
