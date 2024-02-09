namespace TrainSwitching.Logic;

public static class SwitchingOperationParser
{
    /// <summary>
    /// Parses a line of input into a <see cref="SwitchingOperation"/>.
    /// </summary>
    /// <param name="inputLine">Line to parse. See readme.md for details</param>
    /// <returns>The parsed switching operation</returns>
    public static SwitchingOperation Parse(string inputLine)
    {
        SwitchingOperation mySwitch = new SwitchingOperation();

        var splittedString = inputLine.Split(' ');
        mySwitch.TrackNumber = int.Parse(splittedString[2].Remove(splittedString[2].Length - 1));


        if (inputLine.Contains("add"))
        {
            mySwitch.OperationType = 1;
        }
        else if (inputLine.Contains("remove"))
        {
            mySwitch.OperationType = -1;
        }
        else if (inputLine.Contains("train leaves"))
        {
            mySwitch.OperationType = 0;
        }

        if (inputLine.Contains("West"))
        {
            mySwitch.Direction = 1;
        }
        else if (inputLine.Contains("East"))
        {
            mySwitch.Direction = 0;
        }


        if (inputLine.Contains("Passenger Wagon"))
        {
            mySwitch.WagonType = 0;
        }
        else if (inputLine.Contains("Locomotive"))
        {
            mySwitch.WagonType = 1;
        }
        else if (inputLine.Contains("Freight Wagon"))
        {
            mySwitch.WagonType = 2;
        }
        else if (inputLine.Contains("Car Transport Wagon"))
        {
            mySwitch.WagonType = 3;
        }
        else
        {
            mySwitch.WagonType = null;
        }

        var halfText = inputLine.Split(", ");
        var newString = halfText[1].Split(' ');
        if (int.TryParse(newString[1], out int myNum))
        {
            mySwitch.NumberOfWagons = myNum;
        }
        else
        {
            mySwitch.NumberOfWagons = null;
        }

        return mySwitch;
    }
}


