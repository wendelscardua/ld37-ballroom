using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text scoreText;
    public GameObject[] ballPrefabs;
    public GameObject spawnPoint;
    public float spawnTime = 10.0f;
    public float victoryCooldown = 20.0f;
    private float spawnCooldown = 10.0f;
    private int balls = 5;

    // Use this for initialization
    void Start() {
        UpdateScore();
    }

    // Update is called once per frame
    void Update() {
        if (balls > 0)
        {
            spawnCooldown -= Time.deltaTime;
            if (spawnCooldown <= 0.0f)
            {
                SpawnBall();
                spawnCooldown = spawnTime;
            }
        } else
        {
            victoryCooldown -= Time.deltaTime;
            if (victoryCooldown <= 0.0f)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
            }
        }
        UpdateScore();
    }

    public void SpawnBall()
    {
        GameObject prefab = ballPrefabs[Random.Range(0, ballPrefabs.Length)];
        GameObject ball = Instantiate(prefab, spawnPoint.transform.position, Random.rotationUniform);
        ball.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * Random.Range(0.0f, 10.0f), ForceMode.Impulse);
        balls += 1;
    }

    public void BallDestroyed()
    {
        balls -= 1;
    }

    public int BallCount()
    {
        return balls;
    }

    void UpdateScore()
    {
        if (balls == 1)
            scoreText.text = "Throw that one last ball in the trash and the curse will be over";
        else if (balls > 1)
            scoreText.text = "Throw these " + balls + " balls in the trash and the curse will be over";
        else
            scoreText.text = "You are finally free from the curse!\nThe Ballroom Witch should release you any time now...";
    }
}
