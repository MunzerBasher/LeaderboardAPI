using LeaderboardAPI.Date.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LeaderboardAPI.Repository.DbContextConfigrations
{
    public class RacerAccoladeConfig : IEntityTypeConfiguration<RacerAccolade>
    {
        public void Configure(EntityTypeBuilder<RacerAccolade> builder)
        {
            builder.HasOne(a => a.racer).WithMany(a => a.racerAccolade);
            builder.HasOne(a => a.accolade).WithMany(a => a.accoladeAccolade);
        }
    }

}