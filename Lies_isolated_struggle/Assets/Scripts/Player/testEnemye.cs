using UnityEngine;
using UnityEngine.EventSystems;

public class testEnemye : MonoBehaviour
{
    private bool clicked;
    [SerializeField] private int hp;

    private void OnMouseDown()
    {
        clicked = true;
    }

    private void OnMouseUp()
    {
        clicked = false;
    }

    public bool GetClicked()
    {
        return clicked;
    }

    

    public void Damage(int damage)
    {
        if (hp - damage <= 0) 
        {
            Destroy(gameObject);
            CombatManager.instance.UpdateEnemyList();
        }
        else
        {
            Debug.Log("Take " + damage + " damage");
            hp-= damage;
        }
    }
}
