using UnityEngine;

public class Shield : WeaponBase
{
    private Rigidbody rb;
    [SerializeField] private float itmeGucu = 2f;
    public override void Activate1(GameObject owner)
    {
        rb.AddForce(owner.transform.forward * itmeGucu, ForceMode.Impulse);
    }

    public override void Activate2(GameObject owner)
    {

    }
}
