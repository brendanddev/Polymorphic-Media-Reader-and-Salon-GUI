/*
    Class: Book.cs
    Author: Brendan Dileo
    Date: October 28, 2024
    
    Purpose: To model a Book for the media console program.
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
    internal class Book : Media, IEncryptable // Inherits from Media Class, implements IEncryptable interface.
    {
        // Properties

        /// <summary>
        /// The author of the Book.
        /// Includes a getter to retrieve the author of a book.
        /// </summary>
        public string Author { get; }


        /// <summary>
        /// The summary of the book.
        /// Includes a getter to retrieve the summary of a book.
        /// </summary>
        public string Summary { get; }

        // Constructor 

        /// <summary>
        /// This constructor is used to create a Book object.
        /// It will take 4 parameters for the title of the book, release year, author, and summary. Where the title and the year require a
        /// call to the base class constructor to initialize. The values passed for author and summary are validated to ensure they are not
        /// empty or null.
        /// </summary>
        /// <param name="title">The name of the book.</param>
        /// <param name="year">The books release year.</param>
        /// <param name="author">The author of the book.</param>
        /// <param name="summary">A summary of the book.</param>
        public Book(string title, int year, string author, string summary)
            : base(title, year) // Makes call to base class constructor.
        {
            if (string.IsNullOrEmpty(author))
            {
                throw new ArgumentException("Error: The author cannot be empty or null!");
            }
            Author = author;

            if (string.IsNullOrEmpty(summary))
            {
                throw new ArgumentException("Error: The summary cannot be empty or null!");
            }
            Summary = summary;
        }

        // Methods

        /// <summary>
        /// This method is responsible for encrypting the summary of the book.
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
        /// This method is responsible for decrypting the summary of the book.
        /// This method just makes a call to the encrypt method, as this will just reverse the encrypted summary.
        /// </summary>
        /// <returns>A decrypted summary.</returns>
        public string Decrypt()
        {
            return Encrypt();
        }
    }
}
