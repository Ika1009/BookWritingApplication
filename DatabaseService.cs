using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookWritingApplication.Models;
using Microsoft.Maui.Storage;

namespace BookWritingApplication
{
    public static class DatabaseService
    {
        private static SQLiteAsyncConnection? conn;
        private static readonly string dbPath = Path.Combine(FileSystem.AppDataDirectory, "projectdb.sqlite3");

        private static async Task Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(dbPath);
            await conn.CreateTableAsync<Project>();
            await conn.CreateTableAsync<Character>();
        }

        public static async Task<List<Project>> GetAllProjectsAsync()
        {
            try
            {
                await Init();
                return await conn!.Table<Project>().ToListAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error retrieving projects: {ex.Message}");
                return new List<Project>();
            }
        }

        public static async Task<int> AddProjectAsync(Project project)
        {
            try
            {
                await Init();
                return await conn!.InsertAsync(project);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error adding project: {ex.Message}");
                return 0; // Indicate failure
            }
        }

        public static async Task<int> UpdateProjectAsync(Project project)
        {
            try
            {
                await Init();
                return await conn!.UpdateAsync(project);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error updating project: {ex.Message}");
                return 0; // Indicate failure
            }
        }

        public static async Task<int> DeleteProjectAsync(Project project)
        {
            try
            {
                await Init();
                return await conn!.DeleteAsync(project);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error deleting project: {ex.Message}");
                return 0; // Indicate failure
            }
        }
        public static async Task<List<Character>> GetAllCharactersAsync()
        {
            try
            {
                await Init();
                return await conn!.Table<Character>().ToListAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error retrieving characters: {ex.Message}");
                return new List<Character>();
            }
        }

        public static async Task<int> AddCharacterAsync(Character character)
        {
            try
            {
                await Init();
                return await conn!.InsertAsync(character);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error adding character: {ex.Message}");
                return 0; // Indicate failure
            }
        }

        public static async Task<int> UpdateCharacterAsync(Character character)
        {
            try
            {
                await Init();
                return await conn!.UpdateAsync(character);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error updating character: {ex.Message}");
                return 0; // Indicate failure
            }
        }

        public static async Task<int> DeleteCharacterAsync(Character character)
        {
            try
            {
                await Init();
                return await conn!.DeleteAsync(character);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error deleting character: {ex.Message}");
                return 0; // Indicate failure
            }
        }
    }
}
