﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tank))]
public class TankAudio : MonoBehaviour
{
    #region knas
    private Tank TankScript
    {
        get { return m_TankScript ? m_TankScript : m_TankScript = GetComponent<Tank>(); }
        set { m_TankScript = value;}
    }
    private Tank m_TankScript = null;
    #endregion


    #region Sounds
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
    private AudioEvent engineStartup;
    [SerializeField] private AudioSource engineStartupSource;

    private AudioEvent engineIdle;
    [SerializeField] private AudioSource engineIdleSource;

    private AudioEvent engineThrottle;
    [SerializeField] private AudioSource engineThrottleSource;

    private AudioEvent engineRevLOW;
    private AudioEvent engineRevMID;
    private AudioEvent engineRevHIGH;
    [SerializeField] private AudioSource engineRevSource;

    [Header("Tank Turret Audio")]
    [SerializeField] private AudioEvent spinStart;
    [SerializeField] private AudioSource spinStartSource;

    [SerializeField] private AudioEvent spinLoop;
    [SerializeField] private AudioSource spinLoopSource;

    [SerializeField] private AudioEvent spinStop;
    [SerializeField] private AudioSource spinStopSource;

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

    [Header("Tank Explosion")]
    [SerializeField] private AudioEvent tankEXPLSFX;
    [SerializeField] private AudioSource tankEXPLSource;

    private float velocityScaleAUDIO;
    #endregion

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
        engineRevLOW.Play(engineRevSource);
    }
    public void EngineRevMid()
    {
        engineRevSource.Stop();
        engineRevMID.Play(engineRevSource);
    }
    public void EngineRevHigh()
    {
        engineRevSource.Stop();
        engineRevHIGH.Play(engineRevSource);
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
    public void TankEXPLSfx()
    {
        tankEXPLSFX.Play(tankEXPLSource);
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
        engineIdle = TankScript.TankAsset.AudioIdle;
        engineStartup = TankScript.TankAsset.AudioIdle;
        engineThrottle = TankScript.TankAsset.AudioThrottle;

        engineRevLOW = TankScript.TankAsset.AudioRevLow;
        engineRevMID = TankScript.TankAsset.AudioRevMid;
        engineRevHIGH = TankScript.TankAsset.AudioRevHigh;
    }
}
