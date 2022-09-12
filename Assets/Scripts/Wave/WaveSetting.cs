public class WaveSetting
{
    public float MinValue;
    public float MaxValue;
    public int RoundInterval;
    public float ValueIncrement;

    public WaveSetting(float minValue, float maxValue, int roundInterval, float valueIncrement)
    {
        MinValue = minValue;
        MaxValue = maxValue;
        RoundInterval = roundInterval;
        ValueIncrement = valueIncrement;
    }
}
