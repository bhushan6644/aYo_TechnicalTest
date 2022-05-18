using aYo_TechnicalTest.Entites;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace aYo_TechnicalTest.Infrastructure
{
    public class ConversionContext : DbContext
    {
        public ConversionContext(DbContextOptions<ConversionContext> options ) : base(options)
        {
           
        }
        [NotMapped]
        public virtual DbSet<ConversionDetailDto> ConversionDetail { get; set; }
    }
}
