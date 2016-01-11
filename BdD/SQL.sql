--consultar la citas de un usuario
select u.idusuario, u.nombre, u.cedula, c.fecha, c.hora, o.nombre
from usuario u
inner join cita c on u.idusuario = c.idusuario
inner join odontologo o on c.idodontologo = o.idodontologo
where u.cedula = 123456