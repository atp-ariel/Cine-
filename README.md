# Cine+

Proyecto final de Ingeniería de Software, [la orientación](https://evea.uh.cu/mod/resource/view.php?id=11766) del proyecto se encuentra en el EVEA.

## Acerca del desarrollo y control de versiones

Se tienen dos ramas principales:

* **stable:** rama donde está el software o una parte del mismo en un estado estable y funcional.
* **dev:** rama de desarrollo, acá es donde se desarrolla el código, para añadir nuevas funcionalidades añadir ramas a dev, y luego se hacen las mezclas necesarias.

### Clonar el repositorio

Abra una terminal y escriba:

```
git clone https://github.com/ArielTriana/Cine-.git
```
## Acerca de la documentación

Toda la documentación se va a desarrollar en Latex.

No se incluyen en el repositorio los `.pdf` de la documentación ni la orden del proyecto para contribuir al ahorro de MB. Solamente se incluye la plantilla

Para generar los `.pdf`, se debe ejecutar el script `build.sh` incluido en `/doc/Informe`. . Ejemplo:

El informe final se desarrolló utilizando el Latex Template **Book**, los capítulos están en la carpeta `/doc/Informe/chapters/` en un `.tex` aparte.

## Acerca de la pasarela

La pasarela de pagos hasta el momento es una api que tiene un solo Controlador, se debe acceder a través de `api/transfer_money/{number of origin card}/{pin}/{number of final card}/{amount}`.

Esto devuelve un `json` con los siguientes campos:

* `status`: estado de la transferencia. `101`, y `102`.
* `resultMessage`: Mensaje resultante de la transferencia.

La pasarela está implementada como un Bernoulli con parámetro $p = 0.9$.


# Desarrolladores

* Carlos Toledo Silva ([@cts-crypto](https://github.com/cts-crypto))
* Aylín Álvarez Santos ([@chains99](https://github.com/chains99))
* Ariel Alfonso Triana Pérez ([@ArielTriana](https://github.com/ArielTriana))
* Rocio Ortiz Gancedo ([@rocioog00](https://github.com/rocioog00))

# Orden del proyecto

Se quiere desarrollar un sistema software que controle la venta de entradas de un cine denominado Cine+. Paralelamente a la venta de entradas en taquilla, el sistema debe dar soporte a la venta de entradas por internet, debiendo estar ambos coordinados. Los requisitos finales del sistema relacionados con la venta de entradas son los siguientes:

* Cualquier usuario puede comprar entradas a través de la página web. Para ello, en primer lugar, busca y selecciona la película deseada. El sistema muestra los horarios y salas disponibles, entre los que el usuario escoge el más adecuado. El sistema pregunta el número de entradas que se desean y asigna unas butacas automáticamente, pero da opción a que el usuario las modifique a su gusto. Una vez escogidas las butacas definitivas, se reservan de manera provisional: si en 10 minutos no se ha realizado la compra, o el usuario pulsa cancelar compra, vuelven a estar disponibles.
* Para el cálculo del precio de la entrada, se deben tener en cuenta los diferentes descuentos que se ofrecen: día del espectador, descuentos a niños y jubilados, descuentos a alumnos de universidad (con presentación del carnet de la FEU).En la compra por web, el sistema da opción de indicar estas circunstancias, siendo necesario demostrarlas al entregar la entrada en el cine.
* Los usuarios que lo deseen pueden darse de alta como socios del club Cine +, facilitando sus datos personales, bien a través de la página web o bien rellenando un formulario que entregarán en las taquillas del cine. Cuando se da de alta un socio en el sistema, se le asigna un código, que debe indicar a partir de entonces siempre que realice sus compras para participar en el programa de puntos del club. Por cada entrada que un socio del club Cine + compra, se le suman 5 puntos. Los puntos se pueden canjear por entradas.
* Cuando un socio del club realiza una compra (tanto online como en taquilla), el sistema le da opción de pagar las entradas con sus puntos en lugar de con dinero. Una entrada cuesta 20 puntos (El precio de la entrada es configurable por defecto tiene un valor de 20 puntos). Sólo se le ofrecerá esta opción si el socio tiene puntos suficientes para pagar todas las entradas incluidas en dicha compra.
* La compra por web se realiza por medio de tarjeta de crédito, utilizándose una pasarela de pago seguro. En taquilla se admite sólo pago en efectivo.
* La aplicación web se deben de poder permitir imprimir un comprobante de venta de las entradas.
* Una compra realizada a través de la web puede ser anulada hasta 2 horas antes del comienzo de la sesión. Para ello, el usuario deberá introducir el identificador que se le facilita cuando realiza la compra y el número de tarjeta de crédito con la que se realizó la compra (o el código de socio en caso de haber sido canjeada por puntos). Si el usuario es socio del club Cine +, el sistema deberá actualizar los puntos de su cuenta.
* Los gerentes del cine son los encargados de actualizar el listado de películas y horarios disponibles, que se muestran tanto por la web como en las pantallas situadas en el vestíbulo del cine. Además, pueden consultar las estadísticas de venta de entradas por día, por mes, año, periodo de fechas, por película, actores, género, rating , cine cubano frente a cine extranjero, etc.
* Se tiene que mostrar una vista con las sugerencias de 10 películas a ver. Esta lista debe ser actualizada periódicamente. Esta lista se conforma por diferentes criterios como puede ser: las más vistas, las más gustadas, intereses propagandísticos y económicos aleatorios. El gerente es el encargado de escoger cual criterio aplicar a la lista. Solo puede ser escogido un criterio

## Indicaciones

* Tiene que ser una aplicación web multiplaforma. Es obligatorio en empleo del Principio SOLID, DRY, KISS, YAGNI, una arquitectura que permita el desacoplamiento, extensibilidad, lo más refactorizada posible. Tiene que existir algún mecanismo que permita hacer unit testing mockeable. Tiene que existir algún mecanismo que permita generar la bd con la información mínima necesaria cuando se ejecute por primera vez la aplicación.
* Entregar un informe del equipo empleando la plantilla
* Entregar un informe individual donde se explique lo que cada hizo en cualquiera de las fases de desarrollo del software en qué trabajo ,además de lo que le tocó redactar en el informe del equipo