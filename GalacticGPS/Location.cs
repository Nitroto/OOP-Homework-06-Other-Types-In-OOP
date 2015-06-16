using System;
using System.Text;

namespace GalacticGPS
{
    struct Location
    {
        private double latitude;
        private double longitude;

        public Location(double latitude, double longitude, Planet planet)
            :this()
        {
            this.Latitude = latitude;
            this.Logitude = longitude;
            this.Planet = planet;
        }

        public double Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                if (value < -90.0 || value > 90.0)
                {
                    throw new ArgumentOutOfRangeException("latitude", "Latitude should be in the range of -90 ... 90.");
                }
                this.latitude = value;
            }
        }
        public double Logitude
        {
            get
            {
                return this.longitude;
            }
            set
            {
                if (value < -180.0 || value > 180.0)
                {
                    throw new ArgumentOutOfRangeException("longitude", "Longitude should be in the range of -180 ... 180.");
                }
                this.longitude = value;
            }
        }
        public Planet Planet { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("{0}, {1} - {2}", this.Latitude, this.Logitude, this.Planet));
            return output.ToString();
        }
    }
}
