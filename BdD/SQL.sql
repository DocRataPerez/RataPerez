--consultar la citas de un usuario
use rataperez
select u.nombre, u.cedula, c.fecha, c.hora, o.nombre, e.Especialidad
from usuario u
inner join cita c on u.idusuario = c.idusuario
inner join odontologo o on c.idodontologo = o.idodontologo
inner join Especialidad e on e.IdEspecialidad = o.IdEspecialidad
where u.cedula = 1003730130