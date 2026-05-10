using UnityEngine;

public class BlasterBullet : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float speed = 15f;
    [SerializeField] private float lifetime = 10f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private float time = 0f;
    private int playerID;


    private void Start()
    {
        time = 0;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(time > lifetime)
        {
            Debug.Log("Destroy by lifetime"+time);

            DestroySelf();
        }

        
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
       
        if (other != null && other.name == "table")
        {
            return;
        }
        if (other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats p))
        {
            p.TakeDamage(damage);
        }
        if(other.gameObject.TryGetComponent<BlasterBullet>(out BlasterBullet bb))
        {
            if (bb.GetPlayerID() == playerID) {
                return;
            }
        }
        Debug.Log("Destroyed by "+ other.name);

        DestroySelf();
       
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
    public void SetPlayer(int pID)
    {
        playerID = pID;
    }
    public int GetPlayerID() { return playerID; }
}
