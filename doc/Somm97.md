---
title: Especificación de requerimientos utilizando Somm97
author: Equipo 1 Profesor Jose Luis Castañeda
geometry: "left=2cm, right=2cm, top=2cm, bottom=2cm"
---

**Proyecto:** Cine+

**Ejecutores:**

* Carlos Toledo Silva C-311 (Líder)
* Aylín Álvarez Santos C-311
* Rocío Ortiz Gancedo C-311
* Ariel Alfonso Triana Pérez C-311

# Introducción


## Alcance del producto

N/A

## Descripción General

### Perspectiva del producto

El producto busca controlar la venta de entradas de un cine denominado Cine+. Para esto el producto debe dar soporte tanto a la venta de entradas por taquillas como a la venta de entradas por internet, garantizandoce la coordinación de las mismas.

### Funciones del Producto

El producto es una aplicación web multiplataforma que permite la compra de entradas a través de su página web por parte de los clientes y calcula el costo de la entradas atendiendo a diferentes parámetros. Además da soporte a la inscripción de usuarios como socios del club de Cine+, así como los beneficios de los que estos pueden disfrutar. También el producto permite la anulación de las compras de entradas por parte de los usuarios y hace las actualizaciones pertinentes dada la anulación. El producto permite además que los gerentes del cine puedan actualizar el listado de películas y horarios disponibles y que estos sean mostrados en la web. Además estos pueden consultar las estadísticas de venta de entradas por diferentes parámetros. También se posibilita la visualización en una página web de las 10 películas sugeridas por uno de los gerentes del cine.

### Características de los usuarios

Con el producto interactuarán dos tipos de usuarios: clientes y gerentes. Los gerentes dominan toda la información relacionada con la puesta en escena de las peliculas: horarios, precios, péliculas que se mostrarán, sugerencias, etc. Ambos usuarios están identificados tanto con dispositivos móviles y tabletas como con computadoras.

Los gerenetes tienen el conocimiento necesario para operar este tipo de aplicación web. Los clientes conforman un grupo muy heterogéneo, algunos no tienen conocimiento con productos similares, ahí la necesidad de que la interfaz con la que interactúan sea cómoda.

### Restricciones Generales

El cliente solicita que el sistema en cuestión sea una aplicación web, con las funcionalidades anteriormente mencionadas. Además informa que ya reservaron el hosting y dominio (www.cine+.com) de la página y la base de datos. El hosting tiene 4000 MB de almacenamiento.

El cliente pide que las páginas carguen en el tiempo recomendado por los expertos en posicionamiento SEO, para el posicionamiento en buscadores como Google o Bing. Además que el sitio tenga un flujo de navegación sencillo, y que la navegación no sobrepase el tercer nivel.


## Resumen del resto del documento

# Requerimientos específicos

## Requerimientos funcionales

El sitio web debe permitir que cualquier usuario pueda comprar entradas. Para ello debe buscar la pelicula deseada y mostrar los horarios y salas en que estará en pantalla dicha pelicula. Luego de que el usuario escoja la sala y el horario de su preferencia, el sistema le pregunta al usuario el número de entradas y asigna unas butacas autómaticamente, pero da opción a que el usuario las modifique a su gusto, las cuales pasarán a estar reservadas de forma provisional. Si pasado algún un tiempo (por defecto 10 min) el usuario no ha efectuado la compra o este la cancela las butacas vuelven a estar disponibles.

Para el cálculo del precio de la entrada, se deben tener en cuenta los diferentes descuentos que se ofrecen.

Los usuarios que los deseen puden darse de alta como socios del club Cine+, cumpliendo con las pasos pertinentes. A cada socio, cada vez que compre una entrada, se le sumarán 5 puntos, los cuales podrá cambiar en el futuro por entradas. Para hacer esto el socio deberá contar con la suficiente cantidad de puntos para poder pagar todas las entradas de su compra. El precio de la entrada es de 20 puntos por defecto, aunque este se podrá configurar.

