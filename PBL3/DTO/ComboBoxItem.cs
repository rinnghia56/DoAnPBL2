using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DTO
{
    public class ComboBoxItem
    {
        public string valueMember { get; set; }
        public string displayMeber { get; set; }

        public ComboBoxItem()
        {

        }
        public ComboBoxItem(string value, string name)
        {
            this.valueMember = value;
            this.displayMeber = name;
        }
        public override string ToString()
        {
            return displayMeber;
        }
    }
}
