﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents one person.
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// The unique identifier for the person.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The first name of the player. 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The last name of the person.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The primary email adress of the player.
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// The primary cell phone number of the player.
        /// </summary>
        public string CellPhoneNumber { get; set; }
        
        public string FullName 
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
