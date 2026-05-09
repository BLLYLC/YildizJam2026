using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed=10f;
    [SerializeField] private int playerID;
    [SerializeField] private WeaponBase weapon;
    [SerializeField] private Transform playerHand;

    private void Start()
    {
        GameInput.Instance.OnInteract1Action += GameInput_OnInteract1Action;
        GameInput.Instance.OnInteract2Action += GameInout_OnInteract2Action;
    }

    private void GameInout_OnInteract2Action(object sender, int pID)
    {
        if (pID == playerID)
        {
            weapon.Activate2(gameObject);
        }
    }

    private void GameInput_OnInteract1Action(object sender, int pID)
    {
        if (pID == playerID)
        {
            weapon.Activate1(gameObject);
        }
       
    }

    void Update()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized(playerID);
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir*moveSpeed*Time.deltaTime;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed*Time.deltaTime);
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
    }
}
