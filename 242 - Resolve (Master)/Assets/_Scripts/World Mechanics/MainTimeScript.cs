using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/// By: Tobias Johansson & Brandon Transue
/// Contact: tobias@johansson-tobias.com
/// Portfolio: http://www.johansson-tobias.com

/// This is the main script for our Time of Day system. This handles the time and the updating of the sun. 
public class MainTimeScript : MonoBehaviour
{
    /********** ----- VARIABLES ----- **********/

    /// Does the user want to use a moon? 
    [SerializeField]
    private bool _bUseMoon = true;

    /// This is used to check if the user want to use weather effects or only the time of day
    /// *Use \link GetSet_bUseWeather \endlink if you want to change it during runtime.
    [SerializeField]
    private bool _bUseWeather = true;

    /// This is where the user sets how long a full 24 _fCurrentHour day should be in seconds.
    /// *Use \link GetSet_bUseWeather \endlink if you want to change it during runtime.
    [SerializeField]
    private float _fSecondInAFullDay = 60.0f;

    /// With this it is possible to change the speed for the time of day system. *This is only used for debuggning at the moment.\n
    /// *Use \link GetSet_fTimeMultiplier \endlink if you want to access or change this from another script.
    [SerializeField]
    public float _fTimeMultiplier = 1.0f;

    /// A day in the game goes from 0 to 1.\n
    /// *Use \link Get_fCurrentTimeOfDay \endlink if you want to see the current value of this.
    [SerializeField, Range(0, 1)]
    public float _fCurrentTimeOfDay;

    /// We use this CONST to re-count \link _fCurrentTimeOfDay \endlink to hours so it's easier for designer to set when they want the game and such in hours instead of in %. 
    private const float ONEHOURLENGTH = 1.0f / 24.0f;

    /// This is the INT we use so the designer can set the games starting time in hours from the editor\n
    /// *Use \link GetSet_iStartHour \endlink if you want to access or change this from another script.\n
    /// **This is only called once in the Start() so the game knows which time it should start at.
    [SerializeField]
    private int _iStartHour;

    private float _fStartingHour;

    /// This is the INT we use so the designer can set at which _fCurrentHour they want SUNRISE to start\n
    /// *Use \link GetSet_iSunriseStart \endlink if you want to access or change this from another script or during runtime.
    [SerializeField]
    private int _iSunriseStart;

    /// This is the INT we use so the designer can set at which _fCurrentHour they want DAY to start\n
    /// *Use \link GetSet_iDayStart \endlink if you want to access or change this from another script or during runtime.
    [SerializeField]
    private int _iDayStart;

    /// This is the INT we use so the designer can set at which _fCurrentHour they want SUNSET to start\n
    /// *Use \link GetSet_iSunsetStart \endlink if you want to access or change this from another script or during runtime.
    [SerializeField]
    private int _iSunsetStart;

    /// This is the INT we use so the designer can set at which _fCurrentHour they want NIGHT to start\n
    /// *Use \link GetSet_iNightStart \endlink if you want to access or change this from another script or during runtime.
    [SerializeField]
    private int _iNightStart;

    /// We use this varible to re-count the choosen _fCurrentHour into %
    private float _fStartingSunrise;

    /// We use this varible to re-count the choosen _fCurrentHour into %
    private float _fStartingDay;

    /// We use this varible to re-count the choosen _fCurrentHour into %
    private float _fStartingSunset;

    /// We use this varible to re-count the choosen _fCurrentHour into %
    private float _fStartingNight;

    /// I re-count \link Get_fCurrentTimeOfDay \endlink to hours and have \link Get_fCurrentHour \endlink to show it for when we debug the time of day. 
    public float _fCurrentHour;

    /// I re-count \link Get_fCurrentTimeOfDay \endlink to minutes and have \link _fCurrentMinute \endlink to show it for when we debug the time of day. 
    public float _fCurrentMinute;

    /// This is an INT we use to count how many game days the game has been played since the start.\n
    /// *This is at the moment set to 0 in Start(). If you want to save this for future reference this need to be moved as it will be re-set everytime the game starts otherwise.\n
    /// *Use \link Get_iAmountOfDaysPlayed \endlink if you want to see the current value of this.
    private int _iAmountOfDaysPlayed;

    /// This needs to be a directional light so we have a light that covers the whole world. 
    public Light lSun;

    /// This needs to be a directional light so we have a light that covers the whole world. 
    public Light lMoon;

    /// We use this to control Sunrise, Day, Sunset and Night
    public enum Timeset
    {
        SUNRISE,
        DAY,
        SUNSET,
        NIGHT
    };

    [HideInInspector]
    public Timeset enCurrTimeset;

    /********** ----- GETTERS AND SETTERS ----- **********/

    public float Get_fCurrentTimeOfDay { get { return _fCurrentTimeOfDay; } }
    public float Get_fCurrentHour { get { return _fCurrentHour; } }
    public float Get_fCurrentMinute { get { return _fCurrentMinute; } }
    public int Get_iAmountOfDaysPlayed { get { return _iAmountOfDaysPlayed; } }

