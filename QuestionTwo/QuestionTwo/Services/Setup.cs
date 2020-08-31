using QuestionTwo.Properties;
using System;

namespace QuestionTwo.Services
{
    public static class Setup
    {

        public static string GetSettings()
        {
            return string.Concat("Col:",Settings.Default.Columns.ToString(), " Row:", Settings.Default.Rows.ToString()," Gen:", Settings.Default.Generation.ToString());
        }

        public static bool SaveSettings(int rows, int columns, int Generation)
        {
            bool Result = false;
            try
            {
                Settings.Default.Columns = columns;
                Settings.Default.Rows = rows;
                Settings.Default.Generation = Generation;
                Settings.Default.Save();
                Result = true;
            }
            catch (Exception)
            {
                Result = false;
            }
            return Result;
        }
    }
}
