using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectOnClick : MonoBehaviour
{
    Camera _camera;
    [SerializeField] InputActionReference leftButton;
    [SerializeField] InputActionReference position;
    [SerializeField] InputActionReference parameters;

    [SerializeField] Canvas hideCanva1;
    [SerializeField] Canvas hideCanva2;
    [SerializeField] Canvas paramCanva;

    [SerializeField] GameObject messages;

    private void Start()
    {
        _camera = GetComponent<Camera>();

        position.action.Enable();
        parameters.action.Enable();
        parameters.action.performed += switchCanvas;
    }

    private void OnEnable()
    {
        leftButton.action.Enable();
        leftButton.action.performed += CheckMouseCollision;
    }

    private void OnDisable()
    {
        leftButton.action.performed -= CheckMouseCollision;
        leftButton.action.Disable();
    }

    void switchCanvas(InputAction.CallbackContext ctx)
    {
        hideCanva1.gameObject.SetActive(false);
        hideCanva2.gameObject.SetActive(false);
        paramCanva.gameObject.SetActive(true);

        messages.transform.Translate(-1000, 0, 0);

        leftButton.action.Disable();
    }

    public void quitParams()
    {
        leftButton.action.Enable();
    }

    void CheckMouseCollision(InputAction.CallbackContext ctx)
    {
        Vector2 mousePosition = position.action.ReadValue<Vector2>();

        Ray ray = _camera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, Mathf.Infinity);

        if (hit.collider == null)
            return;

        Debug.Log(hit.collider.gameObject.name);


        if (hit.collider.gameObject.CompareTag("Usine"))
        {
            Debug.Log("Usine");

            hit.collider.gameObject.GetComponent<AudioSource>().Play();
            hit.collider.GetComponent<LoadCanvaOnClick>().LoadCanva();

            hideCanva2.gameObject.SetActive(false);

            messages.transform.Translate(-1000, 0, 0);

            enabled = false;
        }
        else if (hit.collider.gameObject.CompareTag("Bureau"))
        {
            Debug.Log("Bureau");

            hit.collider.gameObject.GetComponent<AudioSource>().Play();
            hit.collider.GetComponent<LoadCanvaOnClick>().LoadCanva();
            
            hideCanva2.gameObject.SetActive(false);

            messages.transform.Translate(-1000, 0, 0);

            enabled = false;
        }
        else if (hit.collider.gameObject.CompareTag("Marketing"))
        {
            Debug.Log("Marketing");

            hit.collider.gameObject.GetComponent<AudioSource>().Play();
            hit.collider.GetComponent<LoadCanvaOnClick>().LoadCanva();

            hideCanva2.gameObject.SetActive(false);

            messages.transform.Translate(-1000, 0, 0);

            enabled = false;
        }
    }

    public void Untranslate()
    {
        messages.transform.Translate(1000, 0, 0);
    }
}
