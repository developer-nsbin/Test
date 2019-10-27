using UnityEngine;

public class Bricks : MonoBehaviour
{
    public float rotateSpeed;

    private void Awake()
    {
        RandomColor();
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)) * rotateSpeed *
                         Time.deltaTime);
    }

    private void RandomColor()
    {
        float red = Random.Range(0, 1f);
        float green = Random.Range(0, 1f);
        float blue = Random.Range(0, 1f);
        GetComponent<Renderer>().material.color = new Color(red, green, blue);
    }
}
