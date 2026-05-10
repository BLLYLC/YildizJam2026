using UnityEngine;

public class BlasterBullet : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float speed = 15f;
    [SerializeField] private float lifetime = 10f;
    [SerializeField] private float turnSpeed = 5f;
    private float time = 0f;
    private Transform target; 
    
    public void SetTarget(Transform t)
    {
        target = t;
    }
    
    private void Update()
    {
        time += Time.deltaTime;
        if(time > lifetime)
        {
            DestroySelf();
        }

        if (target != null ) 
        {
            Vector3 direction = target.position - transform.position;
            direction.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            // Anýnda dönme, yavaþça dön
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {   
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
