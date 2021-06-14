using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    class Item
    {
        public string Title { get; set; }
        public bool OnLoan { get; set; }
        public string Loanee { get; set; }
    }
}
