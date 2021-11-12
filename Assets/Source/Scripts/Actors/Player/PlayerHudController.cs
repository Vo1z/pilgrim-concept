using UnityEngine;

public class PlayerHudController : MonoBehaviour
{
    [Header("Sway Settings")]
    [SerializeField] private float smooth;
    [SerializeField] private float multiplier;
    [SerializeField] private float rotationZMultiplier;

    private void Update()
    {
        float movementX = Input.GetAxisRaw("Horizontal") * multiplier;
        float mouseX = Input.GetAxisRaw("Mouse X") * multiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * multiplier;

        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0) 
            movementX /= 10;

        Quaternion rotationX = Quaternion.AngleAxis(Mathf.Clamp(-mouseY, -10, 20), Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(Mathf.Clamp(mouseX, -8, 8), Vector3.up);
        Quaternion rotationYz = Quaternion.AngleAxis(Mathf.Clamp(mouseX / multiplier * rotationZMultiplier, -25, 25), -Vector3.forward);
        Quaternion rotationZ = Quaternion.AngleAxis(Mathf.Clamp(-movementX, -5, 5), Vector3.forward);

        Quaternion targetRotation = rotationX * rotationY * rotationZ * rotationYz;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }
}
