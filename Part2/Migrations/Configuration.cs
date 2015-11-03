namespace Part2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Part2.Models.dbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Part2.Models.dbContext context)
        {
            context.TUser.AddOrUpdate(a => a.Id,
                new Models.UserModel { Id = 1, UserName = "det", Password = "det" });
            context.TFrame.AddOrUpdate(a => a.Id,
                new Models.FrameModel { Id = 1, FrameName = "MainFrame", FrameDescription = "ֳכאגםûי פנויל" }
                );
            context.SaveChanges();

            foreach (var item in context.TFrame.Where(a => a.Id == 1))
            {
                foreach (var item2 in context.TUser.Where(a => a.Id == 1))
                {
                    var t = new Guid("85222392-2D0C-4851-94AC-078A7D5DE9A0");
                    for (int i = 0; i <= 5; i++)
                    {
                        var columnName = "Column" + i.ToString();
                        if (!context.TColumn.Any(
                            a => a.UserId.Id == item2.Id &&
                            a.FrameId.Id == item.Id &&
                            a.ComponentGuid == t &&
                            a.ColumnName == columnName))
                        {
                            context.TColumn.Add(new Models.ColumnModel
                            {
                                ColumnName = columnName,
                                ColumnWidth = 10,
                                ComponentGuid = t,
                                DisplayName = columnName,
                                FrameId = item,
                                IsVisible = false,
                                Position = 0,
                                UserId = item2
                            });
                        }
                    }
                }
            }
            context.SaveChanges();
        }
    }
}
