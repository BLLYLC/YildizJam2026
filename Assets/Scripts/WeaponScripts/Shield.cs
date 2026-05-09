using UnityEngine;

public class Shield : WeaponBase
{
    private Rigidbody rb;
    [SerializeField] private float itmeGucu = 10f;
    [SerializeField] private float secondHalfBuff = 2f;

    [SerializeField] Transform hitPos;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float selfDamage = 5f;
    [SerializeField] private Vector3 boxBoyutu = new Vector3(2f, 2f, 1f); 
    [SerializeField] private LayerMask dusmanLayer;

    public override void Activate1(GameObject owner)
    {
        var hit = Physics.OverlapBox(hitPos.position, boxBoyutu / 2, hitPos.rotation, dusmanLayer);

        bool didHit = false;

        foreach (Collider h in hit)
        {
            if (h.TryGetComponent<PlayerStats>(out PlayerStats p))
            {
                p.TakeDamage(damage);
                didHit = true;
            }
            if (h.TryGetComponent<Rigidbody>(out Rigidbody rakipRb))
            {
                rakipRb.AddForce(owner.transform.forward * itmeGucu, ForceMode.Impulse);
            }
        }
        if(didHit)
        {
            if(owner.TryGetComponent<PlayerStats>(out PlayerStats selfStats))
            {
                selfStats.TakeDamage(selfDamage);
            }
        }
    }

    public override void Activate2(GameObject owner)
    {
        rb.AddForce(owner.transform.forward * itmeGucu * secondHalfBuff, ForceMode.Impulse);

    }
}
