/*
    Class: SalonForm.cs
    Author: Brendan Dileo
    Date: October 28, 2024
    
    Purpose: Implement the view class for the Hair Salon application using a form.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3B
{
    /// <summary>
    /// @author: Brendan Dileo
    /// </summary>
    public partial class SalonForm : Form
    {
        /// <summary>
        /// A boolean variable used to track whether or not a hairdresser has been selected.
        /// This is used when displaying the appointment information in the list box, and not having the name of the hairdresser appear each time.
        /// </summary>
        private bool hairdresserIsSelected = false;

        // Constructor

        /// <summary>
        /// This constructor is used to initialize the form, and set the default state of the forms components.
        /// By default, the selected index will be set to the first item in the hairdresser combo box, and all other form components beside the exit button and the hairdresser group box are
        /// disabled to prevent any erroneous selections.
        /// </summary>
        public SalonForm()
        {
            InitializeComponent();
            hairdresserComboBox.SelectedIndex = 0; // Sets default selected index to 0 (first item).
            servicesGroupBox.Enabled = false;
            addServiceButton.Enabled = false;
            calculateButton.Enabled = false;
            resetButton.Enabled = false;
            totalPriceTextBox.Enabled = false;
            chargesGroupBox.Enabled = false;
            pricesGroupBox.Enabled = false;
        }

        /// <summary>
        /// This method is responsible for handling the event triggered by a user changing the selected index of the hairdresser combo box.
        /// When called, this indicates the user has selected a hairdresser, so the services group box and add service button are enabled.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event data (Unused)</param>
        private void hairdresserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            servicesGroupBox.Enabled = true;
            addServiceButton.Enabled = true;
        }

        /// <summary>
        /// This method is responsible for handling the event triggered by the add service button being clicked.
        /// When this button is clicked the user is adding the chosen services to the charged items list box, reflecting the services for their appointment.
        /// Before any services are added, first the users selection is validated by calling the select services method, to store which services are selected,
        /// and then ensure the list of selected services are not null or empty. If they are null or empty, a error message box is shown. Next, the flag tracking
        /// whether a hairdresser is selected or not is checked, and if a hairdresser has not been chosen yet, a new hairdresser object is created by calling the 
        /// select hairdresser method, storing the selected hairdresser. The hairdresser is then validated, and if it is null an error message box is displayed.
        /// Otherwise, the flag tracking if a hairdresser was selected is set to true, and the name of the hairdresser is added to the charges list box, and the
        /// hairdressers rate is added to the prices list box. Since a service was now selected, the other group boxes and buttons are enabled. Each name of the
        /// services are added to the charges list box, and the corresponding prices are added to the prices list box.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event Data (Unused).</param>
        private void addServiceButton_Click(object sender, EventArgs e)
        {
            List<Service> services = SelectServices(); // Stores the selected services in a list of service objects by using the select services method.

            if (services == null || services.Count == 0) // Checks if the list is either null or empty.
            {
                MessageBox.Show("You must select at least one service!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Displays a error message box if list is null or empty.
                return;
            }

            if (!hairdresserIsSelected) // Checks if a hairdresser hasn't been selected already.
            {
                Hairdresser hairdresser = SelectHairdresser(); // Creates a new Hairdresser object by calling the select hairdresser method.

                if (hairdresser == null) // Checks to see if the hairdresser created is null.
                {
                    MessageBox.Show("You need to select a Hairdresser to continue!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Shows a error message box if the hairdresser is null.
                    return;
                }

                hairdresserIsSelected = true; // Changes to true indicating a hairdresser has been selected.
                chargesListBox.Items.Add(hairdresser.ToString()); // Adds name of hairdresser to charges list box.
                pricesListBox.Items.Add("$" + hairdresser.Rate); // Adds the hairdressers rate to the prices list box.
            }

            chargesGroupBox.Enabled = true;
            pricesGroupBox.Enabled = true;
            calculateButton.Enabled = true;
            resetButton.Enabled = true;
            hairdresserComboBox.Enabled = false;

            foreach (Service service in services) // Loops through each service in the services list.
            {
                chargesListBox.Items.Add(service); // Adds the name of the service to the charges list box.
                pricesListBox.Items.Add("$" + service.Cost); // Adds the price of the service to the prices list box.
            }
        }

        /// <summary>
        /// This method is responsible for handling the event triggered by the calculate total button being clicked.
        /// When this button is clicked, each price of the services that have been selected, and the hairdressers rate are summed, and displayed in the total price text box.
        /// A loop is used to find the total cost of the selected services, which is then added with the hairdressers rate to find the total cost.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event Data (Unused).</param>
        private void calculateButton_Click(object sender, EventArgs e)
        {
            decimal total = 0; // Sets the total to 0 by default.
            Hairdresser hairdresser = SelectHairdresser(); // Selected hairdresser.
            List<Service> services = SelectServices(); // Selected services.

            total += hairdresser.Rate; // Adds the hairdressers rate to the total price.

            foreach (Service service in services) // Loops through all the selected services.
            {
                total += service.Cost; // For every selected service, the cost of that service is added to the total price.
            }

            totalPriceTextBox.Enabled = true; // Enables total price text box.
            totalPriceTextBox.Text = total.ToString("C2"); // Displays the total in the text box.
        }

        /// <summary>
        /// This method is responsible for handling the event triggered by the reset button being clicked.
        /// When this button is clicked, it should reset the form back to its initial state, clearing any selections, and disabling all form components besides the exit button
        /// and the hairdresser group box.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event Data (Unused).</param>
        private void resetButton_Click(object sender, EventArgs e)
        {
            hairdresserComboBox.SelectedIndex = 0;
            chargesListBox.Items.Clear();
            pricesListBox.Items.Clear();
            totalPriceTextBox.Clear();
            servicesListBox.ClearSelected(); // Clears selected services.
            servicesGroupBox.Enabled = false;
            calculateButton.Enabled = false;
            addServiceButton.Enabled = false;
            hairdresserIsSelected = false;
            hairdresserComboBox.Focus(); // Adds focus back to the hairdresser combo box.
            totalPriceTextBox.Enabled = false;
            hairdresserComboBox.Enabled = true;
        }

        /// <summary>
        /// This method is responsible for handling the event triggered by the exit button being clicked.
        /// When the exit button is pressed, the form is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); // Calls close method on current instance of the form class (this instance).
        }

        // Helper Methods

        /// <summary>
        /// This method is responsible for determining which of the hairdressers in the hairdresser combo box are selected.
        /// Initially the selected hairdresser is set to null, and then if/else if statements are used to determine which hairdresser is selected, ensuring only one is selected.
        /// Depending on which index of the hairdresser combo box is selected, the corresponding hairdresser is created and returned.
        /// </summary>
        /// <returns>An instance of the Hairdresser class representing the selected hairdresser.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if an invalid combo box item is selected. Extra layer of error handling.</exception>
        private Hairdresser SelectHairdresser()
        {
            Hairdresser hairdresser = null; // Initialized to null

            // Checks which index of the hairdresser combo box is selected, creates the hairdresser depending on that.
            if (hairdresserComboBox.SelectedIndex == 0)
            {
                hairdresser = new Hairdresser("Jane Samley", 30.00m);
            }
            else if (hairdresserComboBox.SelectedIndex == 1)
            {
                hairdresser = new Hairdresser("Pat Johnson", 45.00m);
            }
            else if (hairdresserComboBox.SelectedIndex == 2)
            {
                hairdresser = new Hairdresser("Ron Chalmers", 40.00m);
            }
            else if (hairdresserComboBox.SelectedIndex == 3)
            {
                hairdresser = new Hairdresser("Sue Pallon", 50.00m);
            }
            else if (hairdresserComboBox.SelectedIndex == 4)
            {
                hairdresser = new Hairdresser("Laurier Renkins", 55.00m);
            } else // Extra layer of error handling, throw exception if index chosen is invalid.
            {
                throw new ArgumentOutOfRangeException("Error: Invalid selection!");
            }

            servicesGroupBox.Enabled = true;
            return hairdresser;
        }

        /// <summary>
        /// This method is responsible for determining which of the services in the services list box are selected.
        /// A new list of service objects is created, this will hold the selected services. A foreach loop is used to loop through each of the selected items in the services list box,
        /// and depending on the service type, a new service is created and added to the list of services. This list of services is returned reflecting the selected services.
        /// <returns>A list of service objects representing the selected services.</returns>
        /// <exception cref="ArgumentException">Thrown if a service was encountered but was invalid.</exception>
        private List<Service> SelectServices()
        {
            List<Service> services = new List<Service>(); // Initializes list of service objects.

            foreach (var item in servicesListBox.SelectedItems) // Loops through each of the selected items in the services list box.
            {
                string type = item.ToString(); // Converts the current list box item to a string, so the type of the service can be compared.

                if (type == "Cut")
                {
                    services.Add(new Service("Cut", 30.00m));
                } else if (type == "Wash, blow-dry, and style")
                {
                    services.Add(new Service("Wash, blow-dry, and style", 20.00m));
                } else if (type == "Colour")
                {
                    services.Add(new Service("Colour", 40.00m));
                } else if (type == "Highlights")
                {
                    services.Add(new Service("Highlights", 50.00m));
                }
                else if (type == "Extension")
                {
                    services.Add(new Service("Extension", 200.00m));
                }
                else if (type == "Up-do")
                {
                    services.Add(new Service("Up-do", 60.00m));
                }
                else // Extra layer of error handling.
                {
                    throw new ArgumentException("Error: Invalid selection!");
                }
            }
            return services; // Returns the list of services.
        }
    }
}
