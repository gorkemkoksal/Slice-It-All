using DG.Tweening;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody playerRb;
    private Transform knife;
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float maxHorizontalSpeed = 5f;
    [SerializeField] private float jumpPower = 1f;
    [SerializeField] private BoxCollider knifeCollider;
    
    private bool isStabbed;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        knife = transform.GetChild(0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isStabbed)
            {
                playerRb.isKinematic = false;
                KnifeColliderEnabler(false);
                isStabbed = false;
            }
            JumpAndRotate();
        }
    }
    private void FixedUpdate()
    {
        ConstantForwardSpeed();
    }
    private void ConstantForwardSpeed()
    {
        if (isStabbed) { return; }

      //  print(playerRb.velocity.z);
        if (playerRb.velocity.z < maxHorizontalSpeed)
        {
            playerRb.AddForce(Vector3.forward * horizontalSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        else
        {
            KnifeColliderEnabler(true);
        }
    }
    private void JumpAndRotate()
    {
        var rotateAmount = Random.Range(250, 360);
        playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        knife.DOLocalRotate(-Vector3.forward * rotateAmount, 1f, RotateMode.FastBeyond360);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plane"))
        {
            playerRb.isKinematic = true;
            playerRb.velocity = Vector3.zero;
            isStabbed = true;
        }
    }
    private void KnifeColliderEnabler(bool isStabbed)
    {
        knifeCollider.enabled = isStabbed;
    }

}
