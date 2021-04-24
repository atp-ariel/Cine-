---
title: Especificación de requerimientos utilizando Somm97
author: Equipo 1 Profesor Jose Luis Castañeda
geometry: "left=2cm, right=2cm, top=2cm, bottom=2cm"
---

**Proyecto:** Cine+

**Ejecutores:**

* Carlos Toledo Silva
* Aylín Álvarez Santos
* Rocío Ortiz Gancedo
* Ariel Alfonso Triana Pérez

# Introducción

## Propósito del documento

N/A

## Alcance del producto

N/A

## Definiciones y acrónimos

Todo documento técnico escrito, especialmente cuando esta destinado a ser leído por otros, requiere que se definan los conceptos de uso común en el mismo, así como las abreviaturas utilizadas 
(Es un error muy frecuente asumir que otros entienden lo que uno escribe con facilidad, por ejemplo: “... El sistema deberá confeccionar Ordenes de Trabajo...”, ¿qué es una Orden de Trabajo? o “... Los especialistas de la DICT se encargarán de ...”, ¿qué es la DICT?)

## Referencias

Si fue necesario para la confección de este documento la consulta de otros, tanto en papel como en formato electrónico disponibles en sitios accesibles, deben ofrecerse las referencias para ayudar a sus lectores a tener una información similar a la que Ud. tenía para escribirlo

# Descripción General

## Perspectiva del producto

El producto que se debe desarrollar bajo el nombre Cine+, debe ser una aplicación web para gestionar la compra/venta de entradas del Cine+. 

Dada la actual situación epidemiológica provocada por el Covid-19, se deben evitar las aglomeraciones de personas; por tanto, es necesario vender las entradas de las sesiones del cine sin provocar largas colas en las taquillas del mismo. De ahí la necesidad de crear un sistema que permita el acceso del público a una "taquilla virtual" donde se venden dichos tickets. El sistema no es un sustituto de las taquillas física. En su lugar, se necesita un sistema centralizado de venta de tickets, ya sea desde la taquilla clásica o la taquilla virtual.

Además, el sistema debe servir como gestionador del club Cine+, aceptar nuevos miembros y permitir los beneficios del mismo. El sistema que se necesita debe ser un sustituto de la cartelera del cine.

El producto da respuesta a los problemas de aglomeraciones en las taquillas y en los alrededores del cine viendo la cartelera o comprando tickets, además de agilizar el proceso de compra/venta. Además el producto, agiliza el proceso "cuadrar las cajas" en la taquilla. Además de facilitar la gestión de la cartelera.

## Funciones del Producto

El producto "Cine+" debe tener las siguientes funcionalidades expresadas por el cliente:

* Permitir la venta de entradas en taquillas físicas, se desea que el taquillero pueda vender las entradas y seleccionar los asientos desde las computadoras de la taquilla.
* Inscribir nuevos miembros en el club Cine+.
* Imprimir los tickets para las sesiones en el Cine+.
* Permitir la venta de tickets por internet directamente al público.
* Mostrar la cartelera del cine.
* Cancelar las ventas de tickets.
* Permitir los pagos online de los tickets.
* Mostrar las películas sugeridas por el gerente.
* Facilitar las consultas de las estadísticas de venta, y otras.

## Características de los usuarios


Los usuarios que interactuarán de forma directa con el producto son:

* Los taquilleros
* Los gerentes
* El público



Como veremos más adelante, muchas decisiones posteriores dependen de las características de los usuarios futuros del producto, por lo que es muy importante caracterizar, cuantitativa y cualitativamente a los mismos, según:

* su grado de experiencia en la actividad que el producto asume
* su identificación con los ambientes y plataformas de hardware y software previstos

## Restricciones Generales

En muchas ocasiones, y este caso que nos ocupa es uno de ellos, los sistemas tienen restricciones “a priori”, derivadas, por ejemplo, de la necesidad de integrarse a entornos existentes (imagen de sitios Web ya utilizado, preferencias visuales, etc). 

