/*
    Class: Movie.cs
    Author: Brendan Dileo
    Date: October 28, 2024
    
    Purpose: To model a Movie for the media console program.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3A
{
    /// <summary>
    /// @author: Brendan Dileo
    /// </summary>
    internal class Movie : Media, IEncryptable // Inherits from media, implements IEncryptable
    {

        // Properties

        /// <summary>
        /// The director of the movie.
        /// Includes a getter to retrieve the director of a movie.
        /// </summary>
        public string Director { get; }

        /// <summary>
        /// The summary of the movie.
        /// Includes a getter to retrieve the summary of a movie.
        /// </summary>
        public string Summary { get; }

        // Constructor

        /// <summary>
        /// This constructor is used to create a Movie object.
        /// It will take 4 parameters for the title of the movie, release year, director, and summary. Where the title and the year require a
        /// call to the base class constructor to initialize. The values passed for director and summary are validated to ensure they are not
        /// empty or null.
        /// </summary>
        /// <param name="title">The name of the movie.</param>
        /// <param name="year">The movies release year.</param>
        /// <param name="director">The director of the movie.</param>
        /// <param name="summary">A summary of the movie.</param>
        public Movie(string title, int year, string director, string summary)
            : base(title, year) // Call to base class constructor.
        {
            if (string.IsNullOrEmpty(director)) // Checks if the director is empty or null.
            {
                throw new ArgumentException("Error: The director name cannot be null or empty!"); // Throws exception if null or empty.
            }
            Director = director;

            if (string.IsNullOrEmpty(summary)) // Checks if summary is empty or null.
            {
                throw new ArgumentException("Error: The summary cannot be null or empty!"); // Throws exception if it is null or empty.
            }
            Summary = summary;
        }

        // Methods

        /// <summary>
        /// This method is responsible for encrypting the summary of the movie.
        /// It uses a basic ROT13 algorithm to encrypt each letter, accounting for both uppercase and lowercase letters.
        /// Any non alphabetical characters stay unchanged.
        /// 
        /// Reference: NetSecProf. (2022, April 4). Rot13 encryption in C++ [Video]. YouTube. https://www.youtube.com/watch?v=tE1QHLbZpdc
        /// </summary>
        /// <returns>An encrypted summary.</returns>
        public string Encrypt() // ROT13 Encryption Algorithm
        {
            string encrypted = ""; // Initializes the encrypted string to an empty string.
            for (int i = 0; i < Summary.Length; i++) // Loops through the length of the summary.. each char.
            {
                if (char.IsUpper(Summary[i])) // Checks for uppercase.
                {
                    encrypted += (char)((Summary[i] - 'A' + 13) % 26 + 'A'); // Shifts letter 13 places forward in alphabet.
                }
                else if (char.IsLower(Summary[i])) // Checks for lowercase.
                {
                    encrypted += (char)((Summary[i] - 'a' + 13) % 26 + 'a');  // Shifts letter 13 places forward in alphabet.
                }
                else // Other characters remain the same.
                {
                    encrypted += Summary[i];
                }
            }
            return encrypted; // Encrypted string is returned.
        }

        /// <summary>
        /// This method is responsible for decrypting the summary of the movie.
        /// This method just makes a call to the encrypt method, as this will just reverse the encrypted summary.
        /// </summary>
        /// <returns>A decrypted summary.</returns>
        public string Decrypt()
        {
            return Encrypt();
        }
    }
}
