using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_api
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Summary
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int severity { get; set; }
        public string phrase { get; set; }
        public string category { get; set; }
    }

    public class Minimum
    {
        public double value { get; set; }
        public string unit { get; set; }
        public int unitType { get; set; }
    }

    public class Maximum
    {
        public double value { get; set; }
        public string unit { get; set; }
        public int unitType { get; set; }
    }

    public class Temperature
    {
        public Minimum minimum { get; set; }
        public Maximum maximum { get; set; }
    }

    public class RealFeelTemperature
    {
        public Minimum minimum { get; set; }
        public Maximum maximum { get; set; }
    }

    public class RealFeelTemperatureShade
    {
        public Minimum minimum { get; set; }
        public Maximum maximum { get; set; }
    }

    public class Heating
    {
        public double value { get; set; }
        public string unit { get; set; }
        public int unitType { get; set; }
    }

    public class Cooling
    {
        public double value { get; set; }
        public string unit { get; set; }
        public int unitType { get; set; }
    }

    public class DegreeDaySummary
    {
        public Heating heating { get; set; }
        public Cooling cooling { get; set; }
    }

    public class AirAndPollen
    {
        public string name { get; set; }
        public int value { get; set; }
        public string category { get; set; }
        public int categoryValue { get; set; }
        public string type { get; set; }
    }

    public class Direction
    {
        public double degrees { get; set; }
        public string localizedDescription { get; set; }
    }

    public class Speed
    {
        public double value { get; set; }
        public string unit { get; set; }
        public int unitType { get; set; }
    }

    public class Wind
    {
        public Direction direction { get; set; }
        public Speed speed { get; set; }
    }

    public class WindGust
    {
        public Direction direction { get; set; }
        public Speed speed { get; set; }
    }

    public class TotalLiquid
    {
        public double value { get; set; }
        public string unit { get; set; }
        public int unitType { get; set; }
    }

    public class Rain
    {
        public double value { get; set; }
        public string unit { get; set; }
        public int unitType { get; set; }
    }

    public class Snow
    {
        public double value { get; set; }
        public string unit { get; set; }
        public int unitType { get; set; }
    }

    public class Ice
    {
        public double value { get; set; }
        public string unit { get; set; }
        public int unitType { get; set; }
    }

    public class Day
    {
        public int iconCode { get; set; }
        public string iconPhrase { get; set; }
        public bool hasPrecipitation { get; set; }
        public string precipitationType { get; set; }
        public string precipitationIntensity { get; set; }
        public string shortPhrase { get; set; }
        public string longPhrase { get; set; }
        public int precipitationProbability { get; set; }
        public int thunderstormProbability { get; set; }
        public int rainProbability { get; set; }
        public int snowProbability { get; set; }
        public int iceProbability { get; set; }
        public Wind wind { get; set; }
        public WindGust windGust { get; set; }
        public TotalLiquid totalLiquid { get; set; }
        public Rain rain { get; set; }
        public Snow snow { get; set; }
        public Ice ice { get; set; }
        public double hoursOfPrecipitation { get; set; }
        public double hoursOfRain { get; set; }
        public double hoursOfSnow { get; set; }
        public double hoursOfIce { get; set; }
        public double cloudCover { get; set; }
    }

    public class Night
    {
        public int iconCode { get; set; }
        public string iconPhrase { get; set; }
        public bool hasPrecipitation { get; set; }
        public string precipitationType { get; set; }
        public string precipitationIntensity { get; set; }
        public string shortPhrase { get; set; }
        public string longPhrase { get; set; }
        public int precipitationProbability { get; set; }
        public int thunderstormProbability { get; set; }
        public int rainProbability { get; set; }
        public int snowProbability { get; set; }
        public int iceProbability { get; set; }
        public Wind wind { get; set; }
        public WindGust windGust { get; set; }
        public TotalLiquid totalLiquid { get; set; }
        public Rain rain { get; set; }
        public Snow snow { get; set; }
        public Ice ice { get; set; }
        public double hoursOfPrecipitation { get; set; }
        public double hoursOfRain { get; set; }
        public double hoursOfSnow { get; set; }
        public double hoursOfIce { get; set; }
        public double cloudCover { get; set; }
    }

    public class Forecast
    {
        public DateTime date { get; set; }
        public Temperature temperature { get; set; }
        public RealFeelTemperature realFeelTemperature { get; set; }
        public RealFeelTemperatureShade realFeelTemperatureShade { get; set; }
        public double hoursOfSun { get; set; }
        public DegreeDaySummary degreeDaySummary { get; set; }
        public List<AirAndPollen> airAndPollen { get; set; }
        public Day day { get; set; }
        public Night night { get; set; }
        public List<string> sources { get; set; }
    }

    public class Root
    {
        public Summary summary { get; set; }
        public List<Forecast> forecasts { get; set; }
    }
}
