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
        private static string dbPath = Path.Combine(FileSystem.AppDataDirectory, "projectdb.sqlite3");

        private static async Task Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(dbPath);
            await conn.CreateTableAsync<Project>();
            await conn.CreateTableAsync<Character>();
            await conn!.CreateTableAsync<Settings>();
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
        // Method to get settings for a specific project
        public static async Task<Settings> GetSettingsByProjectIdAsync(int projectId)
        {
            try
            {
                await Init();
                var settings = await conn!.Table<Settings>().Where(s => s.ProjectID == projectId).FirstOrDefaultAsync();
                return settings ?? new Settings(); // Return empty settings if none found
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving settings: {ex.Message}");
                return new Settings(); // Return default settings in case of error
            }
        }

        // Method to add or update settings
        // This method assumes there should only be one settings record per project,
        // so it either updates the existing settings or creates a new one if it doesn't exist.
        public static async Task<int> SaveSettingsAsync(Settings settings)
        {
            try
            {
                await Init();
                var existingSettings = await conn!.Table<Settings>().Where(s => s.ProjectID == settings.ProjectID).FirstOrDefaultAsync();
                if (existingSettings == null)
                {
                    return await conn.InsertAsync(settings);
                }
                else
                {
                    settings.SettingsID = existingSettings.SettingsID; // Ensure the ID matches for the update
                    return await conn.UpdateAsync(settings);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving settings: {ex.Message}");
                return 0; // Indicate failure
            }
        }

        // Method to delete settings for a specific project
        public static async Task<int> DeleteSettingsByProjectIdAsync(int projectId)
        {
            try
            {
                await Init();
                var settings = await conn!.Table<Settings>().Where(s => s.ProjectID == projectId).FirstOrDefaultAsync();
                if (settings != null)
                {
                    return await conn.DeleteAsync(settings);
                }
                return 0; // Indicate "nothing to delete"
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting settings: {ex.Message}");
                return 0; // Indicate failure
            }
        }

    }
}
