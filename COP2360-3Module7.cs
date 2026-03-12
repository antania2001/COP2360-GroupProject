// Group Project - COP 2360-3 Module 7: Dictionary Group Project Assignment
// Theme: Our Group's Favorite Songs Playlist
// Description: This program allows users to manage a playlist of their favorite songs using a Dictionary data structure
// Created by: Laura Paredes, Antania Burgess, and Ainsley McDonald


using System;
using System.Collections.Generic;
using System.Linq;

class PlaylistDictionary
{
    static void Main(string[] args)
    {
     
        // Creating Dictionary
        // Value: List of Artist, Genre, Duration, Mood

        Dictionary<string, List<string>> playlist = new Dictionary<string, List<string>>();

        // Used to store the user's menu choice

        string choice = "";


        // Main loop: Keeps the menu running until user exits

        while (choice != "g")
        {
            // Display the menu
            Console.WriteLine("\n========== FAVORITE SONGS PLAYLIST ==========");
            Console.WriteLine("a. Populate the Playlist");
            Console.WriteLine("b. Display Playlist Contents");
            Console.WriteLine("c. Remove a Song");
            Console.WriteLine("d. Add a New Song and Details");
            Console.WriteLine("e. Add a Detail to an Existing Song");
            Console.WriteLine("f. Sort Songs Alphabetically");
            Console.WriteLine("g. Exit");
            Console.WriteLine("=============================================");
            Console.Write("Enter your choice: ");

            // Read user's input and convert to lowercase
            choice = Console.ReadLine().ToLower();

            // Handles the menu options (a through g)
            switch (choice)
            {
                // Populate the Dictionary
                case "a":
                    Console.WriteLine("\n--- Populating Playlist ---");

                    // Format: playlist["Song Title"] = new List<string> { "Artist", "Genre", "Duration", "Mood" };
                    // Laura's Top 5 Song Playlist
                    playlist["twilight zone"] = new List<string> { "Ariana Grande", "Pop", "3:18", "Break-up" };
                    playlist["Overboard (feat. Jessic Jarrell)"] = new List<string> { "Justin Bieber", "Pop/R&B", "3:42", "Romance" };
                    playlist["Inolvidable"] = new List<string> { "Reik", "Latin Pop", "3:36", "Nostalgia" };
                    playlist["If Today Was Your Last Day"] = new List<string> { "Nickelback", "Pop Rock", "4:09", "Motivational anthem" };
                    playlist["Gratitude"] = new List<string> { "Brandon Lake", "Contemporary Christian Music", "5:38", "Humility & Vulnerability"

                    //Antania's Top 5 Song Playlist
                    playlist["How You Like That"] = new List<string> { "Blackpink", "Kpop", "3:04", "Party Music" };
                    playlist["DDu-Du DDu-Du"] = new List<string> { "Blackpink", "Kpop", "3:36", "Strength and Attitude" };
                    playlist["Not Alike"] = new List<string> { "Eminem", "Rap", "4:49", "Diss Track" };
                    playlist["Lalisa"] = new List<string> { "Lisa", "Hip hop", "3:27", " Fierce and Energetic" };
                    playlist["Like Jennie"] = new List<string> { "Jennie", "Hip hop", "2:04", "Empowering & Haughty" };

                    Console.WriteLine("Playlist has been uploaded with your favorite songs!");
                    break;

                // Uses enumeration to loop through and display the contents of the playlist

                case "b":
                    Console.WriteLine("\n--- Playlist Contents ---");

                    // Check if the playlist has any songs first
                    if (playlist.Count == 0)
                    {
                        Console.WriteLine("The playlist is empty. Please populate it first (option a).");
                        break;
                    }

                    // This loops through every song and its details
                    foreach (KeyValuePair<string, List<string>> song in playlist)
                    {
                        // Print the song title
                        Console.WriteLine($"\nSong: {song.Key}");

                        // Print each detail in the values list
                        Console.WriteLine($"  Details: {string.Join(", ", song.Value)}");
                    }
                    break;

                // Asks user which song to remove from dictionary
                case "c":
                    Console.WriteLine("\n--- Remove a Song ---");

                    // Asks user which song they want to remove
                    Console.Write("Enter the song title to remove: ");
                    string songToRemove = Console.ReadLine();

                    // Check if the song exists before trying to remove it
                    if (playlist.ContainsKey(songToRemove))
                    {
                        playlist.Remove(songToRemove);
                        Console.WriteLine($"'{songToRemove}' has been removed from the playlist.");
                    }
                    else
                    {
                        Console.WriteLine($"'{songToRemove}' was not found in the playlist.");
                    }
                    break;

                // Asks user for a new song title and its details
                case "d":
                    Console.WriteLine("\n--- Add a New Song ---");

                    // Asks user for the new song title
                    Console.Write("Enter the new song title: ");
                    string newSongTitle = Console.ReadLine();

                    // Check if the song already exists
                    if (playlist.ContainsKey(newSongTitle))
                    {
                        Console.WriteLine($"'{newSongTitle}' already exists. Use option (e) to add details to it.");
                        break;
                    }

                    // Asking user for the song details
                    // (We can customize here our prompts)
                    Console.Write("Enter the artist name: ");
                    string newArtist = Console.ReadLine();

                    Console.Write("Enter the genre: ");
                    string newGenre = Console.ReadLine();

                    Console.Write("Enter the duration (e.g. 3:45): ");
                    string newDuration = Console.ReadLine();

                    Console.Write("Enter the mood/vibe: ");
                    string newMood = Console.ReadLine();

                    // Add the new song and its details to the dictionary
                    playlist[newSongTitle] = new List<string> { newArtist, newGenre, newDuration, newMood };
                    Console.WriteLine($"'{newSongTitle}' has been added to the playlist!");
                    break;

                // Adding a new detail to an already existing song
                case "e":
                    Console.WriteLine("\n--- Add a Detail to an Existing Song ---");

                    // Asks user which song to update
                    Console.Write("Enter the song title to update: ");
                    string existingSong = Console.ReadLine();

                    // Check if the song exists in the dictionary
                    if (playlist.ContainsKey(existingSong))
                    {
                        // Asks user for the new detail to update
                        Console.Write("Enter the new detail to add (e.g. Award, Tag, Note): ");
                        string newDetail = Console.ReadLine();

                        // Adding the new detail to the existing list of values
                        playlist[existingSong].Add(newDetail);
                        Console.WriteLine($"Detail added to '{existingSong}' successfully!");
                    }
                    else
                    {
                        Console.WriteLine($"'{existingSong}' was not found in the playlist.");
                    }
                    break;

                // Retrieves and displays the song titles in alphabetical order

                case "f":
                    Console.WriteLine("\n--- Playlist Sorted Alphabetically ---");

                    // Check if the playlist has any songs
                    if (playlist.Count == 0)
                    {
                        Console.WriteLine("The playlist is empty. Please populate it first (option a).");
                        break;
                    }

                    // Gather all song titles, sort them, then display
                    List<string> sortedSongs = playlist.Keys.ToList();
                    sortedSongs.Sort();

                    // Display the sorted song titles with their details
                    foreach (string song in sortedSongs)
                    {
                        Console.WriteLine($"\nSong: {song}");
                        Console.WriteLine($"  Details: {string.Join(", ", playlist[song])}");
                    }
                    break;

                // Exiting the program
                
                case "g":
                    Console.WriteLine("\nThanks for using the Playlist Manager. Goodbye!");
                    break;

                // Handles any wrong input from user

                default:
                    Console.WriteLine("Invalid choice. Please enter a letter from a to g.");
                    break;
            }
        }
    }

}



