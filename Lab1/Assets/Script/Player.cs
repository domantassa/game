using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{

    private float score = 0;

    private float distance = 0;

    private int enemiesPicked = 0;

    private int heartsPicked = 0;

    public int powerupsPicked = 0;

    public int secondsPassed = 0;

    public int endResultScore = 0;



    public int health;
    public int numOfHearths;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public SpriteRenderer arrow;
    public Sprite brokenArrow;
    public Sprite updatedArrow;
    public Sprite aliveArrow;


    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private TMP_Text finalText;

    [SerializeField]
    private TMP_Text finalWonText;

    [SerializeField]
    private TMP_Text countdownText;

    [SerializeField]
    GameObject target;

    [SerializeField]
    GameObject playerB;

    private float timeDelta = 0f;

    public float timeRemaining;

    private PlayerController playerController;

    private void Awake()
    {
        timeRemaining = 5;
        playerController = GetComponent<PlayerController>();
        finalText.gameObject.SetActive(false);
        finalWonText.gameObject.SetActive(false);
    }

    private void Update()
    {

        //if (started)
        //{
        //    scoreText.gameObject.SetActive(true);
        //}

        
        if(health == 1)
            arrow.sprite = brokenArrow;
        else if(health == 2)
            arrow.sprite = updatedArrow;
        else if (health == 3)
            arrow.sprite = aliveArrow;



        timeDelta += Time.deltaTime;
        RecalculateScore();

        if(health > numOfHearths)
        {
            health = numOfHearths;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearths)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

    }

    float currCountdown;
    public IEnumerator StartRoutine(float countdown)
    {
        currCountdown = countdown;
        while (currCountdown > 0)
        {
            if(currCountdown == 1)
            {
                TakeDamage();
                currCountdown = 10;
            }
            countdownText.text = $"Time left: {Math.Round(currCountdown, 0)}";
            currCountdown--;
            yield return new WaitForSeconds(1.0f);
        }
    }


    private void Start()
    {
        countdownText.gameObject.SetActive(true);
        StartCoroutine(StartRoutine(25));


    }
    public void BlueCylinder()
    {
        Time.timeScale = 0.8f;
    }

    public void RecalculateScore()
    {
        float distance2obj = Vector3.Distance(playerB.transform.position, target.transform.position);
        distance = 547 - distance2obj;
        score = (distance - 100 * enemiesPicked + 50 * heartsPicked + 50 * powerupsPicked - timeDelta * 10 + endResultScore);
        if (score < 0)
            score = 0;
        UpdateScoreText();
    }


    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {Math.Round(score,0)} points";
    }

    public void TakeDamage()
    {
        FindObjectOfType<AudioManager>().Play("EnemySound");
        health = health - 1;
        enemiesPicked += 1;

        if(health <= 0)
        {
            LoseGame();
        }
    }

    public void LoseGame()
    {
        health = 0;
        finalText.gameObject.SetActive(true);
        StopGame();
        FindObjectOfType<GameManager>().EndGame(score);

    }

    public void WinGame()
    {
        float distanceOnEnd = Vector3.Distance(playerB.transform.position, target.transform.position);
        endResultScore = (int)(500 - distanceOnEnd * 10);
        finalWonText.gameObject.SetActive(true);
        StopGame();
        FindObjectOfType<GameManager>().EndGame(score);
    }

    public void GainMovementAbilities()
    {
        playerController.changeAbilitiesState();
    }

    public void doSpaceWarp()
    {
        playerController.doSpaceWarp();
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        playerController.enabled = false;
        
    }

    public void AddLives(int value)
    {
        health += value;
        heartsPicked += 1;
    }


    
}
