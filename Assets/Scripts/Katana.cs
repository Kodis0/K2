using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    [Header("Katana")]//
    public GameObject katana;
    public float KatanaAttackCooldown;
    public float KatanaRange;
    private bool KatanaCanAttack = true;
    private bool KatanaIsAttacking = false;
    public ColDec cold;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (KatanaCanAttack))
        {
            KatanaAttack();
        }
    }
   
    public void KatanaAttack()
    {
        KatanaIsAttacking = true;
        KatanaCanAttack = false;
        Animator anim = katana.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        cold.Shoot_Sound();
        StartCoroutine(KatanaResetAttackCooldown());
    }
    
    IEnumerator KatanaResetAttackCooldown()
    {
        StartCoroutine(KatanaResetAttackBool());
        yield return new WaitForSeconds(KatanaAttackCooldown);
        KatanaCanAttack = true;
    }

    IEnumerator KatanaResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        KatanaIsAttacking = false;
    }
}
