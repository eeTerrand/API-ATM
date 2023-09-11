# API ATM
Esta es un proyecto de API para simular las principales funciones de un ATM en base a los requerimientos estipulados.

Para el mismo, se usó .Net 6.0, aplicando también auto-mapper y Entity framework.

A continuación se adjunta el diagrama de entidad-relación de las tablas planteadas.

![image (102)](https://github.com/eeTerrand/ATM-Interface/assets/124373372/eee74e27-b6f4-4e06-9115-9a5957518581)

Se utilizó el Repository Pattern, aplicando diferentes repositorios para delimitar las diferentes actividades y tratar de tener el menor acoplamiento posible.

Además de los métodos solicitados y se agregó un método de AddUserCard y UnlockUserCard, para poder agregar y desbloquear usuarios que hayan bloqueado su acceso.
