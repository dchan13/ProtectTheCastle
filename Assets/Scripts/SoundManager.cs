﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager> {

    [SerializeField]
    private AudioClip rock;
    [SerializeField]
    private AudioClip arrow;
    [SerializeField]
    private AudioClip fireball;
    [SerializeField]
    private AudioClip hit;
    [SerializeField]
    private AudioClip death;
    [SerializeField]
    private AudioClip gameover;
    [SerializeField]
    private AudioClip level;
    [SerializeField]
    private AudioClip newGame;
    [SerializeField]
    private AudioClip towerBuilt;

    public AudioClip Rock
    {
        get
        {
            return rock;
        }
    }

    public AudioClip Arrow
    {
        get
        {
            return arrow;
        }
    }

    public AudioClip Fireball
    {
        get
        {
            return fireball;
        }
    }

    public AudioClip Hit
    {
        get
        {
            return hit;
        }
    }

    public AudioClip Death
    {
        get
        {
            return death;
        }
    }

    public AudioClip Gameover
    {
        get
        {
            return gameover;
        }
    }

    public AudioClip Level
    {
        get
        {
            return level;
        }
    }

    public AudioClip NewGame
    {
        get
        {
            return newGame;
        }
    }

    public AudioClip TowerBuilt
    {
        get
        {
            return towerBuilt;
        }
    }
}
