﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents one team in a matchup.
    /// </summary>
    public class MatchupEntryModel
    {
        // if type 3 times "/" , appears xml comment
        // if write cw double Tab , appears Console.WriteLine method

        /// <summary>
        /// The unique identifier for the entry.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Represents one team in the matchup.
        /// </summary>
        public int TeamCompetingId { get; set; }
        /// <summary>
        /// Represents one team in the matchup.
        /// </summary>
        public TeamModel TeamCompeting { get; set; }
        /// <summary>
        /// Represents the score for this particular team.
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// The unique identifier for the parent matchup (team).
        /// </summary>
        public int ParentMatchupId { get; set; }
        /// <summary>
        /// Represents the matchup that this team came 
        /// from as the winner.
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }

    }
}