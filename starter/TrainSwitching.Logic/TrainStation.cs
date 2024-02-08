namespace TrainSwitching.Logic;

/*     public const int OPERATION_ADD = 1;
    public const int OPERATION_TRAIN_LEAVE = 0;
    public const int OPERATION_REMOVE = -1;

    public const int WAGON_TYPE_PASSENGER = 0;
    public const int WAGON_TYPE_LOCOMOTIVE = 1;
    public const int WAGON_TYPE_FREIGHT = 2;
    public const int WAGON_TYPE_CAR_TRANSPORT = 3;

    public const int DIRECTION_EAST = 0;
    public const int DIRECTION_WEST = 1; */

public class TrainStation
{
    public Track[] Tracks { get; }

    public TrainStation()
    {
        Tracks = new Track[10];

        for (var i = 0; i < Tracks.Length; i++)
        {
            Tracks[i] = new Track();
        }
    }

    /// <summary>
    /// Tries to apply the given operation to the train station.
    /// </summary>
    /// <param name="op">Operation to apply</param>
    /// <returns>Returns true if the operation could be applied, otherwise false</returns>
    public bool TryApplyOperation(SwitchingOperation op)
    {
        if (op.TrackNumber > 10 || op.TrackNumber < 1) //* Adding or removing wagons to/from tracks that do not exist.
        {
            return false;
        }

        if (op.TrackNumber > 8 && op.Direction == 0)
        {
            return false;
        }

        if (op.OperationType == 1) // ADD
        {
            if (op.Direction == 0) // East
            {
                Tracks[op.TrackNumber].Wagons.Insert(0, (int)op.WagonType!);  // East vorne adden | West hinten adden 
            }
            else
            {
                Tracks[op.TrackNumber].Wagons.Add((int)op.WagonType!);
            }
        }
        if (op.OperationType == 0) // LEAVE
        {
            var containsLocomotive = false;
            foreach (var t in Tracks[op.TrackNumber].Wagons)
            {
                if (t == 1)
                {
                    containsLocomotive = true;
                    break;
                }
            }
            if (!containsLocomotive)
            {
                return true;
            }

            if (Tracks[op.TrackNumber].Wagons.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        return true;
    }

    /// <summary>
    /// Calculates the checksum of the train station.
    /// </summary>
    /// <returns>The calculated checksum</returns>
    /// <remarks>
    /// See readme.md for details on how to calculate the checksum.
    /// </remarks>
    public int CalculateChecksum()
    {
        var totalsum = 0;
        for (var i = 0; i < Tracks.Length; i++) //foreach Track
        {
            int shortsum = 0;
            foreach (var w in Tracks[i].Wagons)
            {
                switch (w)
                {
                    case 0: // PASSENGER
                        shortsum += 1;
                        break;

                    case 1: // LOCOMOTIVE
                        shortsum += 10;
                        break;

                    case 2: // FREIGHT
                        shortsum += 20;
                        break;
                    case 3: // CAR TRANSPORT WAGON
                        shortsum += 30;
                        break;
                }
            }
            totalsum += shortsum * (i + 1);
        }
        return totalsum;
    }
}