using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class TeamModel
    {
        //prop double Tab
        //at C# 6.0 can use cinstuction like 12 string instead of "ctor"  constructor model
        public int Id { get; set; }
        public string TeamName { get; set; }

        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();

        //ctor - constructor
        
        /*
        public TeamModel()
        {
            TeamMembers = new List<PersonModel>();
        }
        */
    }
}
