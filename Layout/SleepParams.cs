using System.Collections.Generic;

public class SleepParameters
{
    public int CycleMinutes { get; set; }
    public double RemPct { get; set; }
    public double DeepPct { get; set; }
    public double RecommendedMinHours { get; set; }
    public double RecommendedMaxHours { get; set; }


    // Convenience access
    public static SleepParameters GetForAge(int age)
    {
        // Define age buckets. These values are conservative defaults; you can replace them with research-sourced numbers.
        var buckets = new List<(int Min, int Max, int Cycle, double Rem, double Deep, double MinH, double MaxH)>
                    {
                        (0, 1, 50, 0.50, 0.15, 14, 17), // infants
                        (2, 5, 60, 0.30, 0.20, 11, 14), // toddlers / preschool
                        (6, 12, 75, 0.25, 0.20, 9, 12), // children
                        (13, 17, 85, 0.25, 0.18, 8, 10), // teens
                        (18, 64, 90, 0.25, 0.18, 7, 9), // adults
                        (65, 120, 90, 0.20, 0.12, 7, 8) // older adults
                    };


        foreach (var b in buckets)
        {
            if (age >= b.Min && age <= b.Max)
            {
                return new SleepParameters
                {
                    CycleMinutes = b.Cycle,
                    RemPct = b.Rem,
                    DeepPct = b.Deep,
                    RecommendedMinHours = b.MinH,
                    RecommendedMaxHours = b.MaxH
                };
            }
        }

        return new SleepParameters
        {
            CycleMinutes = 90,
            RemPct = 0.25,
            DeepPct = 0.18,
            RecommendedMinHours = 7,
            RecommendedMaxHours = 9
        };
    }
}