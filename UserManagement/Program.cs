using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using SQLite.CodeFirst;
using BL;
using DAL;
using Model;
using Utilities;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace InternshipApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        [STAThread]
        static void Main()
        {
            log.Info("Application Started");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                log.Info("Setting Up Database");

                using (DataContext context = new DataContext())
                {
                    string path = context.Database.Connection.DataSource;
                    log.Info("SQLite DB path: " + path);

                    // force database initialization
                    log.Info("Initializing database");
                    context.Database.Initialize(force: false);

                    if (!context.Database.Exists())
                    {
                        log.Info("Database does not exist, creating database");
                        context.Database.Create();
                        log.Info("Database created successfully");
                    }
                    else
                    {
                        log.Info("Database already exists");
                    }

                    log.Info("Checking for default user");
                    // ensure default admin account is created
                    var adminUser = context.Users.FirstOrDefault(u => u.UserName == "admin");
                    if (adminUser == null)
                    {
                        log.Info("No Admin Account Found, Creating Admin Account");
                        var newUser = new User
                        {
                            UserName = "admin",
                            Password = PasswordHelper.HashPassword("password"),
                            Role = "Admin",
                        };
                        context.Users.Add(newUser);
                        context.SaveChanges();
                        log.Info("Admin account created");
                    }
                }

                DataContext serviceContext = new DataContext();
                UnitOfWork unitOfWork = new UnitOfWork(serviceContext);
                UserService userService = new UserService(unitOfWork);

                loginForm login = new loginForm(userService);
                login.StartPosition = FormStartPosition.CenterScreen;
                log.Info("Launching Form");
                Application.Run(login);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Startup error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Fatal("Unhandled exception during startup.", ex);
            }
        }
    }
}