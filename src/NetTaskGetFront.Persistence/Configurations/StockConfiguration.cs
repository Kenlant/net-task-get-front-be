using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetTaskGetFront.Domain.Entities;

namespace NetTaskGetFront.Persistence.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.Property(x => x.Ticker)
                .IsRequired();
            builder.Property(x => x.Timeperiod)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
