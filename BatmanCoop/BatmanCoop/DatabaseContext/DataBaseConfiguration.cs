using BatmanCoopShared.Model.LendModel;
using BatmanCoopShared.Model.ManpowerModel;
using BatmanCoopShared.Model.MasterDataModel;
using Microsoft.EntityFrameworkCore;

namespace BatmanCoop.DatabaseContext
{
    public class DataBaseConfiguration : DbContext
    {
        public DataBaseConfiguration(DbContextOptions<DataBaseConfiguration> options) : base(options)
        {

        }

        //Master Data
        public DbSet<CivilStatus> CivilStatusTable { get; set; }

        //Manpower
        public DbSet<MemberM> MemberTable { get; set; }
        public DbSet<MemberAttachM> MemAttachTable { get; set; }

        //Lend Main
        public DbSet<BuyerModel> BuyerTable { get; set; }

    }
}
