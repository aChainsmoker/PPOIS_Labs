using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace Lab1
{
    public static class JsonStateManager
    {
        private static string GetFilePath(string fileName)
        {
            string directory = "SavedStates";
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            return Path.Combine(directory, fileName);
        }

        public static void SaveState<T>(T state, string fileName)
        {
            try
            {
                string filePath = GetFilePath(fileName);
                if(state is Wedding wedding)
                {
                    wedding.CurrentWeddingPhaseString = IOSystem.GetTheWeddingStateString(wedding.CurrentWeddingPhase);
                }
                string json = JsonSerializer.Serialize(state, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving state: {ex.Message}");
            }
        }

        public static T LoadState<T>(string fileName) where T: class
        {
            try
            {
                string filePath = GetFilePath(fileName);
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<T>(json);;
                }
                else
                {   
                    Console.WriteLine("No saved state found.\n");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading state: {ex.Message}");
                return null;
            }
        }

        public static void DeleteState(string fileName)
        {
            if(File.Exists(GetFilePath(fileName)))
                File.Delete(GetFilePath(fileName));
        }
    }
}
