using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float scaleSpeed;
    public GameObject destroyEffect;

    private void Awake()
    {
        RandomColor();
        Invoke("DestroySelf",2);
    }

    private void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
        ChangeScale();
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bricks")
        {
            Instantiate(destroyEffect, collision.transform.position, Quaternion.identity);

            AudioManager.Instance.PlayEffectMusic(AudioManager.Instance.destroyClip);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);

        }
    }

    private void RandomColor()
    {
        float red = Random.Range(0, 1f);
        float green = Random.Range(0, 1f);
        float blue = Random.Range(0, 1f);
        GetComponent<Renderer>().material.color = new Color(red, green, blue);
    }

    private void ChangeScale()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.2f,0.2f,0.2f), Time.deltaTime*scaleSpeed);
    }

    private void DestroySelf()
    {
        Destroy(gameObject, 2);
    }

}
