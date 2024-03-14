using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configur;

public class BookConfigure:IEntityTypeConfiguration<BookDto>
{
    public void Configure(EntityTypeBuilder<BookDto> builder)
    {
    }
}