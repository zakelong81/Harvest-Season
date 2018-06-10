using UnityEngine;
using System.Collections;
using System;

public class TimeChecker : MonoBehaviour
{

    double LastTimeChecked = 0;
    double EnergyAccumulator;
    int Energy;

    const double EnergyRefillSpeed = 1 / (60 * 3);
    const int EnergyMax = 25;

    double TimeInSeconds()
    {
        DateTime epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
        double timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;

        return timestamp;
    }

    // call this whenever you can!
    void update()
    {
        double TimeNow = TimeInSeconds();
        double TimeDelta = 0;

        // if we have updated before...
        if (LastTimeChecked != 0)
        {
            // get the time difference between now and last time
            TimeDelta = TimeNow - LastTimeChecked;

            // multiply by our factor to increase energy.
            EnergyAccumulator += TimeDelta * EnergyRefillSpeed;

            // get the whole points accumulated so far
            int EnergyInt = (int)EnergyAccumulator;

            // remove the whole points we've accumulated
            if (EnergyInt > 0)
            {
                Energy += EnergyInt;
                EnergyAccumulator -= EnergyInt;
            }

            // cap at the maximum
            if (Energy > EnergyMax)
                Energy = EnergyMax;
        }

        // store the last time we checked
        LastTimeChecked = TimeNow;

    }
}
