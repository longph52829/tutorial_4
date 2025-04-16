using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class test_score : MonoBehaviour
{
    public Text scoreText;
    public int score, current_hp = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScoretext(int scorez)
    {
        score += scorez;
        scoreText.text = $"Score: {score}";
    }
    
    public void Decreasetext(int scorez)
    {
        score -= scorez;
        scoreText.text = $"Score: {score}";
    }
    
    public void double_scoretext(int scorez)
    {
        score += scorez * scorez;
        scoreText.text = $"Score: {score}";
    }

    public void addScore(int scorez)
    {
        score += scorez;
    }
    
    public void decrease(int scorez)
    {
        score -= scorez;
    }
    
    public void double_score(int scorez)
    {
        score += scorez * scorez;
    }

    public void die()
    {
        Destroy(gameObject);
    }
    
    void takeDamage(int damage)
    {
        current_hp -= damage;
        
        if (current_hp <= 0)
        {
            current_hp = 0;
            die();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("quai"))
        {
            takeDamage(50);
        }
    }
}
