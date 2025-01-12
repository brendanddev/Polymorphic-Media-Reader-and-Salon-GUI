/*
    Class: Hairdresser.cs
    Author: Brendan Dileo
    Date: October 28, 2024
    
    Purpose: To model a Hairdresser for the Hair Salon form app.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3B
{
    /// <summary>
    /// @author: Brendan Dileo
    /// </summary>
    class Hairdresser
    {
        // Backing Variables

        /// <summary>
        /// Stores the actual name of the hairdresser in a private string variable.
        /// </summary>
        private string name;

        /// <summary>
        /// Stores the actual hairdresser rate in a private decimal variable.
        /// </summary>
        private decimal rate;

        /// <summary>
        /// A string property that allows for controlled access to the actual name of the hairdresser that is stored in the backing variable.
        /// </summary>
        public string Name
        { 
            get => name; // Retrieves the name of the hairdresser stored in the backing variable.
            private set => name = value; // Allows for the name of the hairdresser to be set inside the class only.
        }

        /// <summary>
        /// A decimal property that allows for controlled access to the hairdressers rate that is stored in the backing variable.
        /// </summary>
        public decimal Rate 
        {
            get => rate; // Retrieves the hairdressers rate stored in the backing variable.
            private set => rate = value; // Hairdressers rate can be set inside of the class only.
        }

        /// <summary>
        /// Used to create an instance of the Hairdresser class, creating a Hairdresser for the Hair Salon form app.
        /// Each Hairdresser will have a name and rate, which are passed to the constructor as parameters. The parameters are validated inside
        /// of the constructor, to ensure the name is null or empty, and that the rate is not less than 0. Even though hairdressers and their
        /// attributes are pre defined, they are validated.
        /// </summary>
        /// <param name="hairdresserName">The name of the hairdresser.</param>
        /// <param name="hairdresserRate">The hairdressers rate.</param>
        /// <exception cref="ArgumentException">Thrown when the hairdressers name is empty or null, or if the hairdressers rate is less than 0.</exception>
        public Hairdresser(string hairdresserName, decimal hairdresserRate)
        {
            if (string.IsNullOrEmpty(hairdresserName)) // Checks if the name parameter is null or empty.
            {
                throw new ArgumentException("The Name of the Hairdresser cannot be empty or null!"); // Throws exception if the name is empty or null.
            }
            Name = hairdresserName; // Sets the name to the name parameter once validated.
            
            if (hairdresserRate < 0) // Checks if the parameter for the hairdressers rate is less than 0.
            {
                throw new ArgumentException("The Rate of the Hairdresser cannot be less than 0!"); // Throws exception if it is less than 0.
            }
            Rate = hairdresserRate; // Otherwise set the hairdressers rate once validated.
        }

        /// <summary>
        /// This method is used to return a string that includes the name of the hairdresser.
        /// </summary>
        /// <returns>A string that includes the name of the hairdresser.</returns>
        public override string ToString()
        {
            return $"{Name}"; // Accesses name using properties getter.
        }
    }
}
