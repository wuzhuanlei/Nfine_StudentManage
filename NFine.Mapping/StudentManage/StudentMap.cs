using NFine.Domain.Entity.StudentManage;
using System.Data.Entity.ModelConfiguration;

namespace NFine.Mapping.StudentManage
{
    public class StudentMap : EntityTypeConfiguration<StudentEntity>
    {
        public StudentMap()
        {
            this.ToTable("Student");
            this.HasKey(t => t.StudentId);
        }
    }
}
