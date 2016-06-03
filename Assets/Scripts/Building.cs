using UnityEngine;


public class Building : MonoBehaviour
{

    [SerializeField]
    private uint width; //in squares
    public uint Width { get { return width; } }

    [SerializeField]
    private uint length;
    public uint Length { get { return width; } }


    public void OnPlaced()
    {
        GetComponent<Collider>().enabled = true;
    }
}
