using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
public class HackVulnerable : MonoBehaviour
{
    public float duration;
    [SerializeField] CyberHackeos_Extremos controls;

    bool isMouseIn;

    private void Start()
    {
        controls = new CyberHackeos_Extremos();
        controls.Enable();
        controls.Player.Fire.performed += BeginHack;
        controls.Player.Fire.canceled += OnCompleteHack;
    }

    public void BeginHack(InputAction.CallbackContext obj)
    {
        Debug.Log("Pressed");
        duration = (float)obj.duration;
    }

    public void OnCompleteHack(InputAction.CallbackContext obj)
    {
        if (obj.duration >= 2 && isMouseIn)
        {
            Debug.Log(obj.duration);
        }
    }

    private void Update()
    {
        if (isMouseIn)
        {
            duration += Time.deltaTime;
        }
        else duration = 0;
    }

    private void OnMouseDown()
    {
        isMouseIn = true;
    }

    private void OnMouseExit() =>  isMouseIn = false;
    private void OnMouseUp() =>  isMouseIn = false;
}
