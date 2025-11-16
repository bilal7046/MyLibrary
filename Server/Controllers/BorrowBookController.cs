using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Entities;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowBookController : ControllerBase
    {
        private readonly MyLibraryContext _context;
        public BorrowBookController(MyLibraryContext context)
        {
            _context = context;
        }

        [HttpPost("Borrow")]
        public async Task<BorrowRecord?> BorrowBookAsync(string memberId, Guid bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null || book.AvailableCopies <= 0)
            {
                return null; // Book not available
            }

            var borrowRecord = new BorrowRecord
            {
                BookId = bookId,
                MemberId = memberId,
                BorrowDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(14) // 2 weeks loan period
            };

            book.AvailableCopies--;
            _context.BorrowRecord.Add(borrowRecord);
            await _context.SaveChangesAsync();
            return borrowRecord;
        }
        [HttpPut("return")]
        public async Task<bool> ReturnBookAsync(Guid borrowId)
        {
            var borrowRecord = await _context.BorrowRecord.Include(b => b.Book).FirstOrDefaultAsync(z => z.Id == borrowId);
            if (borrowRecord == null || borrowRecord.ReturnDate != null)
            {
                return false;
            }

            borrowRecord.ReturnDate = DateTime.UtcNow;
            borrowRecord.Book.AvailableCopies++;

            await _context.SaveChangesAsync();
            return true;
        }
        [HttpGet("records")]
        public async Task<List<BorrowRecord>> GetBorrowRecordsAsync()
        {
            return await _context.BorrowRecord
                .Include(b => b.Book)
                .ToListAsync();

        }
    }
}
