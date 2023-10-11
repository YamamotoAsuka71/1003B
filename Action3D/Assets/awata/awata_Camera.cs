
using UnityEngine;

public class awata_Camera : MonoBehaviour
{
    [SerializeField] const float SENSITIVE = 1.0f;
    [SerializeField] GameObject Player;

    Rigidbody player_rb;
    Transform player;

    float InputX;

    // Start is called before the first frame update
    void Start()
    {
        player_rb = Player.GetComponent<Rigidbody>();
        player = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        SetMovedirection(gameObject.transform);
    }

    void Rotation()
    {
        InputX = Input.GetAxis("Mouse X") * SENSITIVE;

        transform.RotateAround(player.position, player.up, InputX);
    }

    public void SetMovedirection(Transform moveObject)
    {
        Vector3 forward = gameObject.transform.forward;
        Vector3 back = -gameObject.transform.forward;
        Vector3 right = gameObject.transform.right;
        Vector3 left = -gameObject.transform.right;
        Vector3 up = gameObject.transform.up;
        Vector3 down = -gameObject.transform.up;

        if (Input.GetKey(KeyCode.W))
        {
            moveObject.position += forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveObject.position += back * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveObject.position += left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveObject.position += right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            moveObject.position += up * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveObject.position += down * Time.deltaTime;
        }
    }

    
}
