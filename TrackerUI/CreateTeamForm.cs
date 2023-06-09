﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentTracker;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
        private ITeamRequester callingForm;

        public CreateTeamForm(ITeamRequester caller)
        {
            InitializeComponent();
            callingForm = caller;

            //CreateSampleData();

            WireUpLists();
        }


        /*private void CreateSampleData()
{
   availableTeamMembers.Add(new PersonModel { FirstName = "Marek", LastName = "Augustynowicz" });
   availableTeamMembers.Add(new PersonModel { FirstName = "Klaudia", LastName = "Rurkiewicz" });

   selectedTeamMembers.Add(new PersonModel { FirstName = "Jan", LastName = "Kowalski" });
   selectedTeamMembers.Add(new PersonModel { FirstName = "Anna", LastName = "Bydna" });
}*/

        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = null;

            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";

        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;

            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireUpLists(); 
            }
            
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel person = new PersonModel();

                person.FirstName = firsrNameValue.Text;
                person.LastName = lastNameValue.Text;
                person.EmailAddress = emailValue.Text;
                person.CellPhoneNumber = cellphoneValue.Text;

                GlobalConfig.Connection.CreatePerson(person);

                selectedTeamMembers.Add(person);

                WireUpLists();

                firsrNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellphoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("U need to fill in all of the fields.");
            }
        }

        private bool ValidateForm()
        {
            // Validation to the form
            if(firsrNameValue.Text.Length == 0)
            {
                return false;
            }
            if(lastNameValue.Text.Length == 0)
            {
                return false;
            }
            if (emailValue.Text.Length == 0)
            {
                return false;
            }
            if(cellphoneValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void removeSelectedMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;

            if (p != null) 
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists(); 
            }
        }

        private void createTeamtButton_Click(object sender, EventArgs e)
        {
            TeamModel t = new TeamModel();

            if (teamNameValue.Text.Length > 0)
            {
                t.TeamName = teamNameValue.Text;
            }
            else
            {
                MessageBox.Show("Please enter a valid team name", "Invalid Team Name");
                return;
            }

            if (selectedTeamMembers.Count > 0)
            {
                t.TeamMembers = selectedTeamMembers;
            }
            else
            {
                MessageBox.Show("Please enter at least one team member", "Invalid Team Member Count");
                return;
            }

            GlobalConfig.Connection.CreateTeam(t);

            callingForm.TeamComplete(t);

            this.Close();
        }
    }
}
