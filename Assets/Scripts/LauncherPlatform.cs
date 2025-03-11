using System.Collections;
using UnityEngine;

public class LauncherPlatform : MonoBehaviour
{
    [SerializeField] private float launchPower = 10f;
    [SerializeField] private float launchDelay = 1f;

    private static readonly int launch = Animator.StringToHash("Launch");
    private static readonly int launchSpeed = Animator.StringToHash("LaunchSpeed");

    private Animator animator;

    private bool isLaunched = false;

    private Coroutine coroutine;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out RigidbodyReciver rb))
        {
            coroutine = StartCoroutine(Launch(rb));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(coroutine != null)
            StopCoroutine(coroutine);
    }

    private IEnumerator Launch(RigidbodyReciver rb)
    {
        if (!isLaunched)
        {
            yield return new WaitForSeconds(launchDelay);

            rb.AddForce((transform.forward + transform.up) * launchPower, ForceMode.Impulse);

            isLaunched = true;

            animator.SetFloat(launchSpeed, launchPower);
            animator.SetTrigger(launch);
        }
    }

    public void isReady()
    {
        isLaunched = false;
    }
}
