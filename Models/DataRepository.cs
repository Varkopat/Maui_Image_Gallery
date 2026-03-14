using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;

namespace MauiProject.Models
{
    internal class DataRepository
    {
        /// <summary>
        /// Copy file from app package to app data directory
        /// </summary>
        /// <param name="filename"></param>
        internal static async Task CopyFileToAppDataDirectory(string filename)
        {
            // Open the source file
            using Stream inputStream = await FileSystem.Current.OpenAppPackageFileAsync(filename);

            // Create an output filename
            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, filename);

            // Copy the file to the AppDataDirectory
            using FileStream outputStream = File.Create(targetFile);
            await inputStream.CopyToAsync(outputStream);
        }
        /// <summary>
        /// Save ImageView collection to json file
        /// </summary>
        /// <param name="image"></param>
        internal static async Task SaveImageAsync(ImageView image)
        {
            try
            {
                var loadJson = await LoadLocalAsset();
                var images = JsonSerializer.Deserialize<ObservableCollection<ImageView>>(loadJson);
                images.Add(image);
                var saveJson = JsonSerializer.Serialize(images);

                var filePath = Path.Combine(FileSystem.AppDataDirectory, "imageSources.json");
                await File.WriteAllTextAsync(filePath, saveJson);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error saving image: {ex.Message}");
            }
        }
        internal static async Task DeleteImageAsync(ImageView image)
        {
            try
            {
                var loadJson = await LoadLocalAsset();
                var images = JsonSerializer.Deserialize<ObservableCollection<ImageView>>(loadJson) ?? new ObservableCollection<ImageView>();
                images.Remove(image);
                var saveJson = JsonSerializer.Serialize(images);
                var filePath = Path.Combine(FileSystem.AppDataDirectory, "imageSources.json");
                await File.WriteAllTextAsync(filePath, saveJson);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting image: {ex.Message}");
            }
        }
        /// <summary>
        /// Get ImageView collection from json file
        /// </summary>
        internal static async Task<ObservableCollection<ImageView>> GetImagesAsync()
        {
            var data = await LoadLocalAsset();
            var imageCollection = JsonSerializer.Deserialize<ObservableCollection<ImageView>>(data);
            return imageCollection;
        }
        /// <summary>
        /// Load json data from imageSources.json located in AppDataDirectory
        /// </summary>
        private static async Task<string> LoadLocalAsset()
        {
            try
            {
                string mainDir = FileSystem.Current.AppDataDirectory;
                string filePath = Path.Combine(mainDir, "imageSources.json");
                if (File.Exists(filePath))
                {
                    using var reader = new StreamReader(filePath);
                    return await reader.ReadToEndAsync();
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }
        /// <summary>
        /// Check if imageSources.json exists in AppDataDirectory, if not copy from app package
        /// </summary>
        internal static async void CheckAppData()
        {
            var result = await LoadLocalAsset();
            if (result == string.Empty)
            {
                DataRepository.CopyFileToAppDataDirectory("imageSources.json");
                return;
            }
            return;
        }
        /// <summary>
        /// Reset imageSources.json in AppDataDirectory to default imageSources.json state in app package
        /// </summary>
        internal static async void ResetAppData()
        {
            var result = await LoadLocalAsset();
            if (result != string.Empty)
            {
                DataRepository.CopyFileToAppDataDirectory("imageSources.json");
                return;
            }
            return;
        }
        /// <summary>
        /// Loads json data from imageSources.json located in the app package
        /// </summary>
        internal static async Task<string> LoadMauiAsset()
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("imageSources.json");
                using var reader = new StreamReader(stream);

                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }
    }
}
