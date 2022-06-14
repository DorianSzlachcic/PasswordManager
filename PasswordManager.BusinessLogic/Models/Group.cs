using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.Models
{
    public class Group
    {
        public int? Id { get; set; }
        public Color ColorHex;
        public string Name;

        public Group(string name, Color colorHex, int? id = null)
        {
            this.ColorHex = colorHex;
            this.Name = name;
            this.Id = id;
        }
    }
}
