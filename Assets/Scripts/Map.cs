using UnityEngine;


public class Map : MonoBehaviour
{

    private Square[,] grid;
    public Square this[int a, int b]
    {
        get { return grid[a, b]; }
    }

    private GameObject prefab;

    private static int width = 40;
    public static int Width
    {
        get { return width; }
    }

    private static int length = 40;
    public static int Length
    {

        get { return length; }
    }

    void Awake()
    {
        grid = new Square[width, length];
        prefab = Resources.Load<GameObject>("Square");
    }

    
    void Start()
    {

        CreateGrid();
      
    }

    private void CreateGrid()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                GameObject squareObject = Instantiate(prefab, new Vector3(i, 0.0F, j), Quaternion.identity) as GameObject;
                Square square = squareObject.GetComponent<Square>();
                square.X = i;
                square.Z = j;
                grid[i, j] = square;
                squareObject.transform.SetParent(transform);
            }

        }
    }    
}
