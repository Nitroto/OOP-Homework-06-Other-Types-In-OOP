using System;
using System.Text;

namespace GenericListVersion
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class |
        AttributeTargets.Interface, AllowMultiple = false)]
    class VersionAttribute : Attribute
    {
        public int major; 
        public int minor;

        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major
        {
            get
            {
                return this.major;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("major", "Major version cannot be negative!");
                }
                this.major = value;
            }
        }
        public int Minor
        {
            get
            {
                return this.minor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("minor", "Minor version cannot be negative!");
                }
                this.minor = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("Version: {0}.{1}", this.Major, this.Minor));
            return output.ToString();
        }
    }
}
