using UnityEngine;

public class BalanceChecker : MonoBehaviour
{
    public Transform seesawPlank;
    public Transform leftSide;  // Reference to the parent transform of the left side cubes
    public Transform rightSide; // Reference to the parent transform of the right side cubes

    void Update()
    {
        float leftWeight = 0;
        float rightWeight = 0;

        // Calculate total weight on the left side
        foreach (Transform child in leftSide)
        {
            CubeValue cubeValue = child.GetComponent<CubeValue>();
            if (cubeValue != null)
            {
                leftWeight += cubeValue.value;
            }
            Debug.Log("totalleftweight===>");
            Debug.Log(leftWeight);
        }

        // Calculate total weight on the right side
        foreach (Transform child in rightSide)
        {
            CubeValue cubeValue = child.GetComponent<CubeValue>();
            if (cubeValue != null)
            {
                rightWeight += cubeValue.value;
            }
            Debug.Log("totalrightweight===>");
            Debug.Log(rightWeight);
        }

        // Check if the seesaw is balanced
        if (Mathf.Approximately(leftWeight, rightWeight))
        {
            // Debug.Log("Balanced!");
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            Debug.Log("Not Balanced!");
            if(leftWeight > rightWeight)
            {
                Debug.Log("Left side weights more");
                transform.rotation = Quaternion.Euler(0, 0, 5);
            }
            else
            {
                Debug.Log("Right side weights more");
                transform.rotation = Quaternion.Euler(0, 0, -5);
            }
        }
    }
}

// public class CubeValue : MonoBehaviour
// {
//     public float value; // The weight value of the cube
// }