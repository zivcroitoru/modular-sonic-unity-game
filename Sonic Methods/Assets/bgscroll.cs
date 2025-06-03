using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    public Transform[] tiles;
    public float viewZone = 10f;
    public float scrollSpeed = 0.5f;

    private int leftIndex;
    private int rightIndex;
    private float tileWidth;

    void Start()
    {
        tileWidth = tiles[0].GetComponent<SpriteRenderer>().bounds.size.x;
        leftIndex = 0;
        rightIndex = tiles.Length - 1;
    }

    void Update()
    {
        float camX = Camera.main.transform.position.x;

        if (camX < tiles[leftIndex].position.x + viewZone)
            ScrollLeft();
        if (camX > tiles[rightIndex].position.x - viewZone)
            ScrollRight();
    }

    void ScrollLeft()
    {
        tiles[rightIndex].position = new Vector3(
            tiles[leftIndex].position.x - tileWidth,
            tiles[leftIndex].position.y,
            tiles[leftIndex].position.z
        );

        rightIndex = leftIndex;
        leftIndex = (leftIndex - 1 + tiles.Length) % tiles.Length;
    }

    void ScrollRight()
    {
        tiles[leftIndex].position = new Vector3(
            tiles[rightIndex].position.x + tileWidth,
            tiles[rightIndex].position.y,
            tiles[rightIndex].position.z
        );

        leftIndex = rightIndex;
        rightIndex = (rightIndex + 1) % tiles.Length;
    }
}
