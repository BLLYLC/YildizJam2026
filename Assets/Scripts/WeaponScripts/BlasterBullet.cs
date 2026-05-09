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

    private void OnTriggerEnter(Collider other)
    {   print("COLLISANLANDIM2");
        if (other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats p))
        {
            p.TakeDamage(damage);
        }

        DestroySelf();
       
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
