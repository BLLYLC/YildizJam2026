using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float baseMoveSpeed = 10f;
    [SerializeField] private int playerID;
    [SerializeField] private Transform playerHand;
   
    private WeaponBase weapon;
    private float moveSpeed;


    private void Start()
    {
        moveSpeed = baseMoveSpeed;
        GameInput.Instance.OnInteract1Action += GameInput_OnInteract1Action;
        GameInput.Instance.OnInteract2Action += GameInout_OnInteract2Action;
    }

    private void GameInout_OnInteract2Action(object sender, int pID)
    {
        if (pID == playerID && weapon != null)
        {
            weapon.Activate2(gameObject);
        }
    }

    private void GameInput_OnInteract1Action(object sender, int pID)
    {
        if (pID == playerID && weapon != null)
        {
            weapon.Activate1(gameObject);
        }
       
    }

    void Update()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized(playerID);
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if (moveDir != Vector3.zero)
        {
            float rotateSpeed = 10f;
            transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);
        }
    }
    public int GetPlayerID()
    {
        return playerID;
    }
    public void SetWeapon(WeaponBase newWeapon)
    {       
        weapon = newWeapon;
        newWeapon.transform.parent = playerHand;
        newWeapon.transform.localPosition = Vector3.zero;
        newWeapon.transform.localRotation = Quaternion.identity;

        if (newWeapon is LightSaber)
        {
            moveSpeed = baseMoveSpeed * 1.4f;
        }
        else if (newWeapon is Blaster)
        {
            moveSpeed = (baseMoveSpeed * 0.6f);
            newWeapon.transform.localRotation *= Quaternion.Euler(-90, 0, 0);
        }
        
        else
        {
            moveSpeed = baseMoveSpeed;
        }
        
    }
}
