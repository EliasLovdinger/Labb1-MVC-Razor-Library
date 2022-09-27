namespace Labb1_MVC_Razor.Models
{
    public interface IRentBookRepository
    {
        IEnumerable<RentBook> GetAllRentBooks();
        RentBook RentABook(RentBook rentBook);
        RentBook ReturnABook(int rentBookId);
    }
}