La compra por web se realiza por medio de tarjeta de crédito, utilizándose una pasarela de pago seguro. En taquilla se admite sólo pago en efectivo. Además se debe poder imprimir un comprobante de venta de las entradas.

Una compra realizada a través de la web puede ser anulada hasta 2 horas antes del comienzo  de la sesión, restableciéndole al cliente el costo de la compra y dejando sus butacas disponibles. Si el pago fue hecho por un socio utilizando sus puntos, estos serán devueltos a su cuenta.

Los gerentes podrán actualizar el listado de películas y los horarios, los cuales serán mostrados en el sittio. Además estos podrán consultar estadísticas sobre las ventas de entradas.

Se exige mostrar una vista de 10 películas sugeridas para ver, la cual será actualizada periódicamente. Estará lista seguirá un criterio escogido por alguno de los gerentes.

## Requerimientos no funcionales

Dado que esta es una aplicación web para la venta de entradas para un cine, se le debe dar bastante información sobre el tema a la aplicación para que un navegador pueda encontrala más rápidamente.

Los datos referentes a las películas (salas, horarios, etc) serán guardados en una base de datos SQLite. En esta se guardará además la información referente a los socios y a los gerentes del cine.

El acceso de los gerentes y los socios de Cine+ al sistema es a través del nombre de usuario y contraseña. Para el acceso al perfil de usuario es necesario comunicaciones seguras, así como para navegar en la administración para el caso de los gerantes. Las mismas también son necesarias para la realización de los pagos mediante la pasarela. Por lo anterior es necesario contratar un certificado SSL para el sitio. En caso de que se acceda a través de HTTP será imposible ingresar  el nombre y la contraseña, así como recuperar contraseñas.

La interfaz del usuario deberá ser tan familiar como sea posible a los usuarios, lo cual dependerá de la experiencia de los mismos en el uso de otras aplicaciones web. Se solicita además una documentación online para que los clientes y para los gerentes, donde además la dedicada a los clientes contará con información refernte sobre como convertirse en un socio de Cine+ y los beneficios que trae serlo.

## Requerimientos de Entorno

Aunque los gerentes del cine pueden poseer una variada gama de dispositivos móviles se conece que la administración de Cine+ les proverá de recursos necesarios para la realización de sus funciones. Dicho esto se tiene la seguridad de que cada gerente tiene asignado uno de estos dos dispositivos para el acceso:

1.	Laptop ASUS con procesador Intel Core i7 de 4ta generación con navegador Mozilla Firefox 86.0

2.	Laptop HP con procesador Intel Core i5 de 8va generación con navegador Google Chrome 88.0.4324.104

Además en caso de que el gerente no posea un dispositivo móvil de al menos gama media con el que pueda realizar sus funciones, la administración le proverá de un Samsung Galaxy A10 con conexión a Internet y navegadores como Google Chrome 89.0.4389.72 y Safari 14.0.2. 

Los clientes como se conoce son una masa de usuarios heterogéna, como también lo es la masa de dispositivos que ellos tienen disponibles: laptops, móviles, tabletas todos con distintos tipos de sistemas operativos (Windows, Linux, iOS y Android en distintas versiones. Además, en este grupo de usuarios existen distintos tipos de navegadores como Mozilla Firefox, Google Chrome, Opera, Microsoft Edge, Brave, en distintas versiones de los mismos.

En cuanto al hosting, el cliente tiene disponible uno con Windows Server, con 4000 MB de almacenamiento, 1000 MB de base de datos en SQLite, 1 cuenta de acceso para administración, 1000 conexiones concurrentes, 3 cuentas FTP, 1024 Kbps de velocidad de transferencia, soporte para Javascript, para ASP.NET. La aplicación web se desarrollará sobre .NET 5, y C#.

Para el servidor se tiene un Intel(R) Core(TM) i7-8250U CPU 2.60 GHz, 2.60 GHz, con 16GB RAM. El servidor con arquitectura física de 64 bit.
