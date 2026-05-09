using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LightSaber : WeaponBase
{
    [SerializeField] Transform hitPos;
    [SerializeField] float damage;
    public override void Activate1(GameObject owner)
    {
        //Normal attack
        //2 = animasyon + saldýrý

        //hit
        var hit = Physics.OverlapSphere(hitPos.position, 1);
        foreach(Collider h in hit)
        {
            if(h.TryGetComponent<PlayerStats>(out PlayerStats p))
            {
                p.TakeDamage(damage);
            }
        }
    }

    public override void Activate2(GameObject owner)
    {
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
            self.TakeDamage(damage);
        }
    }
}
