using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp;
    public int maxHp;
    private IEnumerator flashRed;

    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
        EnemyBase enemy = this.GetComponent<EnemyBase>();
        if(enemy!=null &&!enemy.IsDead)
        {
            if(flashRed!=null)
            StopCoroutine(flashRed);
            flashRed = enemy.FlashRed();
            StartCoroutine(flashRed);
           // DamagePopup.Create(this.transform.position, damage, enemy.DamagePopupRef);

        }

        if (hp <= 0)
        {
            if(enemy!=null)
            enemy.Die();

        }
    }
    public virtual void Heal(int amount)
    {
        hp += amount;
        if (hp >= maxHp)
        {
            hp = maxHp;
        }
    }

}
