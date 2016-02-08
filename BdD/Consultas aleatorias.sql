select * from Horario h
inner join Odontologo o on o.IdOdontologo = h.IdOdontologo
inner join Especialidad e on o.IdEspecialidad = e.IdEspecialidad

exec InsertarCita 19,1030,'2/22/2016','12:00:00'