namespace XsdToCsharp
{
    /// <summary>
    /// Application settings
    /// </summary>
    internal class AppSettings
    {
        const string FileName = "AppSettings.json";

        /* construction */
        /// <summary>
        /// Constructor
        /// </summary>
        public AppSettings() 
        {
            Load();
        }
        /// <summary>
        /// Loads this instance from a json file
        /// </summary>        
        public void Load()
        {
            if (File.Exists(FileName))
            {
                Json.LoadFromFile(this, FileName);
            }
        }
        /// <summary>
        /// Saves this instance to a json file
        /// </summary>
        public void Save() 
        { 
            Json.SaveToFile(this, FileName);
        }  

        /* properties */
        /// <summary>
        /// The full path to the last used project
        /// </summary>
        public string LastProjectPath { get; set; }
    }
}
