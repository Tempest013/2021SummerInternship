using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp;
    public int maxHp;
    
    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
       
        if(hp <= 0)
        {
            this.GetComponent<EnemyBase>().Die();
        }
    }
    public virtual void Heal(int amount)
    {
        hp += amount;
        if(hp>=maxHp)
        {
            hp = maxHp;
        }
    }

}
