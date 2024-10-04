using UnityEngine;
using UnityEngine.UIElements;

public class Collectible : MonoBehaviour
{
    private const float rotationSpeed = 50f;
    public int worth = 1;
    bool rotate = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Use Singleton instance of GameManager
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddPoint(worth);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("GameManager Instance not found!");
            }
        }
    }

    private void Update()
    {
        if (rotate) { RotateItem(); }
    }

    private void RotateItem()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}