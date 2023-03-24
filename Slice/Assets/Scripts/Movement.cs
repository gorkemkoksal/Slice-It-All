using DG.Tweening;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float maxHorizontalSpeed = 5f;
    [SerializeField] private float jumpPower = 1f;
    [SerializeField] private BoxCollider knifeCollider;

    private Rigidbody playerRb;
    private Transform knife;
    private bool isStabbed; 

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        knife = transform.GetChild(0);
    }
    private void OnEnable() => InputManager.onAnyTouch += InputManager_OnAnyTouch;
    private void OnDisable() => InputManager.onAnyTouch -= InputManager_OnAnyTouch;
    private void FixedUpdate() => ConstantForwardSpeed();
    private void ConstantForwardSpeed()
    {
        if (isStabbed) return;

        if (playerRb.velocity.z < maxHorizontalSpeed)
        {
            playerRb.AddForce(Vector3.forward * horizontalSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        else
        {
            KnifeColliderEnabler(true);
        }
    }
    private void InputManager_OnAnyTouch()
    {
        if (isStabbed)
        {
            playerRb.freezeRotation = false;
            playerRb.isKinematic = false;
            KnifeColliderEnabler(false);
            isStabbed = false;
        }
        JumpAndRotate();
    }
    private void JumpAndRotate()
    {
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        knife.DOLocalRotate(new Vector3(0, 0, -240), 1f, RotateMode.FastBeyond360);
    }
    private void KnifeColliderEnabler(bool isStabbed) => knifeCollider.enabled = isStabbed;
    public void SetIsStabbed(bool isStabbed) => this.isStabbed = isStabbed;



}
