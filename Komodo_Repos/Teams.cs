using Komodo_Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Repos
{
    public enum DeveloperType
    {
        Web = 1,
        Software = 2
    }
    public class Teams
    {
        public string TeamName { get; set; }
        public List<Devs> TeamMembers { get; set; }
        public DeveloperType TypeOfDev { get; set; }

        public Teams()
        {

        }
        public Teams(string teamName, List<Devs> teamMembers, DeveloperType dev)
        {
            TeamName = teamName;
            TeamMembers = teamMembers;
            TypeOfDev = dev;

        }

    }
}
