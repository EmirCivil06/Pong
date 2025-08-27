using UnityEngine;
using UnityEngine.InputSystem;

// Script to handle player movement. Takes input from Input System and moves player accordingly.
public class _Player1Movement : MonoBehaviour
{
    // Fields for script
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float moveSpeed;
    private Vector2 _moveDirection;
    [SerializeField] private InputActionReference moveAction, quitAction;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Renderer Renderer;


    // FixedUpdate for updating physics
    void FixedUpdate()
    {
        rigidBody.linearVelocity = new Vector2(0, _moveDirection.y * moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = moveAction.action.ReadValue<Vector2>();
        if (quitAction.action.WasPressedThisFrame())
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
    }

    // LateUpdate to clamp player within camera bounds after all updates
    void LateUpdate()
    {
        float vert = mainCamera.orthographicSize;
        float horiz = vert * mainCamera.aspect;
        Vector3 camPos = mainCamera.transform.position;
        Vector3 ext = Renderer.bounds.extents;

        Vector3 p = transform.position;
        p.x = Mathf.Clamp(p.x, camPos.x - horiz + ext.x, camPos.x + horiz - ext.x);
        p.y = Mathf.Clamp(p.y, camPos.y - vert + ext.y, camPos.y + vert - ext.y);
        transform.position = p;
    }

}
