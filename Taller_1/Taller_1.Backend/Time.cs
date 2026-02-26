namespace Taller_1.Backend;
public class Time
{
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;

    // 1. 1. No parameters
    public Time()
    {
        _hour = 0;
        _minute = 0;
        _second = 0;
        _millisecond = 0;
    }



    // 2. Just hours
    public Time(int hour)
    {
        Hour = hour;
    }

    // 3. Hours and minutes
    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;


    }


    // 4. Hours, minutes, and seconds
    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
    }

    // 5. Main builder
    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;

    }
    public int Hour
    {
        get => _hour;
        set => _hour = ValidHour(value);
    }

    public int Minute
    {
        get => _minute;
        set => _minute = ValidMinute(value);

    }

    public int Second
    {
        get => _second;
        set => _second = ValidSecond(value);
    }
    public int Millisecond

    {
        get => _millisecond;
        set => _millisecond = ValidMillisecond(value);
    }

    public override string ToString()
    {
        int displayHour = Hour % 12;
        if (displayHour == 0)
            displayHour = 12;

        string ampm = Hour < 12 ? "AM" : "PM";

        return $"{displayHour:00}:{Minute:00}:{Second:00}.{Millisecond:000} {ampm}";
    }

    public int ToMilliseconds()
    {
        return ((Hour * 60 * 60) + (Minute * 60) + Second) * 1000 + Millisecond;
    }

    public int ToSeconds()
    {
        return (Hour * 3600) + (Minute * 60) + Second;
    }

    public int ToMinutes()
    {
        return (Hour * 60) + Minute;
    }

    public bool IsOtherDay(Time other)
    {
        int totaLHours = this.Hour + other.Hour;
        if (totaLHours >= 24)
            return true;
        else
            return false;
    }

    public Time Add(Time other)
    {
        int totalMilliseconds = this.ToMilliseconds() + other.ToMilliseconds();

        int msInDay = 24 * 60 * 60 * 1000;

        totalMilliseconds = totalMilliseconds % msInDay;

        int h = totalMilliseconds / (3600 * 1000);
        totalMilliseconds %= (3600 * 1000);

        int m = totalMilliseconds / (60 * 1000);
        totalMilliseconds %= (60 * 1000);

        int s = totalMilliseconds / 1000;
        int ms = totalMilliseconds % 1000;

        return new Time(h, m, s, ms);
    }
    private int ValidHour(int hour)
    {
        if (hour < 0 || hour > 23)
            throw new ArgumentOutOfRangeException(nameof(hour), $"The hour: {hour},is not Valid");
        return hour;
    }
    private int ValidMinute(int minute)
    {
        if (minute < 0 || minute > 59)
            throw new ArgumentOutOfRangeException(nameof(minute), $"The minute: {minute},is not Valid");
        return minute;
    }
    private int ValidSecond(int second)
    {
        if (second < 0 || second > 59)
            throw new ArgumentOutOfRangeException(nameof(second), $"The second: {second},is not Valid");
        return second;
    }
    private int ValidMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
            throw new ArgumentOutOfRangeException(nameof(millisecond), $"The millisecond: {millisecond},is not Valid");
        return millisecond;
    }

}
