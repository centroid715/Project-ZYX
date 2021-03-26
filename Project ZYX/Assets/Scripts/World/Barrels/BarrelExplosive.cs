﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosive : BarrelBaseCode
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            BarrelCollisionSound();
            DeleteBarrelModel();
            //Some kind of tank damage code here and some fire animations aswell
            if(barrelCollisionSource.isPlaying)
            {
                DeleteBarrelCompletly();
            }
        }
    }
}