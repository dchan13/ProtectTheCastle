﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    private Transform exitPoint;
    [SerializeField]
    private Transform[] waypoints;
    [SerializeField]
    private float navigationUpdate;
    [SerializeField]
    private int healthPoints;

    [SerializeField]
    private int rewardAmount;

    private Transform enemy;
    private float navigationTime = 0;
    private int target = 0;
    private bool isDead = false;

    private Collider2D enemyCollider;
    private Animator anim;

    // Use this for initialization
    void Start () {
        enemy = GetComponent<Transform>();
        enemyCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        GameManager.Instance.RegisterEnemy(this);
	}
	
	// Update is called once per frame
	void Update () {
		if(waypoints != null && !isDead)
        {
            navigationTime += Time.deltaTime;
            if(navigationTime > navigationUpdate)
            {
                if(target < waypoints.Length)
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, waypoints[target].position, navigationTime);
                }
                else
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, exitPoint.position, navigationTime);
                }
                navigationTime = 0;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "checkpoint")
        {
            target++;
        } else if(other.tag == "Finish")
        {
            GameManager.Instance.RoundEscaped += 1;
            GameManager.Instance.TotalEscaped += 1;
            GameManager.Instance.UnregisterEnemy(this);
            GameManager.Instance.isWaveOver();
        } else if(other.tag == "projectile")
        {
            Projectile newP = other.gameObject.GetComponent<Projectile>();
            // bug correction nullpointerexception
            if(newP != null)
            {
                enemyHit(newP.AttackStrength);
            }
            Destroy(other.gameObject);
        }
    }

    public void enemyHit(int hitPoints)
    {
        if(healthPoints - hitPoints > 0)
        {
            healthPoints -= hitPoints;
            anim.Play("Hurt");
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Hit);
        } else
        {
            anim.SetTrigger("didDie");
            die();
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Death);
        }
    }

    public void die()
    {
        isDead = true;
        enemyCollider.enabled = false;
        GameManager.Instance.TotalKilled += 1;
        GameManager.Instance.addMoney(rewardAmount);
        GameManager.Instance.isWaveOver();
    }

    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }
}
