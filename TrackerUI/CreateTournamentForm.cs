using ApplicationUI;
using Dapper;
using System;
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
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
    {
        List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();

        public CreateTournamentForm()
        {
            InitializeComponent();

            WireUpLists();
        }

        private void WireUpLists()
        {
            selectTeamDropDown.DataSource = null;
            selectTeamDropDown.DataSource = availableTeams;
            selectTeamDropDown.DisplayMember = "TeamName";

            tournamentTeamsListBox.DataSource = null;
            tournamentTeamsListBox.DataSource = selectedTeams;
            tournamentTeamsListBox.DisplayMember = "TeamName";

            prizesListBox.DataSource = null;
            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = "PlaceName";
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            // Validate data
            decimal fee = 0;
            bool validateFee = decimal.TryParse(entryFeeValue.Text, out fee);
            if (!validateFee)
            {
                MessageBox.Show("Enter valid fee", "invalid fee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TournamentModel tm = new TournamentModel();

            tm.TournamentName = tournamentNameValue.Text;
            tm.EntryFee = fee;

            tm.Prizes = selectedPrizes;
            tm.TeamModels = selectedTeams;

            TournamentLogic.CreateRounds(tm);

            GlobalConfig.Connection.CreateTournament(tm);

            tm.AlertUsersToNewRound();

            TournamentViewerForm form = new TournamentViewerForm(tm);
            form.Show();
            this.Close();
        }
   
        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel team = (TeamModel)selectTeamDropDown.SelectedItem;

            if (team != null)
            {
                availableTeams.Remove(team);
                selectedTeams.Add(team);

                WireUpLists();
            }
        }

        private void createNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm form = new CreateTeamForm(this);

            form.Show();
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            //call the crearedPrizeForm
            CreatePrizeForm form = new CreatePrizeForm(this);
            form.Show();
        }

        public void PrizeComplete(PrizeModel model)
        {
            // Get back from the form a PrizeModel.
            // Take that PrizeModel and put it into our list of Selected Prizes.
            selectedPrizes.Add(model);

            WireUpLists();
        }

        public void TeamComplete(TeamModel model)
        {
            selectedTeams.Add(model);

            WireUpLists();
        }

        private void removeSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel prize = (PrizeModel)prizesListBox.SelectedItem;

            if (prize != null)
            {
                selectedPrizes.Remove(prize);

                WireUpLists();
            }
        }

        private void removeSelectedPlayerButton_Click(object sender, EventArgs e)
        {
            /*PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;

            if (p != null) 
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);
            tournamentTeamsListBox
                WireUpLists(); 
            }*/
            TeamModel team = (TeamModel)tournamentTeamsListBox.SelectedItem;

            if (team != null)
            {
                selectedTeams.Remove(team);
                availableTeams.Add(team);

                WireUpLists();
            }
        }
    }
}
