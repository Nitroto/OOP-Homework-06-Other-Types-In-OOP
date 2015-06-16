using System;

namespace GalacticGPS
{
    class GalacticGPS
    {
        static void Main()
        {
            try
            {
                Location home = new Location(-18.037986, 28.870097, Planet.Earth);
                Console.WriteLine(home);
            }
            catch (ArgumentOutOfRangeException re)
            {
                Console.WriteLine("Invalid argument for {0}!\n\r{1}", re.ParamName, re.Message);
            }
        }
    }
}
