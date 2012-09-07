using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WinDbgDemo.Models
{
    /// <summary>
    /// In a real app this might be
    ///  - in another assembly
    ///  - a POCO for a database table
    /// </summary>
    public class User
    {
        private static string _username;
        private static List<Color> _favouriteColours;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// A one-to-many relationship
        /// </summary>
        public IEnumerable<Color> FavouriteColours
        {
            get { return _favouriteColours ?? (_favouriteColours = new List<Color>()); }
            set { _favouriteColours = value.ToList(); }
        }
    }
}