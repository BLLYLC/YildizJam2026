using UnityEngine;

public class BlasterBullet : MonoBehaviour
{
    [SerializeField] private float damage = 10;
    private float time = 0;
    private float speed=5;
    private void Update()
    {
        time += Time.deltaTime;
        if(time > 5f)//hayattakalma süresi
        {
            DestroySelf();
        }
        transform.position += transform.forward*speed*Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats p))
        {
            p.TakeDamage(damage);
        }
        print("COLLISANLANDIM1");
        DestroySelf();
        print("COLLISANLANDIM2");
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
