using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineDoctorsAppointmentBooking.Startup))]
namespace OnlineDoctorsAppointmentBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
