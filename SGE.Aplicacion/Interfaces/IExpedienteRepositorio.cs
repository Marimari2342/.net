﻿namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    Expediente ObtenerPorId(int id);
    void Agregar(Expediente expediente);
    void Eliminar(int id);
    void Modificar(Expediente expediente);
    List <Expediente> ObtenerTodos();
    int ObtenerSiguienteId();
    //Cambio automatico del estado de un expediente.
}
