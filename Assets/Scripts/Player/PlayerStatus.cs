// ============================================
// [PlayerStatus.cs]
// 플레이어 스탯
// 
// 가져올것: 플레이어 키입력 정보(PlayerController)
// ============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }
    
    
    /// <summary> 데미지입히기: HP = HP - damage </summary>
    /// <param name="damage"> 데미지량 </param>
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log($"Player {damage} by 적/오브젝트");
        if (currentHP <= 0)
            Die();
    }

    /// <summary> 플레이어 HP <=0 일때 사망 </summary>
    void Die()
    {
        // 사망 처리
        gameObject.SetActive(false);
        Debug.Log("Player Dead");
    }

    /// <summary> HP회복 =>리스폰 </summary>
    /// <param name="amount"> 힐량 </param>
    public void Heal(int amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHP);
    }
}