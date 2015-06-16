using System;

namespace GenericListVersion
{
    class GenericListVersion
    {
        static void Main()
        {
            VersionAttribute versionAttribute;
            Type type = typeof(GenericList<>);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (Attribute attribute in allAttributes)
            {
                versionAttribute = attribute as VersionAttribute;
                if (versionAttribute != null)
                {
                    Console.WriteLine(attribute.ToString());
                }
            }
        }
    }
}
