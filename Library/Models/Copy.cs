using System.Collections.Generic;
using System;

namespace Library.Models
{
    public class Copy
    {
        public Copy()
        {
            this.Patrons = new HashSet<Checkouts>();
        }

        public virtual Book Book { get; set; } 
        public int? BookId {get; set;}
        public int CopyId { get; set; }
        public Boolean? IsCheckedOut {get; set;} = false;
        public DateTime? DueDate {get; set;} = null;

        
        public virtual ICollection<Checkouts> Patrons { get; set; }
    }
}

// copies
// id | copyname     | available | Due?
// 1 Robinson Crusoe | true      | 1/2/2021
// 2 Robinson Crusoe | false     | null
// 3 Robinson Crusoe | true      | null
// 4 JavaScript LearnIt
// 5 Salt Fat Acid Heat
// 6 Salt Fat Acid Heat
// 7
// 8