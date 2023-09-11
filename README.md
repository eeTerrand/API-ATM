# API ATM
Esta es un proyecto de API para simular las principales funciones de un ATM en base a los requerimientos estipulados.

Para el mismo, se usó .Net 6.0, aplicando también auto-mapper y Entity framework.

Se desarrolló con la metodología code first.

A continuación se adjunta el diagrama de entidad-relación de las tablas planteadas.

![image (102)](https://github.com/eeTerrand/ATM-Interface/assets/124373372/eee74e27-b6f4-4e06-9115-9a5957518581)

Se utilizó el Repository Pattern, aplicando diferentes repositorios para delimitar las diferentes actividades y tratar de tener el menor acoplamiento posible.

Además de los métodos solicitados y se agregó un método de AddUserCard y UnlockUserCard, para poder agregar y desbloquear usuarios que hayan bloqueado su acceso.

Se agrega el archivo de script .SQL, que crea una base de datos llamada "ATMApi", un usuario "useratmapi1" y su correspondiente contraseña, el appsetings ya se encuentra configurado para funcionar con esos parametros.

El archivo .sln se encuentra dentro de la carpeta ATMApi.

![image](https://github.com/eeTerrand/API-ATM/assets/124373372/ef59f27e-bdeb-4ce4-b579-a8e6b9e00b56)

En cuanto a los endpoints, separamos en 2 controllers, uno que modifica el objeto "UserCard", donde podemos ver:

UnlockUser/{cardNumber}, donde se desbloquean los usuarios según el número de tarjeta del usuario.

CreateUser, donde se recibe un dto con las propiedades para crear un nuevo usuario.

login/{cardNumber}, donde se recibe el número de tarjeta ingresado por el usuario como un string, con el formato "1111111111111111", asumiendo que el mismo llega formateado.

login-pin/{pinNumber}/{cardId}, donde se envia el pin ingresado por el usuario y se recibe el cardId, que se envió en el endpoint anterior.

Por otro lado, tenemos los endpoints de UserOperation
![image](https://github.com/eeTerrand/API-ATM/assets/124373372/d430f8c3-59d7-4676-8ccf-02c6c6a06445)

En el mismo, existen 2:

useroperations/AddBalance, recibiendo un dto con el userCardId, donde se devuelven los datos de la cuenta de usuario y se realiza un registro con la operación.

useroperations/WithdrawFunds, recibiendo un dto con el userCardId y los fondos a retirar, registrando el retiro de fondos y devolviendo el resultado de la operación.
