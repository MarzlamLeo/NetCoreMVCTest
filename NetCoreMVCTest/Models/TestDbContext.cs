using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVCTest.Models
{
    public class TestDbContext: DbContext
    {
        //数据上下文 说明数据库  表  然后 迁移生成 数据库
        // 1.创建迁移文件  Add-Migration xxxx  名字
        // 2.实现迁移文件内容   Update-Database 
        public TestDbContext(DbContextOptions<TestDbContext> options)
           : base(options)
        {
        }
        public DbSet<DbUser> Users { get; set; }

        public DbSet<DbRole> Roles { get; set; }
    }
}
