# API ATM
Esta es un proyecto de API para simular las principales funciones de un ATM en base a los requerimientos estipulados.

Para el mismo, se usó .Net 6.0, aplicando también auto-mapper y Entity framework.

Se desarrolló con la metodología code first.

A continuación se adjunta el diagrama de entidad-relación de las tablas planteadas.

![imagen diagrama entidad-relacion](https://github.com/eeTerrand/API-ATM/blob/main/imagen%20diagrama%20entidad-relacion.png)

Se utilizó el Repository Pattern, aplicando diferentes repositorios para delimitar las diferentes actividades y tratar de tener el menor acoplamiento posible.

Además de los métodos solicitados y se agregó un método de AddUserCard y UnlockUserCard, para poder agregar y desbloquear usuarios que hayan bloqueado su acceso.

Se agrega el archivo de script .SQL, que crea una base de datos llamada "ATMApi", un usuario "useratmapi1" y su correspondiente contraseña, el appsetings ya se encuentra configurado para funcionar con esos parametros.

El archivo .sln se encuentra dentro de la carpeta ATMApi.

![Imagen endpoints 1](https://github.com/eeTerrand/API-ATM/blob/main/Imagen%20endpoints%201.png)

En cuanto a los endpoints, separamos en 2 controllers, uno que modifica el objeto "UserCard", donde podemos ver:

UnlockUser/{cardNumber}, donde se desbloquean los usuarios según el número de tarjeta del usuario.

CreateUser, donde se recibe un dto con las propiedades para crear un nuevo usuario.

login/{cardNumber}, donde se recibe el número de tarjeta ingresado por el usuario como un string, con el formato "1111111111111111", asumiendo que el mismo llega formateado.

login-pin/{pinNumber}/{cardId}, donde se envia el pin ingresado por el usuario y se recibe el cardId, que se envió en el endpoint anterior.

Por otro lado, tenemos los endpoints de UserOperation

![Imagen endpoints 2](https://github.com/eeTerrand/API-ATM/blob/main/Imagen%20endpoints%202.png)

En el mismo, existen 2:

useroperations/AddBalance, recibiendo un dto con el userCardId, donde se devuelven los datos de la cuenta de usuario y se realiza un registro con la operación.

useroperations/WithdrawFunds, recibiendo un dto con el userCardId y los fondos a retirar, registrando el retiro de fondos y devolviendo el resultado de la operación.
