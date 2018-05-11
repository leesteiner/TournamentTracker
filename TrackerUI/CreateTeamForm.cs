using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers { get; set; } = new List<PersonModel>();
        private List<PersonModel> selectedTeamMembers { get; set; } = new List<PersonModel>();

        public CreateTeamForm()
        {
            InitializeComponent();
            //CreateSampleData();
            WireUpLists();
        }

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel{FirstName = "Lee",LastName = "Steiner" });
            availableTeamMembers.Add(new PersonModel { FirstName = "Sandy", LastName = "Steiner" });

            selectedTeamMembers.Add(new PersonModel {FirstName = "Testor", LastName = "Jenkins" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Tested", LastName = "Gherkins" });
        }

        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListbox.DataSource = selectedTeamMembers;
            teamMembersListbox.DisplayMember = "FullName";
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {

            if (ValidateForm())
            {
                PersonModel p = new PersonModel();
                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.EmailAddress = emailValue.Text;
                p.CellphoneNumber = cellphoneValue.Text;

                GlobalConfig.Connection.CreatePerson(p);

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellphoneValue.Text = "";
            }

            else
            {
                MessageBox.Show("You need to fill in all fields.");
            }

        }

        private bool ValidateForm()
        {
            //TODO - Add better Validation
            bool output = true;
            if (firstNameValue.Text.Length == 0)
            {
                output = false;
            }

            if (lastNameValue.Text.Length == 0)
            {
                output = false;
            }

            if (emailValue.Text.Length == 0)
            {
                output = false;
            }

            if (cellphoneValue.Text.Length == 0)
            {
                output = false;
            }

            return output;
        }
    }
}