En las entrevistas debemos identificar estas restricciones generales, básicamente serán reflejo de las preferencias de los entrevistados, por ejemplo
“preferiría que se viera como Yahoo España” o “me gustaría que tuviese un look como el de WebOO Live

## Dependencias y suposiciones

Si el producto a desarrollar deberá comunicarse con otro sistema ya existente o en desarrollo para obtener información, deberá investigarse la naturaleza y principales características del mismo, con el objetivo de adecuar las decisiones de diseño acorde a esta dependencia operacional

En este aspecto deberán detallarse, si es posible, características como:

* Plataforma de software (SO, lenguaje,etc)
* Tipo y Formato de los datos que maneja ese otro sistema

Además, frecuentemente se asumen ciertas restricciones iniciales, muchas veces no derivadas de ningún razonamiento lógico, simplemente como expresión de la voluntad y gustos del cliente

Por ejemplo:
“ La navegación no debe necesitar más de tres niveles de profundidad...”
“Los menús fijos deberían estar en el lateral derecho...”

# Requerimientos específicos

## Requerimientos funcionales

Enumerar brevemente las funciones que debe realizar el producto según los deseos expresados por el cliente

En este aspecto es difícil buscar uniformidad, porque cada sistema responde a un dominio de problema diferente con condiciones de entorno muy variables, se debe expresar la funcionalidad en términos simples, derivados de los DESEOS del cliente

Por ejemplo, ahondar un poco en la forma en que quisiera el cliente hacer sus preguntas:

*  Tipo Google (escribo una frase y ya)
* Asistente-Avanzadas (rellenando características que filtran los resultados)
* Consultas tipo “Preguntas frecuentes” parametrizadas, es decir, crear como un repositorio de plantillas de las preguntas mas comunes que haría el cliente

Una funcionalidad que dificilmente se les ocurra, pero que se puede tratar de inducir, sería la espacial o territorial. Por ejemplo decirle al entrevistado:

“Si dispone de un mapa de La Habana donde se muestra la ubicación de la UH y sus dependencias, ¿Qué consultas se le ocurre que podría hacer para su trabajo?

## Requerimientos no funcionales

Generalmente se consideran aquí elementos restrictivos generados por el cliente, no directamente relacionados con la funcionalidad del producto
 
A continuación enumeramos una serie de preguntas, cuyas respuestas, si son relevantes, podrían constituir ejemplos de este tipo de requerimientos
(Atención: estas no constituyen las únicas posibles y los entrevistados podrán o no responder dependiendo se su especialidad, experiencia e intereses) 

¿Cuáles son los requerimientos de seguridad?
Por ejemplo: 
*	¿El acceso será controlado con nombres de usuario y contraseñas?
 
*	¿Se incluirá un módulo para las tareas administrativas, reservado a administradores? (permisos selectivos según cargo, etc)
 
*	Considera necesario en algún caso el uso de comunicaciones seguras? (por ejemplo SSL)

¿Cuáles son los requerimientos de almacenamiento, importación y exportación de datos? 
Por ejemplo, 
*	“El sistema debería almacenar todos los datos en una base de datos PostGres, donde puedan ser accesado por otros programas, porque nos interesa que sea software libre”
*	O… “se debererá utilizar SQLServer, porque es el que mejor conocemos y para el que tengo gente preparada para el mantenimiento”
*	Etc…

¿Cuáles son los requerimientos de usabilidad? 
La interfaz del usuario deberá ser tan familiar como sea posible a los usuarios, lo cual dependerá de la experiencia de los mismos en el uso de otras aplicaciones web y/o de escritorio del mismo tipo. 

Caso de tener experiencia previa, el entrevistado podrá dar algunas ideas de como preferiría la interacción, por ejemplo, preferencia por el teclado o por el mouse o por una pantalla táctil, etc

¿Qué tipo de documentación y/o ayuda es necesaria, de acuerdo a la experiencia de los posibles usuarios?

