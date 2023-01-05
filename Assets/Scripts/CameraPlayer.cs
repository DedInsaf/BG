using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    [Header("���������������� ����")]

    float xRotation;
    public float sensivityMouse = 1.5f;

    public Transform Player;
    public void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseX = Input.GetAxis("Mouse X") * sensivityMouse * Time.deltaTime * 300;
        mouseY = Input.GetAxis("Mouse Y") * sensivityMouse * Time.deltaTime * 300;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Player.Rotate(mouseX * new Vector3(0, 1, 0));

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
