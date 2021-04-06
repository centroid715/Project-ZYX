﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tank))]
public class TankAudio : MonoBehaviour
{
    private Tank TankScript = null;



    [Tooltip("Sync the ‟play engine sounds‟ function with the start up sound")]
    [Header("Engine Start Up Time (In seconds)")]
    [SerializeField] private float engineStartUpTime;

    [Header("Engine Sounds Values")]
    [SerializeField] float idleVolumeMin;
    [SerializeField] float idleVolumeMax;
    [SerializeField] float throttlePitchMin;
    public float throttlePitchMax;
    [SerializeField] float throttleVolumeMin;
    [SerializeField] float throttleVolumeMax;

    [Header("Tank Movement Audio")]
    [SerializeField] private AudioEvent engineStartup;
    [SerializeField] private AudioSource engineStartupSource;

    [SerializeField] private AudioEvent engineIdle;
    [SerializeField] private AudioSource engineIdleSource;

    [SerializeField] private AudioEvent engineThrottle;
    [SerializeField] private AudioSource engineThrottleSource;

    [SerializeField] private AudioEvent[] engineRev;
    [SerializeField] private AudioSource engineRevSource;

    [Header("Tank Turret Audio")]
    [SerializeField] private AudioEvent spinStart;
    [SerializeField] private AudioSource spinStartSource;

    [SerializeField] private AudioEvent spinLoop;
    [SerializeField] private AudioSource spinLoopSource;

    [SerializeField] private AudioEvent spinStop;
    [SerializeField] private AudioSource spinStopSource;

    [Header("Tank Barrel Audio")]
    [SerializeField] private AudioEvent barrelLoop;
    [SerializeField] private AudioSource barrelLoopSource;

    [SerializeField] private AudioEvent barrelStuckStart;
    [SerializeField] private AudioSource barrelStuckStartSource;

    [SerializeField] private AudioEvent barrelStuckLoop;
    [SerializeField] private AudioSource barrelStuckLoopSource;

    [Header("Tank Shoot Audio")]
    [SerializeField] private AudioEvent cannonBlast;
    [SerializeField] private AudioSource cannonBlastsource;

    [Header("Powerups")]
    [SerializeField] private AudioEvent PURepairSfx;
    [SerializeField] private AudioSource PURepairSource;

    [Header("Speed Boost")]
    [SerializeField] private AudioEvent PUSpeedBoostStartSfx;
    [SerializeField] private AudioSource PUSpeedBoostStartSource;
    [SerializeField] private AudioEvent PUSpeedBoostLoopSfx;
    [SerializeField] private AudioSource PUSpeedBoostLoopSource;
    [SerializeField] private AudioEvent PUSpeedBoostEndSfx;
    [SerializeField] private AudioSource PUSpeedBoostEndSource;


    private float velocityScaleAUDIO;
    private void Awake()
    {
        // 1. GET REFERENCES
        TankScript = GetComponent<Tank>();

        // 2. EVENT SUBSCRIPTION
        Tank.OnTankFire += tank => 
        {
            if (tank != TankScript) return;
            CannonFire();
        };
    }





    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public IEnumerator EngineStartUpSound()
    {
        engineStartup.Play(engineStartupSource);

        yield return new WaitForSeconds(engineStartUpTime * Time.deltaTime);

        engineIdle.Play(engineIdleSource);
        engineThrottle.Play(engineThrottleSource);
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public void EngineSounds(float velocityScale)
    {
        velocityScaleAUDIO = velocityScale;
        engineIdleSource.volume = Mathf.Lerp(idleVolumeMax, idleVolumeMin, velocityScale);
        engineThrottleSource.pitch = Mathf.Lerp(throttlePitchMin, throttlePitchMax, velocityScale);
        engineThrottleSource.volume = Mathf.Lerp(throttleVolumeMin, throttleVolumeMax, velocityScale);
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public void EngineRevLow()
    {
        engineRevSource.Stop();
        engineRev[0].Play(engineRevSource);
    }
    public void EngineRevMid()
    {
        engineRevSource.Stop();
        engineRev[1].Play(engineRevSource);
    }
    public void EngineRevHigh()
    {
        engineRevSource.Stop();
        engineRev[2].Play(engineRevSource);
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public void TurretSoundPlay()
    {
        spinStart.Play(spinStartSource);
        spinLoop.Play(spinLoopSource);
    }
    public void TurretSoundStop()
    {
        spinLoopSource.Stop();
        spinStop.Play(spinStopSource);
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    /*public void BarrelSoundPlay()
    {
        spinStart.Play(spinStartSource);
        barrelLoop.Play(barrelLoopSource);
    }*/
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    /*public void BarrelStuckPlay()
    {
        barrelLoopSource.Stop();
        barrelStuckStart.Play(barrelStuckStartSource);
        barrelStuckLoop.Play(barrelStuckLoopSource);
    }*/
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public void BarrelSoundStop()
    {
        barrelLoopSource.Stop();
        barrelStuckLoopSource.Stop();
        spinStop.Play(spinStopSource);
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public void CannonFire()
    {
        cannonBlast.Play(cannonBlastsource);
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public void PickupHPSound()
    {
        PURepairSfx.Play(PURepairSource);
    }
    public void PickupSpeedBoostSTARTSound()
    {
        PUSpeedBoostStartSfx.Play(PUSpeedBoostStartSource);
        PUSpeedBoostLoopSfx.Play(PUSpeedBoostLoopSource);
    }
    public void PickupSpeedBoostLOOPSound()
    {
        PUSpeedBoostLoopSource.volume = Mathf.Lerp(throttleVolumeMin, throttleVolumeMax*2, velocityScaleAUDIO);
    }
    public void PickupSpeedBoostENDSound()
    {
        PUSpeedBoostLoopSource.Stop();
        PUSpeedBoostEndSfx.Play(PUSpeedBoostEndSource);
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public void OnLoadStats(TankRef i)
    {
        
    }
}
