using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    private Camera cam;

    public Transform leftSide;
    public Transform rightSide;

    // Define the range for left and right sides
    public Vector2 leftRangeMin = new Vector2(0, 0);
    public Vector2 leftRangeMax = new Vector2(0, 0);
    public Vector2 rightRangeMin = new Vector2(0, 0);
    public Vector2 rightRangeMax = new Vector2(0, 0);

    void Start()
    {
        // Find the LeftSide and RightSide GameObjects in the scene
        leftSide = GameObject.Find("LeftSide").transform;
        rightSide = GameObject.Find("RightSide").transform;
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        // Remove the cube from its current parent
        transform.SetParent(null);

        zCoord = cam.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetTouchWorldPos();
    }

    private Vector3 GetTouchWorldPos()
    {
        Vector3 touchPoint = Input.mousePosition;
        touchPoint.z = zCoord;
        return cam.ScreenToWorldPoint(touchPoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetTouchWorldPos() + offset;
    }

    void OnMouseUp()
    {
        // Check if the cube is within the left range
        if (IsWithinRangeLeft(transform.position, leftRangeMin, leftRangeMax))
        {
            transform.SetParent(leftSide);
        }
        // Check if the cube is within the right range
        else if (IsWithinRangeRight(transform.position, rightRangeMin, rightRangeMax))
        {
            transform.SetParent(rightSide);
        }
        else
        {
            // The cube stays in the root of the hierarchy
            transform.SetParent(null);
        }
    }

    bool IsWithinRangeLeft(Vector3 position, Vector2 rangeMin, Vector2 rangeMax)
    {
        Debug.Log("Variable x: " + position.x + ", Variable 2: " + rangeMin.x + ", Variable 3: " + rangeMax.x);
        Debug.Log(position.x <= rangeMin.x && position.x >= rangeMax.x);
        Debug.Log("Variable y: " + position.y + ", Variable 2: " + rangeMin.y + ", Variable 3: " + rangeMax.y);
        Debug.Log(position.y >= rangeMin.y && position.y <= rangeMax.y);
        return position.x <= rangeMin.x && position.x >= rangeMax.x && position.y >= rangeMin.y && position.y <= rangeMax.y;
    }

    bool IsWithinRangeRight(Vector3 position, Vector2 rangeMin, Vector2 rangeMax)
    {
        Debug.Log("Variable x: " + position.x + ", Variable 2: " + rangeMin.x + ", Variable 3: " + rangeMax.x);
        Debug.Log(position.x >= rangeMin.x && position.x <= rangeMax.x);
        Debug.Log("Variable y: " + position.y + ", Variable 2: " + rangeMin.y + ", Variable 3: " + rangeMax.y);
        Debug.Log(position.y >= rangeMin.y && position.y <= rangeMax.y);
        return position.x >= rangeMin.x && position.x <= rangeMax.x && position.y >= rangeMin.y && position.y <= rangeMax.y;
    }
}