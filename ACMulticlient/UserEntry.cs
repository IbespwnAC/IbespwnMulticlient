﻿namespace ACMulticlient
{
    using System;
    using System.Xml.Serialization;

    public class UserEntry
    {
        public string name;
        [XmlIgnore]
        public byte[] secret;
        [XmlIgnore]
        public string usedACpath;
        [XmlIgnore]
        public string usedworld;

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.name))
            {
                return "(null)";
            }
            return this.name;
        }
    }
}
