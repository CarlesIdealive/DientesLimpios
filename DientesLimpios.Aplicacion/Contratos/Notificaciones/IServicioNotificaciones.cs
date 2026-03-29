namespace DientesLimpios.Aplicacion.Contratos.Notificaciones;

public interface IServicioNotificaciones
{

    Task EnviarConfirmacionCita(ConfirmacionCitaDTO confirmacionCita);
    Task EnviarRecordatorioCita(RecordatorioCitaDTO recordatorioCita);


}
