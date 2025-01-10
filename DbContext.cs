using EmotionCareServer.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Psychologist> Psychologists { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Indication> Indications { get; set; }
    public DbSet<ConsultationSummary> ConsultationSummaries { get; set; }
    public DbSet<DiaryPage> DiaryPages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Psychologist>()
            .ToTable("Psychologists", "public");

        modelBuilder.Entity<Patient>()
            .HasOne<Psychologist>()
            .WithMany()
            .HasForeignKey(p => p.PsychologistId);
        // Definindo a relação entre Notification e User (ou Patient)
        modelBuilder.Entity<Notification>()
            .HasOne<Patient>()  // Ou Patient, dependendo de qual for o tipo de usuário
            .WithMany()  // Isso assume que um usuário pode ter várias notificações
            .HasForeignKey(n => n.UserId);

        // Definindo a relação entre Notification e Psychologist
        modelBuilder.Entity<Notification>()
            .HasOne<Psychologist>()
            .WithMany()  // Isso assume que um psicólogo pode ter várias notificações
            .HasForeignKey(n => n.PsychologistId);
        // Relacionamento entre Indication e Patient (Paciente pode ser nulo)
        modelBuilder.Entity<Indication>()
            .HasOne(i => i.Patient)
            .WithMany()
            .HasForeignKey(i => i.PatientId)
            .OnDelete(DeleteBehavior.SetNull);  // Quando o paciente for excluído, a relação será mantida, mas o campo PatientId ficará null.

        // Relacionamento entre Indication e Psychologist
        modelBuilder.Entity<Indication>()
            .HasOne(i => i.Psychologist)
            .WithMany()
            .HasForeignKey(i => i.PsychologistId);

        // Relacionamento entre ConsultationSummary e Patient
        modelBuilder.Entity<ConsultationSummary>()
            .HasOne(cs => cs.Patient)
            .WithMany()
            .HasForeignKey(cs => cs.PatientId)
            .OnDelete(DeleteBehavior.Cascade);  // Caso o paciente seja deletado, as consultas também serão

        // Relacionamento entre ConsultationSummary e Psychologist
        modelBuilder.Entity<ConsultationSummary>()
            .HasOne(cs => cs.Psychologist)
            .WithMany()
            .HasForeignKey(cs => cs.PsychologistId)
            .OnDelete(DeleteBehavior.Cascade);  // Caso o psicólogo seja deletado, as consultas também serão

        modelBuilder.Entity<DiaryPage>()
            .HasOne(dp => dp.Psychologist)
            .WithMany()
            .HasForeignKey(dp => dp.PsychologistId);

        modelBuilder.Entity<Psychologist>().HasData(
           new Psychologist
           {
               Id = 1,
               OrganizationListId = 0,
               Name = "Dr. John Doe",
               Password = "password123",
               Qualifications = "Ph.D. in Psychology",
               WhatsApp = "+123456789",
               ScheduleId = 1,
               Email = "johndoe@example.com",
               ProfilePicture = "johndoe.jpg",
               SessionDurationMinutes = 60
           },
           new Psychologist
           {
               Id = 2,
               OrganizationListId = 0,
               Name = "Dr. Jane Smith",
               Password="password123",
               Qualifications = "M.Sc. in Clinical Psychology",
               WhatsApp = "+987654321",
               ScheduleId = 2,
               Email = "janesmith@example.com",
               ProfilePicture = "janesmith.jpg",
               SessionDurationMinutes = 45,
           }
        );

        modelBuilder.Entity<Patient>()
          .HasData(
              new Patient
              {
                  Id = 1,
                  Name = "João",
                  Password = "12345678",
                  Email = "joao@example.com",
                  Age = 30,
                  ProfilePicture = "alice.jpg",
                  PsychologistId = 1,
                  OrganizationListId = 1
              },
              new Patient
              {
                  Id = 2,
                  Name = "Bob Brown",
                  Password = "67890",
                  Email = "bobbrown@example.com",
                  Age = 25,
                  ProfilePicture = "bob.jpg",
                  PsychologistId = 2,
                  OrganizationListId = 1
              }
          );
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("public");
    }
}
