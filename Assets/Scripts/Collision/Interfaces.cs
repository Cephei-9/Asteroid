using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ICollisionTaker
{
    void Take();
}

enum CollisionObjects
{
    Player,
    Bullet,
    PlayerBullet,
    NLOBullet,
    Asteroid
}

interface IPlayerTaker 
{
    void Take();
}

interface INLOTaker
{
    void Take();
}

interface IBulletTaker 
{
    void Take();
}

interface IPlayerBulletTaker 
{
    void Take();
}

interface INLOBulletTaker
{
    void Take();
}

public interface IAsteroidTaker
{
    void Take();
}
