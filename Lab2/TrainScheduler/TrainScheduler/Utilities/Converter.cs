namespace TrainScheduler.Utilities;

public static class Converter
{
    public static TimeSpan ConvertStringToTimeSpan(string timeString)
    {
        TimeSpan result;
        string[] timeStringParts = timeString.Split(':');

        if (timeStringParts.Length != 2 || !int.TryParse(timeStringParts[0], out _) || !int.TryParse(timeStringParts[1], out _))
            throw new ArgumentException("Incorrect Travel Time Format!");

        if(Convert.ToInt32(timeStringParts[1]) > 59)
        {
            int amontOfHours = Convert.ToInt32(timeStringParts[1]) / 60;
            timeString = $"{Convert.ToInt32(timeStringParts[0]) + amontOfHours}:{Convert.ToInt32(timeStringParts[1]) - amontOfHours * 60}";
            timeStringParts = timeString.Split(':');
        }

        if (Convert.ToInt32(timeStringParts[0]) > 23)
        {
            int amontOfDays =  Convert.ToInt32(timeStringParts[0]) / 24;
            timeString = $"{amontOfDays}.{Convert.ToInt32(timeStringParts[0]) - amontOfDays*24}:{timeStringParts[1]}";
        }

        if (!TimeSpan.TryParse(timeString, out result))
            throw new StackOverflowException("One of the entered numbers was too big!");

        return result;
    }

}
