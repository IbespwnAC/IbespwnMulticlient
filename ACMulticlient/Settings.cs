namespace ACMulticlient
{
    using System;
    using System.Collections.Generic;

    public class Settings
    {
        public List<UserEntry> accounts;
        public string acmainpath;
        public int[] ACPorts = new int[] { 0x2328, 0x232d, 0x2332 };
        public string[] availableworlds = new string[] { "Frostfell", "Harvestgain", "Leafcull", "Morningthaw", "Solclaim", "Thistledown", "Verdatine", "Wintersebb", "Darktide" };
        public string Defaultworld = "Morningthaw";
        public List<string> LaunchPaths;
        public string[] selectedworlds = new string[] { "Morningthaw", "Darktide" };
        public bool startdecal = true;
    }
}

