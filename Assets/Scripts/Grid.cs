using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{

    [HideInInspector]
    private float gridSpring = 0.02F;
    private RawImage grid;
    Button myButton;


    void Start()
    {
        transform.localScale = new Vector2(Map.Width, Map.Length);
        transform.position = new Vector3(Map.Width / 2F - 0.5F, gridSpring, Map.Length / 2F - 0.5F);
        grid = transform.GetChild(0).GetComponent<RawImage>();
        grid.uvRect = new Rect(Vector2.zero, new Vector2(Map.Width, Map.Length));
    }

    public void GridButton()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