    public bool GetSet_bUseMoon
    {
        get { return _bUseMoon; }
        set { _bUseMoon = value; }
    }
    public float GetSet_fSecondInAFullDay
    {
        get { return _fSecondInAFullDay; }
        set { _fSecondInAFullDay = value; }
    }

    public float GetSet_fTimeMultiplier
    {
        get { return _fTimeMultiplier; }
        set { _fTimeMultiplier = value; }
    }

    public int GetSet_iStartHour
    {
        get { return _iStartHour; }
        set { _iStartHour = value; }
    }

    public int GetSet_iSunriseStart
    {
        get { return _iSunriseStart; }
        set { _iSunriseStart = value; }
    }

    public int GetSet_iDayStart
    {
        get { return _iDayStart; }
        set { _iDayStart = value; }
    }


    public int GetSet_iSunsetStart
    {
        get { return _iSunsetStart; }
        set { _iSunsetStart = value; }
    }


    public int GetSet_iNightStart
    {
        get { return _iNightStart; }
        set { _iNightStart = value; }
    }

    public Color Sunset;
    public Color Night;
    public Color Sunrise;
    public Color Day;
    
    /// Unity function - See Unity documentation
    void Start()
    {
        _fStartingHour = ONEHOURLENGTH * (float)_iStartHour;
        _fCurrentTimeOfDay = _fStartingHour;

        _fStartingSunrise = ONEHOURLENGTH * (float)_iSunriseStart;
        _fStartingDay = ONEHOURLENGTH * (float)_iDayStart;
        _fStartingSunset = ONEHOURLENGTH * (float)_iSunsetStart;
        _fStartingNight = ONEHOURLENGTH * (float)_iNightStart;

        _iAmountOfDaysPlayed = 0;
        _fCurrentHour = 0.0f;
        _fCurrentMinute = 0.0f;
    }

    /// Unity function - See Unity documentation
    void Update()
    {
        UpdateSunAndMoon();
        UpdateTimeset();
        
        // Controls the speed of our "clock"
        _fCurrentTimeOfDay += (Time.deltaTime / _fSecondInAFullDay) * _fTimeMultiplier;

        // Digital time
        _fCurrentHour = 24 * _fCurrentTimeOfDay;
        _fCurrentMinute = 60 * (_fCurrentHour - Mathf.Floor(_fCurrentHour));

        // resets our time of day to 0 + adds a day to our amount of days played
        if (_fCurrentTimeOfDay >= 1.0f)
        {
            _fCurrentTimeOfDay = 0.0f;
            _iAmountOfDaysPlayed += 1;
        }
    }

    /// This is used inside Unitys Update() to update our SUN and MOON (if you have the MOON turned on). 
    void UpdateSunAndMoon()
    {
        // This rotates the sun 360 degree in X-axis according to our current time of day.
        lSun.transform.localRotation = Quaternion.Euler((_fCurrentTimeOfDay * 360) - 90, 170, 0);

        if (_bUseMoon == true)
            lMoon.transform.localRotation = Quaternion.Euler((_fCurrentTimeOfDay * 360) - 270, 170, 0);
    }

    /// Updates Timeset to match time of day.
    void UpdateTimeset()
    {
        if (_fCurrentTimeOfDay >= _fStartingSunrise && _fCurrentTimeOfDay <= _fStartingDay && enCurrTimeset != Timeset.SUNRISE)
        {
            SetCurrentTimeset(Timeset.SUNRISE);
            Debug.Log("Sunrise");
            SetSunriseColors();
        }
        else if (_fCurrentTimeOfDay >= _fStartingDay && _fCurrentTimeOfDay <= _fStartingSunset && enCurrTimeset != Timeset.DAY)
        {
            SetCurrentTimeset(Timeset.DAY);
            Debug.Log("Day");
            SetDayColors();
        }
        else if (_fCurrentTimeOfDay >= _fStartingSunset && _fCurrentTimeOfDay <= _fStartingNight && enCurrTimeset != Timeset.SUNSET)
        {
            SetCurrentTimeset(Timeset.SUNSET);
            Debug.Log("Sunset");
            SetSunsetColors();
        }
        else if (_fCurrentTimeOfDay >= _fStartingNight || _fCurrentTimeOfDay <= _fStartingSunrise && enCurrTimeset != Timeset.NIGHT)
        {
            SetCurrentTimeset(Timeset.NIGHT);
            Debug.Log("Night");
            SetNightColors();
        }
    }

    void SetCurrentTimeset(Timeset currentTime)
    {
        enCurrTimeset = currentTime;
    }

    void SetSunriseColors()
    {
        RenderSettings.ambientLight = Color.Lerp(Night, Sunrise, Time.timeScale);
        lSun.intensity = 0.5f;
    }
    void SetDayColors()
    {
        RenderSettings.ambientLight = Color.Lerp(Sunrise, Day, Time.timeScale);
        lSun.intensity = 1f;
    }
    void SetSunsetColors()
    {
        RenderSettings.ambientLight = Color.Lerp(Day, Sunset, Time.timeScale);
        lSun.intensity = 0.5f;
    }
    void SetNightColors()
    {
        RenderSettings.ambientLight = Color.Lerp(Sunset, Night, Time.timeScale);
        lSun.intensity = 0f;
    }
}
