using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiProject.Models
{
    internal class ImageView
    {
        public string Title { get; set; }
        public string Path { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ImageView other)
            {
                return Title == other.Title && Path == other.Path;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Path);
        }
    }

}
