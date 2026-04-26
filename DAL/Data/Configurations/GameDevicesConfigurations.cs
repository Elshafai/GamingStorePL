using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Configurations
{
    public class GameDevicesConfigurations : IEntityTypeConfiguration<GameDevice>
    {
        public void Configure(EntityTypeBuilder<GameDevice> builder)
        {
            builder.HasKey(gd => new { gd.GameId, gd.DeviceId });
            
            builder.HasOne(gd => gd.Game)
                    .WithMany(g => g.GameDevices)
                    .HasForeignKey(gd => gd.GameId);
            
            builder.HasOne(gd => gd.Device)
                    .WithMany(d => d.GameDevices)
                    .HasForeignKey(gd => gd.DeviceId);
        }
    }
}
