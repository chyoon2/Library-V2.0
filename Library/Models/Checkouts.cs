namespace Library.Models
{
  public class Checkouts
  {
    public int CheckoutsId { get; set; }
    public int PatronId { get; set; }
    public int CopyId { get; set; }
    public Patron Patron { get; set; }
    public Copy Copy { get; set; }
  }
}