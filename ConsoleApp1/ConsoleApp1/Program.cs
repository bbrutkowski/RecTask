using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // załóżmy że tutaj jest edpoint kontrolera Api
            // metoda przedstawiona w zadaniu mogłaby wyglądać tak:

            [HttpPost("delete/{id}")]
            public async Task<IActionResult> Delete(uint id)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user == null) return NotFound();

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"User with id {id} has been deleted.");
                return Ok();
            }

            // wprowadzone zmiany:
            // 1. metoda asynchroniczna 
            // 2. sprawdzenie czy użytkownik został znaleziony - jeśli nie to zostanie zwrócony odpowiedni rezultat
            // 3. zmiana na _logger zamias Debug co jest lepszym rozwiązaniem np pod względem kodu produkcyjnego
        }
    }
}
