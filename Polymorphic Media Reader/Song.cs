/*
    Class: Song.cs
    Author: Brendan Dileo
    Date: October 28, 2024
    
    Purpose: To model a Song for the media console program.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3A
{
    internal class Song : Media // Inherits from Media class.
    {

        /// <summary>
        /// The songs album.
        /// Includes a getter to retrieve the album name.
        /// </summary>
        public string Album { get; }

        /// <summary>
        /// The artist of the song.
        /// Includes a getter to retrieve the artists name.
        /// </summary>
        public string Artist { get; }


        // Constructor

        /// <summary>
        /// This constructor is used to create a Song object.
        /// It will take 4 parameters for the title of the song, release year, album, and artist. Where the title and the year require a
        /// call to the base class constructor to initialize.The values passed for album and artist are validated to ensure they are not
        /// empty or null.
        /// </summary>
        /// <param name="title">The name of the song.</param>
        /// <param name="year">The songs release year.</param>
        /// <param name="album">The songs album.</param>
        /// <param name="artist">The songs artist.</param>
        public Song(string title, int year, string album, string artist)
            : base(title, year) // Calls base class constructor.
        {
            if (string.IsNullOrEmpty(album))
            {
                throw new ArgumentException("Error: The album name cannot be null or empty!");
            }
            Album = album;

            if (string.IsNullOrEmpty(artist))
            {
                throw new ArgumentException("Error: The artist name cannot be null or empty!");
            }
            Artist = artist;
        }
    }
}
