using UnityEngine;

public class CameraControlExam06 : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float offset;
    private float cameraBound;
    public Camera targetCamera;

    // Update is called once per frame
    private void Start()
    {
 
    }
    void LateUpdate()
    {
        Vector3 player1Pos = player1.transform.position;
        Vector3 player2Pos = player2.transform.position;

        targetCamera.transform.position = new Vector3 (player1Pos.x, targetCamera.transform.position.y, player2Pos.z);
        float cameraOffsetZ = (player2Pos.z - player1Pos.z) * offset;
        float cameraOffsetX = (player1Pos.x - player2Pos.x) * offset;
       
        targetCamera.orthographicSize = Mathf.Max(Mathf.Abs(cameraOffsetX), Mathf.Abs(cameraOffsetZ));

        //targetCamera.orthographicSize = player2Pos.z + offset;
        // Student code ...
    }
}
