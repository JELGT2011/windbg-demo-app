using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace WinDbgDemo.Models
{
    public class DemoViewModel
    {
        private readonly User _username = new User();

        // In a real app this and whatever other data might come from a database
        public string Time { get { return DateTime.Now.ToString(CultureInfo.InvariantCulture); } }

        // Complicated calculations performed in the view model
        public string TheSameTimeYesterday { get { return DateTime.Now.AddDays(-1).ToString(CultureInfo.InvariantCulture); } }

        // Underlying data model properties, exposed as strings
        public string Username { get { return _username.Username; } set { _username.Username = value; } }

        public IList<FavouriteColorViewModel> ListDataViewModels
        {
            get { return _username.FavouriteColours.Select(c => new FavouriteColorViewModel { ModelColor = c }).ToList(); }
            set { _username.FavouriteColours = value.Select(m => m.ModelColor); }
        }

        // BEST PRACTICE: Hide the database schema and have every property here return a string.
        //                eg. The "Age" column in your user table may be stored as int, but exposed in the ViewModel as string.

        //                You want to aim to have:
        //                 1. Maximum control over the output in the view
        //                 2. Ability to refactor the database without touching the view, because:

        //                     - Razor is dynamic so you don't have the compiler to help
        //                     - Cognitive load: you only want to have to think about either the model or view at any one time.
    }

    /// <summary>
    /// Wrap up a user's favourite colour
    /// </summary>
    public class FavouriteColorViewModel
    {
        public Color ModelColor
        {
            get { return System.Drawing.Color.FromName(Color); }
            set { Color = value.Name; }
        }
        public string Color { get; set; }
    }
}