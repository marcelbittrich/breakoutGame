using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockGrid : MonoBehaviour
{
    public float maxBlockWidth = 1.0f;
    public float maxBlockHeight = 0.5f;
    public float xMargin = 0.1f;
    public float yMargin = 0.1f;

    public Obstacle obstaclePrefab;

    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        width = transform.localScale.x;
        height = transform.localScale.y;

        CalculateBlockContent();
    }

    void CalculateBlockContent() 
    {
        int cntX = (int) (width / maxBlockWidth);
        int cntY = (int) (height / maxBlockHeight);

        Debug.Log(cntX.ToString()+ " " + cntY.ToString());

        float obstacleWidth = (width - (cntX - 1) * xMargin) / cntX;
        float obstacleHeight = (height - (cntY - 1) * yMargin) / cntY;

        Debug.Log(width.ToString() + " " + obstacleWidth.ToString());

        for (int i = 0; i < cntX; i++)
        {
            for (int j = 0; j < cntY; j++)
            {
                float obstaclePosX = transform.position.x - width / 2 + (i * (xMargin + obstacleWidth)) + obstacleWidth / 2;
                float obstaclePosY = transform.position.y - height / 2 + (j * (yMargin + obstacleHeight)) + obstacleHeight / 2;

                Obstacle obstacle = Instantiate<Obstacle>(obstaclePrefab, new Vector3(obstaclePosX, obstaclePosY, 10), Quaternion.identity);
                obstacle.transform.localScale = new Vector2(obstacleWidth, obstacleHeight);
            }
        }
    }
}
