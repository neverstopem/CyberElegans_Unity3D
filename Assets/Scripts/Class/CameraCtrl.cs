/* author: em
 *  email: neverstopem@gmail.com
 */

using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    float moveSpeed = 20;
    int ratio = 10;

    void Awake()
    {
        moveSpeed *= Globals.scale;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            gameObject.transform.Translate(new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * moveSpeed));
        }

        float movement = Time.deltaTime * moveSpeed * 0.01f;
        if (Input.GetKey(KeyCode.LeftShift)) movement *= ratio;
        else if (Input.GetKey(KeyCode.Space)) movement *= 0.2f;

        if (Input.GetKey(KeyCode.E)) {
            gameObject.transform.Translate(new Vector3(0, movement, 0));
        } else if (Input.GetKey(KeyCode.Q)) {
            gameObject.transform.Translate(new Vector3(0, -movement, 0));
        }

        if (Input.GetKey(KeyCode.W)) {
            gameObject.transform.Translate(new Vector3(0, 0, movement));
        } else if (Input.GetKey(KeyCode.S)) {
            gameObject.transform.Translate(new Vector3(0, 0, -movement));
        }

        if (Input.GetKey(KeyCode.A)) {
            gameObject.transform.Translate(new Vector3(-movement, 0, 0));
        } else if (Input.GetKey(KeyCode.D)) {
            gameObject.transform.Translate(new Vector3(movement, 0, 0));
        }

        if (Input.GetKey(KeyCode.Mouse1)) {
            float CameraX = Input.GetAxis("Mouse X");
            float CameraY = Input.GetAxis("Mouse Y");
            Vector3 Angle = new Vector3(CameraY * 2, -CameraX * 2, 0);
            transform.eulerAngles -= Angle;
        }
    }
}
