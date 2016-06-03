using UnityEngine;


public class CameraController : MonoBehaviour {

    private Transform node;
    new private Transform camera;
    [SerializeField]
    private float speed = 0.3F;
    [SerializeField]
    private float rotationSpeed = 2F;

	
	void Start ()
    {

        node = transform.GetChild(0);               
     
	}
	
	
	void Update ()
    {
        ChekMouse();
        ChekScroll();
        HorizontalCamLimit();
        VerticalCamLimit();

    }

    private void ChekMouse()
    {
        if (Input.mousePosition.x < Screen.width / 20)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position - transform.right, speed);
        }

        if (Input.mousePosition.x > Screen.width - Screen.width / 20)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.right, speed);
        }

        if (Input.mousePosition.y < Screen.height / 20)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position - transform.forward, speed);
        }

        if (Input.mousePosition.y > Screen.height - Screen.height / 20)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, speed);
        }

    }

    private void ChekScroll()
    {
        if (Input.mouseScrollDelta.y == 1)
        {
            node.Rotate(Vector3.left * rotationSpeed);                
        }

        if (Input.mouseScrollDelta.y == -1)
        {
            node.Rotate(Vector3.right * rotationSpeed);
        }        
    }

    private void HorizontalCamLimit()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 5, Map.Width-4), 0, Mathf.Clamp(transform.position.z, 5, Map.Length-4));
        
    }

    private void VerticalCamLimit()
    {
        node.eulerAngles = new Vector3(Mathf.Clamp(node.eulerAngles.x, 15, 70), 45, 0);
    }
}