Por ejemplo, el cliente puede decir:
*	“Prefiero tener una buena ayuda en línea, consultable desde el propio sistema”
y/o
*	“Prefiero un buen manual impreso, para leerlo off-line”

¿Cuáles son los requerimientos de mantenimiento y evolución? 
La capacidad de mantenimiento es nuestra habilidad para realizar cambios al producto en el tiempo. 

De acuerdo a la opinión del cliente
*	¿Algunas de las características del sistema, como sus fuentes de datos o su funcionalidad podría variar en el futuro cercano?
*	¿de alguna manera es posible anticipar estos posibles cambios en las mismas para prepararnos desde ahora?
 

¿Cuáles son los requerimientos de actualización? 
Muy relacionado con el anterior está la posibilidad de mantener actualizado el producto es la capacidad para completar y entregar funcionando nuevas versiones del producto cuando sea necesario. 
Este aspecto afecta tanto al software, como a los datos, por ejemplo, si una corrección provoca que el formato de los datos cambie (algún campo se adiciona o se divide, etc), la actualización incluirá el proceso de transformación de los viejos datos al nuevo formato..

¿Cuáles son los requerimientos de soporte técnico? 
Debemos analizar nuestra habilidad de proveer soporte técnico eficiente y a bajo costo. En muchas ocasiones los sistemas fracasan, porque el cliente no puede mantenerlo funcionando sin la actuación directa de los desarrolladores, pero esto no es siempre posible!

Consultar al entrevistado sobre experiencias anteriores de este tipo


## Requerimientos de Entorno

¿Cuáles son los requerimientos de hardware del sistema? 
Básicamente, NO se trata de decir que hardware CREEMOS que debe tener el sistema para su correcto funcionamiento, sino que hardware TIENE disponible para la operación del mismo el cliente y así condicionar otras decisiones de diseño a estas restricciones, aunque no esta negada la posibilidad de proponer cambios y mejoras en la plataforma actual, bien fundamentadas

¿Cuáles son los requerimientos de software del sistema? 
Por ejemplo, proponer, de acuerdo con el cliente y sus condiciones de entorno
*	 Sistema Operativo
*	 Marco de trabajo (por ejemplo .NET o J2EE)
*	 Lenguaje de programación

(las respuestas dependerán de la experticidad del cliente y podrían estar condicionadas por la experticidad del personal del cliente para asumir en el futuro la actualización y mantenimiento del sistema)
 
En este caso es MUY IMPORTANTE tener en cuenta las posibilidades reales de explotación del producto por parte del cliente y sus preferencias

 Por ejemplo, no podemos proponer simplemente un software basado en servicios Web programados en ASP.NET si el cliente no cuenta con servidores Windows y experiencia en la administración de este tipo de servidores, a no ser que se incluya una propuesta preliminar de solución a esta limitación 
“... servicio Web basado en ASP.NET soportado sobre el framework de .NET desarrollado por el proyecto Mono y publicado a través de un Web Server Apache con su plugin para ASP.NET)

# Anexos

*	 Nombre y cargo u ocupación de las personas entrevistadas
*	 Cantidad de tiempo dedicado al o a los encuentros sostenidos por el equipo para producir las especificaciones (sin “globos”, que lo solicito con fines estadísticos, no evaluativos!)
*	 Posibles formatos ejemplo de documentos, interfaces y otros similares, que facilite el cliente para ayudar a comprender sus ideas y necesidades (muchas veces un vicedecano o jefe de dpto tiene unos modelos fijos que debe llenar y entregar sistemáticamente)

Estas entrevistas se deberán efectuar en lo que queda de esta semana y la siguiente y deben enviarnos un documento a mas tardar el lunes 17 con las respuestas recibidas y sus propuestas, opiniones o comentarios sobre la calidad del proceso, interés demostrado por el entrevistado y cualquier otro elemento que se les ocurra importante









