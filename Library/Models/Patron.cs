using System.Collections.Generic;

namespace Library.Models
{
    public class Patron
    {
        public Patron()
        {
            this.Copies = new HashSet<Checkouts>();
        }
        
        public int PatronId { get; set; }
        public string PatronName { get; set; }
        public virtual LibrarianUser User { get; set; } 
        
        public virtual ICollection<Checkouts> Copies { get; set; }
    }
}