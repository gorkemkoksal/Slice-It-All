using DG.Tweening;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float verticalSpeed = 5f;
    [SerializeField] private float maxVerticalSpeed = 5f;
    [SerializeField] private float spinSpeed = 5f;
    [SerializeField] private float jumpPower = 1f;
    [SerializeField] private BoxCollider knifeCollider;

    private Rigidbody playerRb;
    private bool isStabbed;
    private bool isKnockback;
    private ParticleSystem particleVFX;
    public bool IsEnded;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        particleVFX = GetComponent<ParticleSystem>();
    }
    private void OnEnable()
    {
        InputManager.OnAnyTouch += InputManager_OnAnyTouch;
        HolderHit.OnAnyBackHit += HolderHit_OnAnyBackHit;
        KnifeHit.OnAnyStab += KnifeHit_OnAnyStab;
        KnifeHit.OnAnyCut += KnifeHit_OnAnyCut;
    }
    private void OnDisable()
    {
        InputManager.OnAnyTouch -= InputManager_OnAnyTouch;
        HolderHit.OnAnyBackHit -= HolderHit_OnAnyBackHit;
        KnifeHit.OnAnyStab -= KnifeHit_OnAnyStab;
        KnifeHit.OnAnyCut -= KnifeHit_OnAnyCut;
    }
    private void FixedUpdate()
    {
        if (isStabbed) return;
        if (isKnockback) return;
        ConstantForwardSpeed();
    }
    private void ConstantForwardSpeed()
    {
        if (playerRb.velocity.z < maxVerticalSpeed)
        {
            playerRb.AddForce(Vector3.forward * verticalSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        else
        {
            KnifeColliderEnabler(true);
        }
    }
    private void InputManager_OnAnyTouch()
    {
        if (IsEnded) return;
        isKnockback = false;
        if (isStabbed)
        {
           // RigidbodyConstraintsSetter();

            playerRb.isKinematic = false;
            KnifeColliderEnabler(false);
            isStabbed = false;
        }
        //Spin(spinSpeed);
        playerRb.DORotate(new Vector3(660, 0, 0), 1f,RotateMode.FastBeyond360);
        Jump(jumpPower);

        particleVFX.Stop();
        particleVFX.Play();
    }
    private void KnifeColliderEnabler(bool isStabbed) => knifeCollider.enabled = isStabbed;
    private void HolderHit_OnAnyBackHit()
    {
        isKnockback = true;
        Spin(-spinSpeed * 0.75f);
        Jump(jumpPower/3, 5);
        print("back");
    }
    private void KnifeHit_OnAnyStab()
    {
        playerRb.freezeRotation = true;
        playerRb.isKinematic = true;
        playerRb.velocity = Vector3.zero;
        isStabbed = true;
    }
    private void KnifeHit_OnAnyCut()
    {
        playerRb.angularVelocity = Vector3.zero;
        isKnockback = true;
    }
    private void Jump(float jumpPower, float backwardPower = 0)
    {
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce(Vector3.up * jumpPower + Vector3.back * backwardPower, ForceMode.Impulse);
    }
    private void Spin(float spinSpeed)
    {
        playerRb.angularVelocity = Vector3.zero;
        playerRb.AddRelativeTorque(Vector3.right * spinSpeed, ForceMode.Impulse);

    }
    private void RigidbodyConstraintsSetter()
    {
        playerRb.constraints = RigidbodyConstraints.None;
        playerRb.constraints = RigidbodyConstraints.FreezePositionX;
        playerRb.constraints = RigidbodyConstraints.FreezeRotationY;
        playerRb.constraints = RigidbodyConstraints.FreezeRotationZ;
    }
}
