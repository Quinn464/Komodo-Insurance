using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Repos
{
    public class TeamsRepositorys
    {
        private List<Teams> _listOfTeams = new List<Teams>();

        //c
        public void AddTeamToList(Teams teams)
        {
            _listOfTeams.Add(teams);
        }
        //r
        public List<Teams> GetTeamList()
        {
            return _listOfTeams;
        }

        //u
        public bool UpdateExistingTeam(string originalName, Teams newTeam)
        {
            Teams oldTeam = GetTeamsByName(originalName);
            if (oldTeam != null)
            {
                oldTeam.TeamName = newTeam.TeamName;
                oldTeam.TeamMembers = newTeam.TeamMembers;
                oldTeam.TypeOfDev = newTeam.TypeOfDev;

                return true;
            }
            else
            {
                return false;
            }
        }

        //d
        public bool RemoveTeamFromList(string name)
        {
            Teams teams = GetTeamsByName(name);
            if (teams == null)
            {
                return false;
            }
            int initalCount = _listOfTeams.Count;   
            _listOfTeams.Remove(teams);
            if (initalCount > _listOfTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Extra Method
        public Teams GetTeamsByName(string name)
        {
            foreach(Teams team in _listOfTeams)
            {
                if (team.TeamName == name)
                    return team;
            }
            return null;
        }

        //Add team member to team by ID

       // Remove team member by id


        //helper
        public string JoinListTogether(string id)
        {
            Teams team = GetTeamsByName(id);
            List<string> names = new List<string>();
                foreach (var name in team.TeamMembers)
            {
                string teamMemeber = name.Name;
                names.Add(teamMemeber);                
            }
            string listNames = String.Join(", ", names);
            return listNames;
        }
    }
}
