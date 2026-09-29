using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;

    public TextMeshProUGUI countText;
    public float speed = 0;
    public GameObject winTextObject;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        AudioManager.instance.PlayMusic();
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            AudioManager.instance.PlayCoinSFX();
        }

    }
    void SetCountText()
    {
        countText.text = "Coin: " + count.ToString();
        if (count == 6)
        {
            AudioManager.instance.PlayEnemyDeathSound();
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            StartCoroutine(DeathDelay());
            Debug.Log("Enemy has died");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            Destroy(gameObject);
            // Update the winText to display "You Lose!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";

        }
    }
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(3.0f); // Wait for 3 seconds
        
        SceneManager.LoadScene(sceneName);

    }
}
