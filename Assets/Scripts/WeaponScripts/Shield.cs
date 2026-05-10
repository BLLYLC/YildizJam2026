using System.Collections;
using UnityEngine;

public class Shield : WeaponBase
{
    [SerializeField] private float itmeGucu = 10f;
    [SerializeField] private float chargeDuration = 0.4f;  // Charge süresi
    [SerializeField] private float chargeSpeed = 20f;       // Charge hýzý
    [SerializeField] private Transform hitPos;
    [SerializeField] private float damage = 15f;
    [SerializeField] private float selfDamage = 5f;
    [SerializeField] private Vector3 boxBoyutu = new Vector3(2f, 2f, 1f);

    // Blok sistemi
    private bool isBlocking = false;
    private float blockCooldown = 3f;
    private float blockTimer = 0f;
    private bool cooldownActive = false;

    private void Update()
    {
        // Cooldown geri sayýmý
        if (cooldownActive)
        {
            blockTimer -= Time.deltaTime;
            if (blockTimer <= 0f)
            {
                cooldownActive = false;
                blockTimer = 0f;
            }
        }
    }

    // Activate1: Blok + Yakýn Vuruþ (öz hasar ile)
    public override void Activate1(GameObject owner)
    {
        // Blok aktifse vurma, sadece blok yap
        if (!cooldownActive)
        {
            StartCoroutine(BlockCoroutine());
            return; // Blok baþladý, vuruþ yapma
        }

        // Cooldown'daysa yakýn vuruþ yap
        var hits = Physics.OverlapBox(hitPos.position, boxBoyutu / 2, hitPos.rotation);
        bool didHit = false;

        foreach (Collider h in hits)
        {
            if (h.gameObject == owner) continue; // Kendine vurma

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

        // Rakibe vurduysan kendine de hasar al
        if (didHit && owner.TryGetComponent<PlayerStats>(out PlayerStats self))
        {
            self.TakeDamage(selfDamage);
        }
    }

    // Activate2: Charge saldýrýsý
    public override void Activate2(GameObject owner)
    {
        StartCoroutine(ChargeCoroutine(owner));
    }

    // 3 saniye blok coroutine
    private IEnumerator BlockCoroutine()
    {
        isBlocking = true;
        yield return new WaitForSeconds(3f); // 3 saniye blok
        isBlocking = false;

        // Cooldown baþlat
        cooldownActive = true;
        blockTimer = blockCooldown;
    }

    // Charge coroutine
    private IEnumerator ChargeCoroutine(GameObject owner)
    {
        float elapsed = 0f;

        while (elapsed < chargeDuration)
        {
            owner.transform.position += owner.transform.forward * chargeSpeed * Time.deltaTime;
            elapsed += Time.deltaTime;

            // Charge sýrasýnda çarpýþma kontrolü
            var hits = Physics.OverlapBox(hitPos.position, boxBoyutu / 2, hitPos.rotation);
            foreach (Collider h in hits)
            {
                if (h.gameObject == owner) continue;

                if (h.TryGetComponent<PlayerStats>(out PlayerStats p))
                {
                    p.TakeDamage(damage * 1.5f); // Charge hasarý daha fazla
                    yield break; // Çarptýktan sonra dur
                }
            }

            yield return null;
        }
    }

    // Dýþarýdan blok kontrolü — PlayerStats buraya bakacak
    public bool IsBlocking()
    {
        return isBlocking;
    }
}