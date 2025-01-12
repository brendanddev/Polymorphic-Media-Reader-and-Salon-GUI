/*
    Class: Service.cs
    Author: Brendan Dileo
    Date: October 28, 2024
    
    Purpose: To model a Service object for the Hair Salon form app.
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
    class Service
    {

        /// <summary>
        /// Stores the actual value of the service type.
        /// </summary>
        private string type;

        /// <summary>
        /// Stores the actual value of the cost for the service.
        /// </summary>
        private decimal cost;

        // Properties

        /// <summary>
        /// Allows for controlled access to the actual value of the services type that is stored in the backing variable, 
        /// representing the type of the chosen service.
        /// </summary>
        public string Type
        {
            get => type; // Retrieves the value of type stored in backing variable.
            private set => type = value; // Allows type to be set inside of the class only.
        }

        /// <summary>
        /// Allows for controlled access to the actual value of the services cost that is stored in the backing variable,
        /// representing the cost of the chosen service.
        /// </summary>
        public decimal Cost
        {
            get => cost; // Retrieves the value of the cost stored in the backing variable.
            private set => cost = value; // Allows for the cost of the service to be set inside of the class only.
        }


        /// <summary>
        /// Used to create an instance of the Service class.
        /// Each service will have a type, and a cost which are provided to the constructor as parameters.
        /// </summary>
        /// <param name="type">The type of service.</param>
        /// <param name="cost">The cost of the service.</param>
        /// <exception cref="ArgumentException">Thrown when the service type is empty or null, or if the cost of the service is less than 0.</exception>
        public Service(string type, decimal cost)
        {
            if (string.IsNullOrEmpty(type)) // Checks if the type is null or empty.
            {
                throw new ArgumentException($"Error: The Service Type cannot be empty or null! You entered: {type}!"); // Throws an exception if it is.
            }
            Type = type; // Otherwise set the type.

            if (cost < 0) // Checks if cost is less than 0.
            {
                throw new ArgumentException($"The Service Cost cannot be less than 0! You entered: {cost}!"); // If it is, throw an exception.
            }
            Cost = cost; // If cost is not less than 0, set the cost.
        }

        /// <summary>
        /// This method is used to return a string that includes the type of the service.
        /// </summary>
        /// <returns>A string representing a service.</returns>
        public override string ToString()
        {
            return $"{Type}";
        }
    }
}
