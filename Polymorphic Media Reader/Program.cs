/*
    Class: Program.cs
    Author: Brendan Dileo
    Date: October 28, 2024
    
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Assignment3A
{
    /// <summary>
    /// @author: Brendan Dileo
    /// </summary>
    internal class Program 
    {
        /// <summary>
        /// A list of Media objects.
        /// </summary>
        private static List<Media> media; 

        /// <summary>
        /// The main method.
        /// Entry point of the application.
        /// </summary>
        /// <param name="args">Command line args passed to application.</param>
        static void Main(string[] args) 
        {
            ReadData();
            DisplayMainMenu();
            bool isRunning = true; // Flag that controls if the program exits or keeps running.

            while (isRunning) // While loop continuing to execute until the user chooses to quit.
            {
                isRunning = ReadMenuSelection(); // Method returns true if the user dosent want to quit, false if they want to quit.
            }
        }

        // Helper Methods

        /// <summary>
        /// This method is responsible for displaying the main menu of options to the user.
        /// </summary>
        static public void DisplayMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      Media Display Menu                     ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("║ Enter one of the following options to display the media:    ║\n║" +
                "                                                             ║");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("║ [1] - List All Books - No Summary Displayed                 ║");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("║ [2] - List All Movies - No Summary Displayed                ║");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("║ [3] - List All Songs                                        ║");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("║ [4] - List All Media - No Summary Displayed Where Applicable║");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("║ [5] - Search All Media By Title                             ║");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("║ [0] - Exit the Menu                                         ║");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
            Console.WriteLine("\nEnter your selection: ");
        }

        /// <summary>
        /// This method is responsible for reading, and handling the choice made by the user.
        /// The choice made by the user indicates which of the media types they want to list by, or if they want to search or exit the application.
        /// First the input from the user is read and saved into a string, this is then attempted to parse into an integer as the input indicates 
        /// which menu option the user picked. If the parse is successful, it is then validated to ensure it is within an accurate range of values.
        /// If not, an exception is thrown. Once parsed and validated, the value is used to determine which case to execute in the switch case.
        /// Each of the cases will make a call to the corresponding method associated with that option. If the user makes a valid selection, the
        /// method will return true indicating the user has not chosen to quit. If the user enters 6, the method returns false indicating the user
        /// wants to quit, which will stop the main loop.
        /// </summary>
        /// <returns>A boolean value indicating whether the user wants to quit the application.</returns>
        static public bool ReadMenuSelection()
        {
            int option;
            while (true)
            {
                string choice = Console.ReadLine(); // Reads the user input from console.
                try
                {
                    if (int.TryParse(choice, out option)) // Attempts to parse choice, will store value in option if successful.
                    {
                        if (option < 1 || option > 6) // Validates users selection.
                        {
                            throw new ArgumentOutOfRangeException("Error: You must enter a number between 1 - 6!"); // Throws exception if selection is out of valid range.
                        }

                        switch (option)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Listing all Books (No Summary)...\n");
                                ListAllBooks();
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Listing all Movies (No Summary)...\n");
                                ListAllMovies();
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Listing all Songs...\n");
                                ListAllSongs();
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Listing all Media (No Summary)...");
                                ListAllMedia();
                                break;
                            case 5:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Enter the title to search by: ");
                                string title = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                SearchAllMedia(title);
                                break;
                            case 6:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Exiting...");
                                Console.WriteLine("Have a good day!");
                                return false;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("That was not an option! Please enter a number between 1 - 6!");
                                break;
                        }

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter your next selection: ");
                        return true;

                    } else // Executes if the choice entered by user could not be parsed to an integer.
                    {
                        throw new FormatException("Error: You must enter a valid number!"); // Throws exception indicating input format was invalid.
                    }
                }
                catch (ArgumentOutOfRangeException e) // Exception handling for a value out of the valid range.
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e) // Exception handling for when the user input cannot be parsed.
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e) // General error handling
                {
                    Console.WriteLine("Error: Unexpected Error!" + e.Message);
                }
                return true;
            }
        }

        /// <summary>
        /// This method is responsible for listing all Books from the list of media, no summaries.
        /// A foreach loop is used to iterate through all of the media objects in the list, and uses pattern matching to check the type of each object.
        /// If the type of the media is a book, it is displayed in a structured format.
        /// </summary>
        static public void ListAllBooks()
        {
            int i = 1;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Books");
            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════");
            Console.ResetColor();
            foreach (Media item in media) // Loops through all media objects in the list.
            {
                if (item is Book book) // Pattern match to check if the media object is a book.
                {
                    Console.WriteLine($"{i}: {book.Title}, {book.Year}, {book.Author}\n");
                    i++;
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════");
        }

        /// <summary>
        /// This method is responsible for listing all Movies from the list of media, no summaries.
        /// A foreach loop is used to iterate through all of the media objects in the list, and uses pattern matching to check the type of each object.
        /// If the type of the media is a movie, it is displayed in a structured format.
        /// </summary>
        static public void ListAllMovies()
        {
            int i = 1;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Movies");
            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════");
            Console.ResetColor();

            foreach (Media item in media) // Loops through all media objects in the list.
            {
                if (item is Movie movie) // Pattern match to check if the media object is a movie.
                {
                    Console.WriteLine($"{i}: {movie.Title}, {movie.Year}, {movie.Director}\n");
                    i++;
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════");
        }

        /// <summary>
        /// This method is responsible for listing all Movies from the list of song.
        /// A foreach loop is used to iterate through all of the media objects in the list, and uses pattern matching to check the type of each object.
        /// If the type of the media is a song, it is displayed in a structured format.
        /// </summary>
        static public void ListAllSongs()
        {
            int i = 1;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Songs");
            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════");
            Console.ResetColor();

            foreach (Media item in media) // Loops through all media objects in the list.
            {
                if (item is Song song) // Pattern match to check if the media object is a song.
                {
                    Console.WriteLine($"{i}: {song.Title}, {song.Year}, {song.Album}, {song.Artist}\n");
                    i++;
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════");
        }

        /// <summary>
        /// This method is responsible for listing all media from the list of media, no summaries where applicable.
        /// This method just makes calls to the other methods to reduce code duplication.
        /// </summary>
        static public void ListAllMedia()
        {
            Console.WriteLine("Listing all Media (No Summary)...");
            ListAllBooks();
            ListAllMovies();
            ListAllSongs();
        }

        /// <summary>
        /// This method is responsible for reading data from a file, parsing the data, and populating a list of media objects based on the data read.
        /// An instance of the stream reader class is used to read the data from the file, continuing to read the data until the end of the file is reached.
        /// Line by line the data is read, skipping the lines that split up the media, and parsing by the characters that split up the attributes of the media
        /// object. Once parsed, depending on the media type the corresponding object is created and added to the list of media.
        /// </summary>
        public static void ReadData()
        {
            media = new List<Media>(100); // List of up to 100 media objects
            string file = "Data.txt"; // Data file.

            try
            {
                using (StreamReader reader = new StreamReader(file)) // Uses a new instance of the stream reader class to read the data from the file.
                {
                    string line; // Declares the variable that will hold each line read.

                    while ((line = reader.ReadLine()) != null) // Continues to execute until the end of the file has been reached (No text).
                    {
                        if (line == "------") // Checks if the line read was this string of characters as this indicates the start of a new media object.
                        {
                            continue; // Skips current line if encountered.
                        }

                        string[] parts = line.Split('|'); // Creates an array of strings based on the '|'. This is where the data is parsed.

                        if (parts.Length < 4) // Checks that once the data is parsed, it has an invalid number of parts which indicate not enough data to create an object from it.
                        {
                            continue; // Skips the line with the invalid data.
                        }

                        string type = parts[0].ToUpper(); // Converts the string at index 0 of the array to all uppercase, and stores in a variable. This indicates the type of the media.
                        string title = parts[1]; // Stores the title of the media which is at the first index of the array into a variable.

                        if (!int.TryParse(parts[2], out int year)) // Checks if the year is not a valid integer (cant be parsed).
                        {
                            throw new ArgumentException($"Error: The year {year} is in a invalid format!"); // Throws an exception if year is not valid
                        }

                        Media mediaItem = null; // Initializes the current media item to null.

                        if (type == "MOVIE" && parts.Length >= 4) // Checks that the type is movie and the length of the array is valid.
                        {
                            string director = parts[3]; // Assigns the director.
                            string summary = ReadSummary(reader); // Calls the read summary method to read the summary.
                            
                            mediaItem = new Movie(title, year, director, summary); // Creates the movie object based on the data.
                        } 
                        else if (type == "BOOK" && parts.Length >= 4) // Checks that the type is book and the length of the array is valid.
                        {
                            string author = parts[3]; // Assigns the author.
                            string summary = ReadSummary(reader); // Calls the read summary method to read the summary.

                            mediaItem = new Book(title, year, author, summary); // Creates the book object based on the data.
                        }
                        else if (type == "SONG" && parts.Length >= 4) // Checks that the type is song and the length of the array is valid.
                        {
                            string album = parts[3]; // Assigns the album.
                            string artist = parts[4]; // Assigns the artist.

                            mediaItem = new Song(title, year, album, artist); // Creates the song object based on the data.
                        }
                        if (mediaItem != null) // Ensure the media item is not null before adding to list of media.
                        {
                            media.Add(mediaItem); // Add the media object to the list of media.
                        }
                    }
                }
            }
            catch (FileNotFoundException e) // Handle exception thrown when file could not be found.
            {
                Console.WriteLine($"Error: Could not find the file {file}!");
            }
            catch (IOException e) // Handle exceptions specific to input and output (Permission or file path issues).
            {
                Console.WriteLine($"Error: An error occurred when accessing the file: {file}! {e.Message}");
            }
            catch (Exception e) // General exception handling for unexpected errors.
            {
                Console.WriteLine($"An unexpected error occurred: {e.Message}"); 
            }
        }

        /// <summary>
        /// This method is responsible for parsing and reading the summary of media object.
        /// It uses an instance of the stream reader class to read the data from the file, and adds each line of text from the file to a variable to construct the summary.
        /// Once a sequence of dashes are encountered, this indicates the end of a summary.
        /// </summary>
        /// <param name="reader">The StreamReader used to read from the file.</param>
        /// <returns>The constructed summary of the media object.</returns>
        private static string ReadSummary(StreamReader reader)
        {
            string summary = ""; // Initializes the summary to an empty string.

            string line;
            while ((line = reader.ReadLine()) != null && line.Trim() != "-----") // Continues to read until the end of file is reached or a sequence of dashes is encountered.
            {
                summary += line + "\n"; // Adds each new line read to the summary.
            }

            return summary.Trim(); // Returns the summary trimmed.
        }

        /// <summary>
        /// This method is responsible for letting the user search for a media object by title.
        /// It makes use of the search method implemented in the media class. The parameter is the title the user is going to search by. Once validated, a boolean flag is used 
        /// to indicate whether or not a media object with the title keyword was found. If an item with that name is found, nested if statements are used to display the corresponding
        /// media object, in a structured format including a summary for the media object where applicable. If no media was found, a message is displayed to the user.
        /// </summary>
        /// <param name="title">The title keyword the user is searching by.</param>
        /// <exception cref="ArgumentException">Thrown if no title is entered, or if the title was invalid.</exception>
        static public void SearchAllMedia(string title)
        {
            if (string.IsNullOrEmpty(title)) // Checks if the parameter is empty or null.
            {
                throw new ArgumentException("You must enter a Title to search by!");
            }

            bool isFound = false; // Boolean flag indicating whether a title with a similar name has been found.

            Console.WriteLine($"Search Results: ");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            
            foreach (Media item in media) // Loop through each media object in the list of media.
            {
                if (string.IsNullOrEmpty(item.Title)) // Checks if the title of the media is empty or null.
                {
                    throw new ArgumentException("The Title was missing or invalid!");
                }

                if (item.Search(title)) // Calls search method to search for the media object with the corresponding title.
                {
                    if (item is Book book) // Checks if media object is a book.
                    {
                        Console.WriteLine($"Type: Book, Title: {book.Title}, Year: {book.Year}, Author: {book.Author}");
                        Console.WriteLine($"\nSummary: \n{book.Decrypt()}\n"); // Decrypt the books summary.
                        Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                        isFound = true; // Sets flag to true to indicate media with this title has been found.
                    }

                    if (item is Movie movie) // Checks if media object is a movie.
                    {
                        Console.WriteLine($"Type: Movie, Title: {movie.Title}, Year: {movie.Year}, Director: {movie.Director}");
                        Console.WriteLine($"\nSummary: \n{movie.Decrypt()}\n"); // Decrypt movies summary.
                        Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                        isFound = true; // Sets flag to true to indicate media with this title has been found.
                    }

                    if (item is Song song) // Checks if media object is a song.
                    {
                        Console.WriteLine($"Type: Song, Title: {song.Title}, Year: {song.Year}, Album: {song.Album}, Artist: {song.Artist}");
                        Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                        isFound = true; // Sets flag to true to indicate media with this title has been found.
                    }
                }
            }

            if (!isFound) // Check if no media was found.
            {
                Console.WriteLine($"There was no Media found with {title}");
            }
        }
    }
}
