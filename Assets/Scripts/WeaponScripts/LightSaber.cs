using System.Collections;
using UnityEngine;

public class LightSaber : WeaponBase
{
    [SerializeField] private Transform hitPos;
    [SerializeField] private float damage = 20f;
    [SerializeField] private float dashForce = 5f;
    [SerializeField] private float dashDuration = 0.15f;

    public override void Activate2(GameObject owner)
    {
        //Normal attack
        //2 = animasyon + saldýrý

        //hit
        var hit = Physics.OverlapSphere(hitPos.position, 1);
        bool didHit = false;

        foreach(Collider h in hit)
        {
            if(h.TryGetComponent<PlayerStats>(out PlayerStats p))
            {
                p.TakeDamage(damage);
                didHit = true;
            }
        }

        if (!didHit && owner.TryGetComponent<PlayerStats>(out PlayerStats self))
        {
            self.TakeDamage(damage * 0.5f);
        }
    }

    public override void Activate1(GameObject owner)
    {
        StartCoroutine(DashCoroutine(owner));

        var hit = Physics.OverlapSphere(hitPos.position, 1);
        bool didHit = false;
        foreach (Collider h in hit)
        {
            if (h.TryGetComponent<PlayerStats>(out PlayerStats p))
            {
                p.TakeDamage(damage);
                didHit = true;
            }
        }

        if ( (!didHit) && (owner.TryGetComponent<PlayerStats>(out PlayerStats self)))
        {
            self.TakeDamage(damage * 0.5f);
        }
    }

    private IEnumerator DashCoroutine(GameObject owner)
    {
        float elapsed = 0f;

        while (elapsed < dashDuration)
        {
            owner.transform.position += owner.transform.forward * dashForce * Time.deltaTime;
            elapsed += Time.deltaTime;
            yield return null;
        }
    }


}
