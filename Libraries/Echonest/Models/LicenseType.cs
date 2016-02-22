using System;

namespace Echonest.Models
{
    public class LicenceType
    {
        public LicenceTypeEnum Type { get; set; }

        public override string ToString()
        {
            switch (this.Type)
            {
                case LicenceTypeEnum.EchoSource:
                    return "echo-source";
                case LicenceTypeEnum.AllRightsReserved:
                    return "all-rights-reserved";
                case LicenceTypeEnum.CcBySa:
                    return "cc-by-sa";
                case LicenceTypeEnum.CcByNc:
                    return "cc-by-nc";
                case LicenceTypeEnum.CcByNcNd:
                    return "cc-by-nc-nd";
                case LicenceTypeEnum.CcByNcSa:
                    return "cc-by-nc-sa";
                case LicenceTypeEnum.CcByNd:
                    return "cc-by-nd";
                case LicenceTypeEnum.CcBy:
                    return "cc-by";
                case LicenceTypeEnum.PublicDomain:
                    return "public-domain";
                case LicenceTypeEnum.Unknown:
                    return "unknown";
            }

            return null;
        }
    }

    public enum LicenceTypeEnum
    {
        EchoSource,
        AllRightsReserved,
        CcBySa,
        CcByNc,
        CcByNcNd,
        CcByNcSa,
        CcByNd,
        CcBy,
        PublicDomain,
        Unknown
    }
}
