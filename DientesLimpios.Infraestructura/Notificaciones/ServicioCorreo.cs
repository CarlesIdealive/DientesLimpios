using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace DientesLimpios.Infraestructura.Notificaciones;

public class ServicioCorreo : IServicioNotificaciones
{
    private readonly IConfiguration configuration;

    public ServicioCorreo(IConfiguration configuration)
    {
        this.configuration = configuration;
    }



    public async Task EnviarConfirmacionCita(ConfirmacionCitaDTO confirmacionCita)
    {
        var asunto = "Confirmacion de cita - Dientes Limpios";
        var cuerpo = $"Hola {confirmacionCita.Paciente},\n\n" +
                     $"Tu cita con el dentista {confirmacionCita.Dentista} en el consultorio {confirmacionCita.Consultorio} ha sido confirmada para el día {confirmacionCita.Fecha:dd/MM/yyyy} a las {confirmacionCita.Fecha:HH:mm}.\n\n" +
                     "¡Gracias por elegir Dientes Limpios!";

        await EnviarMensaje(confirmacionCita.Paciente_Email, asunto, cuerpo);
    }






    private async Task EnviarMensaje(string emailDestinatario, string asunto, string cuerpo)
    {
        var nuestroEmail = configuration.GetValue<string>("cONFIGURACIONES_EMAIL:EMAIL");
        var password = configuration.GetValue<string>("cONFIGURACIONES_EMAIL:PASSWORD");
        var host = configuration.GetValue<string>("cONFIGURACIONES_EMAIL:HOST");
        var puerto = configuration.GetValue<int>("cONFIGURACIONES_EMAIL:PUERTO");

        var smtpClient = new SmtpClient(host, puerto);
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new System.Net.NetworkCredential(nuestroEmail, password);

        var mensaje = new MailMessage(nuestroEmail!, emailDestinatario, asunto, cuerpo);
        await smtpClient.SendMailAsync(mensaje);
    }
    


}
